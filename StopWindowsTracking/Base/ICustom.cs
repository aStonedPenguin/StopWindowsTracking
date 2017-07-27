namespace StopWindowsTracking.Base
{
    public interface ICustom
    {
        string GetName();
        string GetInfo();
        bool CanRun();
        void Run();
    }
}
