using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Obras;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Planillas
{
    public class cPlanilla
    {
        int sidtplanilla;
        string snumero;
        string smes;
        string saño;
        DateTime sfecha;
        int sidtmeta;
        int sidtfuentefinanciamiento;
        int sidtregimenlaboral;
        string sdescripcion;
        string splantilla;
        string sobservaciones;

        private List<cDetallePlanilla> listaDetallePlanilla;

        private cPlantillaPlanilla oPlantilla = new cPlantillaPlanilla();

        public int IdtPlanilla
        {
            get { return sidtplanilla; }
            set { sidtplanilla = value; }
        }
        public string Numero
        {
            get { return snumero; }
            set { snumero = value; }
        }
        public string Mes
        {
            get { return smes; }
            set { smes = value; }
        }
        public string Año
        {
            get { return saño; }
            set { saño = value; }
        }
        public DateTime Fecha
        {
            get { return sfecha; }
            set { sfecha = value; }
        }
        public int IdtMeta
        {
            get { return sidtmeta; }
            set { sidtmeta = value; }
        }
        public int IdtFuenteFinanciamiento
        {
            get { return sidtfuentefinanciamiento; }
            set { sidtfuentefinanciamiento = value; }
        }
        public int IdtRegimenLaboral
        {
            get { return sidtregimenlaboral; }
            set { sidtregimenlaboral = value; }
        }
        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }
        public string Plantilla
        {
            get { return splantilla; }
            set { splantilla = value; }
        }

        public string Observaciones
        {
            get { return sobservaciones; }
            set { sobservaciones = value; }
        }

        public List<cDetallePlanilla> ListaDetallePlanilla
        {
            get
            {
                return listaDetallePlanilla;
            }

            set
            {
                listaDetallePlanilla = value;
            }
        }

        public DataTable ListarFechaPlanilla(int pidtplanilla)
        {
            return Conexion.GDatos.TraerDataTable("spListarFechaPlanilla", pidtplanilla);
        }

        public DataTable ListarMetaDePlanilla(int pidtplanilla)
        {
            return Conexion.GDatos.TraerDataTable("spListarMetaDePlanilla", pidtplanilla);
        }
        public DataTable ListarAñosPlanilla()
        {
            return Conexion.GDatos.TraerDataTable("spListarAñosPlanilla");
        }

        public DataTable ListarDetallePlanillaX(int pidtplanilla)
        {
            return Conexion.GDatos.TraerDataTable("spListarDetallePlanillaX" , pidtplanilla);
        }

        public DataTable ListarPlanillaTrabajadorX(string pMes, string pAño)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaTrabajadorX", pMes, pAño);
        }

        public DataTable ListarPlanillaX(string pMes, string pAño)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillaX",pMes,pAño);
        }

        public DataTable ListarBoletaPagoXMesYRegimenLaboral()
        {
            return Conexion.GDatos.TraerDataTable("spListarBoletaPagoXMesYRegimenLaboral");
        }

        public DataTable ListarPlantillaTrabajadorXRegimenLaboral(string pMes, string pAño, int idRegimenLaboral)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlantillaTrabajadorXRegimenLaboral", pMes, pAño, idRegimenLaboral);
        }

        public DataTable ListarRegimenLaboralPlanilla(string pNumeroPlanilla)
        {
            return Conexion.GDatos.TraerDataTable("spListarRegimenLaboralPlanilla", pNumeroPlanilla);
        }

        public DataTable ListarPLanillasXmesYaño2 (string pmes, string paño)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillasXMesAnio", pmes, paño);
        }

        public DataTable ListarPlanillaXmesYaño(string pmes, string paño )
        {
            return Conexion.GDatos.TraerDataTable("ListarPlanillaXmesYaño", pmes,paño);
        }

        public DataTable ListarPlanilla( )
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanilla" );
        }

        public Boolean CrearPlanilla(cPlanilla miPlanilla)
        {
            Conexion.GDatos.Ejecutar("spCrearPlanilla", miPlanilla.Numero, miPlanilla.Mes, miPlanilla.Año, miPlanilla.Fecha, miPlanilla.IdtMeta, miPlanilla.IdtFuenteFinanciamiento, miPlanilla.IdtRegimenLaboral, miPlanilla.Descripcion, miPlanilla.Plantilla, miPlanilla.Observaciones);
            return true;
        }

        public Boolean ModificarPlanilla(cPlanilla miPlanilla)
        {
            Conexion.GDatos.Ejecutar("spModificarPlanilla", miPlanilla.IdtPlanilla, miPlanilla.Numero, miPlanilla.Mes,miPlanilla.Año, miPlanilla.Fecha, miPlanilla.IdtMeta, miPlanilla.IdtFuenteFinanciamiento, miPlanilla.IdtRegimenLaboral, miPlanilla.Descripcion, miPlanilla.Plantilla, miPlanilla.Observaciones);
            return true;
        }

        public Boolean EliminarPlanilla(int IdtPlanilla)
        {
            Conexion.GDatos.Ejecutar("spELiminarPlanilla", IdtPlanilla);
            return true;
        }

        public cPlanilla TraerPlanilla(int idtPlanilla)
        {
            cPlanilla planillaAuxiliar = new cPlanilla();
            DataTable tablaAuxiliar;
            tablaAuxiliar = Conexion.GDatos.TraerDataTable("spTraerPlanillaxID", idtPlanilla);
            if (tablaAuxiliar.Rows.Count > 0)
            {
                planillaAuxiliar.IdtPlanilla = Convert.ToInt16(tablaAuxiliar.Rows[0][0]);
                planillaAuxiliar.Numero = Convert.ToString(tablaAuxiliar.Rows[0][1]);
                planillaAuxiliar.Mes = Convert.ToString(tablaAuxiliar.Rows[0][2]);
                planillaAuxiliar.Año = Convert.ToString(tablaAuxiliar.Rows[0][3]);
                planillaAuxiliar.Fecha = Convert.ToDateTime(tablaAuxiliar.Rows[0][4]);
                planillaAuxiliar.IdtMeta = Convert.ToInt16(tablaAuxiliar.Rows[0][5]);
                planillaAuxiliar.IdtFuenteFinanciamiento = Convert.ToInt16(tablaAuxiliar.Rows[0][6]);
                planillaAuxiliar.IdtRegimenLaboral = Convert.ToInt16(tablaAuxiliar.Rows[0][7]);
                planillaAuxiliar.Observaciones = Convert.ToString(tablaAuxiliar.Rows[0][10]);
                return planillaAuxiliar;
            }
           else
            {
                throw new cReglaNegociosException("No existe filas para el id de planilla. Funcion: TraerPlanilla");
            }
        }

        public cPlanilla TraerPLanillaConTrabajadorDuplicado(cTrabajador TrabajadorDuplicado, string Mes, int anio, int codigoPlanillaActual)
        {
            cPlanilla planillaAuxiliar= null;
            DataTable tablaAuxiliar;
            tablaAuxiliar = Conexion.GDatos.TraerDataTable("spBuscarTrabajadorEnOtraPlanilla", Mes, anio, TrabajadorDuplicado.IdTrabajador, codigoPlanillaActual);
            if (tablaAuxiliar.Rows.Count > 0)
            {
                planillaAuxiliar = new cPlanilla();
                planillaAuxiliar.IdtPlanilla = Convert.ToInt16(tablaAuxiliar.Rows[0][0]);
                planillaAuxiliar.Numero = Convert.ToString(tablaAuxiliar.Rows[0][1]);
                planillaAuxiliar.Mes = Convert.ToString(tablaAuxiliar.Rows[0][2]);
                planillaAuxiliar.Año = Convert.ToString(tablaAuxiliar.Rows[0][3]);
                planillaAuxiliar.Fecha = Convert.ToDateTime(tablaAuxiliar.Rows[0][4]);
                planillaAuxiliar.IdtMeta = Convert.ToInt16(tablaAuxiliar.Rows[0][5]);
                planillaAuxiliar.IdtFuenteFinanciamiento = Convert.ToInt16(tablaAuxiliar.Rows[0][6]);
                planillaAuxiliar.IdtRegimenLaboral = Convert.ToInt16(tablaAuxiliar.Rows[0][7]);
                planillaAuxiliar.Descripcion = tablaAuxiliar.Rows[0][8].ToString();
                planillaAuxiliar.Plantilla = tablaAuxiliar.Rows[0][9].ToString();
                planillaAuxiliar.Observaciones = tablaAuxiliar.Rows[0][10].ToString();

                cDetallePlanilla detalle = new cDetallePlanilla();
                detalle.IdtDetallePlanilla = Convert.ToInt16(tablaAuxiliar.Rows[0][11]);
                detalle.Cargo = tablaAuxiliar.Rows[0][12].ToString();
                detalle.FechaInicio = Convert.ToDateTime(tablaAuxiliar.Rows[0][13]);
                detalle.DiasLaborados = Convert.ToInt16(tablaAuxiliar.Rows[0][14]);
                detalle.TotalIngresos = Convert.ToDecimal(tablaAuxiliar.Rows[0][15]);
                detalle.TotalATrabajador = Convert.ToDecimal(tablaAuxiliar.Rows[0][16]);
                detalle.TotalDescuentos = Convert.ToDecimal(tablaAuxiliar.Rows[0][17]);
                detalle.TotalAEmpleador = Convert.ToDecimal(tablaAuxiliar.Rows[0][18]);
                detalle.NetoaCobrar = Convert.ToDecimal(tablaAuxiliar.Rows[0][19]);
                detalle.IdtTrabajador = Convert.ToInt16(tablaAuxiliar.Rows[0][20]);

                planillaAuxiliar.ListaDetallePlanilla = new List<cDetallePlanilla>();
                planillaAuxiliar.ListaDetallePlanilla.Add(detalle);

                return planillaAuxiliar;
            }
            else
            {
                return null;
            }
        }

        public cPlanilla TraerPLanillaConTrabajadorDuplicadoConCargasSociales(cTrabajador TrabajadorDuplicado, string Mes, int anio, int codigoPlanillaActual)
        {
            cPlanilla planillaAuxiliar = null;
            DataTable tablaAuxiliar;
            tablaAuxiliar = Conexion.GDatos.TraerDataTable("spBuscarTrabajadorEnOtraPlanilla", Mes, anio, TrabajadorDuplicado.IdTrabajador, codigoPlanillaActual);
            if (tablaAuxiliar.Rows.Count > 0)
            {
                planillaAuxiliar = new cPlanilla();
                planillaAuxiliar.IdtPlanilla = Convert.ToInt16(tablaAuxiliar.Rows[0][0]);
                planillaAuxiliar.Numero = Convert.ToString(tablaAuxiliar.Rows[0][1]);
                planillaAuxiliar.Mes = Convert.ToString(tablaAuxiliar.Rows[0][2]);
                planillaAuxiliar.Año = Convert.ToString(tablaAuxiliar.Rows[0][3]);
                planillaAuxiliar.Fecha = Convert.ToDateTime(tablaAuxiliar.Rows[0][4]);
                planillaAuxiliar.IdtMeta = Convert.ToInt16(tablaAuxiliar.Rows[0][5]);
                planillaAuxiliar.IdtFuenteFinanciamiento = Convert.ToInt16(tablaAuxiliar.Rows[0][6]);
                planillaAuxiliar.IdtRegimenLaboral = Convert.ToInt16(tablaAuxiliar.Rows[0][7]);
                planillaAuxiliar.Descripcion = tablaAuxiliar.Rows[0][8].ToString();
                planillaAuxiliar.Plantilla = tablaAuxiliar.Rows[0][9].ToString();
                planillaAuxiliar.Observaciones = tablaAuxiliar.Rows[0][10].ToString();

                cDetallePlanilla detalle = new cDetallePlanilla();
                detalle.IdtDetallePlanilla = Convert.ToInt16(tablaAuxiliar.Rows[0][11]);
                detalle.Cargo = tablaAuxiliar.Rows[0][12].ToString();
                detalle.FechaInicio = Convert.ToDateTime(tablaAuxiliar.Rows[0][13]);
                detalle.DiasLaborados = Convert.ToInt16(tablaAuxiliar.Rows[0][14]);
                detalle.TotalIngresos = Convert.ToDecimal(tablaAuxiliar.Rows[0][15]);
                detalle.TotalATrabajador = Convert.ToDecimal(tablaAuxiliar.Rows[0][16]);
                detalle.TotalDescuentos = Convert.ToDecimal(tablaAuxiliar.Rows[0][17]);
                detalle.TotalAEmpleador = Convert.ToDecimal(tablaAuxiliar.Rows[0][18]);
                detalle.NetoaCobrar = Convert.ToDecimal(tablaAuxiliar.Rows[0][19]);
                detalle.IdtTrabajador = Convert.ToInt16(tablaAuxiliar.Rows[0][20]);

                planillaAuxiliar.ListaDetallePlanilla = new List<cDetallePlanilla>();
                planillaAuxiliar.ListaDetallePlanilla.Add(detalle);

                oPlantilla = oPlantilla.TraerPlantillaxDescripcion(planillaAuxiliar.Plantilla);
                if (oPlantilla.Descripcion == "RACIONAMIENTO")
                {
                    return null;
                }
                else
                {
                    return planillaAuxiliar;
                }
                
            }
            else
            {
                return null;
            }
        }
    }
}
