using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cTurno
    {
        int _CodigoTurno;
        string _NombreTurno;
        int _ToleranciaInicio;
        DateTime _InicioTurno;
        DateTime _FinTurno;


        public cTurno()
        {
            _InicioTurno = new DateTime(2021, 1, 1);
            _FinTurno = new DateTime(2021, 1, 1);
        }

        public int CodigoTurno
        {
            get
            {
                return _CodigoTurno;
            }

            set
            {
                _CodigoTurno = value;
            }
        }

        public string NombreTurno
        {
            get
            {
                return _NombreTurno;
            }

            set
            {
                _NombreTurno = value;
            }
        }

        public int ToleranciaInicio
        {
            get
            {
                return _ToleranciaInicio;
            }

            set
            {
                _ToleranciaInicio = value;
            }
        }

        public DateTime InicioTurno
        {
            get
            {
                return _InicioTurno;
            }

            set
            {
                _InicioTurno = value;
            }
        }

        public DateTime FinTurno
        {
            get
            {
                return _FinTurno;
            }

            set
            {
                _FinTurno = value;
            }
        }

        public List<cTurno> ListaTurnos()
        {
            try
            {
                List<cTurno> NuevaListaTurnos = new List<cTurno>();
                //codigo prueba

                cTurno oTurno = new cTurno();
                oTurno.NombreTurno = "Turno Ejemplo";

                NuevaListaTurnos.Add(oTurno);

                return NuevaListaTurnos;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al traer la lista de turnos: " + ex.Message);
            }
        }
    }
}
