using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class JugadaActivaException:Exception
    {
        public JugadaActivaException():base()
        {

        }
        public JugadaActivaException(string message) : base(message)
        {

        }
    }
}
