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
                    miSuspension.IdtTipoSuspencionLaboral = Convert.ToInt32(oTabla.Rows[i]["idttiposuspensionlaboral"].ToString());
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
    }
}
