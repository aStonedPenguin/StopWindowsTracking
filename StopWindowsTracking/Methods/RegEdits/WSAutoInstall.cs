using Microsoft.Win32;
using StopWindowsTracking.Base;

namespace StopWindowsTracking.Methods.RegEdits
{
    public class WSAutoInstall : IRegEdit
    {
        public string GetName()
            => "Block unwanted apps";

        public string GetInfo()
            => "Stops apps from being auto installed";

        public RegEdit[] GetRegEdits()
            => new RegEdit[] {
                new RegEdit {
                    Parent = Registry.LocalMachine,
                    SubKey = @"SOFTWARE\Policies\Microsoft\WindowsStore",
                    Name = "AutoDownload",
                    Value = 2,
                    CreateKey = true
                }
            };
    }
}
