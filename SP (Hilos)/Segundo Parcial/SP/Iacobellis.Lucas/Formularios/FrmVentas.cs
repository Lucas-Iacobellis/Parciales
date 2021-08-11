using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using CapaDeNegocio;
using Entidades;
using Serializacion;

namespace Formularios
{
    public partial class FrmVentas : Form
    {
        //SoundPlayer sonido;

        SerializacionXML<List<Pedido>> serializacionXML;
        SerializacionTXT serializacionTXT;

        Thread hiloUno;
        Thread hiloDos;

        ClienteNegocio clienteNegocio;
        EmpleadoNegocio empleadoNegocio;
        ProductoNegocio productoNegocio;
        PedidoNegocio pedidoNegocio;
        public FrmVentas()
        {
            InitializeComponent();

            serializacionXML = new SerializacionXML<List<Pedido>>();
            serializacionTXT = new SerializacionTXT();

            clienteNegocio = new ClienteNegocio();
            empleadoNegocio = new EmpleadoNegocio();
            productoNegocio = new ProductoNegocio();
            pedidoNegocio = new PedidoNegocio();

            Negocio.ListaVentas = new List<Producto>();
        }
        private void dataGridViewPedidosIniciales_MouseDown(object sender, MouseEventArgs e)
        {
            int row = dataGridViewPedidosIniciales.HitTest(e.X, e.Y).RowIndex;
            dataGridViewPedidosIniciales.DoDragDrop(row, DragDropEffects.Copy);
        }
        private void dataGridViewVentas_DragDrop(object sender, DragEventArgs e)
        {
            int indiceFila = Convert.ToInt32(e.Data.GetData(Type.GetType("System.Int32")));
            Point point = dataGridViewVentas.PointToClient(new Point(e.X, e.Y));
            DataGridViewRow dtRow = new DataGridViewRow();
            DataGridView.HitTestInfo dtRowHit = dataGridViewVentas.HitTest(point.X, point.Y);
            int rowDeDestino = dtRowHit.RowIndex;

            if (dtRowHit.Type == DataGridViewHitTestType.Cell)
            {
                dtRow = dataGridViewPedidosIniciales.Rows[indiceFila];
            }

            if (rowDeDestino != -1)
            {

                Producto producto = new Producto(dtRow.Cells[0].Value.ToString(), ((float)dtRow.Cells[1].Value), Convert.ToInt32(dtRow.Cells[2].Value), dtRow.Cells[3].Value.ToString(), dtRow.Cells[4].Value.ToString());
                Producto.ProductoRepetido(producto);

                dataGridViewVentas.Rows.Clear();

                foreach (Producto item in Negocio.ListaVentas)
                {
                    dataGridViewVentas.Rows[0].Cells[0].Value = item.Nombre;
                    dataGridViewVentas.Rows[0].Cells[1].Value = item.Precio;
                    dataGridViewVentas.Rows[0].Cells[2].Value = item.Cantidad;
                    dataGridViewVentas.Rows[0].Cells[3].Value = item.IdProducto;
                    dataGridViewVentas.Rows[0].Cells[4].Value = item.Marca;
                }
            }

        }
        private void dataGridViewVentas_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        //private void btnComprar_Click(object sender, EventArgs e)
        //{
        //    string mensaje = "";
        //    string comprador = "";
        //    string vendedor = "";

        //    for (int i = 0; i < dataGridViewVentas.Rows.Count; i++)
        //    {
        //        if (dataGridViewVentas.Rows[i].Cells[0].Value != null)
        //        {
        //            comprador = "Compra realizada por: " + comboBoxNombreCliente.Text + " " + comboBoxApellidoCliente.Text + "\r\n";
        //            vendedor = "Venta realizada por: " + txtEmpleado.Text + "\r\n";
        //            mensaje += "Producto: " + dataGridViewVentas.Rows[i].Cells[0].Value.ToString() + "\r\n" + "Precio: $" + dataGridViewVentas.Rows[i].Cells[1].Value.ToString() + "\r\n" + "Cantidad: " + dataGridViewVentas.Rows[i].Cells[2].Value.ToString() + "\r\n";
        //        }
        //    }

        //    mensaje += "Cantidad total: " + Producto.CantidadTotalProductos() + "\r\n" + "Precio total: $" + Producto.SumaProductos(comboBoxApellidoCliente.Text);

        //    MessageBox.Show(mensaje);
        //    MessageBox.Show("Gracias por su compra !!!");

        //    sonido = new SoundPlayer(Application.StartupPath + @"\sonido\CajaRegistradora.wav");
        //    sonido.Play();


        //    serializacionTXT.Guardar(RutaDeArchivos.PATHCOMPRASTXT, "Compras.txt", comprador + mensaje);
        //    serializacionTXT.Guardar(RutaDeArchivos.PATHVENTASTXT, "Ventas.txt", vendedor + mensaje);

        //    for (int i = 0; i < Negocio.ListaVentas.Count; i++)
        //    {
        //        for (int j = 0; j < Negocio.ListaProductos.Count; j++)
        //        {
        //            if (Negocio.ListaVentas[i].IdProducto == Negocio.ListaProductos[j].IdProducto)
        //            {
        //                Negocio.ListaProductos[i].Cantidad = Negocio.ListaProductos[j].Cantidad - Negocio.ListaVentas[i].Cantidad;
        //            }
        //        }
        //    }
        //}
        public void CargarComboCliente()
        {
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
        private void btnAtras_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();

            hiloUno.Abort();
            hiloDos.Abort();

            this.Dispose();

            Negocio.ListaPedidosEnPreparacion.Clear();
            Negocio.ListaPedidosXML.Clear();

            this.Close();
        }
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            dataGridViewPedidosIniciales.AllowDrop = true;
            dataGridViewVentas.AllowDrop = true;

            clienteNegocio.CargarClientes();
            empleadoNegocio.CargarEmpleados();
            productoNegocio.CargarProductos();

            CargarComboCliente();
            CargarVendedor();
            

            pedidoNegocio.EstadoHilos = true;

            CargarListaXML();

        }
        private void FrmVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();

            hiloUno.Abort();
            hiloDos.Abort();

            this.Dispose();

            Negocio.ListaPedidosEnPreparacion.Clear();
            Negocio.ListaPedidosXML.Clear();

            this.Close();
        }
        public void Hilos()
        {
            hiloUno = new Thread(CargarPedidos);
            hiloDos = new Thread(PreparacionDelPedido);

            if (pedidoNegocio.EstadoHilos == true)
            {
                hiloUno.Start();
                hiloDos.Start();

                //pedidoNegocio.EstadoHilos = false;
            }

            else
            {
                pedidoNegocio.EstadoHilos = false;
            }

        }
        public void CargarListaXML()
        {
            List<Pedido> lista = new List<Pedido>(Negocio.ListaPedidosXML);
            serializacionXML.Leer(RutaDeArchivos.PATHPEDIDOSXML + "Pedidos.xml", out lista);

            foreach (Pedido item in lista)
            {
                if (Negocio.ListaPedidosXML.Count != 0)
                {
                    Negocio.ListaPedidosXML.Insert(Negocio.ListaPedidosXML.Count - 1, item);
                }

                else
                {
                    Negocio.ListaPedidosXML.Add(item);
                }
            }

            Hilos();
        }
        public void CargarPedidosIniciales()
        {
            int indice = Negocio.ListaPedidosXML.Count;

            if (this.dataGridViewPedidosIniciales.InvokeRequired)
            {
                this.dataGridViewPedidosIniciales.BeginInvoke((MethodInvoker)delegate ()
                {
                    dataGridViewPedidosIniciales.Rows.Clear();

                    for (int i = 0; i < Negocio.ListaPedidosXML.Count; i++)
                    {
                        this.dataGridViewPedidosIniciales.Rows.Add(Negocio.ListaPedidosXML[i].Nombre, Negocio.ListaPedidosXML[i].Precio, Negocio.ListaPedidosXML[i].Cantidad, Negocio.ListaPedidosXML[i].IdProducto, Negocio.ListaPedidosXML[i].Marca, Negocio.ListaPedidosXML[i].IdCliente, Negocio.ListaPedidosXML[i].IdEmpleado, Negocio.ListaPedidosXML[i].IdVenta, Negocio.ListaPedidosXML[i].Estado, Negocio.ListaPedidosXML[i].Delivery);
                    }
                });
            }

            else
            {
                dataGridViewPedidosIniciales.Rows.Clear();

                for (int i = 0; i < Negocio.ListaPedidosXML.Count; i++)
                {
                    this.dataGridViewPedidosIniciales.Rows.Add(Negocio.ListaPedidosXML[i].Nombre, Negocio.ListaPedidosXML[i].Precio, Negocio.ListaPedidosXML[i].Cantidad, Negocio.ListaPedidosXML[i].IdProducto, Negocio.ListaPedidosXML[i].Marca, Negocio.ListaPedidosXML[i].IdCliente, Negocio.ListaPedidosXML[i].IdEmpleado, Negocio.ListaPedidosXML[i].IdVenta, Negocio.ListaPedidosXML[i].Estado, Negocio.ListaPedidosXML[i].Delivery);
                }
            }
    }
        public void CargarPedidos()
        {
            CargarPedidosIniciales();

            if (Negocio.ListaPedidosXML.Count != 0)
            {
                for (int i = Negocio.ListaPedidosXML.Count - 1; i >= 0; i--)
                {

                    Negocio.ListaPedidosXML[i].Estado = "En Preparación";
                    pedidoNegocio.ModificarPedido(Negocio.ListaPedidosXML[i]);

                    Thread.Sleep(3000);

                    if ("xml" - Negocio.ListaPedidosXML[i])
                    {
                        CargarPedidosIniciales();
                    }

                }
            }

            else
            {
                Negocio.ListaPedidosXML[0].Estado = "En Preparación";
                pedidoNegocio.ModificarPedido(Negocio.ListaPedidosXML[0]);

                Thread.Sleep(3000);

                if ("xml" - Negocio.ListaPedidosXML[0])
                {
                    CargarPedidosIniciales();
                }
            }

            CargarPedidosIniciales();
        }

        public void PreparacionDelPedido()
        {
            Thread.Sleep(250);

            if (Negocio.ListaPedidosXML.Count != 0)
            {
               for (int i = Negocio.ListaPedidosXML.Count - 1; i >= 0; i--)
               {
                    if ("preparacion" + Negocio.ListaPedidosXML[i])
                    {
                        CargarGrillaPedidos();
                    }

                    Thread.Sleep(1150);

                    Thread.Sleep(1500);

               }


            }
        }
        public void CargarGrillaPedidos()
        {
            int indice = Negocio.ListaPedidosEnPreparacion.Count - 1;

            if (Negocio.ListaPedidosXML.Count != 0)
            {
                if (this.dataGridViewVentas.InvokeRequired)
                {
                    this.dataGridViewVentas.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.dataGridViewVentas.Rows.Add(Negocio.ListaPedidosEnPreparacion[indice].Nombre, Negocio.ListaPedidosEnPreparacion[indice].Precio, Negocio.ListaPedidosEnPreparacion[indice].Cantidad, Negocio.ListaPedidosEnPreparacion[indice].IdProducto, Negocio.ListaPedidosEnPreparacion[indice].Marca, Negocio.ListaPedidosEnPreparacion[indice].IdCliente, Negocio.ListaPedidosEnPreparacion[indice].IdEmpleado, Negocio.ListaPedidosEnPreparacion[indice].IdVenta, Negocio.ListaPedidosEnPreparacion[indice].Estado, Negocio.ListaPedidosEnPreparacion[indice].Delivery);
                    });
                }

                else
                {
                    if (this.dataGridViewVentas.InvokeRequired)
                    {
                        this.dataGridViewVentas.BeginInvoke((MethodInvoker)delegate ()
                        {
                            this.dataGridViewVentas.Rows.Add(Negocio.ListaPedidosEnPreparacion[0].Nombre, Negocio.ListaPedidosEnPreparacion[0].Precio, Negocio.ListaPedidosEnPreparacion[0].Cantidad, Negocio.ListaPedidosEnPreparacion[0].IdProducto, Negocio.ListaPedidosEnPreparacion[0].Marca, Negocio.ListaPedidosEnPreparacion[0].IdCliente, Negocio.ListaPedidosEnPreparacion[0].IdEmpleado, Negocio.ListaPedidosEnPreparacion[0].IdVenta, Negocio.ListaPedidosEnPreparacion[0].Estado, Negocio.ListaPedidosEnPreparacion[0].Delivery);
                        });
                    }
                    
                }

            }
            else
            {
                if (this.dataGridViewVentas.InvokeRequired)
                {
                    this.dataGridViewVentas.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.dataGridViewVentas.Rows.Add(Negocio.ListaPedidosEnPreparacion[0].Nombre, Negocio.ListaPedidosEnPreparacion[0].Precio, Negocio.ListaPedidosEnPreparacion[0].Cantidad, Negocio.ListaPedidosEnPreparacion[0].IdProducto, Negocio.ListaPedidosEnPreparacion[0].Marca, Negocio.ListaPedidosEnPreparacion[0].IdCliente, Negocio.ListaPedidosEnPreparacion[0].IdEmpleado, Negocio.ListaPedidosEnPreparacion[0].IdVenta, Negocio.ListaPedidosEnPreparacion[0].Estado, Negocio.ListaPedidosEnPreparacion[0].Delivery);
                    });
                }
            }

        }
    }
}
