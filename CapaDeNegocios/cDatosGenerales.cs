using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios
{
    public class cDatosGenerales
    {
        string nombre;
        string ruc;
        string lugar;
        string nombreOficina;
        Boolean tecnicos276;
        string bearer;

        public cDatosGenerales()
        {
            try
            {
                DataTable auxiliar = Conexion.GDatos.TraerDataTable("spTraerDatosGenerales");
                foreach (DataRow item in auxiliar.Rows)
                {
                    this.nombre = item[1].ToString();
                    this.ruc = item[2].ToString();
                    this.lugar = item[3].ToString();
                    this.nombreOficina = item[4].ToString();
                    this.tecnicos276 = Convert.ToBoolean(item[6]);
                    this.bearer = item[7].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al trae datos generales:  Error en la conexion: " + ex.Message);
            }
            
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Ruc
        {
            get
            {
                return ruc;
            }

            set
            {
                ruc = value;
            }
        }

        public string Lugar
        {
            get
            {
                return lugar;
            }

            set
            {
                lugar = value;
            }
        }

        public string NombreOficina
        {
            get
            {
                return nombreOficina;
            }

            set
            {
                nombreOficina = value;
            }
        }

        public bool Tecnicos276
        {
            get
            {
                return tecnicos276;
            }

            set
            {
                tecnicos276 = value;
            }
        }

        public string Bearer
        {
            get
            {
                return bearer;
            }

            set
            {
                bearer = value;
            }
        }
    }
}
