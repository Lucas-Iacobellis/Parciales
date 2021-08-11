using System;
using System.IO;
using System.Text;
using Interfaces;

namespace Serializacion
{
    public class Log:ILog 
    {
        public bool Info(string datos) 
        {
            bool variable = false;

            try
            {
                if (Directory.Exists(RutaDeArchivos.PATHLOG))
                {
                    using (StreamWriter file = new StreamWriter(RutaDeArchivos.PATHLOG + "log.txt", true, Encoding.UTF8))
                    {
                        file.WriteLine(datos);
                    }

                    variable = true;
                }

                else 
                {
                    Directory.CreateDirectory(RutaDeArchivos.PATHLOG);

                    using (StreamWriter file = new StreamWriter(RutaDeArchivos.PATHLOG + "log.txt", true, Encoding.UTF8))
                    {
                        file.WriteLine(datos);
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return variable;
        }
        public bool GetInfo(out string datos)
        {
            try
            {
                using (StreamReader file = new StreamReader(RutaDeArchivos.PATHLOG + "log.txt"))
                {
                    datos = file.ReadToEnd();
                }

                return true;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
        }
    }
}

