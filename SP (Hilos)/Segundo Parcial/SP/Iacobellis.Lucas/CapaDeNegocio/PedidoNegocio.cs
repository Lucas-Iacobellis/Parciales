using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDeDatos;

namespace CapaDeNegocio
{
    public class PedidoNegocio
    {
        public bool estadoHilos = true;

        public bool EstadoHilos 
        {
            get { return this.estadoHilos; }
            set { this.estadoHilos = value; }
        }

        public void CargarPedidos()
        {
            ManajedorSQL.CargarListaPedidos();
        }
        public bool InsertarPedido(Pedido pedido)
        {
            return ManajedorSQL.InsertPedido(pedido);
        }
        public bool EliminarPedido(Pedido pedido)
        {
            return ManajedorSQL.DeletePedido(pedido);
        }
        public bool ModificarPedido(Pedido pedido)
        {
            return ManajedorSQL.UpdatePedidos(pedido);
        }
    }
}
