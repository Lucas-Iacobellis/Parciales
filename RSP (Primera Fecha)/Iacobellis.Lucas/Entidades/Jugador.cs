using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Jugador
    {
        private int numeroDeCamiseta;
        private string nombreJugador;
        private string piernaHabil;

        public int NumeroDeCamiseta
        {

            get { return this.numeroDeCamiseta; }
            set { this.numeroDeCamiseta = value; }
        }


        public string NombreJugador
        {

            get { return this.nombreJugador; }
            set { this.nombreJugador = value; }
        }


        public string PiernaHabil
        {

            get { return this.piernaHabil; }
            set { this.piernaHabil = value; }
        }

        public Jugador()
        {

        }

        //public Jugador(int numeroDeCamiseta, string nombreJugador):this()
        //{

        //    this.numeroDeCamiseta = NumeroDeCamiseta;
        //    this.nombreJugador = NombreJugador;

        //}

        public Jugador(int numeroDeCamiseta, string nombreJugador, string piernaHabil)
        {
            this.NumeroDeCamiseta = numeroDeCamiseta;
            this.NombreJugador = nombreJugador;
            this.PiernaHabil = piernaHabil;
        }
    }
}
