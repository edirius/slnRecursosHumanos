using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaDeNegocios.Asistencia
{
    public class cCatalogoAsistencia
    {
        public cAsistenciaMes  LLenarAsistencia(cTrabajador miTrabajador, int mes, int año)
        {
            cAsistenciaMes oAsistenciaMes = new cAsistenciaMes();
            oAsistenciaMes.InicioMes = new DateTime(año, mes, 1);
            oAsistenciaMes.FinMes = new DateTime(año, mes, 1).AddMonths(1).AddDays(-1);
            DataTable ListaTrabajadores = new DataTable();

            foreach (DataRow item in ListaTrabajadores.Rows)
            {
                

            }
            //ejemplo
            cAsistenciaDia oAsistenciaDia = new cAsistenciaDia();
            oAsistenciaDia.Dia = new DateTime(2021, 5, 18);

            cPicado oPicado = new cPicado();
            oPicado.Picado = new DateTime(2021, 5, 18, 8, 1, 0);
            //oPicado.Trabajador = miTrabajador;

            oAsistenciaDia.ListaPicados.Add(oPicado);

            oAsistenciaMes.ListaAsistenciaDia.Add(oAsistenciaDia);

            return oAsistenciaMes;
        }

        public void AgregarDiaFestivo(cDiaFestivo oFestivo)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearDiaFestivo", oFestivo.Nombre, oFestivo.DiaFestivo);

            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al ingresar dias festivos: " + ex.Message);
            }
        }

        public void ModificarFestivo(cDiaFestivo oFestivo)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarDiaFestivo", oFestivo.Codigo, oFestivo.Nombre, oFestivo.DiaFestivo);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al modificar el dia festivo: " + ex.Message);
            }
        }

        public void Eliminarfestivo(cDiaFestivo oFestivo)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarDiaFestivo", oFestivo.Codigo);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al eliminar el dia festivo: " + ex.Message);
            }
        }

        public List<cDiaFestivo> ListaDiaFestivo(int anio)
        {
            try
            {
                List<cDiaFestivo> ListaNueva = new List<cDiaFestivo>();

                DataTable oData = Conexion.GDatos.TraerDataTable("spListarDiasFestivos", anio);

                foreach (DataRow item in oData.Rows)
                {
                    cDiaFestivo oDiaFestivo = new cDiaFestivo();
                    oDiaFestivo.Codigo = Convert.ToInt16(item["idtdiafestivo"].ToString());
                    oDiaFestivo.Nombre = item["nombrediafestivo"].ToString();
                    oDiaFestivo.DiaFestivo = Convert.ToDateTime(item["diafestivo"].ToString());

                    ListaNueva.Add(oDiaFestivo);
                }

                return ListaNueva;

            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al listar los dias festivos: " + ex.Message);
            }
        }

        public void CrearHorarioTrabajador(cHorarioTrabajador oHorarioTrabajador)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearHorarioTrabajador", oHorarioTrabajador.Trabajador.IdTrabajador, oHorarioTrabajador.FechaInicioHorario, oHorarioTrabajador.FechaFinHorario, oHorarioTrabajador.Horario.CodigoHorario);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al asignar el horario al trabajador: " + ex.Message);
            }
        } 

        public void ModificarHorarioTrabajador(cHorarioTrabajador oHorarioTrabajador)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarHorarioTrabajador", oHorarioTrabajador.Codigo, oHorarioTrabajador.Trabajador.IdTrabajador, oHorarioTrabajador.FechaInicioHorario, oHorarioTrabajador.FechaFinHorario, oHorarioTrabajador.Horario.CodigoHorario);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al modificar el horario del trabjador: " + ex.Message);
            }
        }

        public void EliminarTrabajador(cHorarioTrabajador oHorarioTrabajador)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarHorarioTrabajador", oHorarioTrabajador.Codigo);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al eliminar el horario del trabajador: " + ex.Message);
            }
        }

        #region horarios
       
        public void CrearHorario(cHorario oHorario)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearHorario", oHorario.NombreHorario, oHorario.TurnoLunes.CodigoTurnoDia, oHorario.TurnoMartes.CodigoTurnoDia, 
                    oHorario.TurnoMiercoles.CodigoTurnoDia, oHorario.TurnoJueves.CodigoTurnoDia, oHorario.TurnoViernes.CodigoTurnoDia, oHorario.TurnoSabado.CodigoTurnoDia, oHorario.TurnoDomingo.CodigoTurnoDia);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al crear el horario: " + ex.Message);
            }
        }

        public void ModificarHorario(cHorario oHorario)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarHorario", oHorario.CodigoHorario, oHorario.NombreHorario, oHorario.TurnoLunes.CodigoTurnoDia, oHorario.TurnoMartes.CodigoTurnoDia,
                    oHorario.TurnoMiercoles.CodigoTurnoDia, oHorario.TurnoJueves.CodigoTurnoDia, oHorario.TurnoViernes.CodigoTurnoDia, oHorario.TurnoSabado.CodigoTurnoDia, oHorario.TurnoDomingo.CodigoTurnoDia);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al modificar el horario: " + ex.Message);
            }
        }

        public void EliminarHorario(cHorario oHorario)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarHorario", oHorario.CodigoHorario);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al eliminar el horario: " + ex.Message);
            }
        }

        public List<cHorario> ListaHorarios()
        {
            try
            {
                List<cHorario> oListaHorarios = new List<cHorario>();
                DataTable oTabla = new DataTable();
                oTabla = Conexion.GDatos.TraerDataTable("spTraerListaHorarios");
                foreach (DataRow item in oTabla.Rows)
                {
                    cHorario oHorario = new cHorario();
                    oHorario.CodigoHorario = Convert.ToInt16(item["idthorario"].ToString());
                    oHorario.NombreHorario = item["nombrehorario"].ToString();
                    oHorario.TurnoLunes = TraerTurnoDia(Convert.ToInt16(item["turnolunes"].ToString()));
                    oHorario.TurnoMartes = TraerTurnoDia(Convert.ToInt16(item["turnomartes"].ToString()));
                    oHorario.TurnoMiercoles = TraerTurnoDia(Convert.ToInt16(item["turnomiercoles"].ToString()));
                    oHorario.TurnoJueves = TraerTurnoDia(Convert.ToInt16(item["turnojueves"].ToString()));
                    oHorario.TurnoViernes = TraerTurnoDia(Convert.ToInt16(item["turnoviernes"].ToString()));
                    oHorario.TurnoSabado = TraerTurnoDia(Convert.ToInt16(item["turnosabado"].ToString()));
                    oHorario.TurnoDomingo = TraerTurnoDia(Convert.ToInt16(item["turnodomingo"].ToString()));
                    oListaHorarios.Add(oHorario);
                }

                return oListaHorarios;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al listar horarios: " + ex.Message);
            }
        }
        #endregion

        #region TurnosDia
        public void CrearTurnoDia(cTurnoDia oTurnoDia)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearTurnoDia", oTurnoDia.NombreTurnoDia);
                oTurnoDia.CodigoTurnoDia = ListaTurnosDias().Last().CodigoTurnoDia;
                foreach (cTurno item in oTurnoDia.ListaTurnos)
                {
                    AgregarTurnoDiaTurno(oTurnoDia, item);
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al crear el turno dia: " + ex.Message);
            }
        }

        public void ModificarTurnoDia(cTurnoDia oTurnoDia)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarTurnoDia", oTurnoDia.CodigoTurnoDia, oTurnoDia.NombreTurnoDia);
                foreach (cTurno item in oTurnoDia.ListaTurnos)
                {
                    if (TraerTurnos(oTurnoDia).Find(x => x.CodigoTurno == item.CodigoTurno) == null)
                    {
                        AgregarTurnoDiaTurno(oTurnoDia, item);
                    }
                }

                foreach (cTurno item in TraerTurnos(oTurnoDia))
                {
                    if (oTurnoDia.ListaTurnos.Find(x => x.CodigoTurno == item.CodigoTurno) == null)
                    {
                        EliminarDiaTurno(oTurnoDia, item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al modificar el turno dia: " + ex.Message);
            }
        }

        public void EliminarTurnoDia(cTurnoDia oTurnoDia)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarTurnoDia", oTurnoDia.CodigoTurnoDia);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al eliminar el turno dia: " + ex.Message);
            }
        }

        public cTurnoDia TraerTurnoDia(int codigo)
        {
            try
            {
                cTurnoDia oTurno = new cTurnoDia();
                oTurno.CodigoTurnoDia = 0;
                oTurno.NombreTurnoDia = "";
                DataTable oTable;
                oTable = Conexion.GDatos.TraerDataTable("spTraerTurnoDiaXCodigo", codigo);

                foreach (DataRow item in oTable.Rows)
                {
                    oTurno.CodigoTurnoDia = Convert.ToInt16(item["idtturnodia"].ToString());
                    oTurno.NombreTurnoDia = item["nombreturnodia"].ToString();
                }

                return oTurno;
                
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al traer turno dia: " + ex.Message);
            }
        }


        public void AgregarTurnoDiaTurno(cTurnoDia oTurnoDia, cTurno oTurno)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearTurnoTurnoDia", oTurnoDia.CodigoTurnoDia, oTurno.CodigoTurno);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al agregarr el turno en el turnodia: " + ex.Message);
            }
        }

      


        public void EliminarDiaTurno(cTurnoDia oTurnoDia, cTurno oTurno)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarTurnoTurnoDia", oTurnoDia.CodigoTurnoDia, oTurno.CodigoTurno);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al quitar el turno en el turnodia: " + ex.Message);
            }
        }

     
        public List<cTurno> TraerTurnos(cTurnoDia oTurnoDia)
        {

            try
            {
                List<cTurno> oListaTurnos = new List<cTurno>();

                DataTable oTable;
                oTable = Conexion.GDatos.TraerDataTable("spTraerListaTurnosXTurnosDias", oTurnoDia.CodigoTurnoDia);

                foreach (DataRow item in oTable.Rows)
                {
                    cTurno oTurno = new cTurno();
                    oTurno.CodigoTurno = Convert.ToInt16(item["idtturno"].ToString());
                    oTurno.NombreTurno = item["nombreturno"].ToString();
                    oTurno.ToleranciaInicio = Convert.ToInt16(item["toleranciaTurno"].ToString());
                    oTurno.InicioTurno = Convert.ToDateTime(item["inicioTurno"].ToString());
                    oTurno.FinTurno = Convert.ToDateTime(item["finTurno"].ToString());
                    oListaTurnos.Add(oTurno);
                }

                return oListaTurnos;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al listar los turnos: " + ex.Message);
            }
        }

        public List<cTurnoDia> ListaTurnosDias()
        {
            try
            {
                List<cTurnoDia> oListaTurnos = new List<cTurnoDia>();

                DataTable oTable;
                oTable = Conexion.GDatos.TraerDataTable("spListarTurnosDias");

                foreach (DataRow item in oTable.Rows)
                {
                    cTurnoDia oTurno = new cTurnoDia();
                    oTurno.CodigoTurnoDia = Convert.ToInt16(item["idtturnodia"].ToString());
                    oTurno.NombreTurnoDia = item["nombreturnodia"].ToString();
                    oListaTurnos.Add(oTurno);
                }

                return oListaTurnos;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al listar los turnos: " + ex.Message);
            }
        }

        public List<cTurnoDia> ListaTurnosDiasyVacio()
        {
            try
            {
                List<cTurnoDia> oListaTurnos = new List<cTurnoDia>();

                DataTable oTable;
                oTable = Conexion.GDatos.TraerDataTable("spListarTurnosDias");

                cTurnoDia oVacio = new cTurnoDia();
                oVacio.CodigoTurnoDia = 0;
                oVacio.NombreTurnoDia = "Sin Turno";
                oListaTurnos.Add(oVacio);
                foreach (DataRow item in oTable.Rows)
                {
                    cTurnoDia oTurno = new cTurnoDia();
                    oTurno.CodigoTurnoDia = Convert.ToInt16(item["idtturnodia"].ToString());
                    oTurno.NombreTurnoDia = item["nombreturnodia"].ToString();
                    oListaTurnos.Add(oTurno);
                }

                return oListaTurnos;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al listar los turnos: " + ex.Message);
            }
        }

        #endregion

        public void CrearTurno(cTurno oTurno)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearTurno", oTurno.NombreTurno, oTurno.ToleranciaInicio, oTurno.InicioTurno, oTurno.FinTurno);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Erro al crear turno: " + ex.Message);
            }
        }

        public void ModificarTurno(cTurno oTurno)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarTurno", oTurno.CodigoTurno, oTurno.NombreTurno, oTurno.ToleranciaInicio, oTurno.InicioTurno, oTurno.FinTurno);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al modificar turno: " + ex.Message);
            }
        }

        public void EliminarTurno(cTurno oTurno)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarrTurno", oTurno.CodigoTurno);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al eliminar turno: " + ex.Message);
            }
        }

        public List<cTurno> ListaTurnos()
        {
            try
            {
                List<cTurno> oListaTurnos = new List<cTurno>();

                DataTable oTable;
                oTable = Conexion.GDatos.TraerDataTable("spListarTurnos");

                foreach (DataRow item in oTable.Rows)
                {
                    cTurno oTurno = new cTurno();
                    oTurno.CodigoTurno = Convert.ToInt16(item["idtturno"].ToString());
                    oTurno.NombreTurno = item["nombreturno"].ToString();
                    oTurno.ToleranciaInicio = Convert.ToInt16(item["toleranciaTurno"].ToString());
                    oTurno.InicioTurno = Convert.ToDateTime(item["inicioTurno"].ToString());
                    oTurno.FinTurno = Convert.ToDateTime(item["finTurno"].ToString());
                    oListaTurnos.Add(oTurno);
                }

                return oListaTurnos;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al listar los turnos: " + ex.Message);
            }
        }

        public void IngresarNuevaSalida(cExcepcionesAsistencia NuevaSalida)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearSalidaTrabajador", NuevaSalida.Tipo, NuevaSalida.Comentario, NuevaSalida.InicioExcepcion, NuevaSalida.FinExcepcion, NuevaSalida.Trabajador.IdTrabajador);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al ingresar Nueva salida: " + ex.Message);
            }
        }

        public void ModificarSalida(cExcepcionesAsistencia NuevaSalida)
        {
            try
            {
                try
                {
                    Conexion.GDatos.Ejecutar("spModificarSalidaTrabajador", NuevaSalida.CodigoExcepcion, NuevaSalida.Tipo, NuevaSalida.Comentario, NuevaSalida.InicioExcepcion, NuevaSalida.FinExcepcion);
                }
                catch (Exception ex)
                {
                    throw new cReglaNegociosException("Error al ingresar Nueva salida: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al modificar salida: " + ex.Message);
            }
        }

        public void EliminarSalida(cExcepcionesAsistencia NuevaSalida)
        {
            try
                {
                    Conexion.GDatos.Ejecutar("spEliminarSalidaTrabajador", NuevaSalida.CodigoExcepcion);
                }
                catch (Exception ex)
                {
                    throw new cReglaNegociosException("Error al eliminar Nueva salida: " + ex.Message);
                }
        }

        public List<cExcepcionesAsistencia> ListaSalidas(cTrabajador oTrabajador)
        {
            try
            {
                List<cExcepcionesAsistencia> oLista = new List<cExcepcionesAsistencia>();
                DataTable data;

                data = Conexion.GDatos.TraerDataTable("spListarSalidasTrabajador", oTrabajador.IdTrabajador);

                foreach (DataRow item in data.Rows)
                {
                    cExcepcionesAsistencia salida = new cExcepcionesAsistencia();
                    salida.CodigoExcepcion = Convert.ToInt16(item["idtsalida"].ToString());
                    salida.Tipo = item["tipo"].ToString();
                    salida.Comentario = item["comentario"].ToString();
                    salida.InicioExcepcion = Convert.ToDateTime(item["iniciosalida"].ToString());
                    salida.FinExcepcion = Convert.ToDateTime(item["finsalida"].ToString());
                    salida.Trabajador = oTrabajador;
                    oLista.Add(salida);
                }
                return oLista;
            }
            catch (Exception ex) 
            {
                throw new cReglaNegociosException("Error al traer la lista de salidas: " + ex.Message);
            }
        }


        public List<cExcepcionesAsistencia> ListaSalidas(cTrabajador oTrabajador, DateTime oFecha)
        {
            try
            {
                List<cExcepcionesAsistencia> oLista = new List<cExcepcionesAsistencia>();
                DataTable data;

                data = Conexion.GDatos.TraerDataTable("spListarSalidasTrabajador", oTrabajador.IdTrabajador, oFecha);

                foreach (DataRow item in data.Rows)
                {
                    cExcepcionesAsistencia salida = new cExcepcionesAsistencia();
                    salida.CodigoExcepcion = Convert.ToInt16(item["idtsalida"].ToString());
                    salida.Tipo = item["tipo"].ToString();
                    salida.Comentario = item["comentario"].ToString();
                    salida.InicioExcepcion = Convert.ToDateTime(item["iniciosalida"].ToString());
                    salida.FinExcepcion = Convert.ToDateTime(item["finsalida"].ToString());
                    salida.Trabajador = oTrabajador;
                    oLista.Add(salida);
                }
                return oLista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al traer la lista de salidas: " + ex.Message);
            }
        }

        public void CrearTrabajadorReloj (cTrabajadorReloj oTrabajadorReloj)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearTrabajadorReloj", oTrabajadorReloj.OTrabajador.IdTrabajador, oTrabajadorReloj.CodigoReloj);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al asignar el trabajador al reloj: " + ex.Message);
            }
        }

        public void ModificarTrabajadorReloj(cTrabajador oTrabajador, int codigoReloj)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarTrabajadorReloj", oTrabajador.IdTrabajador, codigoReloj);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al asignar el trabajador al reloj: " + ex.Message);
            }
        }

        public void EliminarTrabajadorReloj(cTrabajador oTrabajador)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarTrabajadorReloj", oTrabajador.IdTrabajador);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al eliminar la asignacion del trabajador al reloj: " + ex.Message);
            }
        }

        public cTrabajadorReloj TraerTrabajadorReloj( cTrabajador oTrabajador)
        {
            try
            {
                cTrabajadorReloj oTrabajadorReloj = null;

                DataTable data = new DataTable();
                data = Conexion.GDatos.TraerDataTable("spBuscarTrabajadorReloj", oTrabajador.IdTrabajador);

                foreach (DataRow item in data.Rows)
                {
                    oTrabajadorReloj = new cTrabajadorReloj();
                    oTrabajadorReloj.CodigoReloj = Convert.ToInt16(item["idtreloj"].ToString());
                    oTrabajadorReloj.OTrabajador = oTrabajador;
                }

                return oTrabajadorReloj;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al traer trabajador reloj: " + ex.Message);
            }
        }

        public cTrabajador TraerTrabajadorXCodigoReloj(int codigoReloj)
        {
            try
            {
                cTrabajador oTrabajadorReloj = null;

                DataTable data = new DataTable();
                data = Conexion.GDatos.TraerDataTable("spBuscarTrabajadorReloj", codigoReloj);

                foreach (DataRow item in data.Rows)
                {
                    oTrabajadorReloj = new cTrabajador();
                    oTrabajadorReloj = oTrabajadorReloj.traerTrabajador(Convert.ToInt16(item["idttrabajador"].ToString()));
                }

                return oTrabajadorReloj;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al traer trabajador reloj: " + ex.Message);
            }
        }


        #region PicadoReloj
        public void CrearPicadoReloj(cPicado oPicado)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearPicadoReloj", oPicado.TrabajadorReloj.CodigoReloj, oPicado.Picado);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al crear picado del reloj: " + ex.Message);
            }
        }

        public void ModificarPicadoReloj(cPicado oPicado)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarPicadoReloj", oPicado.CodigoPicado, oPicado.TrabajadorReloj.CodigoReloj, oPicado.Picado);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al crear picado del reloj: " + ex.Message);
            }
        }

        public List<cPicado> ListaPicadoxMes(cTrabajadorReloj miTrabajadorReloj, DateTime FechaMes)
        {
            try
            {
                List<cPicado> Lista = new List<cPicado>();

                DataTable oData = new DataTable();
                oData = Conexion.GDatos.TraerDataTable("spListarPicadoRelojxMes", miTrabajadorReloj.CodigoReloj, FechaMes);

                foreach (DataRow item in oData.Rows)
                {
                    cPicado oNuevoPicado = new cPicado();
                    oNuevoPicado.CodigoPicado = Convert.ToInt16(item["idtpicadoreloj"].ToString());
                    oNuevoPicado.Picado = Convert.ToDateTime(item["fecha"].ToString());
                    oNuevoPicado.TrabajadorReloj.CodigoReloj = Convert.ToInt16(item["idtreloj"].ToString());

                    Lista.Add(oNuevoPicado);
                }

                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al listar los picados del reloj: " + ex.Message);
            }
        }

        public List<cPicado> ListaPicadoxDia(cTrabajadorReloj miTrabajadorReloj, DateTime FechaMes)
        {
            try
            {
                List<cPicado> Lista = new List<cPicado>();

                DataTable oData = new DataTable();
                oData = Conexion.GDatos.TraerDataTable("spListarPicadoRelojxDia", miTrabajadorReloj.CodigoReloj, FechaMes);

                foreach (DataRow item in oData.Rows)
                {
                    cPicado oNuevoPicado = new cPicado();
                    oNuevoPicado.CodigoPicado = Convert.ToInt16(item["idtpicadoreloj"].ToString());
                    oNuevoPicado.Picado = Convert.ToDateTime(item["fecha"].ToString());
                    oNuevoPicado.TrabajadorReloj.CodigoReloj = Convert.ToInt16(item["idtreloj"].ToString());

                    Lista.Add(oNuevoPicado);
                }

                return Lista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al listar los picados del reloj: " + ex.Message);
            }
        }
        #endregion
    }
}
