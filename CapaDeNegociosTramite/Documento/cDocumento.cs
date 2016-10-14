using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
using System.Collections.Generic;
using System;
namespace CapaDeNegociosTramite.Documento
{
    public class cDocumento
    {
        public int CodigoDocumento { get; set; }

        public string Expediente { get; set; }

        public DateTime FechaDocumento { get; set; }

        public int Folios { get; set; }

        public string Dependencia { get; set; }

        public string Asunto { get; set; }

        public string Presentado { get; set; }

        public string Firma { get; set; }

        public int CodigoCargo { get; set; }

        public int CodigoTipoDocumento { get; set; }
            

        public DataTable AgregarDocumento()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteInsertarDocumento", Expediente, FechaDocumento, Folios, Dependencia, Asunto, Presentado, Firma, CodigoCargo, CodigoTipoDocumento);
        }
        public DataTable ModificarDocumento()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteModificarDocumento", CodigoDocumento, Expediente, FechaDocumento, Folios, Dependencia, Asunto, Presentado, Firma, CodigoCargo, CodigoTipoDocumento);
        }
        public DataTable EliminarDocumento()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteEliminarDocumento", CodigoDocumento, Expediente);
        }
        public DataTable ListarDocumento()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarDocumento");
        }
    }
}
