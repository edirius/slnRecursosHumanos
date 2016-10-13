using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegociosTramite.Oficina
{
    public class cOficina
    {
        public int CodigoOficina { get; set; }

        public string NombreOficina{ get; set;}

        public string Dependencia { get; set; }

        public string DescripcionOficina { get; set; }

        
        public DataTable AgregarOficina()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteInsertarOficina", Dependencia, NombreOficina, DescripcionOficina);
        }
        public DataTable ModificarOficina()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteModificarOficina", CodigoOficina, Dependencia, NombreOficina, DescripcionOficina);
        }
        public DataTable EliminarOficina()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteEliminarOficina", CodigoOficina, NombreOficina);
        }
        public DataTable ListarOficina()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarOficina");
        }
        
    }
}
