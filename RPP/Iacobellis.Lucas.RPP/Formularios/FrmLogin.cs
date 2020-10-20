using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Validaciones;

namespace Formularios
{
    public partial class FrmLogin : Form
    {
        Dictionary<string, string> diccionario = new Dictionary<string, string>();
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            string validacionUsuario = Validar.ValidarUsuario(usuario);
            string validacionContraseña = Validar.ValidarNumeroDeEntrada(contraseña);

            if (validacionUsuario == "Vacio")
            {
                MessageBox.Show("El usuario esta vacio. Reingrese usuario");
            }

            if (validacionUsuario == "Espacios")
            {
                MessageBox.Show("El usuario contiene espacios. Reingrese usuario");
            }

            if (validacionContraseña == "Vacia")
            {
                MessageBox.Show("La contraseña esta vacia. Reingrese contraseña");
            }

            if (validacionContraseña == "Incorrecta")
            {
                MessageBox.Show("La contraseña debe tener solo numeros");
            }

            if (validacionUsuario == "Correcto" && validacionContraseña == "Correcta") 
            {
                diccionario.Add(usuario, contraseña);
                MessageBox.Show("Bienvenido al Kwik E Mart !!!");

                this.Visible = false;
                FrmMenu formularioMenu = new FrmMenu();
                formularioMenu.Show();
            }
          
        }
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
