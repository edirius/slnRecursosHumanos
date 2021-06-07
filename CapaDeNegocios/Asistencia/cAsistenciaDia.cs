using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cAsistenciaDia
    {
        List<cPicado> _ListaPicados;
        DateTime _Dia;
        Boolean _Tarde;
        Boolean _Falta;
        int _MinutosTarde;

        Boolean _PicadoSalida;
        Boolean _DiaLibre;
        cTurnoDia _TurnoDiaTrabajador;
        List<cExcepcionesAsistencia> _ListaSalidas;
        
        public cAsistenciaDia()
        {
            _ListaPicados = new List<cPicado>();
            _TurnoDiaTrabajador = new cTurnoDia();
        }

        public List<cPicado> ListaPicados
        {
            get
            {
                return _ListaPicados;
            }

            set
            {
                _ListaPicados = value;
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

        public bool Tarde
        {
            get
            {
                return _Tarde;
            }

            set
            {
                _Tarde = value;
            }
        }

        public bool Falta
        {
            get
            {
                return _Falta;
            }

            set
            {
                _Falta = value;
            }
        }

       

        public int MinutosTarde
        {
            get
            {
                return _MinutosTarde;
            }

            set
            {
                _MinutosTarde = value;
            }
        }

        public List<cExcepcionesAsistencia> ListaSalidas
        {
            get
            {
                return _ListaSalidas;
            }

            set
            {
                _ListaSalidas = value;
            }
        }

        public cTurnoDia TurnoDiaTrabajador
        {
            get
            {
                return _TurnoDiaTrabajador;
            }

            set
            {
                _TurnoDiaTrabajador = value;
            }
        }

        public bool PicadoSalida
        {
            get
            {
                return _PicadoSalida;
            }

            set
            {
                _PicadoSalida = value;
            }
        }

        public bool DiaLibre
        {
            get
            {
                return _DiaLibre;
            }

            set
            {
                _DiaLibre = value;
            }
        }

        public void Actualizardatos()
        {
            try
            {
                // Dia Libre
                if (_TurnoDiaTrabajador.CodigoTurnoDia != 0)
                {
                    //Verificamos que tiene turnos
                    if (_TurnoDiaTrabajador.ListaTurnos.Count > 0)
                    {
                        foreach (cTurno miTurno in _TurnoDiaTrabajador.ListaTurnos)
                        {
                            foreach (cPicado miPicado in ListaPicados)
                            {
                                //pico antes del horario
                                if (miPicado.Picado.TimeOfDay <= miTurno.InicioTurno.TimeOfDay )
                                {
                                    _MinutosTarde = 0;
                                    _Tarde = false;
                                    _Falta = false;
                                }
                                else
                                {
                                    //pico despues del horario de inicio, pero antes del horario de fin
                                    if (miPicado.Picado.TimeOfDay < miTurno.FinTurno.TimeOfDay)
                                    {
                                        _MinutosTarde = (miPicado.Picado.TimeOfDay - miTurno.InicioTurno.TimeOfDay).Minutes;
                                        if (_MinutosTarde >= miTurno.ToleranciaInicio)
                                        {
                                            _Tarde = true;
                                            _Falta = false;
                                        }
                                        else
                                        {
                                            _Tarde = false;
                                            _Falta = false;
                                        }

                                        if (_MinutosTarde >= miTurno.ToleranciaFalta)
                                        {
                                            _Tarde = false;
                                            _Falta = true;
                                        }
                                    }
                                    //es el picado de salida
                                    else
                                    {
                                        _PicadoSalida = true;
                                    }
                                }
                            }
                        }
                    }
                }

                else
                {
                    _DiaLibre = true;
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al actualizar datos de la asistencia del dia del trabajador: " + ex.Message);
            }
        }
    }
}
