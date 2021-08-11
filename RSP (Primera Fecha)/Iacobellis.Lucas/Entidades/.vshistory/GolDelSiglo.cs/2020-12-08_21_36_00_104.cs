using System.Threading;
using Audio;
using Entidades.Excepciones;

namespace Entidades
{
    public class GolDelSiglo
    {
        private Thread hiloRelato;
        public void IniciarJugada()
        {
            if (hiloRelato != null && hiloRelato.IsAlive)
            {
                throw new JugadaActivaException("El gol ya está ocurriendo. Disfrutelo.");
            }

            else
            {
                hiloRelato = new Thread(Relato.VictorHugoMorales);
                hiloRelato.Start();
            }
        }
        public void CerrarApp()
        {
            AbortarHiloRelato();
        }

        public void AbortarHiloRelato() 
        {
            if(hiloRelato != null && hiloRelato.IsAlive)
                 hiloRelato.Abort();
        }   
    }
}
