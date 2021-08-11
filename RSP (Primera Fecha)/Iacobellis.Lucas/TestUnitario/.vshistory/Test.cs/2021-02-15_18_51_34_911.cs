using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _20201203;
using Entidades;
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
            D10S d10S = new D10S();
            d10S.btnGolDelSiglo_Click(new object(), new EventArgs());
            d10S.btnGolDelSiglo_Click(new object(), new EventArgs());
        }

        [TestMethod]
        public void ProbarMetodoDeExtension()
        {

        }

    }
}
