using System;

namespace Entidades.Excepciones
{
    public class ChoqueException : Exception
    {
        public ChoqueException(string mensaje) : base(mensaje)
        {

        }
    }
}
