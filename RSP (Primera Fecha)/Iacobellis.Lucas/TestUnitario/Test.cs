using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _20201203;
using Entidades;
using Entidades.Excepciones;
using Entidades.Extension;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TestUnitario
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [ExpectedException(typeof(JugadaActivaException))]
        public void ProbarExcepcion()
        {
            GolDelSiglo golDelSiglo = new GolDelSiglo();
            golDelSiglo.IniciarJugada();
            golDelSiglo.IniciarJugada();
        }

        [TestMethod]
        public void ProbarMetodoDeExtension()
        {
            //Arrange
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = "Prueba";
            string expected = "a";

            //Act
            string result = pictureBox.ObtenerUltimoCaracterDelNombre();

            //Assert
            Assert.AreEqual(expected, result);
            
        }

    }
}
