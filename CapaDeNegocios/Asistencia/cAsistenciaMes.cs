using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cAsistenciaMes
    {
        cTrabajador _Trabajador;
        List<cAsistenciaDia> _ListaAsistenciaDia;
        List<cExcepcionesAsistencia> _ListaSalidas;
        DateTime _InicioMes;
        DateTime _FinMes;
        cHorario _HorarioTrabajador;
        int _TotalTardanzas;
        int _TotalFaltasMes;
        int _TotalMinutosTarde;


        public cAsistenciaMes()
        {
            _Trabajador = new cTrabajador();
            _ListaAsistenciaDia = new List<cAsistenciaDia>();
            _ListaSalidas = new List<cExcepcionesAsistencia>();
            _HorarioTrabajador = new cHorario();
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

        public List<cAsistenciaDia> ListaAsistenciaDia
        {
            get
            {
                return _ListaAsistenciaDia;
            }

            set
            {
                _ListaAsistenciaDia = value;
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

        public cHorario HorarioTrabajador
        {
            get
            {
                return _HorarioTrabajador;
            }

            set
            {
                _HorarioTrabajador = value;
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



      

        public int TotalTardanzas
        {
            get
            {
                return _TotalTardanzas;
            }

            set
            {
                _TotalTardanzas = value;
            }
        }

        public int TotalFaltasMes
        {
            get
            {
                return _TotalFaltasMes;
            }

            set
            {
                _TotalFaltasMes = value;
            }
        }

        public int TotalMinutosTarde
        {
            get
            {
                return _TotalMinutosTarde;
            }

            set
            {
                _TotalMinutosTarde = value;
            }
        }

        public List<cAsistenciaDia> LlenarAsistencias( List<cPicado> ListaPicados, DateTime FechaInicio, DateTime FechaFin, cHorario miHorario, List<cExcepcionesAsistencia> ListaSalidasMes, List<cDiaFestivo> ListaDiaFestivosMes)
        {
            try
            {
                List<cAsistenciaDia> NuevaLista = new List<cAsistenciaDia>();
                int numeroDias = 0;
                numeroDias = (FechaFin - FechaInicio).Days + 1;
                //comentario
                for (int i = 0; i < numeroDias; i++)
                {
                    cAsistenciaDia NuevaAsistencia = new cAsistenciaDia();
                    NuevaAsistencia.Dia = FechaInicio.AddDays(i);

                    foreach (cPicado item in ListaPicados)
                    {
                        if (item.Picado.Date == NuevaAsistencia.Dia.Date)
                        {
                            NuevaAsistencia.ListaPicados.Add(item);
                        }
                    }

                    foreach (cExcepcionesAsistencia item in ListaSalidasMes)
                    {
                        //Si la fecha de salida es la misma que el dia
                        if (NuevaAsistencia.Dia.Date == item.InicioExcepcion.Date || NuevaAsistencia.Dia.Date == item.FinExcepcion.Date)
                        {
                            NuevaAsistencia.ListaSalidas.Add(item);
                        }
                        //Si la fecha de papeleta de salida es de varios dias
                        if (NuevaAsistencia.Dia.Date > item.InicioExcepcion.Date && NuevaAsistencia.Dia.Date < item.FinExcepcion.Date)
                        {
                            NuevaAsistencia.ListaSalidas.Add(item);
                        }
                    }

                    foreach (cDiaFestivo item in ListaDiaFestivosMes)
                    {
                        if (NuevaAsistencia.Dia.Date == item.DiaFestivo)
                        {
                            NuevaAsistencia.DiaFestivo = item;
                        }
                    }

                    switch (NuevaAsistencia.Dia.DayOfWeek)
                    {
                        case DayOfWeek.Sunday:
                            NuevaAsistencia.TurnoDiaTrabajador = miHorario.TurnoDomingo;
                            
                            break;
                        case DayOfWeek.Monday:
                            NuevaAsistencia.TurnoDiaTrabajador = miHorario.TurnoLunes;
                            break;
                        case DayOfWeek.Tuesday:
                            NuevaAsistencia.TurnoDiaTrabajador = miHorario.TurnoMartes;
                            break;
                        case DayOfWeek.Wednesday:
                            NuevaAsistencia.TurnoDiaTrabajador = miHorario.TurnoMiercoles;
                            break;
                        case DayOfWeek.Thursday:
                            NuevaAsistencia.TurnoDiaTrabajador = miHorario.TurnoJueves;
                            break;
                        case DayOfWeek.Friday:
                            NuevaAsistencia.TurnoDiaTrabajador = miHorario.TurnoViernes;
                            break;
                        case DayOfWeek.Saturday:
                            NuevaAsistencia.TurnoDiaTrabajador = miHorario.TurnoSabado;
                            break;
                        default:
                            break;
                    }

                    NuevaLista.Add(NuevaAsistencia);
                }

                return NuevaLista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al llenar las asistencias: " + ex.Message);
            }
        }

        public void Actualizardatos()
        {
            try
            {
                foreach (cAsistenciaDia item in  ListaAsistenciaDia)
                {
                    //Si no tiene horario
                    if (HorarioTrabajador.CodigoHorario == 0)
                    {
                        item.Actualizardatos(false);
                    }
                    else
                    {
                        item.Actualizardatos(true);
                    }
                    if (item.Falta == cAsistenciaDia.TipoFalta.FaltaPicadoEntrada || item.Falta == cAsistenciaDia.TipoFalta.FaltaPicadoFinal || item.Falta == cAsistenciaDia.TipoFalta.FaltaTotal)
                    {
                        TotalFaltasMes++;
                    }

                    if (item.Tarde == true)
                    {
                        TotalTardanzas++;
                    }

                    TotalMinutosTarde += item.MinutosTarde;
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al actualizar los datos de la asistencia del mes: " + ex.Message);
            }
        }

        public cAsistenciaDia BuscarAsistenciaDiaXFecha(DateTime Fecha)
        {
            try
            {
                foreach (cAsistenciaDia item in _ListaAsistenciaDia)
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
                throw new cReglaNegociosException("Error en el metodo BuscarAsistenciaDiaXFecha: " + ex.Message);
            }
        }

        public cExcepcionesAsistencia BuscarExcepcionAsistencia(DateTime Fecha)
        {
            try
            {
                foreach (cExcepcionesAsistencia item in _ListaSalidas)
                {
                    if (Fecha.Date >= item.InicioExcepcion.Date && Fecha.Date <= item.FinExcepcion )
                    {
                        return item;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo BuscarExcepcionAsistencia: " + ex.Message);
            }
        }
    }
}
