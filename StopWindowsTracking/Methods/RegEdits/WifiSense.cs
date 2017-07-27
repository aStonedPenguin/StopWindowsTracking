using Microsoft.Win32;
using StopWindowsTracking.Base;

namespace StopWindowsTracking.Methods.RegEdits
{
    public class WifiSense : IRegEdit
    {
        public string GetName()
            => "WifiSense";

        public string GetInfo()
            => "Disables WifiSense";

        public RegEdit[] GetRegEdits()
            => new RegEdit[] {
                 new RegEdit {
                    Parent = Registry.ClassesRoot,
                    SubKey = @"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config",
                    Name = "AutoConnectAllowedOEM",
                    Value = 0,
                    CreateKey = true
                }
            };
    }
}