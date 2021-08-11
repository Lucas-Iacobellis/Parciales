using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using SerializacionXML;

namespace Entidades
{
    public static class Helper
    {
        /// <summary>
        /// Serializar el objeto y retorna la ruta
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string Serializar(List<Pelota> pelota)
        {
            //throw new NotImplementedException("Punto no realizado");

            string output = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ListaDePelotas.xml";
            XmlSerializer writer = new XmlSerializer(typeof(List<Pelota>));
            FileStream file = File.Create(output);
            writer.Serialize(file, pelota);
            file.Close();
            return output;

        }

        /// <summary>
        /// Deserializa el objeto que se encuentra en la ruta y lo retorna
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static List<Pelota> Deserializar(string ruta)
        {
            //throw new NotImplementedException("Punto no realizado");

            List<Pelota> output;
            XmlSerializer reader = new XmlSerializer(typeof(List<Pelota>));
            StreamReader file = new StreamReader(ruta);
            output = (List<Pelota>)reader.Deserialize(file);
            file.Close();
            return output;

        }

        public static List<Jugador> BuscarEnlog()
        {
            //throw new NotImplementedException("Punto no realizado");

            List<Jugador> output = new List<Jugador>();
            //ILog log = new LogDB();
            var log = new LogDB();
            string info = "";

            if (log.GetInfo(out info))
            {
                string[] lineas = info.Split('|');

                foreach (var linea in lineas)
                {
                    if (linea != "")
                    {
                        string nombre = linea.Split('\t')[1];

                        Jugador jugador = new Jugador
                        {
                            Nombre = nombre
                        };

                        int puntos = Convert.ToInt32(linea.Split('\t')[2]);
                        jugador.SumarPuntos(puntos);
                        output.Add(jugador);
                    }


                }
            }
            return output;
        }

        public static void GuardarEnLog(Jugador jugador)
        {
            //throw new NotImplementedException("Punto no realizado");

            //ILog log = new LogDB();

            var log = new LogDB();
            bool ok = log.Info(jugador.Nombre, jugador.Puntos);
            if (!ok)
            {
                throw new Exception("error al guardar en el  log de la db");
            }
        }
    }
}