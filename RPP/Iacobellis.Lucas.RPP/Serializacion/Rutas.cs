using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializacion
{
    public static class Rutas
    {
        public static string PATHLOG = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Iacobellis.Lucas.PP\\Logs\\";
        public static string PATHCOMPRASTXT = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Iacobellis.Lucas.PP\\Compras\\";
        public static string PATHVENTASTXT = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Iacobellis.Lucas.PP\\Ventas\\";
    }
}