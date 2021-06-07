using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cHorario
    {
        int _CodigoHorario;
        string _NombreHorario;
        cTurnoDia _TurnoLunes;
        cTurnoDia _TurnoMartes;
        cTurnoDia _TurnoMiercoles;
        cTurnoDia _TurnoJueves;
        cTurnoDia _TurnoViernes;
        cTurnoDia _TurnoSabado;
        cTurnoDia _TurnoDomingo;


        public cHorario()
        {
            cTurnoDia NuevoTurnoDia = new cTurnoDia();
            //NuevoTurnoDia.CodigoTurnoDia = 1;
            //NuevoTurnoDia.NombreTurnoDia = "Sin Turno";
            //_TurnoLunes = NuevoTurnoDia;
            //_TurnoMartes = NuevoTurnoDia;

        }

        public int CodigoHorario
        {
            get
            {
                return _CodigoHorario;
            }

            set
            {
                _CodigoHorario = value;
            }
        }

        public string NombreHorario
        {
            get
            {
                return _NombreHorario;
            }

            set
            {
                _NombreHorario = value;
            }
        }

        public cTurnoDia TurnoLunes
        {
            get
            {
                return _TurnoLunes;
            }

            set
            {
                _TurnoLunes = value;
            }
        }

        public cTurnoDia TurnoMartes
        {
            get
            {
                return _TurnoMartes;
            }

            set
            {
                _TurnoMartes = value;
            }
        }

        public cTurnoDia TurnoMiercoles
        {
            get
            {
                return _TurnoMiercoles;
            }

            set
            {
                _TurnoMiercoles = value;
            }
        }

        public cTurnoDia TurnoJueves
        {
            get
            {
                return _TurnoJueves;
            }

            set
            {
                _TurnoJueves = value;
            }
        }

        public cTurnoDia TurnoViernes
        {
            get
            {
                return _TurnoViernes;
            }

            set
            {
                _TurnoViernes = value;
            }
        }

        public cTurnoDia TurnoSabado
        {
            get
            {
                return _TurnoSabado;
            }

            set
            {
                _TurnoSabado = value;
            }
        }

        public cTurnoDia TurnoDomingo
        {
            get
            {
                return _TurnoDomingo;
            }

            set
            {
                _TurnoDomingo = value;
            }
        }

        //public List<cHorario> ListaHorarios()
        //{
        //    try
        //    {
        //        List<cHorario> NuevaListaHorarios = new List<cHorario>();

        //        //Codigo Ejemplo

        //        cHorario EjemploHorario = new cHorario();
        //        EjemploHorario.CodigoHorario = 0;
        //        EjemploHorario.NombreHorario = "Ejemplo Horario";

        //        NuevaListaHorarios.Add(EjemploHorario);

        //        return NuevaListaHorarios;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new cReglaNegociosException("Error al listar los horarios: " + ex.Message);
        //    }
        //}
    }
}
