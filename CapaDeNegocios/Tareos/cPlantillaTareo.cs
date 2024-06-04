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
        bool obrero;
        bool activo;

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

        public bool Obrero
        {
            get
            {
                return obrero;
            }

            set
            {
                obrero = value;
            }
        }

        public bool Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        public DataTable ListarPlantillaTareos(Boolean Todos, Boolean Activos)
        {
            try
            {
                return Conexion.GDatos.TraerDataTable("spListarPlantillaTareo2", Todos, Activos);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ListarPlantillaTareos: " + ex.Message);
            }
        }

        public Boolean CrearPlantillaTareo(cPlantillaTareo miPlantilla)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearPlantillaTareo2", miPlantilla.Descripcion, miPlantilla.Jornal, miPlantilla.Racionamiento, miPlantilla.Obrero, miPlantilla.Activo);
                return true;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo CrearPlantillaTareos: " + ex.Message);
            }
        }

        public Boolean ModificarPlantillaTareo(cPlantillaTareo miPlantilla)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarPlantillaTareo2", miPlantilla.IdPlantillaTareo, miPlantilla.descripcion, miPlantilla.Jornal, miPlantilla.Racionamiento, miPlantilla.Obrero, miPlantilla.Activo);
                return true;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ModificarPlantillaTareos: " + ex.Message);
            }
        }

        public Boolean EliminarPlantillaTareo(int id)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarPlantillaTareo", id);
                return true;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo EliminarPlantillaTareos: " + ex.Message);
            }
        }

        public cPlantillaTareo TraerPlantillaTareo(int id)
        {
            try
            {
                DataTable Plantilla = Conexion.GDatos.TraerDataTable("spTraerPlantillaTareo", id);
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
                    NuevaPlantilla.Obrero = Convert.ToBoolean(Plantilla.Rows[0][4]);
                    NuevaPlantilla.Activo = Convert.ToBoolean(Plantilla.Rows[0][5]);
                    return NuevaPlantilla;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerPlantillatareo: " + ex.Message);
            }
        }

        public cPlantillaTareo TraerPlantillaTareoXNombre(string pdescripcion)
        {
            try
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
                    NuevaPlantilla.Obrero = Convert.ToBoolean(Plantilla.Rows[0][4]);
                    NuevaPlantilla.Activo = Convert.ToBoolean(Plantilla.Rows[0][5]);
                    return NuevaPlantilla;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerPlantillaTareoXNombre: " + ex.Message);
            }
        }
    }
}
