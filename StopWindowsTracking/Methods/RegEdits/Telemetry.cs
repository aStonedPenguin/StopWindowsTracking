using Microsoft.Win32;
using StopWindowsTracking.Base;

namespace StopWindowsTracking.Methods.RegEdits
{
    class Telemetry : IRegEdit
    {
        public string GetName()
            => "Telemetry";

        public string GetInfo()
            => "Disables telemetry/associated services";

        public RegEdit[] GetRegEdits()
            => new RegEdit[] {
                new RegEdit {
                    Parent = Registry.LocalMachine,
                    SubKey = @"SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                    Name = "AllowTelemetry",
                    Value = 0,
                    CreateKey = true
                },
                new RegEdit {
                    Parent = Registry.LocalMachine,
                    SubKey = @"SYSTEM\CurrentControlSet\Services",
                    Name = "DiagTrack",
                    Value = 4
                },
                new RegEdit {
                    Parent = Registry.LocalMachine,
                    SubKey = @"SYSTEM\CurrentControlSet\Services",
                    Name = "dmwappushservice",
                    Value = 4
                },
            };
    }
}
