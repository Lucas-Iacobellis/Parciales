using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades.Excepciones;
using Entidades.Extension;

namespace TestUnitario
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [ExpectedException(typeof(JugadaActivaException))]
        public void ProbarExcepcion()
        {

        }

        [TestMethod]
        public void ProbarMetodoDeExtension()
        {

        }

    }
}
