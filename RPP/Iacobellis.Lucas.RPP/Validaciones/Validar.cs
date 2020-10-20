using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.WindowsRuntime;
using Exepciones;
using System.Net.Http.Headers;

namespace Validaciones
{
    public static class Validar
    {
        public static string ValidarUsuario(string usuario)
        {
            string cadena = usuario.Replace(" ", "");

            if (string.IsNullOrEmpty(usuario))
            {
                return "Vacio";
            }

            if (usuario != cadena) 
            {
                return "Espacios";
            }

            else
            {
                return "Correcto";
            }

        }
        public static string ValidarNumeroDeEntrada(string cadena) 
        {
            string cadenaSoloNumeros = "";
            string patron = @"(?:- *)?\d+(?:\.\d+)?";
            Regex regex = new Regex(patron);

            foreach (Match m in regex.Matches(cadena))
            {
                cadenaSoloNumeros += m.Value;
            }

            if (Validar.ValidarString(cadena) == "") 
            {
                return "Numero erroneo";
            }

            if (string.IsNullOrEmpty(cadena))
            {
                return "Vacia";
            }

            if (cadena != cadenaSoloNumeros)
            {
                return "Incorrecta";
            }
           
            else
            {
                return "Correcta";
            }
        }
        public static string ValidarString(string dato)
        {
            try
            {
                if (!string.IsNullOrEmpty(dato))
                {
                    return dato;
                }
            }

            catch (StringInvalidoException)
            {
                throw new StringInvalidoException("String invalido, reingrese dato");
            }

            return "";
            
        }
        public static int ValidarEntero(int dato)
        {
            try
            {
                string datoString = dato.ToString();

                if (!string.IsNullOrEmpty(datoString) && int.TryParse(datoString, out dato))
                {
                    return dato;
                }

            }

            catch (EnteroInvalidoException)
            {
               throw new EnteroInvalidoException("Entero invalido, reingrese dato");
            }

            return 0;
        }

        public static float ValidarFloat(float dato)
        {
            try
            {
                string datoString = dato.ToString();

                if (!string.IsNullOrEmpty(datoString) && float.TryParse(datoString, out dato))
                {
                    return dato;
                }
            }

            catch (FloatInvalidoException)
            {
                throw new FloatInvalidoException("Float invalido, reingrese dato");
            }

            return 0;
        }
        public static int ValidarStringToInt(string dato)
        {
            try
            {
                int datoInt;

                if (!string.IsNullOrEmpty(dato) && int.TryParse(dato, out datoInt))
                {
                    return datoInt;
                }
            }

            catch (EnteroInvalidoException)
            {
                throw new EnteroInvalidoException("No se puede convertir String a Int");
            }

            return 0;
        }

        public static float ValidarStringToFloat(string dato)
        {
            try
            {
                float datoFloat;

                if (!string.IsNullOrEmpty(dato) && float.TryParse(dato, out datoFloat))
                {
                    return datoFloat;
                }
            }

            catch (FloatInvalidoException)
            {
                throw new FloatInvalidoException("No se puede convertir String a Float");
            }

            return 0;
           
        }
        public static int ValidarEdad(int edad) 
        {
            try
            {
                int validarEntero = Validar.ValidarEntero(edad);

                if (validarEntero > 0 && validarEntero < 100)
                {
                    return edad;
                }
            }

            catch (EnteroInvalidoException)
            {
                throw new EnteroInvalidoException("La edad ingresada no es valida");
            }

            return 0;

        }
    }
}
