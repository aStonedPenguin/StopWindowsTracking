using System;
using System.IO;
using StopWindowsTracking.Base;
using System.Security.AccessControl;
using System.ServiceProcess;

namespace StopWindowsTracking.Methods.Custom
{
    public class DiagTrack : ICustom
    {
        public string GetName()
            => "Tracking logs";

        public string GetInfo()
            => "Clears DiagTrack Log";

        private string FileDir = $@"{Environment.ExpandEnvironmentVariables("%systemdrive%")}\ProgramData\Microsoft\Diagnosis\ETLLogs\AutoLogger\";
        private string FilePath = $"AutoLogger-Diagtrack-Listener.etl";

        public bool CanRun()
            => true;

        public void Run()
        {
            try
            {
                ServiceController service = new ServiceController("DiagTrack");
                service.Stop();

                if (!Directory.Exists(FileDir))
                    Directory.CreateDirectory(FileDir);

                string path = FileDir + FilePath;
                if (!File.Exists(path))
                    File.Create(path);

                File.WriteAllText(path, "dont track me thx m$");

                FileInfo fi = new FileInfo(path);

                FileSecurity fs = fi.GetAccessControl();

                fs.SetAccessRuleProtection(true, false);

                AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));

                foreach (FileSystemAccessRule rule in rules)
                    fs.RemoveAccessRule(rule);

                fs.AddAccessRule(new FileSystemAccessRule("Authenticated Users", FileSystemRights.Read, AccessControlType.Deny));

                File.SetAccessControl(path, fs);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(IOException))
                    Console.WriteLine("DiagTrack already locked");

                if (e.GetType() == typeof(InvalidOperationException))
                    Console.WriteLine("No DiagTrack service??");


            }
        }
    }
}