using System;
using System.Collections.Generic;
using Entidades.Excepciones;
using Entidades.Serializacion;

namespace Entidades
{
    public static class Helper
    {
        /// <summary>
        /// Serializar el objeto y retorna la ruta
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string Serializar(List<Pelota> pelotas)
        {
            string ruta = RutaDeArchivos.PATHLOG;

            try
            {
                Log<List<Pelota>> logXMLPelotas = new Log<List<Pelota>>();
                bool variable = logXMLPelotas.Guardar(ruta, "ListaDePelotas.txt", pelotas);
                if (variable == true)
                {
                    return pelotas.ToString();
                }
            }
            catch (Exception)
            {

                throw new ArchivosException("No se pudo serializar la lista de pelotas");
            }

            return ruta;
        }

        /// <summary>
        /// Deserializa el objeto que se encuentra en la ruta y lo retorna
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static List<Pelota> Deserializar(string ruta)
        {
            Log<List<Pelota>> logXMLPelotas = new Log<List<Pelota>>();
            List<Pelota> pelotas = new List<Pelota>();
            logXMLPelotas.Leer(ruta + "ListaDePelotas.txt", out pelotas);
            return pelotas;
        }

        public static List<Jugador> BuscarEnlog()
        {
            LogDB logDB = new LogDB();
            List<Jugador> jugadores = new List<Jugador>();
            string listaDeJugadores = jugadores.ToString();
            
            if(logDB.GetInfo(out listaDeJugadores)) 
            {
                return jugadores;
            }

            return jugadores;
        }

        public static void GuardarEnLog(Jugador jugador)
        {
            LogDB logDB = new LogDB();
            logDB.Info(jugador.Nombre, jugador.Puntos);
        }
        public static T GetValue<T>(String value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        public static List<Pelota> GetValue<T>(T value)
        {
            return (List<Pelota>)Convert.ChangeType(value, typeof(List<Pelota>));
        }
    }
}