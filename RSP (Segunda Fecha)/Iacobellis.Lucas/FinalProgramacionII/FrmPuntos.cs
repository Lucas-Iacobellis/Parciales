using System;
using System.Windows.Forms;
using Entidades;

namespace FinalProgramacionII
{
    public partial class FrmPuntos : Form
    {
        public FrmPuntos()
        {
            InitializeComponent();

        }

        private void FrmPuntos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Helper.BuscarEnlog();

        }
    }
}
