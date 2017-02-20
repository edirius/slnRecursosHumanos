using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.ResidenteMeta
{
    public class cBuscarTrabajador
    {
        public DataTable BuscarTrabajadores(string ptrabajador, string pcargo)
        {
            return Conexion.GDatos.TraerDataTable("spBuscarTrabajador", ptrabajador + '%', pcargo + '%');
        }
    }
}
