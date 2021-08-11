namespace Entidades
{
    public class PelotaNeutra : Pelota
    {


        static PelotaNeutra()
        {

        }
        public PelotaNeutra()
        {
            this.posX = rnd.Next(1, MaximoX);
            this.posY = rnd.Next(1, MaximoY);
        }

        public void Posicionar(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }
    }
}
