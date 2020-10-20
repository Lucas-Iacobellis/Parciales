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
using Serializacion;

namespace Formularios
{
    public partial class FrmCompras : Form
    {
        public FrmCompras()
        {
            InitializeComponent();
          
            Negocio.ListaCompras = new List<Producto>();
        }
        public void GetDataSource()
        { 
            dataGridViewProductos.DataSource = null;
            dataGridViewProductos.DataSource = Negocio.ListaProductos;
            dataGridViewProductos.AutoResizeRows();
            dataGridViewProductos.Columns[0].ReadOnly = true;
            dataGridViewProductos.Columns[1].ReadOnly = true;
            dataGridViewProductos.Columns[2].ReadOnly = true;
            dataGridViewProductos.Columns[3].ReadOnly = true;
            dataGridViewProductos.Columns[4].ReadOnly = true;
        }
        private void dataGridViewProductos_MouseDown(object sender, MouseEventArgs e)
        {
            int row = dataGridViewProductos.HitTest(e.X, e.Y).RowIndex;
            dataGridViewProductos.DoDragDrop(row, DragDropEffects.Copy);
        }
        private void dataGridViewCompras_DragDrop(object sender, DragEventArgs e)
        {
            int indiceFila = Convert.ToInt32(e.Data.GetData(Type.GetType("System.Int32")));
            Point point = dataGridViewCompras.PointToClient(new Point(e.X, e.Y));
            DataGridViewRow dtRow = new DataGridViewRow();
            DataGridView.HitTestInfo dtRowHit = dataGridViewCompras.HitTest(point.X, point.Y);
            int rowDeDestino = dtRowHit.RowIndex;
            int columnaDestino = dtRowHit.ColumnIndex;


            if (dtRowHit.Type == DataGridViewHitTestType.Cell)
            {
                dtRow = dataGridViewProductos.Rows[indiceFila];
            }

            if (rowDeDestino != -1)
            {

                Producto producto = new Producto(dtRow.Cells[0].Value.ToString(), ((float)dtRow.Cells[1].Value), Convert.ToInt32(dtRow.Cells[2].Value), dtRow.Cells[3].Value.ToString(), dtRow.Cells[4].Value.ToString());
                Producto.ProductoRepetido(producto);

                CrearRowEnBlanco();

                dataGridViewCompras.Rows.Clear();

                foreach (Producto item in Negocio.ListaCompras)
                {
                    CrearRowEnBlanco();

                    dataGridViewCompras.Rows[0].Cells[0].Value = item.Nombre;
                    dataGridViewCompras.Rows[0].Cells[1].Value = item.Precio;
                    dataGridViewCompras.Rows[0].Cells[2].Value = item.Cantidad;
                    dataGridViewCompras.Rows[0].Cells[3].Value = item.IdProducto;
                    dataGridViewCompras.Rows[0].Cells[4].Value = item.Marca;
                }

                CrearRowEnBlanco();
            }

        }
        private void dataGridViewCompras_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            string comprador = "";
            string vendedor = "";

            for (int i = 0; i < dataGridViewCompras.Rows.Count; i++)
            {
                if (dataGridViewCompras.Rows[i].Cells[0].Value != null)
                {
                    comprador = "Compra realizada por: " + comboBoxNombreCliente.Text + "\r\n" + comboBoxApellidoCliente.Text + "\r\n";
                    vendedor = "Venta realizada por: " + txtEmpleado.Text + "\r\n";
                    mensaje += "Producto: " + dataGridViewCompras.Rows[i].Cells[0].Value.ToString() + "\r\n" + "Precio: $" + dataGridViewCompras.Rows[i].Cells[1].Value.ToString() + "\r\n" + "Cantidad: " + dataGridViewCompras.Rows[i].Cells[2].Value.ToString() + "\r\n";
                }
            }

            mensaje += "Cantidad total: " + Producto.CantidadTotalProductos() + "\r\n" + "Precio total: $" + Producto.SumaProductos(comboBoxApellidoCliente.Text);

            MessageBox.Show(mensaje);
            MessageBox.Show("Gracias!!! Vuelva prontosss");

            SerializacionTXT serializar = new SerializacionTXT();
            serializar.Guardar(Rutas.PATHCOMPRASTXT, "Compras.txt", comprador + mensaje);
            serializar.Guardar(Rutas.PATHVENTASTXT, "Ventas.txt", vendedor + mensaje);

            foreach (var item in Negocio.ListaClientes)
            {
                if (item.Nombre == comboBoxNombreCliente.Text)
                {
                    item.CantidadDeCompras = item.CantidadDeCompras + 1;
                }
            }

            foreach (var item in Negocio.ListaEmpleados)
            {
                if (item.Nombre == txtEmpleado.Text)
                {
                    item.CantidadDeVentas = item.CantidadDeVentas + 1;
                }
            }
        }
        public void CrearRowEnBlanco()
        {
            DataGridViewRow nuevaRow = new DataGridViewRow();
            dataGridViewCompras.Rows.Insert(0, nuevaRow);
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            this.Visible = false;
            frmClientes.Show();
        }

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

            bool variable = false;

            Negocio.HarcodearEmpleados();

            while (variable == false)
            {
                numeroRandom = random.Next(1, Negocio.ListaEmpleados.Count+1);

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
        private void FrmCompras_Load(object sender, EventArgs e)
        {
            Negocio.HarcodearClientes();
            Negocio.HarcodearEmpleados();
            Negocio.HarcodearProductos();
            GetDataSource();
            CargarComboCliente();
            CargarVendedor();
            dataGridViewCompras.AllowDrop = true;
            CrearRowEnBlanco();
        }
        private void FrmCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

    }
}
