using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Asistencia
{
    public class cAsistenciaSuspencionLaboral
    {
        int sidtasistenciatrabajador;
        int sidttiposuspencionlaboral;

        public int IdtAsistenciaTrabajador
        {
            get { return sidtasistenciatrabajador; }
            set { sidtasistenciatrabajador = value; }
        }
        public int IdtTipoSuspencionLaboral
        {
            get { return sidttiposuspencionlaboral; }
            set { sidttiposuspencionlaboral = value; }
        }

        public DataTable ListarAsistenciaSuspencionLaboral(int IdtAsistenciaTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarAsistenciaSuspencionLaboral", IdtAsistenciaTrabajador);
        }

        public Boolean CrearAsistenciaSuspencionLaboral(cAsistenciaSuspencionLaboral miAsistenciaSuspencionLaboral)
        {
            Conexion.GDatos.Ejecutar("spCrearAsistenciaSuspencionLaboral", miAsistenciaSuspencionLaboral.IdtAsistenciaTrabajador, miAsistenciaSuspencionLaboral.IdtTipoSuspencionLaboral);
            return true;
        }

        public Boolean ModificarAsistenciaSuspencionLaboral(cAsistenciaSuspencionLaboral miAsistenciaSuspencionLaboral)
        {
            Conexion.GDatos.Ejecutar("spModificarAsistenciaSuspencionLaboral", miAsistenciaSuspencionLaboral.IdtAsistenciaTrabajador, miAsistenciaSuspencionLaboral.IdtTipoSuspencionLaboral);
            return true;
        }

        public Boolean EliminarAsistenciaSuspencionLaboral(int IdtAsistenciaTrabajador)
        {
            Conexion.GDatos.Ejecutar("spELiminarAsistenciaSuspencionLaboral", IdtAsistenciaTrabajador);
            return true;
        }

    }
}
