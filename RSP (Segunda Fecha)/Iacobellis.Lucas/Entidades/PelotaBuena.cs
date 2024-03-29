﻿using System;
using System.Collections.Generic;
using Entidades.Excepciones;
using Entidades.Interfaces;

namespace Entidades
{
    public class PelotaBuena : Pelota, IMovimiento
    {
        #region NO_TOCAR_NADA
        int velX = 1;
        int velY = 1;

        public PelotaBuena()
        {
            this.posX = rnd.Next(1, MaximoX);
            this.posY = rnd.Next(1, MaximoY);
        }
        public static PelotaBuena HacerBuena(Pelota pelota)
        {
            if (pelota is PelotaNeutra)
            {
                return new PelotaBuena() { color = ConsoleColor.Green, indice = pelota.Indice, posX = pelota.PosX, posY = pelota.PosY, movX = 1, movy = 1 };
            }
            else if (pelota is PelotaBuena)
            {
                return (PelotaBuena)pelota;
            }
            #endregion

            //Cambiar por ChoqueException
            throw new ChoqueException("Se Termina el juego");

            #region NO_TOCAR_NADA
        }
        public int VelX { get { return velX; } set { velX = value; } }
        public int VelY { get { return velY; } set { velY = value; } }

        public void HayChoque(List<Pelota> pelotas)
        {
            if (indice > 0)
            {

                if (Math.Abs(pelotas[indice - 1].PosX - posX) < 15 && (Math.Abs(pelotas[indice - 1].PosY - PosY) < 15))
                {
                    pelotas[indice - 1] = HacerBuena(pelotas[indice - 1]);
                }
                if (pelotas[indice - 1].PosX - posX < 0)
                {
                    Pelota.Ordernar(pelotas);
                }
            }
        }

        public void Mover()
        {
            posX = posX + velX;
            posY = posY + velY;
            Verificar();
        }

        public void Verificar()
        {
            if (posX < 2 && velX < 0 || posX > MaximoX - 5 && velX > 0)
                velX = -1 * velX;

            if (posY < 2 && velY < 0 || posY > MaximoY - 5 && velY > 0)
                velY = -1 * velY;
        }



        public static List<PelotaBuena> BuscarBuenas()
        {
            List<PelotaBuena> buenas = new List<PelotaBuena>();
            foreach (Pelota item in Juego.Pelotas)
            {
                if (item is PelotaBuena)
                    buenas.Add((PelotaBuena)item);
            }
            return buenas;
        }

        #endregion
    }
}
