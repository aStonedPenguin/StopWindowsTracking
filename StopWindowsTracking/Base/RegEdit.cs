using Microsoft.Win32;

namespace StopWindowsTracking.Base
{
    public class RegEdit
    {
        public RegistryKey Parent;
        public string SubKey;
        public string Name;
        public object Value;
        public bool CreateKey = false;
        public RegistryValueKind Kind = RegistryValueKind.DWord;

        private RegistryKey Key {
            get
            {
                return Parent.OpenSubKey(SubKey, true);
            }
        }

        public bool CanRun()
            => CreateKey || (Parent.OpenSubKey(SubKey) != null &&  Key.GetValue(Name) != null);

        public void Run()
        {
            if (CreateKey)
            {
                if (Key == null)
                    Parent.CreateSubKey(SubKey, true);
                Key.CreateSubKey(Name, true);
            }

            Key.SetValue(Name, Value, Kind);
        }
    }
}
