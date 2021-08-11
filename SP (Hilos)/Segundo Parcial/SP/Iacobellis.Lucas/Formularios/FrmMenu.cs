using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmClientes formuluarioClientes = new FrmClientes();
            formuluarioClientes.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmEmpleados formuluarioEmpleados = new FrmEmpleados();
            formuluarioEmpleados.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmProductos formuluarioProductos = new FrmProductos();
            formuluarioProductos.Show();
        }
        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmVentas frm = new FrmVentas();
            frm.Show();
        }
        private void menuMiniSuper_MouseEnter(object sender, EventArgs e)
        {
            for (int i = 0; i < menuMiniSuper.Items.Count; i++)
            {
                menuMiniSuper.Items[i].Visible = true;
            }
        }

        private void menuMiniSuper_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < menuMiniSuper.Items.Count; i++)
            {
                menuMiniSuper.Items[i].Visible = false;
            }
        }
        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }        
    }
}
