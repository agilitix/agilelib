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

        public static bool HasSessionInTime(this SessionSettings sessionSettings)
        {
            DateTime now = DateTime.UtcNow;
            IEnumerable<Dictionary> settings = sessionSettings.GetSessions()
                                                              .Select(sessionSettings.Get);
            return settings.Select(setting => new SessionSchedule(setting))
                           .Any(sch => sch.IsSessionTime(now));
        }
    }
}
