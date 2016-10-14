using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Sunat
{
    public class cTipoSuspencionLaboral
    {
        int sidttiposuspencionlaboral;
        string scodigo;
        string sdescripcion;
        string sabreviacion;
        bool ssubsidiado;

        public int IdtTipoSuspencionLaboral
        {
            get { return sidttiposuspencionlaboral; }
            set { sidttiposuspencionlaboral = value; }
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
        public string Abreviacion
        {
            get { return sabreviacion; }
            set { sabreviacion = value; }
        }
        public bool Subsidiado
        {
            get { return ssubsidiado; }
            set { ssubsidiado = value; }
        }

        public DataTable ListarTipoSuspencionLaboral()
        {
            return Conexion.GDatos.TraerDataTable("spListarTipoSuspencionLaboral");
        }

        public Boolean CrearTipoSuspencionLaboral(cTipoSuspencionLaboral miTipoSuspencionLaboral)
        {
            Conexion.GDatos.Ejecutar("spCrearTipoSuspencionLaboral", miTipoSuspencionLaboral.Codigo, miTipoSuspencionLaboral.Descripcion, miTipoSuspencionLaboral.Abreviacion, miTipoSuspencionLaboral.Subsidiado);
            return true;
        }

        public Boolean ModificarTipoSuspencionLaboral(cTipoSuspencionLaboral miTipoSuspencionLaboral)
        {
            Conexion.GDatos.Ejecutar("spModificarTipoSuspencionLaboral", miTipoSuspencionLaboral.IdtTipoSuspencionLaboral, miTipoSuspencionLaboral.Codigo, miTipoSuspencionLaboral.Descripcion, miTipoSuspencionLaboral.Abreviacion, miTipoSuspencionLaboral.Subsidiado);
            return true;
        }

        public Boolean EliminarTipoSuspencionLaboral(int IdtTipoSuspencionLaboral)
        {
            Conexion.GDatos.Ejecutar("spELiminarTipoSuspencionLaboral", IdtTipoSuspencionLaboral);
            return true;
        }
    }
}
