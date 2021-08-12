using System;
using System.IO;
using System.Xml.Serialization;
using Entidades.Excepciones;
using Entidades.Interfaces;

namespace Entidades.Serializacion
{
    public class LogXML<T> : IArchivo<T>
    {
        Log<T> logFile;
        public LogXML()
        {
            logFile = new Log<T>();
        }
        public bool Guardar(string path, string archivo, T datos)
        {
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(T));

                if (Directory.Exists(path))
                {
                    using (StreamWriter writer = new StreamWriter(path + archivo))
                    {
                        s.Serialize(writer, datos);
                    }
                }

                else
                {
                    Directory.CreateDirectory(path);

                    using (StreamWriter writer = new StreamWriter(path + archivo))
                    {
                        s.Serialize(writer, datos);
                    }

                    throw new ArchivosException("Ruta del archivo inexistente. Se creo la ruta: " + path + archivo);
                }

                return true;
            }

            catch (ArchivosException ex)
            {
                logFile.Guardar(path,archivo,Helper.GetValue<T>(ex.Message));
                return false;
            }
        }
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer deserializar = new XmlSerializer(typeof(T));

                using (StreamReader reader = new StreamReader(archivo))
                {
                    datos = (T)deserializar.Deserialize(reader);
                    DevolucionDeDatos(datos);
                }

                return true;
            }

            catch (ArchivosException ex)
            {
                throw new ArchivosException(ex.Message, ex);
            }

            catch (Exception ex)
            {
                datos = default(T);
                logFile.Guardar(RutaDeArchivos.PATHLOG, archivo, Helper.GetValue<T>(ex.Message));
                return false;
            }


        }
        public T DevolucionDeDatos(T datos)
        {
            return datos;
        }
    }
}
