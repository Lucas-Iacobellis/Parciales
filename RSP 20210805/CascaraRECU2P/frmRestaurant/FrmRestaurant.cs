using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Threading;
using System.Threading.Tasks;



namespace frmRestaurant
{
    public partial class FrmRestaurant : Form
    {
        Restaurant restaurant;
        ComidaDAO<Comida> comidaDao;
        BindingSource bindingSource;
        List<Comida> pedidos;
        Thread hiloCocinero;
      
        public FrmRestaurant()
        {
            InitializeComponent();
            DgMenu.MultiSelect = false;
            DgMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        private void FrmRestaurant_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPedir_Click(object sender, EventArgs e)
        {         
            DataGridViewRow filaSeleccionada = DgMenu.SelectedRows[0]; 
            Comida comida = (Comida)filaSeleccionada.DataBoundItem; 

        
           
        }

        


        private void btnCocinar_Click(object sender, EventArgs e)
        {
           
            

        }

      

    }
}
