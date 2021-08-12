namespace Entidades.Interfaces
{
    public interface ILog
    {
        bool Info(string jugador, int puntos);
        bool GetInfo(out string datos);
    }
}
