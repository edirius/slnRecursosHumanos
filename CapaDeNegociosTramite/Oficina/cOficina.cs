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

        public Boolean AgregarOficina(cOficina oficina)
        {
            DataTable Auxiliar = new DataTable();
            Auxiliar = Conexion.GDatos.TraerDataTable("spOficinaInsertar", oficina.NombreOficina, oficina.Dependencia, oficina.DescripcionOficina);
            if (Convert.ToString(Auxiliar.Rows[0][0]) == "0")
            {
                return true;
            }
            else
            {
                throw new cReglaNegociosException(Convert.ToString(Auxiliar.Rows[0][1]));
            }
        }

        public Boolean ModificarOficina(cOficina oficina)
        {
            Conexion.GDatos.Ejecutar("spOficinaModificar", oficina.NombreOficina, oficina.Dependencia, oficina.DescripcionOficina);
            return true;
        }
        public DataTable ListarOficina()
        {
            return Conexion.GDatos.TraerDataTable("spOficinaListar");
        }

        public Boolean EliminarOficina(cOficina oficina)
        {
            try
            {
                if (Conexion.GDatos.Ejecutar("spOficinaEliminar", oficina.CodigoOficina) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException("Error Eliminar Oficina. Detalles: " + e.Message, e);
            }

        }

    }
}
