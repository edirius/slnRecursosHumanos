using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
namespace CapaDeNegociosTramite.Documento
{
    public class cTipoDocumento
    {
        public int CodigoTipoDocumento { get; set; }

        public string Descripcion { get; set; }

        public DataTable AgregarTipoDocumento()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteInsertarTipoDocumento", Descripcion);
        }
        public DataTable ModificarTipoDocumento()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteModificarTipoDocumento", CodigoTipoDocumento, Descripcion);
        }
        public DataTable EliminarTipoDocumento()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteEliminarTipoDocumento", CodigoTipoDocumento, Descripcion);
        }
        public DataTable ListarTipoDocumento()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarTipoDocumento");
        }

    }
}
