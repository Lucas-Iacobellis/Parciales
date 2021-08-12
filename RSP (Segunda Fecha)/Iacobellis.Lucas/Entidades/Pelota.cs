using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(PelotaBuena)), XmlInclude(typeof(PelotaMala)), XmlInclude(typeof(PelotaNeutra))]
    public class Pelota
    {

        protected int posX;
        protected int posY;
        protected int movX;
        protected int movy;
        protected static int MaximoX;
        protected static int MaximoY;
        protected static Random rnd;


        protected ConsoleColor color;
        protected int indice;

        static Pelota()
        {
            MaximoX = 700;
            MaximoY = 400;
            rnd = new Random(DateTime.Now.Millisecond);
        }

        public int PosX
        {
            get { return this.posX; }
        }
        public int PosY
        {
            get { return this.posY; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public static void Ordernar(List<Pelota> pelotas)
        {
            pelotas.Sort((x, y) => x.PosX - y.posX);
            for (int i = 0; i < pelotas.Count; i++)
            {
                pelotas[i].indice = i;
            }
        }

        public override bool Equals(object obj)
        {
            Pelota pelota = (Pelota)obj;

            return
                   posX == pelota.posX &&
                   posY == pelota.posY &&
                   movX == pelota.movX &&
                   movy == pelota.movy &&
                   color == pelota.color &&
                   indice == pelota.indice &&
                   PosX == pelota.PosX &&
                   PosY == pelota.PosY &&
                   Indice == pelota.Indice;
        }
    }
}
