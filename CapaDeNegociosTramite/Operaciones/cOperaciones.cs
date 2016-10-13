using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
namespace CapaDeNegociosTramite.Operaciones
    {
        public class cOperaciones
        {
            public int CodigoOperacion { get; set; }

            public string Descripcion { get; set; }

            public DataTable AgregarOperacion()
            {
                return Conexion.GDatos.TraerDataTable("spTramiteInsertarOperacion", Descripcion);
            }
            public DataTable ModificarOperacion()
            {
                return Conexion.GDatos.TraerDataTable("spTramiteModificarOperacion", CodigoOperacion, Descripcion);
            }
            public DataTable EliminarOperacion()
            {
                return Conexion.GDatos.TraerDataTable("spTramiteEliminarOperacion", CodigoOperacion, Descripcion);
            }
            public DataTable ListarOperacion()
            {
                return Conexion.GDatos.TraerDataTable("spTramiteListarOperacion");
            }

        }
    }



