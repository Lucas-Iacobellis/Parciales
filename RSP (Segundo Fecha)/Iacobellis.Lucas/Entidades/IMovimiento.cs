using System.Collections.Generic;

namespace Entidades
{
    public interface IMovimiento
    {
        void Mover();
        void Verificar();
        void HayChoque(List<Pelota> p);
    }
}