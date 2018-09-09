using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using AxCommandLine;
using AxCommandLine.Interfaces;
using AxConfiguration;
using AxConfiguration.Interfaces;
using log4net;

namespace AxHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;

            Process p = GetParent(Process.GetCurrentProcess());
            Console.WriteLine(p.ProcessName);

            bool b = IsRunningAsAService;

            // This is a sandbox sample.
        }

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        public static bool IsRunningAsAService
        {
            get
            {
                try
                {
                    Process parent = GetParent(Process.GetCurrentProcess());
                    return parent?.ProcessName == "services";
                }
                catch (InvalidOperationException ex)
                {
                    // Nothing.
                }
                return false;
            }
        }

        private static Process GetParent(Process child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(nameof(child));
            }

            try
            {
                IntPtr toolHelp32Snapshot = Kernel32.CreateToolhelp32Snapshot(Kernel32.TH32CS_SNAPPROCESS, 0U);
                if (toolHelp32Snapshot == IntPtr.Zero)
                {
                    return null;
                }

                Kernel32.PROCESSENTRY32 processEntry = new Kernel32.PROCESSENTRY32()
                                               {
                                                   dwSize = (uint) Marshal.SizeOf(typeof(Kernel32.PROCESSENTRY32))
                                               };
                if (!Kernel32.Process32First(toolHelp32Snapshot, ref processEntry))
                {
                    return null;
                }

                int processId = 0;

                do
                {
                    if (child.Id == processEntry.th32ProcessID)
                    {
                        processId = (int) processEntry.th32ParentProcessID;
                    }
                }
                while (processId == 0 && Kernel32.Process32Next(toolHelp32Snapshot, ref processEntry));

                if (processId > 0)
                {
                    return Process.GetProcessById(processId);
                }
            }
            catch (Exception ex)
            {
                // log error somewhere.
            }

            return null;
        }
    }

    internal static class Kernel32
    {
        public static uint TH32CS_SNAPPROCESS = 2;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

        [DllImport("kernel32.dll")]
        public static extern bool Process32First(IntPtr hSnapshot, ref Kernel32.PROCESSENTRY32 lppe);

        [DllImport("kernel32.dll")]
        public static extern bool Process32Next(IntPtr hSnapshot, ref Kernel32.PROCESSENTRY32 lppe);

        public struct PROCESSENTRY32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }
    }
}
