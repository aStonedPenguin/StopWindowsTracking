using System.Diagnostics;
using System.Collections.Generic;

namespace StopWindowsTracking.Base
{
    public class WSBloatware
    {
        public static List<WSBloatware> All = new List<WSBloatware>
        {
            new WSBloatware { Name = "Skype", ID = "skype" },
            new WSBloatware { Name = "OneNote", ID = "onenote" },
            new WSBloatware { Name = "3D Builder", ID = "3dbuilder" },
            new WSBloatware { Name = "Alarms && Clocks", ID = "windowsalarms" },
            new WSBloatware { Name = "Calendar and Mail", ID = "windowscommunicationsapps" },
            new WSBloatware { Name = "Camera", ID = "windowscamera" },
            new WSBloatware { Name = "Drawboard PDF", ID = "drawboardpdf" },
            new WSBloatware { Name = "Feedback Hub", ID = "windowsfeedbackhub" },
            new WSBloatware { Name = "Food && Drink", ID = "bingfoodanddrink" },
            new WSBloatware { Name = "Get Office App", ID = "officehub" },
            new WSBloatware { Name = "Get Skype App", ID = "skypeapp" },
            new WSBloatware { Name = "Get Started App", ID = "getstarted" },
            new WSBloatware { Name = "Groove Music", ID = "zunemusic" },
            new WSBloatware { Name = "Health && Fitness", ID = "binghealthandfitness" },
            new WSBloatware { Name = "Maps", ID = "windowsmaps" },
            new WSBloatware { Name = "Messaging", ID = "messaging" },
            new WSBloatware { Name = "Money", ID = "bingfinance" },
            new WSBloatware { Name = "Movies && TV", ID = "zunevideo" },
            new WSBloatware { Name = "News", ID = "bingnews" },
            new WSBloatware { Name = "People", ID = "people" },
            new WSBloatware { Name = "Phone Companion", ID = "windowsphone" },
            new WSBloatware { Name = "Photos", ID = "photos" },
            new WSBloatware { Name = "Reader", ID = "reader" },
            new WSBloatware { Name = "Reading List", ID = "windowsreadinglist" },
            new WSBloatware { Name = "Solitaire Collection", ID = "solitairecollection" },
            new WSBloatware { Name = "Sports", ID = "bingsports" },
            new WSBloatware { Name = "Sticky Notes", ID = "microsoftstickynotes" },
            new WSBloatware { Name = "Sway App", ID = "sway" },
            new WSBloatware { Name = "Travel", ID = "bingtravel" },
            new WSBloatware { Name = "Voice Recorder", ID = "soundrecorder" },
            new WSBloatware { Name = "Weather", ID = "bingweather" },
            new WSBloatware { Name = "Xbox", ID = "xboxapp" },
            new WSBloatware { Name = "Xbox Game Speech", ID = "XboxSpeechToTextOverlay" },
            new WSBloatware { Name = "Paint 3D", ID = "MSPaint" },
            new WSBloatware { Name = "Calculator", ID = "windowscalculator" },
            new WSBloatware { Name = "3D Preview", ID = "Microsoft3DViewer" },
            new WSBloatware { Name = "Paid Wi-Fi & Cellular", ID = "OneConnect" },
        };

        public string Name;
        public string ID;

        public bool IsInstalled()
        {
            // TODO: Find out how to do this
            return true;
        }

        public void Uninstall()
        {
            using (Process proc = new Process())
            {
                proc.StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c powershell \"Get-AppxPackage *{ID}* |Remove-AppxPackage\"",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,

                };
                proc.Start();
                proc.WaitForExit();
            }
        }
    }
}
