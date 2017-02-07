using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Planillas
{
    public class cIngresos5taCategoria
    {
        public DataTable Ingresos5taCategoria(int sidtplanilla, string smes, string saño, int sidttrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spIngresos5taCategoria", sidtplanilla, smes, saño, sidttrabajador);
        }

        public DataTable Ingresos5taMensual(string smes, string saño, int sidttrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spIngresos5taMensual", smes, saño, sidttrabajador);
        }
    }
}
