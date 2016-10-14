using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
namespace CapaDeNegociosTramite.Requisito_Oficina
{
    public class cRequisitoOficina
    {
        public int CodigoRequisitoOficina { get; set; }

        public string NombreRequisito { get; set; }

        public int CodigoOficina { get; set; }


        public DataTable AgregarRequisito()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteInsertarRequisitosOficina", NombreRequisito, CodigoOficina);
        }
        public DataTable ModificarRequisito()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteModificarRequisitosOficina", CodigoRequisitoOficina, NombreRequisito, CodigoOficina);
        }
        public DataTable EliminarRequisito()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteEliminarRequisitosOficina", CodigoRequisitoOficina, NombreRequisito);
        }
        public DataTable ListarRequisito()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarRequisitos");
        }

    }
}
