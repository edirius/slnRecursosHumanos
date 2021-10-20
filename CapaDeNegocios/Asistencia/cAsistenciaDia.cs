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

        cPicado _PicadoEntrada;
        cPicado _PicadoSalida;

        DateTime _Dia;

        Boolean _Tarde;
        TipoFalta _Falta;
   
        int _MinutosTarde;

        TipoDia _EventoDia;

        Boolean _DiaLibre;
        cTurnoDia _TurnoDiaTrabajador;
        List<cExcepcionesAsistencia> _ListaSalidas;

        cDiaFestivo _DiaFestivo;

        TimeSpan _HorasTrabajadas;
        TimeSpan _HorasAsignadas;
        
        public enum TipoFalta
        {
            FaltaPicadoEntrada,
            FaltaPicadoFinal,
            FaltaJustificada,
            FaltaTotal,
            SinFalta
        }

        public enum TipoDia
        {
            DiaLaborable,
            DiaFestivo,
             DiaLibre
        }

        public cAsistenciaDia()
        {
            _ListaPicados = new List<cPicado>();
            _TurnoDiaTrabajador = new cTurnoDia();
            _ListaSalidas = new List<cExcepcionesAsistencia>();
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

        public cDiaFestivo DiaFestivo
        {
            get
            {
                return _DiaFestivo;
            }

            set
            {
                _DiaFestivo = value;
            }
        }

        public TipoFalta Falta
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

        public cPicado PicadoEntrada
        {
            get
            {
                return _PicadoEntrada;
            }

            set
            {
                _PicadoEntrada = value;
            }
        }

        public cPicado PicadoSalida
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

        public TipoDia EventoDia
        {
            get
            {
                return _EventoDia;
            }

            set
            {
                _EventoDia = value;
            }
        }

        public TimeSpan HorasTrabajadas
        {
            get
            {
                return _HorasTrabajadas;
            }

            set
            {
                _HorasTrabajadas = value;
            }
        }

        public TimeSpan HorasAsignadas
        {
            get
            {
                return _HorasAsignadas;
            }

            set
            {
                _HorasAsignadas = value;
            }
        }

        private TipoDia DescubrirTipoDia ()
        {
            try
            {
                if (_DiaFestivo != null)
                {
                    return TipoDia.DiaFestivo;
                }

                if (_TurnoDiaTrabajador.CodigoTurnoDia == 0)
                {
                    return TipoDia.DiaLibre;
                }

                return TipoDia.DiaLaborable;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error : " + ex.Message);
            }
        }

        public void Actualizardatos()
        {
            try
            {
                _EventoDia = DescubrirTipoDia();

                switch (_EventoDia)
                {
                    case TipoDia.DiaLaborable:
                        //Verificamos que tiene turnos
                        if (_TurnoDiaTrabajador.ListaTurnos.Count > 0)
                        {
                            foreach (cTurno miTurno in _TurnoDiaTrabajador.ListaTurnos)
                            {
                                List<cPicado> PicadosEntrada = new List<cPicado>();
                                List<cPicado> PicadosSalida = new List<cPicado>();
                                List<cPicado> PicadosSinEfecto = new List<cPicado>();

                                foreach (cPicado miPicado in ListaPicados)
                                {

                                    //Si el picado es menor al horario de inicio de picado mas los minutos de tolerancia
                                    if (miPicado.Picado.TimeOfDay <= miTurno.InicioTurno.AddMinutes(miTurno.ToleranciaFalta).TimeOfDay)
                                    {
                                        PicadosEntrada.Add(miPicado);
                                    }
                                    else if (miPicado.Picado.TimeOfDay >= miTurno.FinTurno.TimeOfDay)
                                    {
                                        PicadosSalida.Add(miPicado);
                                    }
                                    else
                                    {
                                        //Los picados quedan sin efecto.
                                        PicadosSinEfecto.Add(miPicado);
                                    }
                                }

                                if (PicadosEntrada.Count > 0)
                                {
                                    _PicadoEntrada = PicadosEntrada.Find(y => y.Picado == PicadosEntrada.Min(x => x.Picado));
                                }
                                else
                                {
                                    _PicadoEntrada = null;
                                }
                                if (PicadosSalida.Count > 0)
                                {
                                    _PicadoSalida = PicadosSalida.Find(y => y.Picado == PicadosSalida.Max(x => x.Picado));
                                }
                                else
                                {
                                    _PicadoSalida = null;
                                }

                                //calculos para picado de entrada
                                if (_PicadoEntrada == null)
                                {
                                    _MinutosTarde = 0;
                                    _Tarde = false;
                                    _Falta = TipoFalta.FaltaPicadoEntrada;
                                }
                                else
                                {
                                    //pico antes del horario
                                    if (_PicadoEntrada.Picado.TimeOfDay <= miTurno.InicioTurno.AddMinutes(miTurno.ToleranciaInicio).TimeOfDay)
                                    {
                                        MinutosTarde = 0;
                                        _Tarde = false;
                                        _Falta = TipoFalta.SinFalta;
                                    }
                                    else
                                    {
                                        MinutosTarde = (miTurno.InicioTurno.AddMinutes(miTurno.ToleranciaFalta) - _PicadoEntrada.Picado.TimeOfDay).Minute;
                                        _Tarde = true;
                                        _Falta = TipoFalta.SinFalta;
                                    }

                                }

                                //Calculos para picado de salida

                                if (_PicadoSalida == null)
                                {
                                    if (_Falta == TipoFalta.FaltaPicadoEntrada)
                                    {
                                        _Falta = TipoFalta.FaltaTotal;
                                    }
                                    else
                                    {
                                        _Falta = TipoFalta.FaltaPicadoFinal;
                                    }
                                }
                            }
                        }

                        foreach (cExcepcionesAsistencia item in _ListaSalidas)
                        {
                            //Si la fecha de salida es la misma que el dia
                            if (_Dia.Date == item.InicioExcepcion.Date || _Dia.Date == item.FinExcepcion.Date)
                            {
                                //Verificamos que la papeleta justifica el picado de entrada
                                if (item.InicioExcepcion.TimeOfDay <= _TurnoDiaTrabajador.ListaTurnos[0].InicioTurno.TimeOfDay)
                                {
                                    _MinutosTarde = 0;
                                    _Tarde = false;
                                    if (_Falta == TipoFalta.FaltaTotal)
                                    {
                                        _Falta = TipoFalta.FaltaPicadoFinal;
                                    }
                                    else
                                    {
                                        if (_Falta == TipoFalta.FaltaPicadoEntrada)
                                        {
                                            _Falta = TipoFalta.FaltaJustificada;
                                        }
                                        else
                                        {
                                            //if (_Falta != TipoFalta.FaltaPicadoFinal)
                                            //{
                                            //    _Falta = TipoFalta.SinFalta;
                                            //}
                                            
                                        }
                                    }
                                }
                                if (item.FinExcepcion.TimeOfDay >= _TurnoDiaTrabajador.ListaTurnos[0].FinTurno.TimeOfDay)
                                {
                                    if (_Falta == TipoFalta.FaltaTotal)
                                    {
                                        _Falta = TipoFalta.FaltaPicadoEntrada;
                                    }
                                    else
                                    {
                                        _Falta = TipoFalta.FaltaJustificada;
                                    }
                                }
                            }
                            //Si la fecha de papeleta de salida es de varios dias
                            if (_Dia.Date > item.InicioExcepcion.Date && _Dia.Date < item.FinExcepcion.Date)
                            {
                                _Tarde = false;
                                if (_Falta != TipoFalta.SinFalta)
                                {
                                    _Falta = TipoFalta.FaltaJustificada;
                                }
                                _MinutosTarde = 0;
                                _Tarde = false;

                            }
                        }
                        if (_Falta == TipoFalta.SinFalta)
                        {
                            _HorasTrabajadas = (new DateTime(2000, 1, 1, 13, 0, 0).TimeOfDay - TurnoDiaTrabajador.ListaTurnos[0].InicioTurno.TimeOfDay) + (_PicadoSalida.Picado.TimeOfDay - new DateTime(2000, 1, 1, 14, 0, 0).TimeOfDay);
                        }
                        _HorasAsignadas = _HorasTrabajadas = (new DateTime(2000, 1, 1, 13, 0, 0).TimeOfDay - TurnoDiaTrabajador.ListaTurnos[0].InicioTurno.TimeOfDay) + (TurnoDiaTrabajador.ListaTurnos[0].FinTurno.TimeOfDay - new DateTime(2000, 1, 1, 14, 0, 0).TimeOfDay);
                        break;
                    case TipoDia.DiaFestivo:
                        _DiaLibre = false;
                        _Tarde = false;
                        _Falta = TipoFalta.SinFalta;
                        _MinutosTarde = 0;
                        _HorasTrabajadas = new TimeSpan(0);
                        _HorasAsignadas = new TimeSpan(0);
                        break;
                    case TipoDia.DiaLibre:
                        _DiaLibre = true;
                        _Tarde = false;
                        _Falta = TipoFalta.SinFalta;
                        _MinutosTarde = 0;
                        _HorasTrabajadas = new TimeSpan(0);
                        _HorasAsignadas = new TimeSpan(0);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al actualizar datos de la asistencia del dia del trabajador: " + ex.Message);
            }
        }
    }
}
