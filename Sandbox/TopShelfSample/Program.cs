using System;
using Topshelf;

namespace TopShelfSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            TopshelfExitCode rc = HostFactory.Run(x =>
                                                  {
                                                      x.UseLog4Net("log4net.config");

                                                      x.Service<Service>(sc =>
                                                                         {
                                                                             sc.ConstructUsing(name => new Service());
                                                                             sc.WhenStarted(s => s.Start());
                                                                             sc.WhenStopped(s => s.Stop());
                                                                             sc.WhenPaused(s => s.Pause());
                                                                             sc.WhenContinued(s => s.Continue());
                                                                             sc.WhenShutdown(s => s.Shutdown());
                                                                         });

                                                      x.RunAsLocalSystem();
                                                      x.StartManually();
                                                      x.DependsOnEventLog();

                                                      x.EnableServiceRecovery(r =>
                                                                              {
                                                                                  r.RestartService(0); // restart the service after 0 minutes
                                                                                  r.RestartService(0);
                                                                                  r.RestartService(0);

                                                                                  r.SetResetPeriod(1); // set the reset interval to one day
                                                                              });

                                                      x.SetDescription("TopshelfSample to show some features");
                                                      x.SetDisplayName("TopshelfSample");
                                                      x.SetServiceName("TopshelfSample");
                                                  });

            int exitCode = (int) Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
