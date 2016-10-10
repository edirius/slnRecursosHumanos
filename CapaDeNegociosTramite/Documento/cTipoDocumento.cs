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

        public int AgregarTipoDocumento()
        {
            return Conexion.GDatos.Ejecutar("spTramiteInsertarTipoDocumento", Descripcion);
        }
        public int ModificarTipoDocumento()
        {
            return Conexion.GDatos.Ejecutar("spTramiteModificarTipoDocumento", CodigoTipoDocumento, Descripcion);
        }
        public int EliminarTipoDocumento()
        {
            return Conexion.GDatos.Ejecutar("spTramiteEliminarTipoDocumento", CodigoTipoDocumento);
        }
        public DataTable ListarTipoDocumento()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarTipoDocumento");
        }
    }
}
