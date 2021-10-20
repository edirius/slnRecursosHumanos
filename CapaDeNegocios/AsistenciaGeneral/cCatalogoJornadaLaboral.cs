using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.AsistenciaGeneral
{
    public class cCatalogoJornadaLaboral
    {

        /// <summary>
        /// Funcion que devuelve los dias que estan subsidiados o con falta guardados en al base de datos
        /// </summary>
        /// <param name="miTrabajador"></param>
        /// <param name="Inicio"></param>
        /// <param name="Fin"></param>
        /// <returns></returns>
        public CapaDeNegocios.AsistenciaGeneral.cJornadaLaboral TraerJornadaLaboralEntreFechas(cTrabajador miTrabajador, DateTime Inicio, DateTime Fin)
        {
            try
            {
                CapaDeNegocios.Asistencia.cAsistenciaTrabajador oAsistencia = new Asistencia.cAsistenciaTrabajador();

                DataTable oTabla = oAsistencia.ListarAsistenciaTrabajadorEntreFECHAS(miTrabajador.IdTrabajador, Inicio, Fin);

                CapaDeNegocios.AsistenciaGeneral.cJornadaLaboral oJornada = new cJornadaLaboral();

                for (int i = 0; i < oTabla.Rows.Count; i++)
                {
                    
                    CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral oDetalle = new cDetalleJornadaLaboral();
                    oDetalle.Trabajador = miTrabajador;
                    oDetalle.Codigo = Convert.ToInt32(oTabla.Rows[i]["idtasistenciatrabajador"].ToString());
                    oDetalle.Dia = Convert.ToDateTime(oTabla.Rows[i]["fecha"].ToString());
                    string tipo = oTabla.Rows[i]["tipo"].ToString();
                    switch (tipo)
                    {
                        case "F":
                            oDetalle.TipoDia = cDetalleJornadaLaboral.enumTipoDiaJornada.NoLaborado;
                            oDetalle.SuspensionLaboral = this.TrearTipoSuspencionLaboralxCodigoAsistencia(oDetalle.Codigo);
                            break;
                        case "S":
                            oDetalle.TipoDia = cDetalleJornadaLaboral.enumTipoDiaJornada.Subsidiado;
                            oDetalle.SuspensionLaboral = this.TrearTipoSuspencionLaboralxCodigoAsistencia(oDetalle.Codigo);
                            break;
                        case "N":
                            oDetalle.TipoDia = cDetalleJornadaLaboral.enumTipoDiaJornada.Laborado;
                            break;
                        case "T":
                            oDetalle.TipoDia = cDetalleJornadaLaboral.enumTipoDiaJornada.Tardanza;
                            break;
                        case "L":
                            oDetalle.TipoDia = cDetalleJornadaLaboral.enumTipoDiaJornada.Feriado;
                            break;
                        default:
                            break;
                    }
                    oJornada.ListaDetalleJornadaLaboral.Add(oDetalle);
                }

                return oJornada;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo TraerJornadaLaboral: " + ex.Message);
            }
        }

        /// <summary>
        /// Metodo para traer suspencionlaboral a partir del codigo de asistencia trabajador
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public CapaDeNegocios.Sunat.cTipoSuspencionLaboral TrearTipoSuspencionLaboralxCodigoAsistencia(int Codigo)
        {
            try
            {
                CapaDeNegocios.Sunat.cTipoSuspencionLaboral miSuspension = null;

                DataTable oTabla = Conexion.GDatos.TraerDataTable("spTraerSuspencionLaboralxCodigo", Codigo);
                for (int i = 0; i < oTabla.Rows.Count;  i++)
                {
                    miSuspension = new Sunat.cTipoSuspencionLaboral();
                    miSuspension.IdtTipoSuspencionLaboral = Convert.ToInt32(oTabla.Rows[i]["idttiposuspencionlaboral"].ToString());
                    miSuspension.Codigo = oTabla.Rows[i]["codigo"].ToString();
                    miSuspension.Descripcion = oTabla.Rows[i]["descripcion"].ToString();
                    miSuspension.Abreviacion = oTabla.Rows[i]["abreviacion"].ToString();
                }
                return miSuspension;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo traerTipoSuspencionLaboral :" + ex.Message);
            }
        }

        public void ActualizarDetalleSuspensionLaboral(cDetalleJornadaLaboral DetalleAntiguo, cDetalleJornadaLaboral DetalleNuevo)
        {
            CapaDeNegocios.Asistencia.cAsistenciaSuspencionLaboral miAsistenciaSuspencionLaboral = new Asistencia.cAsistenciaSuspencionLaboral();
            CapaDeNegocios.Asistencia.cAsistenciaTrabajador miAsistenciaTrabajador = new CapaDeNegocios.Asistencia.cAsistenciaTrabajador();

            if (DetalleAntiguo != null)
            {
                if (DetalleAntiguo.SuspensionLaboral != null)
                {
                    miAsistenciaSuspencionLaboral.EliminarAsistenciaSuspencionLaboral(DetalleAntiguo.Codigo);

                }
                miAsistenciaTrabajador.EliminarAsistenciaTrabajador(DetalleAntiguo.Codigo);

                CrearJornadaLaboral(DetalleNuevo);
                if (DetalleNuevo != null && DetalleNuevo.SuspensionLaboral != null)
                {
                    DataTable oAsistenciaTrabajador = new DataTable();
                    oAsistenciaTrabajador = miAsistenciaTrabajador.ListarAsistenciaTrabajador(DetalleNuevo.Trabajador.IdTrabajador);
                    DetalleNuevo.Codigo = Convert.ToInt32(oAsistenciaTrabajador.Compute("MAX(idtasistenciatrabajador)", ""));
                    CrearSuspensionLaboral(DetalleNuevo);
                }
            }
            else
            {
                CrearJornadaLaboral(DetalleNuevo);
                if (DetalleNuevo != null && DetalleNuevo.SuspensionLaboral != null)
                {
                    DataTable oAsistenciaTrabajador = new DataTable();
                    oAsistenciaTrabajador = miAsistenciaTrabajador.ListarAsistenciaTrabajador(DetalleNuevo.Trabajador.IdTrabajador);
                    DetalleNuevo.Codigo = Convert.ToInt32(oAsistenciaTrabajador.Compute("MAX(idtasistenciatrabajador)", ""));
                    CrearSuspensionLaboral(DetalleNuevo);
                }
            }

        }

        public void ActualizarDetalleSuspensionLaboral(CapaDeNegocios.Asistencia.cAsistenciaMes AsistenciaMes, cJornadaLaboral JornadaLaboral)
        {
            try
            {
                foreach (CapaDeNegocios.Asistencia.cAsistenciaDia item in AsistenciaMes.ListaAsistenciaDia)
                {
                    bool Encontrado = false;
                    foreach (cDetalleJornadaLaboral item2 in JornadaLaboral.ListaDetalleJornadaLaboral)
                    {
                        //verificamos que es el mismo dia
                        if (item.Dia.Date == item2.Dia.Date)
                        {
                            Encontrado = true;
                            if (EsDiferente(item, item2))
                            {
                                Actualizar(item, item2);
                            }
                        }
                    }
                    //Significa que no se encontro una jornada laboral en la base de datos
                    if (!Encontrado)
                    {
                        cDetalleJornadaLaboral item3 = new cDetalleJornadaLaboral();
                        item3.Codigo = 0;
                        item3.Dia = item.Dia;
                        item3.SuspensionLaboral = null;
                        item3.TipoDia = cDetalleJornadaLaboral.enumTipoDiaJornada.Laborado;
                        item3.Trabajador = AsistenciaMes.Trabajador;

                        Actualizar(item, item3);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error en el metodo ActualizarDetalleSuspensionLaboral: " + ex.Message);
            }
        }

        private bool EsDiferente(CapaDeNegocios.Asistencia.cAsistenciaDia item, cDetalleJornadaLaboral item2)
        {
            bool llave = false;

            if (item.DiaLibre)
            {
                if (item2.TipoDia == cDetalleJornadaLaboral.enumTipoDiaJornada.Laborado)
                {
                    llave = false;
                }
                else
                {
                    llave = true;
                }
            }
            else if (item.Tarde)
            {
                if (item2.TipoDia == cDetalleJornadaLaboral.enumTipoDiaJornada.Tardanza)
                {
                    llave = false;
                }
                else
                {
                    llave = true;
                }
            }
            else
            {
                switch (item.Falta)
                {
                    case Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoEntrada:
                    case Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoFinal:
                    case Asistencia.cAsistenciaDia.TipoFalta.FaltaTotal:
                        if (item2.TipoDia == cDetalleJornadaLaboral.enumTipoDiaJornada.NoLaborado)
                        {
                            llave = false;
                        }
                        else
                        {
                            llave = true;
                        }
                        break;
                    case Asistencia.cAsistenciaDia.TipoFalta.FaltaJustificada:
                        if (item2.TipoDia == cDetalleJornadaLaboral.enumTipoDiaJornada.Justificado)
                        {
                            llave = false;
                        }
                        else
                        {
                            llave = true;
                        }
                        break;
                    case Asistencia.cAsistenciaDia.TipoFalta.SinFalta:
                        if (item2.TipoDia == cDetalleJornadaLaboral.enumTipoDiaJornada.Laborado)
                        {
                            llave = false;
                        }
                        else
                        {
                            llave = true;
                        }
                        break;
                }
            }

            return llave;
        }

        private void Actualizar(CapaDeNegocios.Asistencia.cAsistenciaDia item, cDetalleJornadaLaboral item2)
        {
            CapaDeNegocios.Asistencia.cAsistenciaSuspencionLaboral miAsistenciaSuspencionLaboral = new Asistencia.cAsistenciaSuspencionLaboral();
            CapaDeNegocios.Asistencia.cAsistenciaTrabajador miAsistenciaTrabajador = new CapaDeNegocios.Asistencia.cAsistenciaTrabajador();
            //Verificamos si la jornada es normal o null
            //Si es null significa que es normal
            if (item2.Codigo == 0)
            {
                item2 = DevolverJornadaAPartirAsistencia(item, item2.Trabajador);
                CrearJornadaLaboral(item2);
                if (item2 != null && item2.SuspensionLaboral != null)
                {
                    DataTable oAsistenciaTrabajador = new DataTable();
                    oAsistenciaTrabajador = miAsistenciaTrabajador.ListarAsistenciaTrabajador(item2.Trabajador.IdTrabajador);
                    item2.Codigo = Convert.ToInt32(oAsistenciaTrabajador.Compute("MAX(idtasistenciatrabajador)", ""));
                    CrearSuspensionLaboral(item2);
                }
            }
            else
            //Sginifica que tiene registrado un registro de jornada laboral y  lo eliminamos
            {
                if (item2.SuspensionLaboral != null)
                {
                    miAsistenciaSuspencionLaboral.EliminarAsistenciaSuspencionLaboral(item2.Codigo);
                    
                }
                miAsistenciaTrabajador.EliminarAsistenciaTrabajador(item2.Codigo);
                //luego creamos el nuevo
                item2 = DevolverJornadaAPartirAsistencia(item, item2.Trabajador);
                CrearJornadaLaboral(item2);
                if (item2.SuspensionLaboral != null)
                {
                    DataTable oAsistenciaTrabajador = new DataTable();
                    oAsistenciaTrabajador = miAsistenciaTrabajador.ListarAsistenciaTrabajador(item2.Trabajador.IdTrabajador);
                    item2.Codigo = Convert.ToInt32(oAsistenciaTrabajador.Compute("MAX(idtasistenciatrabajador)", ""));
                    CrearSuspensionLaboral(item2);
                }
            }
        }



        private void CrearJornadaLaboral(cDetalleJornadaLaboral miDetalle)
        {
            if (miDetalle != null)
            {
                string valor = "";
                switch (miDetalle.TipoDia)
                {
                    case cDetalleJornadaLaboral.enumTipoDiaJornada.Laborado:
                        valor = "N";
                        break;
                    case cDetalleJornadaLaboral.enumTipoDiaJornada.Justificado:
                        valor = "J";
                        break;
                    case cDetalleJornadaLaboral.enumTipoDiaJornada.Subsidiado:
                        valor = "S";
                        break;
                    case cDetalleJornadaLaboral.enumTipoDiaJornada.NoLaborado:
                        valor = "F";
                        break;
                    case cDetalleJornadaLaboral.enumTipoDiaJornada.Tardanza:
                        valor = "T";
                        break;
                    case cDetalleJornadaLaboral.enumTipoDiaJornada.Feriado:
                        valor = "N";
                        break;
                    default:
                        break;
                }
                if (valor != "N")
                {
                    Conexion.GDatos.Ejecutar("spCrearAsistenciaTrabajador", miDetalle.Dia, valor, miDetalle.Trabajador.IdTrabajador);
                }
            }
            
            
        }

        private void CrearSuspensionLaboral(cDetalleJornadaLaboral miDetalle)
        {
            Conexion.GDatos.Ejecutar("spCrearAsistenciaSuspencionLaboral", miDetalle.Codigo, miDetalle.SuspensionLaboral.IdtTipoSuspencionLaboral);
        }

        private CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral DevolverJornadaAPartirAsistencia(CapaDeNegocios.Asistencia.cAsistenciaDia item, CapaDeNegocios.cTrabajador mitrabajador)
        {
            CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral NuevaJornada = new cDetalleJornadaLaboral();
            NuevaJornada.Trabajador = mitrabajador;
            if (item.DiaLibre)
            {
                NuevaJornada = null;
            }
            else if (item.Tarde)
            {
                NuevaJornada.Dia = item.Dia;
                NuevaJornada.TipoDia = cDetalleJornadaLaboral.enumTipoDiaJornada.Tardanza;
            }
            else
            {
                switch (item.Falta)
                {
                    case Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoEntrada:
                    case Asistencia.cAsistenciaDia.TipoFalta.FaltaPicadoFinal:
                    case Asistencia.cAsistenciaDia.TipoFalta.FaltaTotal:
                        NuevaJornada.Dia = item.Dia;
                        NuevaJornada.TipoDia = cDetalleJornadaLaboral.enumTipoDiaJornada.NoLaborado;
                        NuevaJornada.SuspensionLaboral = new Sunat.cTipoSuspencionLaboral();
                        NuevaJornada.SuspensionLaboral.IdtTipoSuspencionLaboral = 7;
                        break;
                    case Asistencia.cAsistenciaDia.TipoFalta.FaltaJustificada:
                        NuevaJornada.Dia = item.Dia;
                        NuevaJornada.TipoDia = cDetalleJornadaLaboral.enumTipoDiaJornada.Justificado;
                        break;
                    case Asistencia.cAsistenciaDia.TipoFalta.SinFalta:
                        NuevaJornada = null;
                        break;
                }
            }

            return NuevaJornada;
        }
    }
}
