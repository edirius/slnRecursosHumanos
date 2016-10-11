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


        public int AgregarRequisito()
        {
            return Conexion.GDatos.Ejecutar("spTramiteInsertarRequisitosOficina", NombreRequisito, CodigoOficina);
        }
        public int ModificarRequisito()
        {
            return Conexion.GDatos.Ejecutar("spTramiteModificarRequisitosOficina", CodigoRequisitoOficina, NombreRequisito, CodigoOficina);
        }
        public int EliminarRequisito()
        {
            return Conexion.GDatos.Ejecutar("spTramiteEliminarRequisitosOficina", CodigoRequisitoOficina);
        }
        public DataTable ListarRequisito()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarRequisitos");
        }

    }
}
