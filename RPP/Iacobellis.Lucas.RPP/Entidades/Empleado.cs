using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado:Persona
    {
        private int cantidadDeVentas;
        private int idEmpleado;
        public int CantidadDeVentas 
        {
            get { return this.cantidadDeVentas; }
            set { this.cantidadDeVentas = value; } 
        }
        public int IdEmpleado 
        {
            get { return this.idEmpleado; }
            set { this.idEmpleado = value; } 
        }
        public Empleado()
        {

        }
        public Empleado(string nombre, string apellido, int edad, int dni) :base(nombre,apellido,edad,dni)
        {

        }
        public Empleado(string nombre, string apellido, int edad, int dni, int cantidadDeVentas, int idEmpleado):this(nombre,apellido,edad,dni)
        {
            this.CantidadDeVentas = cantidadDeVentas;
            this.idEmpleado = idEmpleado;
        }
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Ventas realizadas: " + this.CantidadDeVentas);
            sb.AppendLine("ID Empleado: " + this.IdEmpleado);
            
            return sb.ToString();
        }
        public static bool operator +(List<Empleado> listaEmpleados, Empleado empleado)
        {
            bool retorno = false;

            for (int i = 0; i < listaEmpleados.Count; i++)
            {
                if (listaEmpleados != empleado)
                {
                    listaEmpleados.Add(empleado);
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator -(List<Empleado> listaEmpleados, Empleado empleado)
        {
            bool retorno = false;

            for (int i = 0; i < listaEmpleados.Count; i++)
            {
                if (listaEmpleados == empleado)
                {
                    listaEmpleados.RemoveAt(i);
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator ==(List<Empleado> listaEmpleados, Empleado empleado)
        {
            bool sonIguales = false;

            for (int i = 0; i < listaEmpleados.Count; i++)
            {
                if (listaEmpleados[i].Dni == empleado.Dni || listaEmpleados[i].IdEmpleado == empleado.IdEmpleado)
                {
                    sonIguales = true;
                    break;
                }
            }

            return sonIguales;
        }
        public static bool operator !=(List<Empleado> listaEmpleados, Empleado empleado)
        {

            return !(listaEmpleados == empleado);
        }
    }
}
