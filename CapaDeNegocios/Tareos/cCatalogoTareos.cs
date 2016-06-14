using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Tareos
{
    public class cCatalogoTareos
    {
        public DataTable ListarTareos()
        {
            return  Conexion.GDatos.TraerDataTable("spListarTareos");
        }
        public Boolean InsertarTareo(cTareo miTareo)
        {
            Conexion.GDatos.Ejecutar("spInsertarTareo", miTareo.Meta.Codigo , miTareo.FechaInicio , miTareo.FechaFinal , miTareo.IngenieroResponsable.IdTrabajador , miTareo.TipoTareo );
            return true;
        }

        public Boolean ModificarTareo(cTareo miTareo)
        {
            Conexion.GDatos.Ejecutar("spModificarTareo", miTareo.Codigo, miTareo.Meta.Codigo, miTareo.FechaInicio, miTareo.FechaFinal, miTareo.IngenieroResponsable.IdTrabajador, miTareo.TipoTareo);
            return true;
        }

        public Boolean EliminarTareo(cTareo miTareo)
        {
            Conexion.GDatos.Ejecutar("EliminarTareo", miTareo.Codigo);
            return true;
        }
    }
}
