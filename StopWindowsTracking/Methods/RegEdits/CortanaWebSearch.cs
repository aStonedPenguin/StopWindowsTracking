using Microsoft.Win32;
using StopWindowsTracking.Base;

namespace StopWindowsTracking.Methods.RegEdits
{
    public class CortanaWebSearch : IRegEdit
    {
        public string GetName()
            => "Cortana Web Search";

        public string GetInfo()
            => "Disable Cortana Web Search";

        public RegEdit[] GetRegEdits()
            => new RegEdit[] {
                new RegEdit {
                    Parent = Registry.LocalMachine,
                    SubKey = @"SOFTWARE\Policies\Microsoft\Windows\Windows Search",
                    Name = "ConnectedSearchUseWeb",
                    Value = 0,
                    CreateKey = true
                }
            };
    }
}
