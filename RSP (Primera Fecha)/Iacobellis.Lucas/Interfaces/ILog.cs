namespace Interfaces
{
    public interface ILog
    {
        bool Info(string info);
        bool GetInfo(out string datos);
    }
}