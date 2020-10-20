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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }
        public void GetDataSource()
        {
            dataGridViewClientes.DataSource = null;
            dataGridViewClientes.DataSource = Negocio.ListaClientes;
            dataGridViewClientes.AutoResizeRows();
            dataGridViewClientes.Columns[1].ReadOnly = true;
            dataGridViewClientes.Columns[2].ReadOnly = true;
            dataGridViewClientes.Columns[3].ReadOnly = true;
            dataGridViewClientes.Columns[4].ReadOnly = true;
            dataGridViewClientes.Columns[5].ReadOnly = true;
            dataGridViewClientes.Columns[6].ReadOnly = true;
        }
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            bool validacionNombre = false;
            bool validacionApellido = false;
            bool validacionEdad = false;
            bool validacionDNI = false;
            bool validacionCantidadDeCompras = false;
            bool validacionIdCliente = false;

            if (Validar.ValidarString(txtNombre.Text) == "" && txtNombre.Text != "Sin nombre")
            {
                validacionNombre = true;
                MessageBox.Show("Nombre invalido");
            }

            if (Validar.ValidarString(txtApellido.Text) == "" && txtApellido.Text != "Sin apellido")
            {
                validacionApellido = true;
                MessageBox.Show("Apellido invalido");
            }

            if (Validar.ValidarEdad(Validar.ValidarStringToInt(txtEdad.Text)) == 0)
            {
                validacionEdad = true;
                MessageBox.Show("Edad invalida");
            }

            if (Validar.ValidarEntero(Validar.ValidarStringToInt(txtDni.Text)) == 0)
            {
                validacionDNI = true;
                MessageBox.Show("DNI invalido");
            }

            if (Validar.ValidarNumeroDeEntrada(txtCantidadDeCompras.Text) == "Numero erroneo")
            {
                validacionCantidadDeCompras = true;
                MessageBox.Show("Cantidad de compras invalida. Tiene que ser un valor numerico mayor o igual a 0");
            }

            if (Validar.ValidarEntero(Validar.ValidarStringToInt(txtIdCliente.Text)) == 0)
            {
                validacionIdCliente= true;
                MessageBox.Show("ID Cliente invalido");
            }

            if (validacionNombre == false && validacionApellido == false && validacionEdad == false && validacionDNI == false && validacionCantidadDeCompras == false && validacionIdCliente == false) 
            {
                Cliente cliente = new Cliente(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text), Convert.ToInt32(txtDni.Text), Convert.ToInt32(txtCantidadDeCompras.Text), Convert.ToInt32(txtIdCliente.Text));
                if (Negocio.ListaClientes + cliente == false)
                {
                    MessageBox.Show("Ya existe un cliente con esos datos");
                    GetDataSource();
                }

                else
                {
                    MessageBox.Show("Cliente agregado a la lista");
                    GetDataSource();
                }
            }
              
        }
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            bool variable = false;
            List<Cliente> listaDelete = new List<Cliente>();

            for (int i = 0; i < Negocio.ListaClientes.Count; i++)
            {

                if (Convert.ToBoolean(dataGridViewClientes.Rows[i].Cells[0].Value) == true)
                {
                    Cliente clienteAux = new Cliente();

                    clienteAux.CantidadDeCompras = Convert.ToInt32(dataGridViewClientes.Rows[i].Cells[1].Value);
                    clienteAux.IdCliente = Convert.ToInt32(dataGridViewClientes.Rows[i].Cells[2].Value);
                    clienteAux.Nombre = dataGridViewClientes.Rows[i].Cells[3].Value.ToString();
                    clienteAux.Apellido = dataGridViewClientes.Rows[i].Cells[4].Value.ToString();
                    clienteAux.Edad = Convert.ToInt32(dataGridViewClientes.Rows[i].Cells[5].Value);
                    clienteAux.Dni = Convert.ToInt32(dataGridViewClientes.Rows[i].Cells[6].Value);

                    listaDelete.Add(clienteAux);
                }

            }

            for (int i = 0; i < listaDelete.Count; i++)
            {
                if (Negocio.ListaClientes - listaDelete[i])
                {
                    variable = true;
                }
            }

            if (variable == true)
            {
                MessageBox.Show("Cliente/es eliminado/os de la lista");
                GetDataSource();
            }

            else
            {
                MessageBox.Show("Seleccione el/los clientes que quiere eliminar");
            }
        }
        private void btnComprar_Click(object sender, EventArgs e)
        {
            FrmCompras frmCompras = new FrmCompras();
            this.Visible = false;
            frmCompras.Show();
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            this.Visible = false;
            frmMenu.Show();
        }
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            Negocio.HarcodearClientes();
            GetDataSource();
        }
        private void FrmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

    }
}
