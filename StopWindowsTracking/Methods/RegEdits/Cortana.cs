using Microsoft.Win32;
using StopWindowsTracking.Base;

namespace StopWindowsTracking.Methods.RegEdits
{
    public class Cortana : IRegEdit
    {
        public string GetName()
            => "Cortana";

        public string GetInfo()
            => "Disable Cortana";

        public RegEdit[] GetRegEdits()
            => new RegEdit[] {
                new RegEdit {
                    Parent = Registry.LocalMachine,
                    SubKey = @"SOFTWARE\Policies\Microsoft\Windows\Windows Search",
                    Name = "AllowCortana",
                    Value = 0,
                    CreateKey = true
                }
            };
    }
}
