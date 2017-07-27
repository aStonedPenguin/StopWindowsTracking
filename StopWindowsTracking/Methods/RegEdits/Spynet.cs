using Microsoft.Win32;
using StopWindowsTracking.Base;

namespace StopWindowsTracking.Methods.RegEdits
{
    public class Spynet : IRegEdit
    {
        public string GetName()
            => "Spynet";

        public string GetInfo()
            => "Disables Windows Defender automatic samples";

        public RegEdit[] GetRegEdits()
            => new RegEdit[] {
                 new RegEdit {
                    Parent = Registry.LocalMachine,
                    SubKey = @"SOFTWARE\Policies\Microsoft\Windows Defender\Spynet",
                    Name = "SpyNetReporting ",
                    Value = 0,
                    CreateKey = true
                }
            };
    }
}