using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios.Tareos
{
    public class cPlantillaTareo
    {
        int idPlantillaTareo;
        string descripcion;
        bool jornal;
        bool racionamiento;

        public int IdPlantillaTareo
        {
            get
            {
                return idPlantillaTareo;
            }

            set
            {
                idPlantillaTareo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public bool Jornal
        {
            get
            {
                return jornal;
            }

            set
            {
                jornal = value;
            }
        }

        public bool Racionamiento
        {
            get
            {
                return racionamiento;
            }

            set
            {
                racionamiento = value;
            }
        }

        public DataTable ListarPlantillaTareos()
        {
            return Conexion.GDatos.TraerDataTable("spListarPlantillaTareo");
        }

        public Boolean CrearPlantillaTareo(cPlantillaTareo miPlantilla)
        {
            Conexion.GDatos.Ejecutar("spCrearPlantillaTareo", miPlantilla.Descripcion, miPlantilla.Jornal, miPlantilla.Racionamiento);
            return true;
        }

        public Boolean ModificarPlantillaTareo(cPlantillaTareo miPlantilla)
        {
            Conexion.GDatos.Ejecutar("spModificarPlantillaTareo", miPlantilla.IdPlantillaTareo, miPlantilla.descripcion, miPlantilla.Jornal, miPlantilla.Racionamiento);
            return true;
        }

        public Boolean EliminarPlantillaTareo(int id)
        {
            Conexion.GDatos.Ejecutar("spEliminarPlantillaTareo", id);
            return true;
        }

        public cPlantillaTareo TraerPlantillaTareo(int id)
        {
            DataTable Plantilla = Conexion.GDatos.TraerDataTable("spTraerPlantillaTareo", id);
            if (Plantilla.Rows.Count > 0)
            {
                cPlantillaTareo NuevaPlantilla= new cPlantillaTareo();
                NuevaPlantilla.IdPlantillaTareo = Convert.ToInt16(Plantilla.Rows[0][0].ToString());
                NuevaPlantilla.Descripcion = Plantilla.Rows[0][1].ToString();
                NuevaPlantilla.Jornal = Convert.ToBoolean(Plantilla.Rows[0][2]);
                if (Plantilla.Rows[0][3] is DBNull)
                {
                    NuevaPlantilla.Racionamiento = false;
                }
                else
                {
                    NuevaPlantilla.Racionamiento = Convert.ToBoolean(Plantilla.Rows[0][3]);
                    
                }
                return NuevaPlantilla; 
            }
            else
            {
                return null;
            }
        }

        public cPlantillaTareo TraerPlantillaTareoXNombre(string pdescripcion)
        {
            DataTable Plantilla = Conexion.GDatos.TraerDataTable("spBuscarPlantillaTareoXNombre", pdescripcion);
            if (Plantilla.Rows.Count > 0)
            {
                cPlantillaTareo NuevaPlantilla = new cPlantillaTareo();
                NuevaPlantilla.IdPlantillaTareo = Convert.ToInt16(Plantilla.Rows[0][0].ToString());
                NuevaPlantilla.Descripcion = Plantilla.Rows[0][1].ToString();
                NuevaPlantilla.Jornal = Convert.ToBoolean(Plantilla.Rows[0][2]);
                if (Plantilla.Rows[0][3] is DBNull)
                {
                    NuevaPlantilla.Racionamiento = false;
                }
                else
                {
                    NuevaPlantilla.Racionamiento = Convert.ToBoolean(Plantilla.Rows[0][3]);

                }
                return NuevaPlantilla;
            }
            else
            {
                return null;
            }
        }
    }
}
