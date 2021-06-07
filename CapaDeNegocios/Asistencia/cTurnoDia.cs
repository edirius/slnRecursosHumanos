using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cTurnoDia
    {
        int _CodigoTurnoDia;
        string _NombreTurnoDia;
        List<cTurno> _ListaTurnos;

        public cTurnoDia()
        {
            _ListaTurnos = new List<cTurno>();
        }

        public int CodigoTurnoDia
        {
            get
            {
                return _CodigoTurnoDia;
            }

            set
            {
                _CodigoTurnoDia = value;
            }
        }

        public string NombreTurnoDia
        {
            get
            {
                return _NombreTurnoDia;
            }

            set
            {
                _NombreTurnoDia = value;
            }
        }

        public List<cTurno> ListaTurnos
        {
            get
            {
                return _ListaTurnos;
            }

            set
            {
                _ListaTurnos = value;
            }
        }

        //public List<cTurnoDia> ListaTurnosDia()
        //{
        //    try
        //    {
        //        List<cTurnoDia> NuevaListaTurnosDia = new List<cTurnoDia>();

        //        //Codigo Prueba

        //        cTurnoDia NuevoTurnoDia = new cTurnoDia();
        //        NuevoTurnoDia.CodigoTurnoDia = 0;
        //        NuevoTurnoDia.NombreTurnoDia = "Sin Turno";
        //        NuevaListaTurnosDia.Add(NuevoTurnoDia);

        //        cTurnoDia miTurno = new cTurnoDia();
        //        miTurno.CodigoTurnoDia = 1;
        //        miTurno.NombreTurnoDia = "Prueba turno dia";
        //        NuevaListaTurnosDia.Add(miTurno);
        //        return NuevaListaTurnosDia;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new cReglaNegociosException("Error al traer la lista de turnos de dia: " + ex.Message);
        //    }
        //}
    }
}
