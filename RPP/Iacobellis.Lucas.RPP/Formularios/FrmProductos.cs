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
using Exepciones;
using Validaciones;

namespace Formularios
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }
        public void GetDataSource()
        {
            dataGridViewProductos.DataSource = null;
            dataGridViewProductos.DataSource = Negocio.ListaProductos;
            dataGridViewProductos.AutoResizeRows();
            dataGridViewProductos.Columns[1].ReadOnly = true;
            dataGridViewProductos.Columns[2].ReadOnly = true;
            dataGridViewProductos.Columns[3].ReadOnly = true;
            dataGridViewProductos.Columns[4].ReadOnly = true;
            dataGridViewProductos.Columns[5].ReadOnly = true;
            lblCantidadBajoStock.Text = Negocio.BajoStock().ToString();
            lblCantidadTotalStock.Text = Negocio.TotalStock().ToString();
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            bool validacionNombre = false;
            bool validacionPrecio = false;
            bool validacionCantidad = false;
            bool validacionIdProducto = false;
            bool validacionMarca = false;
            
            if (Validar.ValidarString(txtNombre.Text) == "" && txtNombre.Text != "Sin nombre") 
            {
                validacionNombre = true;
                MessageBox.Show("Nombre invalido");
            }

            if(Validar.ValidarStringToFloat(txtPrecio.Text) == 0) 
            {
                validacionPrecio = true;
                MessageBox.Show("Precio invalido");
            }

            if (Validar.ValidarStringToInt(txtCantidadDeProductos.Text) == 0)
            {
                validacionCantidad = true;
                MessageBox.Show("Cantidad invalida");
            }

            if (Validar.ValidarEntero(Validar.ValidarStringToInt(txtIdProducto.Text)) == 0)
            {
                validacionIdProducto = true;
                MessageBox.Show("ID Producto invalido");
            }

            if (Validar.ValidarString(txtMarca.Text) == "")
            {
                validacionMarca = true;
                MessageBox.Show("Marca invalida");
            }

            if (validacionNombre == false && validacionPrecio == false && validacionCantidad == false && validacionIdProducto == false && validacionMarca == false)
            {  
                
                Producto producto = new Producto(txtNombre.Text, Convert.ToInt32(txtPrecio.Text), Convert.ToInt32(txtCantidadDeProductos.Text), txtIdProducto.Text, txtMarca.Text);
                if (Negocio.ListaProductos + producto == false)
                {
                    MessageBox.Show("Ya existe un producto con esos datos");
                    GetDataSource();    
                }
                else 
                {
                    Producto.ProductoRepetidoSuma(producto);
                    MessageBox.Show("Producto agregado a la lista");
                    GetDataSource();
                }
                              
            }
        }
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            bool variable = false;
            List<Producto> listaDelete = new List<Producto>();

            for (int i = 0; i < Negocio.ListaProductos.Count; i++)
            {

                if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                {
                    Producto productoAux = new Producto();
                    productoAux.Nombre = dataGridViewProductos.Rows[i].Cells[1].Value.ToString();
                    productoAux.Precio = Convert.ToInt32(dataGridViewProductos.Rows[i].Cells[2].Value);
                    productoAux.Cantidad = Convert.ToInt32(dataGridViewProductos.Rows[i].Cells[3].Value);
                    productoAux.IdProducto = dataGridViewProductos.Rows[i].Cells[4].Value.ToString();
                    productoAux.Marca = dataGridViewProductos.Rows[i].Cells[5].Value.ToString();

                    listaDelete.Add(productoAux);
                }

            }

            for (int i = 0; i < listaDelete.Count; i++)
            {
                if (Negocio.ListaProductos - listaDelete[i])
                {
                    variable = true;
                }
            }

            if (variable == true)
            {
                MessageBox.Show("Producto/os eliminado/os de la lista");
                GetDataSource();
            }

            else
            {
                MessageBox.Show("Seleccione el/los productos que quiere eliminar");
            }
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            this.Visible = false;
            frmMenu.Show();
        }
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            Negocio.HarcodearProductos();
            GetDataSource();
        }
        private void FrmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
