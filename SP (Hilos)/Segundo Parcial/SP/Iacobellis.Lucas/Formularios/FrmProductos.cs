using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaDeNegocio;
using Entidades;
using Validaciones;
using Serializacion;

namespace Formularios
{
    public partial class FrmProductos : Form
    {
        //Stopwatch sw;

        SerializacionXML<List<Pedido>> serializacionXML;

        ProductoNegocio productoNegocio;
        EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
        ClienteNegocio clientesNegocio = new ClienteNegocio();
        
        public FrmProductos()
        {
            InitializeComponent();

            serializacionXML = new SerializacionXML<List<Pedido>>();

            productoNegocio = new ProductoNegocio();
        }
        public void GetDataSource()
        {
            dataGridViewProductos.DataSource = null;

            productoNegocio.CargarProductos();
            
            dataGridViewProductos.DataSource = Negocio.ListaProductos;

            dataGridViewProductos.AutoResizeRows();

            dataGridViewProductos.Columns[1].ReadOnly = true;
            dataGridViewProductos.Columns[2].ReadOnly = true;
            dataGridViewProductos.Columns[3].ReadOnly = true;
            dataGridViewProductos.Columns[4].ReadOnly = true;
            dataGridViewProductos.Columns[5].ReadOnly = true;

            lblCantidadTotalStock.Text = Negocio.TotalStock().ToString();
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            bool validacionNombre = true;
            bool validacionPrecio = true;
            bool validacionCantidad = true;
            bool validacionIdProducto = true;
            bool validacionMarca = true;
            
            if (Validar.ValidarString(txtNombre.Text) == "") 
            {
                validacionNombre = false;
                MessageBox.Show("Nombre invalido");
            }

            if(Validar.ValidarStringToFloat(txtPrecio.Text) == 0) 
            {
                validacionPrecio = false;
                MessageBox.Show("Precio invalido");
            }

            if (Validar.ValidarStringToInt(txtCantidadDeProductos.Text) == 0)
            {
                validacionCantidad = false;
                MessageBox.Show("Cantidad invalida");
            }

            if (Validar.ValidarEntero(Validar.ValidarStringToInt(txtIdProducto.Text)) == 0)
            {
                validacionIdProducto = false;
                MessageBox.Show("ID Producto invalido");
            }

            if (Validar.ValidarString(txtMarca.Text) == "")
            {
                validacionMarca = false;
                MessageBox.Show("Marca invalida");
            }

            if (validacionNombre == true && validacionPrecio == true && validacionCantidad == true && validacionIdProducto == true && validacionMarca == true)
            {  
                Producto producto = new Producto(txtNombre.Text, Convert.ToInt32(txtPrecio.Text), Convert.ToInt32(txtCantidadDeProductos.Text), txtIdProducto.Text, txtMarca.Text);

                if (Negocio.ListaProductos + producto == true)
                {
                    productoNegocio.InsertarProducto(producto);
                    Producto.ProductoRepetidoSuma(producto);

                    MessageBox.Show("Producto agregado");
                    GetDataSource();
                    LimpiarDatos();
                }

                else 
                {
                    MessageBox.Show("Ya existe un producto con esos datos");
                    GetDataSource();
                    LimpiarDatos();
                }
                              
            }
        }
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            bool variable = false;

            Producto productoAEliminar = new Producto();

            List<Producto> listaAEliminar = new List<Producto>();

            for (int i = 0; i < Negocio.ListaProductos.Count; i++)
            {

                if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                {
                    productoAEliminar.Nombre = dataGridViewProductos.Rows[i].Cells[1].Value.ToString();
                    productoAEliminar.Precio = Convert.ToInt32(dataGridViewProductos.Rows[i].Cells[2].Value);
                    productoAEliminar.Cantidad = Convert.ToInt32(dataGridViewProductos.Rows[i].Cells[3].Value);
                    productoAEliminar.IdProducto = dataGridViewProductos.Rows[i].Cells[4].Value.ToString();
                    productoAEliminar.Marca = dataGridViewProductos.Rows[i].Cells[5].Value.ToString();

                    listaAEliminar.Add(productoAEliminar);
                }
            }

            for (int i = 0; i < listaAEliminar.Count; i++)
            {
                if (Negocio.ListaProductos - listaAEliminar[i])
                {
                    variable = true;
                }
            }

            if (variable == true)
            {
                productoNegocio.EliminarProducto(productoAEliminar);
                MessageBox.Show("Producto/os eliminado/os");
                GetDataSource();
                LimpiarDatos();
            }

            else
            {
                MessageBox.Show("Seleccione el/los productos que quiere eliminar");
                LimpiarDatos();
            }
        }
        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            bool variable = false;

            Producto productoModificado = new Producto();

            for (int i = 0; i < Negocio.ListaProductos.Count; i++)
            {

                if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                {
                    productoModificado.Nombre = txtNombre.Text;
                    productoModificado.Precio = Validar.ValidarStringToFloat(txtPrecio.Text);
                    productoModificado.Cantidad = Convert.ToInt32(txtCantidadDeProductos.Text);
                    productoModificado.IdProducto = txtIdProducto.Text;
                    productoModificado.Marca = txtMarca.Text;

                    variable = true;
                }

            }
            
            if (variable == true)
            {
                productoNegocio.ModificarProducto(productoModificado);
                MessageBox.Show("Producto modificado");
                GetDataSource();
                LimpiarDatos();
            }

            else
            {
                MessageBox.Show("Seleccione el producto que quiere modificar");
                LimpiarDatos();
            }

            txtIdProducto.ReadOnly = false;
        }
        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdProducto.ReadOnly = true;

            btnEliminarProducto.Enabled = true;

            int contador = 0;
            for (int i = 0; i < dataGridViewProductos.Rows.Count; i++)
            {
                if (dataGridViewProductos.Rows[i].Cells["Seleccionar"].Value != null)
                {
                    bool tilde = (bool)dataGridViewProductos.Rows[i].Cells["Seleccionar"].Value;

                    if (tilde == true)
                    {
                        contador++;
                    }
                }

            }

            if (contador == 1)
            {
                btnModificarProducto.Enabled = true;

                if (e.RowIndex != -1)
                {
                    for (int i = 0; i < Negocio.ListaProductos.Count; i++)
                    {

                        if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                        {
                            txtNombre.Text = Negocio.ListaProductos[i].Nombre;
                            txtPrecio.Text = Negocio.ListaProductos[i].Precio.ToString();
                            txtCantidadDeProductos.Text = Negocio.ListaProductos[i].Cantidad.ToString();
                            txtIdProducto.Text = Negocio.ListaProductos[i].IdProducto;
                            txtMarca.Text = Negocio.ListaProductos[i].Marca;
                        }
                    }
                }
            }

            else
            {
                btnModificarProducto.Enabled = false;
                LimpiarDatos();
            }
        }

        private void dataGridViewProductos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewProductos.IsCurrentCellDirty)
            {
                dataGridViewProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
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
            txtPrecio.Text = "";
            txtCantidadDeProductos.Text = "";
            txtIdProducto.Text = "";
            txtMarca.Text = "";
        }

        //private void FrmProductos_MouseMove(object sender, MouseEventArgs e)
        //{
        //    IniciarTimer();
        //}
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            GetDataSource();
            CargarComboCliente();
            CargarVendedor();
            //timerSesion = new Timer();
            //timerSesion.Tick += new EventHandler(timerSesion_Tick);
            //IniciarTimer();
        }
        private void FrmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Negocio.ListaProductos.Count == 0)
            {
                Negocio.TodoBorradoProductos = true;
            }

            //timerSesion.Stop();
            //sw.Stop();

            this.Dispose();
            this.Close();
        }

        private void btnHacerPedido_Click(object sender, EventArgs e)
        {
            bool resultado = false;

            PedidoNegocio pedidosNegocio = new PedidoNegocio();
            pedidosNegocio.CargarPedidos();

            for (int i = 0; i < Negocio.ListaProductos.Count; i++)
            {

                if (Convert.ToBoolean(dataGridViewProductos.Rows[i].Cells[0].Value) == true)
                {
                    Pedido pedido = new Pedido(dataGridViewProductos.Rows[i].Cells["Nombre"].Value.ToString(), float.Parse(dataGridViewProductos.Rows[i].Cells["Precio"].Value.ToString()), int.Parse(dataGridViewProductos.Rows[i].Cells["Cantidad"].Value.ToString()), dataGridViewProductos.Rows[i].Cells["IdProducto"].Value.ToString(), dataGridViewProductos.Rows[i].Cells["Marca"].Value.ToString(), 1, 2, 1, "Falta Entregar", "Falta Entregar"); //Hacer Metodo para que busque en la base de datos el id del cliente pasandole el apellido del cliente y ponerlo aca. Seria algo como una query que diga select * from tqabla where nombrecliente = @condicion eso te devuelve una lista o un datatble y del él obretes solo el id y lo retornas
                    resultado = pedidosNegocio.InsertarPedido(pedido);                                                                                                                                                 //    resultado = pedidosNegocio.InsertarPedido(pedido);
                }
            }

            if (resultado == true)
            {
                pedidosNegocio.CargarPedidos();
                serializacionXML.Guardar(RutaDeArchivos.PATHPEDIDOSXML, "Pedidos.xml", Negocio.ListaPedidos);
                MessageBox.Show("El pedido ha sido creado con exito. Debe dirigirse a la pantalla de Pedidos para ver su estado"); //Pedidos en curso es la delas 2 grillas

            }

            else
            {
                MessageBox.Show("Error con la carga del pedido");
            }
        }

        public void CargarComboCliente()
        {

            clientesNegocio.CargarClientes();
            this.comboBoxNombreCliente.DataSource = Negocio.ListaClientes;
            this.comboBoxNombreCliente.ValueMember = "Nombre";
            this.comboBoxNombreCliente.DisplayMember = "Nombre";

            this.comboBoxApellidoCliente.DataSource = Negocio.ListaClientes;
            this.comboBoxApellidoCliente.ValueMember = "Apellido";
            this.comboBoxApellidoCliente.DisplayMember = "Apellido";
        }

        public void CargarVendedor()
        {
            Random random = new Random();
            int numeroRandom;

            empleadoNegocio.CargarEmpleados();

            bool variable = false;

            while (variable == false)
            {
                numeroRandom = random.Next(1, Negocio.ListaEmpleados.Count + 1);

                foreach (var item in Negocio.ListaEmpleados)
                {

                    if (item.IdEmpleado == numeroRandom)
                    {
                        txtEmpleado.Text = item.Nombre;
                        variable = true;
                    }
                }
            }

        }
    }
}
