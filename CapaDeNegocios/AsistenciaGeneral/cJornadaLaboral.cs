using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.AsistenciaGeneral
{
    public class cJornadaLaboral
    {
        private cTrabajador _Trabajador;
        private DateTime _Mes;
        private DateTime _InicioMes;
        private DateTime _FinMes;
        private List<cDetalleJornadaLaboral> _ListaDetalleJornadaLaboral;

        public cJornadaLaboral()
        {
            _ListaDetalleJornadaLaboral = new List<cDetalleJornadaLaboral>();
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

        public DateTime Mes
        {
            get
            {
                return _Mes;
            }

            set
            {
                _Mes = value;
            }
        }

        public DateTime InicioMes
        {
            get
            {
                return _InicioMes;
            }

            set
            {
                _InicioMes = value;
            }
        }

        public DateTime FinMes
        {
            get
            {
                return _FinMes;
            }

            set
            {
                _FinMes = value;
            }
        }

        public List<cDetalleJornadaLaboral> ListaDetalleJornadaLaboral
        {
            get
            {
                return _ListaDetalleJornadaLaboral;
            }

            set
            {
                _ListaDetalleJornadaLaboral = value;
            }
        }

        public cDetalleJornadaLaboral DevolverDetalleJornadaXFecha(DateTime Fecha)
        {
            try
            {
                foreach (cDetalleJornadaLaboral item in _ListaDetalleJornadaLaboral)
                {
                    if (item.Dia.Date == Fecha.Date)
                    {
                        return item;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error el metodo DevolverDetalleJornadaXFecha: " + ex.Message);
            }
        }
    }
}
