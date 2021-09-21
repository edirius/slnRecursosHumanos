using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios;
using CapaDeNegocios.Asistencia;
using CapaDeNegocios.AsistenciaGeneral;

namespace CapaUsuario.AsistenciaGen
{
    public class ViewJornadaLaboral
    {
        private DateTime _Inicio;
        private DateTime _Fin;
        private CapaDeNegocios.Asistencia.cHorario _oHorario;
        private CapaDeNegocios.AsistenciaGeneral.cJornadaLaboral _JornadaLaboral;
        private cAsistenciaMes _AsistenciaMes;
        private List<DetalleViewJornadaLaboral> _ListaDetalleViewJornadaLaboral;

        public ViewJornadaLaboral()
        {
            _ListaDetalleViewJornadaLaboral = new List<DetalleViewJornadaLaboral>();
        }

        public DateTime Inicio
        {
            get
            {
                return _Inicio;
            }

            set
            {
                _Inicio = value;
            }
        }

        public DateTime Fin
        {
            get
            {
                return _Fin;
            }

            set
            {
                _Fin = value;
            }
        }

        public cHorario OHorario
        {
            get
            {
                return _oHorario;
            }

            set
            {
                _oHorario = value;
            }
        }

        public cJornadaLaboral JornadaLaboral
        {
            get
            {
                return _JornadaLaboral;
            }

            set
            {
                _JornadaLaboral = value;
            }
        }

        public cAsistenciaMes AsistenciaMes
        {
            get
            {
                return _AsistenciaMes;
            }

            set
            {
                _AsistenciaMes = value;
            }
        }

        public List<DetalleViewJornadaLaboral> ListaDetalleViewJornadaLaboral
        {
            get
            {
                return _ListaDetalleViewJornadaLaboral;
            }

            set
            {
                _ListaDetalleViewJornadaLaboral = value;
            }
        }



        /// <summary>
        /// Crea y llena los detalles de la jornada laboral
        /// </summary>
        public void LlenarDetalleJornadaLaboral()
        {
            int diasMes = (_Fin - _Inicio).Days + 1;
            for (int i = 0; i < diasMes; i++)
            {
                DetalleViewJornadaLaboral oDetalle = new DetalleViewJornadaLaboral();
                oDetalle.Dia = _Inicio.AddDays(i);
                oDetalle.AsistenciaDia = AsistenciaMes.BuscarAsistenciaDiaXFecha(_Inicio.AddDays(i));
                oDetalle.DetalleJornadaLaboral = _JornadaLaboral.DevolverDetalleJornadaXFecha(_Inicio.AddDays(i));
                oDetalle.ExcepcionAsistencia = AsistenciaMes.BuscarExcepcionAsistencia(_Inicio.AddDays(i));
                oDetalle.TurnoDia = _oHorario.DevolverTurnoDia(_Inicio.AddDays(i));
                oDetalle.NumeroDia = i+1;
                _ListaDetalleViewJornadaLaboral.Add(oDetalle);
            }
        }
    }
}
