using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Negocio
    {
        private static List<Cliente> listaClientes;
        private static List<Empleado> listaEmpleados;
        private static List<Producto> listaProductos;
        private static List<Producto> listaCompras;
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
        public static List<Producto> ListaCompras 
        {
            get { return Negocio.listaCompras; }
            set { Negocio.listaCompras = value; }
        }

        static Negocio()
        {
            Negocio.ListaClientes = new List<Cliente>();
            Negocio.ListaEmpleados = new List<Empleado>();
            Negocio.ListaProductos = new List<Producto>();
            Negocio.ListaCompras = new List<Producto>();
        }
        public static void HarcodearClientes()
        {
            if(Negocio.ListaClientes.Count == 0) 
            {
                ListaClientes.Add(new Cliente("Marge", "Simpson", 34, 34790321, 0, 2));
                ListaClientes.Add(new Cliente("Nerd", "Flanders", 40, 30587349, 0, 3));
            }    
        }
        public static void HarcodearEmpleados()
        {
            if(Negocio.ListaEmpleados.Count == 0) 
            {
                ListaEmpleados.Add(new Empleado("Sanjay ", "Nahasapeemapetilon", 35, 33432978, 0, 1));
                ListaEmpleados.Add(new Empleado("Homero", "Simpson", 34, 34789312, 0, 2));
            }
        }
        public static void HarcodearProductos()
        {
            if(Negocio.ListaProductos.Count == 0) 
            {
                listaProductos.Add(new Producto("Cerveza", 100, 102, "1", "Duff"));
                listaProductos.Add(new Producto("Hamburguesas", 120, 122, "2", "Krusty"));
                listaProductos.Add(new Producto("Cereales", 55, 57, "3", "Krusty"));
                listaProductos.Add(new Producto("Buzz", 24, 26, "4", "Cola"));
                listaProductos.Add(new Producto("Squishee", 42, 46, "5", "7-Eleven's Slurpee"));
                listaProductos.Add(new Producto("Radioctive Man Comics", 11, 13, "6", "Bongo"));
                listaProductos.Add(new Producto("Rosquillas", 26, 28, "7", "Springfield"));
                listaProductos.Add(new Producto("Perritos calientes", 28, 30, "8", "Springfield"));
                listaProductos.Add(new Producto("Armas", 14, 16, "9", "Springfield"));
                listaProductos.Add(new Producto("Refrezco", 2, 4, "10", "Fresisuis)"));

                listaProductos.Add(new Producto("Purpurina", 3, 5, "11", "Springfield"));
                listaProductos.Add(new Producto("Papel maché", 7, 9, "12", "Springfield"));
                listaProductos.Add(new Producto("Flores", 14, 16, "13", "Springfield"));
                listaProductos.Add(new Producto("Boletos de lotería", 60, 62, "14", "Springfield"));
                listaProductos.Add(new Producto("Patatas fritas que provocan diarrea", 44, 46, "15", "Springfield"));
                listaProductos.Add(new Producto("Pasteles lunares ", 27, 29, "16", "Springfield"));
                listaProductos.Add(new Producto("Tarjetas para San Valentín", 6, 8, "17", "Springfield"));
                listaProductos.Add(new Producto("Fruta", 8, 10, "18", "Springfield"));
                listaProductos.Add(new Producto("Leche de 1961", 37, 39, "19", "Springfield"));
                listaProductos.Add(new Producto("Jamón rancio", 21, 23, "20", "Springfield"));

                listaProductos.Add(new Producto("Chupelupes", 9, 11, "21", "Springfield"));
                listaProductos.Add(new Producto("Horóscopos", 2, 4, "22", "Springfield"));
                listaProductos.Add(new Producto("Libros educativos", 4, 6, "23", "Springfield"));
                listaProductos.Add(new Producto("Revistas porno", 15, 17, "24", "Springfield"));
                listaProductos.Add(new Producto("Pan de astronauta", 48, 50, "25", "Krusty"));
                listaProductos.Add(new Producto("Teléfonos móviles llenos de caramelos", 11, 13, "26", "Springfield"));
                listaProductos.Add(new Producto("Petardos ilegales", 53, 55, "27", "Krusty"));
                listaProductos.Add(new Producto("Cigarrilos", 10, 12, "28", "Laramie"));
                listaProductos.Add(new Producto("Carne", 6, 8, "29", "Krusty"));
                listaProductos.Add(new Producto("Pescado", 2, 4, "30", "Springfield"));
            }
        }
        public static int BajoStock()
        {
            int contador = 0;

            foreach (var item in Negocio.ListaProductos)
            {
                if (item.Cantidad < 10) 
                {
                    contador++;
                }
            }

            return contador;
        }
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
