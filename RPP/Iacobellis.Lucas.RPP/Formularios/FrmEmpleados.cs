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
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }
        public void GetDataSource()
        {
            dataGridViewEmpleados.DataSource = null;
            dataGridViewEmpleados.DataSource = Negocio.ListaEmpleados;
            dataGridViewEmpleados.AutoResizeRows();
            dataGridViewEmpleados.Columns[1].ReadOnly = true;
            dataGridViewEmpleados.Columns[2].ReadOnly = true;
            dataGridViewEmpleados.Columns[3].ReadOnly = true;
            dataGridViewEmpleados.Columns[4].ReadOnly = true;
            dataGridViewEmpleados.Columns[5].ReadOnly = true;
            dataGridViewEmpleados.Columns[6].ReadOnly = true;
        }
        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            bool validacionNombre = false;
            bool validacionApellido = false;
            bool validacionEdad = false;
            bool validacionDNI = false;
            bool validacionCantidadDeVentas = false;
            bool validacionIdEmpleado = false;

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

            if (Validar.ValidarNumeroDeEntrada(txtCantidadDeVentas.Text) == "Numero erroneo")
            {
                validacionCantidadDeVentas = true;
                MessageBox.Show("Cantidad de ventas invalida. Tiene que ser un valor numerico mayor o igual a 0");
            }

            if (Validar.ValidarEntero(Validar.ValidarStringToInt(txtIdEmpleado.Text)) == 0)
            {
                validacionIdEmpleado = true;
                MessageBox.Show("ID Empleado invalido");
            }

            if (validacionNombre == false && validacionApellido == false && validacionEdad == false && validacionDNI == false && validacionCantidadDeVentas == false && validacionIdEmpleado == false)
            {
                Empleado empleado = new Empleado(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text), Convert.ToInt32(txtDni.Text), Convert.ToInt32(txtCantidadDeVentas.Text), Convert.ToInt32(txtIdEmpleado.Text));
                if (Negocio.ListaEmpleados + empleado == false)
                {
                    MessageBox.Show("Ya existe un empleado con esos datos");
                    GetDataSource();
                }

                else
                {
                    MessageBox.Show("Empleado agregado a la lista");
                    GetDataSource();
                }
            }           
        }
        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            bool variable = false;
            List<Empleado> listaDelete = new List<Empleado>();

            for (int i = 0; i < Negocio.ListaEmpleados.Count; i++)
            {

                if (Convert.ToBoolean(dataGridViewEmpleados.Rows[i].Cells[0].Value) == true)
                {
                    Empleado empleadoAux = new Empleado();

                    empleadoAux.CantidadDeVentas = Convert.ToInt32(dataGridViewEmpleados.Rows[i].Cells[1].Value);
                    empleadoAux.IdEmpleado = Convert.ToInt32(dataGridViewEmpleados.Rows[i].Cells[2].Value);
                    empleadoAux.Nombre = dataGridViewEmpleados.Rows[i].Cells[3].Value.ToString();
                    empleadoAux.Apellido = dataGridViewEmpleados.Rows[i].Cells[4].Value.ToString();
                    empleadoAux.Edad = Convert.ToInt32(dataGridViewEmpleados.Rows[i].Cells[5].Value);
                    empleadoAux.Dni = Convert.ToInt32(dataGridViewEmpleados.Rows[i].Cells[6].Value);

                    listaDelete.Add(empleadoAux);
                }

            }

            for (int i = 0; i < listaDelete.Count; i++)
            {
                if (Negocio.ListaEmpleados - listaDelete[i])
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
        private void btnAtras_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            this.Visible = false;
            frmMenu.Show();
        }
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            Negocio.HarcodearEmpleados();
            GetDataSource();
        }
        private void FrmEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

    }
}
