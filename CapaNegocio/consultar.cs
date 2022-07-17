using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class consultar
    {
        public static string insertar(string tabla, dynamic[] datos)
        {
            string info=conexionBD.insertarDatos(tabla, datos);
            return info;
        }
    }
}
