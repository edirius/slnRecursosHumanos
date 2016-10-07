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

        
        public int AgregarOficina()
        {
            return Conexion.GDatos.Ejecutar("spTramiteInsertarOficina", Dependencia, NombreOficina, DescripcionOficina);
        }
        public int ModificarOficina()
        {
            return Conexion.GDatos.Ejecutar("spTramiteModificarOficina", CodigoOficina, Dependencia, NombreOficina, DescripcionOficina);
        }
        public int EliminarOficina()
        {
            return Conexion.GDatos.Ejecutar("spTramiteEliminarOficina", CodigoOficina);
        }
        public DataTable ListarOficina()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarOficina");
        }
        
    }
}
