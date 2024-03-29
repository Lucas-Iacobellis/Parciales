﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using CapaDeNegocio;
using Entidades;
using Validaciones;

namespace Formularios
{
    public partial class FrmClientes : Form
    {
        //Stopwatch sw;

        ClienteNegocio clienteNegocio;
        Thread hiloCliente;
        public FrmClientes()
        {
            InitializeComponent();

            clienteNegocio = new ClienteNegocio();
        }
        public void GetDataSource()
        {
            
            dataGridViewClientes.DataSource = null;
            clienteNegocio.CargarClientes();
            dataGridViewClientes.DataSource = Negocio.ListaClientes;

            dataGridViewClientes.AutoResizeRows();

            dataGridViewClientes.Columns[1].ReadOnly = true;
            dataGridViewClientes.Columns[2].ReadOnly = true;
            dataGridViewClientes.Columns[3].ReadOnly = true;
            dataGridViewClientes.Columns[4].ReadOnly = true;
            dataGridViewClientes.Columns[5].ReadOnly = true;
        }
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            bool validacionNombre = true;
            bool validacionApellido = true;
            bool validacionEdad = true;
            bool validacionDNI = true;
            bool validacionIdCliente = true;

            if (Validar.ValidarString(txtNombre.Text) == "")
            {
                validacionNombre = false;
                MessageBox.Show("Nombre invalido");
            }

            if (Validar.ValidarString(txtApellido.Text) == "")
            {
                validacionApellido = false;
                MessageBox.Show("Apellido invalido");
            }

            if (Validar.ValidarEdad(Validar.ValidarStringToInt(txtEdad.Text)) == 0)
            {
                validacionEdad = false;
                MessageBox.Show("Edad invalida");
            }

            if (Validar.ValidarEntero(Validar.ValidarStringToInt(txtDni.Text)) == 0)
            {
                validacionDNI = false;
                MessageBox.Show("DNI invalido");
            }
            
            if (Validar.ValidarEntero(Validar.ValidarStringToInt(txtIdCliente.Text)) == 0)
            {
                validacionIdCliente = false;
                MessageBox.Show("ID Cliente invalido");
            }

            if (validacionNombre == true && validacionApellido == true && validacionEdad == true && validacionDNI == true && validacionIdCliente == true)
            {
                Cliente cliente = new Cliente(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text), Convert.ToInt32(txtDni.Text), Convert.ToInt32(txtIdCliente.Text));

                if (Negocio.ListaClientes + cliente == true)
                {
                    hiloCliente = new Thread(delegate () { clienteNegocio.InsertarCliente(cliente); });
                    hiloCliente.Start();

                    while (hiloCliente.IsAlive)
                    {
                        //if (this.label1.InvokeRequired)
                        //{
                            this.label1.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.label1.Text = "Se esta guardando el cliente";
                            });
                        //}
                        //else 
                        //{
                        //    this.label1.Text = "Se esta guardando el cliente";
                        //}

                        Thread.Sleep(5000);
                    }

                    Thread.Sleep(5000);

                    //clienteNegocio.InsertarCliente(cliente);
                    MessageBox.Show("Cliente/a agregado/a");
                    this.label1.Text = string.Empty;
                    GetDataSource();
                    LimpiarDatos();
                }
                
                else
                {
                    MessageBox.Show("Ya existe un/a cliente/a con esos datos");
                    GetDataSource();
                    LimpiarDatos();
                }
            }

        }
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            bool variable = false;

            Cliente clienteAEliminar = new Cliente();

            List<Cliente> listaAEliminar = new List<Cliente>();

            for (int i = 0; i < Negocio.ListaClientes.Count; i++)
            {

                if (Convert.ToBoolean(dataGridViewClientes.Rows[i].Cells[0].Value) == true)
                {
                    clienteAEliminar.IdCliente = Convert.ToInt32(dataGridViewClientes.Rows[i].Cells[2].Value);
                    clienteAEliminar.Nombre = dataGridViewClientes.Rows[i].Cells[3].Value.ToString();
                    clienteAEliminar.Apellido = dataGridViewClientes.Rows[i].Cells[4].Value.ToString();
                    clienteAEliminar.Edad = Convert.ToInt32(dataGridViewClientes.Rows[i].Cells[5].Value);
                    clienteAEliminar.Dni = Convert.ToInt32(dataGridViewClientes.Rows[i].Cells[6].Value);

                    listaAEliminar.Add(clienteAEliminar);
                }

            }

            for (int i = 0; i < listaAEliminar.Count; i++)
            {
                if (Negocio.ListaClientes - listaAEliminar[i])
                {
                    variable = true;
                }
            }

            if (variable == true)
            {
                clienteNegocio.EliminarCliente(clienteAEliminar);
                MessageBox.Show("Cliente/es eliminado/os");
                GetDataSource();
                LimpiarDatos();
            }

            else
            {
                MessageBox.Show("Seleccione el/los cliente/s que quiere eliminar");
                LimpiarDatos();
            }
        }
        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            bool variable = false;

            Cliente clienteModificado = new Cliente();

            for (int i = 0; i < Negocio.ListaClientes.Count; i++)
            {

                if (Convert.ToBoolean(dataGridViewClientes.Rows[i].Cells[0].Value) == true)
                {
                    clienteModificado.IdCliente = Convert.ToInt32(txtIdCliente.Text);
                    clienteModificado.Nombre = txtNombre.Text;
                    clienteModificado.Apellido = txtApellido.Text;
                    clienteModificado.Edad = Convert.ToInt32(txtEdad.Text);
                    clienteModificado.Dni = Convert.ToInt32(txtDni.Text);

                    variable = true;
                }

            }
            
            if (variable == true) 
            {
                clienteNegocio.ModificarCliente(clienteModificado);
                MessageBox.Show("Cliente/a modificado/a");
                GetDataSource();
                LimpiarDatos();
            }

            else
            {
                MessageBox.Show("Seleccione el/la cliente/a que quiere modificar");
                LimpiarDatos();
            }

            txtIdCliente.ReadOnly = false;
        }
        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdCliente.ReadOnly = true;

            btnEliminarCliente.Enabled = true;

            int contador = 0;
            for (int i = 0; i < dataGridViewClientes.Rows.Count; i++)
            {
                if (dataGridViewClientes.Rows[i].Cells["Seleccionar"].Value != null) 
                {
                    bool tilde = (bool)dataGridViewClientes.Rows[i].Cells["Seleccionar"].Value;

                    if (tilde == true)
                    {
                        contador++;
                    }
                }
                
            }

            if (contador == 1)
            {
                btnModificarCliente.Enabled = true;

                if (e.RowIndex != -1)
                {
                    for (int i = 0; i < Negocio.ListaClientes.Count; i++)
                    {

                        if (Convert.ToBoolean(dataGridViewClientes.Rows[i].Cells[0].Value) == true)
                        {
                            txtNombre.Text = Negocio.ListaClientes[i].Nombre;
                            txtApellido.Text = Negocio.ListaClientes[i].Apellido;
                            txtEdad.Text = Negocio.ListaClientes[i].Edad.ToString();
                            txtDni.Text = Negocio.ListaClientes[i].Dni.ToString();
                            txtIdCliente.Text = Negocio.ListaClientes[i].IdCliente.ToString();
                        }
                    }
                }
            }

            else
            {
                btnModificarCliente.Enabled = false;
                LimpiarDatos();
            }
        }

        private void dataGridViewClientes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewClientes.IsCurrentCellDirty)
            {
                dataGridViewClientes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void btnSeleccionarProductos_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            this.Visible = false;
            frmProductos.Show();

            //timerSesion.Stop();
            //sw.Stop();
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            this.Visible = false;
            this.Close();
            frmMenu.Show();
        }
        //private void timerSesion_Tick(object sender, EventArgs e)
        //{
        //    if (sw.Elapsed.Seconds == 10)
        //    {
        //        timerSesion.Stop();
        //        sw.Stop();
        //        MessageBox.Show("Cierre de sesion por inactividad");
        //        FrmLogin frmLogin = new FrmLogin();
        //        frmLogin.Show();
        //        this.Close();

        //    }
        //}

        //private void IniciarTimer()
        //{
        //    timerSesion.Start();

        //    sw = new Stopwatch();
        //    sw.Start();
        //}
        public void LimpiarDatos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtDni.Text = "";
            txtIdCliente.Text = "";
        }
        //private void FrmClientes_MouseMove(object sender, MouseEventArgs e)
        //{
        //    IniciarTimer();
        //}
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            //clienteNegocio.CargarClientes();
            GetDataSource();

            //timerSesion = new Timer();
            //timerSesion.Tick += new EventHandler(timerSesion_Tick);
            //IniciarTimer();
        }
        private void FrmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Negocio.ListaClientes.Count == 0) 
            {
                Negocio.TodoBorradoClientes = true;
            }

            //timerSesion.Stop();
            //sw.Stop();

            this.Dispose();
            this.Close();
        }

       
    }
}
