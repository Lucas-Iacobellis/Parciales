using System.Collections.Generic;

namespace Entidades
{
    public static class Negocio
    {
        private static List<Cliente> listaClientes;
        private static List<Empleado> listaEmpleados;
        private static List<Producto> listaProductos;
        private static List<Producto> listaVentas;
        private static List<Pedido> listaPedidos;
        private static List<Pedido> listaPedidosXML;
        private static List<Pedido> listaPedidosEnPreparacion;

        private static bool todoBorradoClientes;
        private static bool todoBorradoEmpleados;
        private static bool todoBorradoProductos;
        public static List<Cliente> ListaClientes 
        {
            get { return Negocio.listaClientes; }
            set { Negocio.listaClientes = value; }
        }
        public static List<Empleado> ListaEmpleados 
        {
            get { return Negocio.listaEmpleados; }
            set { Negocio.listaEmpleados = value; }
        }
        public static List<Producto> ListaProductos 
        {
            get { return Negocio.listaProductos; }
            set { Negocio.listaProductos = value; }
        }
        public static List<Producto> ListaVentas
        {
            get { return Negocio.listaVentas; }
            set { Negocio.listaVentas = value; }
        }
        public static List<Pedido> ListaPedidos
        {
            get { return Negocio.listaPedidos; }
            set { Negocio.listaPedidos = value; }
        }
        public static List<Pedido> ListaPedidosXML
        {
            get { return Negocio.listaPedidosXML; }
            set { Negocio.listaPedidosXML = value; }
        }
        public static List<Pedido> ListaPedidosEnPreparacion
        {
            get { return Negocio.listaPedidosEnPreparacion; }
            set { Negocio.listaPedidosEnPreparacion = value; }
        }

        public static bool TodoBorradoClientes 
        {
            get { return Negocio.todoBorradoClientes; }
            set { Negocio.todoBorradoClientes = value; } 
        }

        public static bool TodoBorradoEmpleados
        {
            get { return Negocio.todoBorradoEmpleados; }
            set { Negocio.todoBorradoEmpleados = value; }
        }
        public static bool TodoBorradoProductos
        {
            get { return Negocio.todoBorradoProductos; }
            set { Negocio.todoBorradoProductos = value; }
        }

        static Negocio()
        {
            Negocio.ListaClientes = new List<Cliente>();
            Negocio.ListaEmpleados = new List<Empleado>();
            Negocio.ListaProductos = new List<Producto>();
            Negocio.ListaVentas = new List<Producto>();
            Negocio.listaPedidos = new List<Pedido>();
            Negocio.listaPedidosXML = new List<Pedido>();
            Negocio.listaPedidosEnPreparacion = new List<Pedido>();
        }

        //public static void HarcodearClientes()
        //{
        //    if(Negocio.ListaClientes.Count == 0 && Negocio.TodoBorradoClientes == false) 
        //    {
        //        ListaClientes.Add(new Cliente("Pedro", "Perez", 35, 30932457, 1));
        //        ListaClientes.Add(new Cliente("Javier", "Gimenez", 40, 26341289, 2));
        //    }    
        //}

        //public static void HarcodearEmpleados()
        //{
        //    if(Negocio.ListaEmpleados.Count == 0 && Negocio.todoBorradoEmpleados == false) 
        //    {
        //        ListaEmpleados.Add(new Empleado("Gaston", "Gonzalez", 40, 26472190, 1));
        //        ListaEmpleados.Add(new Empleado("Mauro", "Martinez", 35, 30752314, 2));
        //    }
        //}

        //public static void HarcodearProductos()
        //{
        //    if(Negocio.ListaProductos.Count == 0 && Negocio.todoBorradoProductos == false) 
        //    {
        //        listaProductos.Add(new Producto("Cerveza", 150, 10, "1", "Lucky Strike"));
        //        listaProductos.Add(new Producto("Gaseosa", 100, 20, "2", "Coca Cola"));
        //    }
        //}
        public static int TotalStock() 
        {
            int acumulador = 0;

            foreach (var item in Negocio.ListaProductos)
            {
                acumulador = acumulador + item.Cantidad;
            }

            return acumulador;
        }

    }
}
