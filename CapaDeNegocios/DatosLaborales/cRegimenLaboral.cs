using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cRegimenLaboral
    {
        int sidtregimenlaboral;
        string scodigo;
        string sdescripcion;

        public int IdTRegimenLaboral
        {
            get { return sidtregimenlaboral; }
            set { sidtregimenlaboral = value; }
        }
        public string Codigo
        {
            get { return scodigo; }
            set { scodigo = value; }
        }
        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }

        public DataTable ListarRegimenLaboral()
        {
            return Conexion.GDatos.TraerDataTable("spListarRegimenLaboral");
        }

        public Boolean CrearRegimenLaboral(cRegimenLaboral miRegimenLaboral)
        {
            Conexion.GDatos.Ejecutar("spCrearRegimenLaboral", miRegimenLaboral.Codigo, miRegimenLaboral.Descripcion);
            return true;
        }

        public Boolean ModificarRegimenLaboral(cRegimenLaboral miRegimenLaboral)
        {
            Conexion.GDatos.Ejecutar("spModificarRegimenLaboral", miRegimenLaboral.IdTRegimenLaboral, miRegimenLaboral.Codigo, miRegimenLaboral.Descripcion);
            return true;
        }

        public Boolean EliminarRegimenLaboral(int IdTRegimenLaboral)
        {
            Conexion.GDatos.Ejecutar("spELiminarRegimenLaboral", IdTRegimenLaboral);
            return true;
        }
    }
}
