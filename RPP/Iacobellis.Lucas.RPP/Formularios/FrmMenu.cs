using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmClientes formuluarioClientes = new FrmClientes();
            formuluarioClientes.Show();
        }
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmEmpleados formuluarioEmpleados = new FrmEmpleados();
            formuluarioEmpleados.Show();
        }
        private void btnProductos_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmProductos formuluarioProductos = new FrmProductos();
            formuluarioProductos.Show();
        }
        private void btnCompras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmCompras formuluarioCompras = new FrmCompras();
            formuluarioCompras.Show();
        }
        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        
    }
}
