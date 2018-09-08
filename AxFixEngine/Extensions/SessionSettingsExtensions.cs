using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxExtensions;
using QuickFix;

namespace AxFixEngine.Extensions
{
    public static class SessionSettingsExtensions
    {
        public static string Dump(this SessionSettings sessionSettings)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<Dictionary> settings = sessionSettings.GetSessions().Select(sessionSettings.Get);
            foreach (Dictionary dictionary in settings)
            {
                dictionary.AsEnumerable()
                          .Select(x => x.ToString())
                          .ForEach(x => sb.Append(x));
                sb.AppendLine();
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static IEnumerable<SessionID> SessionsInTime(this SessionSettings sessionSettings)
        {
            DateTime utc = DateTime.UtcNow;
            IEnumerable<SessionID> sessionsInTime = sessionSettings.GetSessions()
                                                                   .Select(x => new {session = x, schedule = new SessionSchedule(sessionSettings.Get(x))})
                                                                   .Where(x => x.schedule.IsSessionTime(utc))
                                                                   .Select(x => x.session);
            return sessionsInTime;
        }
    }
}
