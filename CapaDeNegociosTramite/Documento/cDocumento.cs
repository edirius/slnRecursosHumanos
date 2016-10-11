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

        public string De { get; set; }

        public string Firma { get; set; }

        public int CodigoCargo { get; set; }

        public int CodigoTipoDocumento { get; set; }
            

        public int AgregarDocumento()
        {
            return Conexion.GDatos.Ejecutar("spTramiteInsertarDocumento", Expediente, FechaDocumento, Folios, Dependencia, Asunto, De, Firma, CodigoCargo, CodigoTipoDocumento);
        }
        public int ModificarDocumento()
        {
            return Conexion.GDatos.Ejecutar("spTramiteModificarDocumento", CodigoDocumento, Expediente, FechaDocumento, Folios, Dependencia, Asunto, De, Firma, CodigoCargo, CodigoTipoDocumento);
        }
        public int EliminarDocumento()
        {
            return Conexion.GDatos.Ejecutar("spTramiteEliminarDocumento", CodigoDocumento);
        }
        public DataTable ListarDocumento()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarDocumento");
        }
    }
}
