using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cHorarioTrabajador
    {
        int _Codigo;
        DateTime _FechaInicioHorario;
        DateTime _FechaFinHorario;
        cTrabajador _Trabajador;
        cHorario _Horario;

        public DateTime FechaInicioHorario
        {
            get
            {
                return _FechaInicioHorario;
            }

            set
            {
                _FechaInicioHorario = value;
            }
        }

        public DateTime FechaFinHorario
        {
            get
            {
                return _FechaFinHorario;
            }

            set
            {
                _FechaFinHorario = value;
            }
        }

        public cTrabajador Trabajador
        {
            get
            {
                return _Trabajador;
            }

            set
            {
                _Trabajador = value;
            }
        }

        public cHorario Horario
        {
            get
            {
                return _Horario;
            }

            set
            {
                _Horario = value;
            }
        }

        public int Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
            }
        }

        public void AgregarHorario(cHorarioTrabajador nuevoHorarioTrabajador)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error el agregar el nuevo horario: " + ex.Message);
            }
        }
    }
}
