using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface InterfaceArchivos<T>
    {
         bool Guardar(string path, string archivo, T datos);
         bool Leer(string archivo, out T datos);
    }
}

