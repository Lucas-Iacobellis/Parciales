namespace Entidades
{
    public class Jugador
    {
        private string nombre;

        private int puntos = 0;

        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Jugador()
        {

        }
        public Jugador(string nombre, int puntos)
        {
            this.Nombre = nombre;
            this.Puntos = puntos;
        }
        public void SumarPuntos(int puntos)
        {
            this.Puntos += puntos;
        }

    }
}