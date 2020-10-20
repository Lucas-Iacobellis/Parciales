using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente:Persona
    {
        private int cantidadDeCompras;
        private int idCliente;
        public int CantidadDeCompras
        {
            get { return this.cantidadDeCompras; }
            set { this.cantidadDeCompras = value; }
        }
        public int IdCliente 
        {
            get { return this.idCliente; }
            set { this.idCliente = value; } 
        }
        public Cliente()
        {

        }
        public Cliente(string nombre, string apellido, int edad, int dni) : base(nombre,apellido,edad,dni)
        {

        }
        public Cliente(string nombre, string apellido, int edad, int dni, int cantidadDeCompras, int idCliente):this(nombre,apellido,edad,dni)
        {
            this.CantidadDeCompras = cantidadDeCompras;
            this.IdCliente = idCliente;
        }
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Compras realizadas: " + this.CantidadDeCompras);

            return sb.ToString();
        }
        public static bool operator +(List<Cliente> listaClientes, Cliente cliente)
        {
            bool retorno = false;

            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes != cliente)
                {
                    listaClientes.Add(cliente);
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator -(List<Cliente> listaClientes, Cliente cliente)
        {
            bool retorno = false;

            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes == cliente)
                {
                    listaClientes.RemoveAt(i);
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator ==(List<Cliente> listaClientes, Cliente cliente)
        {
            bool sonIguales = false;

            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes[i].Dni == cliente.Dni || listaClientes[i].IdCliente == cliente.IdCliente)
                {
                    sonIguales = true;
                    break;
                }
            }

            return sonIguales;
        }
        public static bool operator !=(List<Cliente> listaClientes, Cliente cliente)
        {

            return !(listaClientes == cliente);
        }
    }
}
