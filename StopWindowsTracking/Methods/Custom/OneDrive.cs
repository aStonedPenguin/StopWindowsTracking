using System;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using StopWindowsTracking.Base;

namespace StopWindowsTracking.Methods.Custom
{
    public class OneDrive : ICustom
    {
        public string GetName()
            => "OneDrive";

        public string GetInfo()
            => "Uninstall/remove File Explorer icon";

        private string FilePath = $@"{Environment.ExpandEnvironmentVariables("%systemroot%")}\SysWOW64\OneDriveSetup.exe";

        private RegEdit[] RegEdits = new RegEdit[] {
            new RegEdit {
                Parent = Registry.ClassesRoot,
                SubKey = @"CLSID\{018D5C66-4533-4307-9B53-224DE2ED1FE6}",
                Name = "System.IsPinnedToNameSpaceTree",
                Value = 0
            },
            new RegEdit {
                Parent = Registry.LocalMachine,
                SubKey = @"SOFTWARE\Policies\Microsoft\Windows\OneDrive",
                Name = "DisableFileSyncNGSC",
                Value = 0
            }
        };

        public bool CanRun()
            => File.Exists(FilePath);

        public void Run()
        {
            foreach (var proc in Process.GetProcessesByName("OneDrive.exe"))
                proc.Kill();

            using (Process proc = new Process())
            {
                proc.StartInfo = new ProcessStartInfo
                {
                    FileName = FilePath,
                    Arguments = "/uninstall",
                    UseShellExecute = true

                };
                proc.Start();
                proc.WaitForExit();
            }

            foreach (RegEdit v in RegEdits)
                if (v.CanRun())
                    v.Run();
        }
    }
}