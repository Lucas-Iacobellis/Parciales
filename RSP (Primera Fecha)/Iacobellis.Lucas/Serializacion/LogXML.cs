using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;
using Interfaces;

namespace Serializacion
{
    public class SerializacionXML<T> : IArchivo<T>
    {
        //Log logFile = new Log();
        Log logFile;
        public SerializacionXML()
        {
            logFile = new Log();
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
                logFile.Info(ex.ToString());
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
                logFile.Info(ex.ToString());
                return false;
            }


        }
        public T DevolucionDeDatos(T datos)
        {
            return datos;
        }
    }
}
