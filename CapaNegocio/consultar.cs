using System;
using System.Collections.Generic;
using System.Data;
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

        public static DataTable consultaTodosElementos(string tabla, string[] datos, string where)
        {
            string columnas = "";
            for (int i = 0; i < datos.Length; i++)
            {
                columnas += "\"" + datos[i] + "\"";
                if (i != datos.Length - 1)
                {
                    columnas += ", ";
                }
            }
            string query = "Select " + columnas + " from \"" + tabla + "\" " + where;
            DataTable resultado = conexionBD.consultaUnDato(query);
            return resultado;

        }
    }
}
