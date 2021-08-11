namespace Entidades
{
    public class Jugador
    {
        private string nombre;

        private int puntos = 0;

        public int Puntos
        {
            get { return puntos; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public void SumarPuntos(int puntos)
        {
            this.puntos += puntos;
        }

    }
}