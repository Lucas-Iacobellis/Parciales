using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones;
namespace Entidades
{
    public class Pedido : Producto
    {
        private int idCliente;
        private int idEmpleado;
        private int idVenta;
        private string estado;
        private string delivery;

        private static int indice;
        public int IdCliente
        {
            get { return this.idCliente; }

            set
            {
                this.idCliente = Validar.ValidarEntero(value);
            }
        }
        public int IdEmpleado
        {
            get { return this.idEmpleado; }

            set
            {
                this.idEmpleado = Validar.ValidarEntero(value);
            }
        }


        public int IdVenta
        {
            get { return this.idVenta; }

            set
            {
                this.idVenta = Validar.ValidarEntero(value);
            }
        }
        public string Estado
        {
            get { return this.estado; }

            set
            {
                this.estado = Validar.ValidarString(value);
            }
        }

        public string Delivery
        {
            get { return this.delivery; }

            set
            {
                this.delivery = Validar.ValidarString(value);
            }
        }
        public Pedido()
        {

        }
        public Pedido(string nombre, float precio, int cantidad, string idProducto, string marca, int idCliente, int idEmpleado, int idVenta, string estado, string delivery):base(nombre, precio, cantidad, idProducto, marca)
        {
            this.IdCliente = idCliente;
            this.IdEmpleado = idEmpleado;
            this.IdVenta = idVenta;
            this.Estado = estado;
            this.Delivery = delivery;
        }

        public static bool operator +(string tipo, Pedido pedido)
        {
            bool retorno = false;
            switch (tipo)
            {
                case "xml":

                    if (Negocio.ListaPedidosXML.Count != 0)
                    {
                        for (int i = 0; i < Negocio.ListaPedidosXML.Count; i++)
                        {
                            if (Negocio.ListaPedidosXML != pedido)
                            {
                                Negocio.ListaPedidosXML.Add(pedido);
                                retorno = true;
                            }
                        }
                    }

                    else 
                    {
                        Negocio.ListaPedidosXML.Add(pedido);
                        retorno = true;
                    }
                    
                    break;

                case "pedidos":

                    if(Negocio.ListaPedidos.Count != 0) 
                    {
                        for (int i = 0; i < Negocio.ListaPedidos.Count; i++)
                        {
                            if (Negocio.ListaPedidos != pedido)
                            {
                                Negocio.ListaPedidos.Add(pedido);
                                retorno = true;
                            }
                        }
                    }

                    else
                    {
                        Negocio.ListaPedidos.Add(pedido);
                        retorno = true;
                    }

                    break;

                case "preparacion":

                    if (Negocio.ListaPedidosEnPreparacion.Count != 0)
                    {
                        for (int i = 0; i < Negocio.ListaPedidosEnPreparacion.Count; i++)
                        {
                            if (Negocio.ListaPedidosEnPreparacion != pedido)
                            {
                                Negocio.ListaPedidosEnPreparacion.Add(pedido);
                                retorno = true;
                            }
                        }
                    }

                    else
                    {
                        Negocio.ListaPedidosEnPreparacion.Add(pedido);
                        retorno = true;
                    }

                    break;

            default:
                    break;
            }

            return retorno;
        }
        public static bool operator -(string tipo, Pedido pedido)
        {
            bool retorno = false;
            switch (tipo)
            {
                case "xml":

                    if (Negocio.ListaPedidosXML.Count != 0) 
                    {
                        for (int i = 0; i < Negocio.ListaPedidosXML.Count; i++)
                        {
                            if (Negocio.ListaPedidosXML == pedido)
                            {
                                Negocio.ListaPedidosXML.RemoveAt(indice);
                                retorno = true;
                            }
                        }
                    }
                        
                    break;

                case "pedidos":

                    if (Negocio.ListaPedidos.Count != 0)
                    {
                        for (int i = 0; i < Negocio.ListaPedidos.Count; i++)
                        {
                            if (Negocio.ListaPedidos == pedido)
                            {
                                Negocio.ListaPedidos.RemoveAt(indice);
                                retorno = true;
                            }
                        }
                    }

                    break;

                case "preparacion":

                    if (Negocio.ListaPedidosEnPreparacion.Count != 0)
                    {
                        for (int i = 0; i < Negocio.ListaPedidosEnPreparacion.Count; i++)
                        {
                            if (Negocio.ListaPedidosEnPreparacion != pedido)
                            {
                                Negocio.ListaPedidosEnPreparacion.RemoveAt(indice);
                                retorno = true;
                            }
                        }
                    }

                    break;

             default:
                    break;
            }

            return retorno;
        }
        public static bool operator ==(List<Pedido> listaPedidos, Pedido pedido)
        {
            bool sonIguales = false;

            for (int i = 0; i < listaPedidos.Count; i++)
            {
                if (listaPedidos[i].IdProducto == pedido.IdProducto && listaPedidos[i].Marca == pedido.Marca && listaPedidos[i].IdCliente == pedido.IdCliente && listaPedidos[i].IdEmpleado == pedido.IdEmpleado && listaPedidos[i].IdVenta == pedido.IdVenta)
                {
                    indice = i;
                    sonIguales = true;
                    break;
                }
            }

            return sonIguales;
        }
        public static bool operator !=(List<Pedido> listaPedidos, Pedido pedido)
        {
            return !(listaPedidos == pedido);
        }
    }
}
