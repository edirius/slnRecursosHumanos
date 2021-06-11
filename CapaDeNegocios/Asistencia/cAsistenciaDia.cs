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
        TipoFalta _Falta;
   
        int _MinutosTarde;

        Boolean _PicadoSalida;
        Boolean _DiaLibre;
        cTurnoDia _TurnoDiaTrabajador;
        List<cExcepcionesAsistencia> _ListaSalidas;
        cDiaFestivo _DiaFestivo;
        
        public enum TipoFalta
        {
            FaltaPicadoEntrada,
            FaltaPicadoFinal,
            FaltaJustificada,
            FaltaTotal,
            SinFalta
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

        public void Actualizardatos()
        {
            try
            {
                // Dia Libre
                if (_TurnoDiaTrabajador.CodigoTurnoDia != 0)
                {
                    //Dia festivo
                    if (DiaFestivo != null)
                    {
                        _DiaLibre = true;
                        _Tarde = false;
                        _Falta = TipoFalta.SinFalta;
                        _MinutosTarde = 0;
                    }
                    else
                    {
                        //Verificamos que tiene turnos
                        if (_TurnoDiaTrabajador.ListaTurnos.Count > 0)
                        {
                            foreach (cTurno miTurno in _TurnoDiaTrabajador.ListaTurnos)
                            {
                                foreach (cPicado miPicado in ListaPicados)
                                {
                                    //pico antes del horario
                                    if (miPicado.Picado.TimeOfDay <= miTurno.InicioTurno.TimeOfDay)
                                    {
                                        _MinutosTarde = 0;
                                        _Tarde = false;
                                        _Falta = TipoFalta.SinFalta;
                                        
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
                                                _Falta = TipoFalta.SinFalta;
                                            }
                                            else
                                            {
                                                _Tarde = false;
                                                _Falta = TipoFalta.SinFalta;
                                            }

                                            if (_MinutosTarde >= miTurno.ToleranciaFalta)
                                            {
                                                _Tarde = false;
                                                _Falta = TipoFalta.FaltaPicadoEntrada;
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

                        if (_PicadoSalida == false)
                        {
                            if (_Falta == TipoFalta.SinFalta)
                            {
                                _Falta = TipoFalta.FaltaPicadoFinal;
                            }
                            else
                            {
                                _Falta = TipoFalta.FaltaTotal;
                            }
                            
                        }

                        foreach (cExcepcionesAsistencia item in _ListaSalidas)
                        {
                            //Si la fecha de salida es la misma que el dia
                            if ( _Dia.Date == item.InicioExcepcion.Date || _Dia.Date == item.FinExcepcion.Date)
                            {
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
                                            _Falta = TipoFalta.SinFalta;
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
                                        if (_Falta == TipoFalta.FaltaPicadoEntrada)
                                        {
                                            _Falta = TipoFalta.FaltaJustificada;
                                        }
                                        else
                                        {
                                            _Falta = TipoFalta.SinFalta;
                                        }
                                        
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
                            }
                        }
                    }
                
                }

                else
                {
                    _DiaLibre = true;
                    _Tarde = false;
                    _Falta = TipoFalta.SinFalta;
                    _MinutosTarde = 0;
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al actualizar datos de la asistencia del dia del trabajador: " + ex.Message);
            }
        }
    }
}
