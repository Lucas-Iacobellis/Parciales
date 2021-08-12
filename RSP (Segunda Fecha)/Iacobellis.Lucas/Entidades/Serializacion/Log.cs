using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Entidades.Interfaces;
namespace Entidades.Serializacion
{
    public class Log<T>:IArchivo<T>
    {
        public bool Guardar(string path, string archivo, T datos)
        {
            bool variable = false;

            try
            {
                if (Directory.Exists(RutaDeArchivos.PATHLOG))
                {
                    using (StreamWriter file = new StreamWriter(RutaDeArchivos.PATHLOG + "ListaDePelotas.txt", true, Encoding.UTF8))
                    {
                        //file.WriteLine(datos);
                        List<Pelota> listaPelotas = Helper.GetValue(datos);
                        foreach (Pelota item in listaPelotas)
                        {
                            file.WriteLine("La posicion x de la pelota es: " + item.PosX + " y la posicion de la pelota es: " + item.PosY); ;
                        }
                    }

                    variable = true;
                }

                else
                {
                    Directory.CreateDirectory(RutaDeArchivos.PATHLOG);

                    using (StreamWriter file = new StreamWriter(RutaDeArchivos.PATHLOG + "ListaDePelotas.txt", true, Encoding.UTF8))
                    {
                        //file.WriteLine(datos);
                        List<Pelota> listaPelotas = Helper.GetValue(datos);
                        foreach (Pelota item in listaPelotas)
                        {
                            file.WriteLine("La posicion x de la pelota es: " + item.PosX + " y la posicion de la pelota es: " + item.PosY); ;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return variable;
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (StreamReader file = new StreamReader(RutaDeArchivos.PATHLOG + "log.txt"))
                {
                    datos = Helper.GetValue<T>(file.ReadToEnd());
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
