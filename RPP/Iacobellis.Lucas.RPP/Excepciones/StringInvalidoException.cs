using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class StringInvalidoException : Exception
    {
        public StringInvalidoException()
            : base()
        {

        }

        public StringInvalidoException(string mensaje)
            : base(mensaje)
        {

        }

        public StringInvalidoException(Exception innerException)
            : base(innerException.Message, innerException)
        {

        }

        public StringInvalidoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }

    }
}
