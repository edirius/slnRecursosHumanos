using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Sunat;

namespace CapaDeNegocios.AsistenciaGeneral
{
    public class cDetalleJornadaLaboral
    {

        public enum enumTipoDiaJornada
        {
            Laborado,
            Justificado,
            Subsidiado,
            NoLaborado,
            Tardanza,
            Feriado
        }

        private int _Codigo;
        private enumTipoDiaJornada _TipoDia;
        private DateTime _Dia;
        private CapaDeNegocios.Sunat.cTipoSuspencionLaboral _SuspensionLaboral;
        private cTrabajador _Trabajador;

        public enumTipoDiaJornada TipoDia
        {
            get
            {
                return _TipoDia;
            }

            set
            {
                _TipoDia = value;
            }
        }

        public DateTime Dia
        {
            get
            {
                return _Dia;
            }

            set
            {
                _Dia = value;
            }
        }

        public cTipoSuspencionLaboral SuspensionLaboral
        {
            get
            {
                return _SuspensionLaboral;
            }

            set
            {
                _SuspensionLaboral = value;
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
    }
}
