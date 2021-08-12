using System.Collections.Generic;

namespace Entidades
{
    public static class PelotaExtension
    {
        public static List<PelotaBuena> BuscarBuenas(this List<Pelota> pelotas)
        {
            List<PelotaBuena> buenas = new List<PelotaBuena>();
            foreach (Pelota item in Juego.Pelotas)
            {
                if (item is PelotaBuena)
                    buenas.Add((PelotaBuena)item);
            }
            return buenas;
        }
    }
}
