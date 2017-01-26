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
            Conexion.GDatos.Ejecutar("spCrearPlanilla", miPlanilla.Numero, miPlanilla.Mes, miPlanilla.Año, miPlanilla.Fecha, miPlanilla.IdtMeta, miPlanilla.IdtFuenteFinanciamiento, miPlanilla.IdtRegimenLaboral, miPlanilla.Descripcion, miPlanilla.Plantilla);
            return true;
        }

        public Boolean ModificarPlanilla(cPlanilla miPlanilla)
        {
            Conexion.GDatos.Ejecutar("spModificarPlanilla", miPlanilla.IdtPlanilla, miPlanilla.Numero, miPlanilla.Mes,miPlanilla.Año, miPlanilla.Fecha, miPlanilla.IdtMeta, miPlanilla.IdtFuenteFinanciamiento, miPlanilla.IdtRegimenLaboral, miPlanilla.Descripcion, miPlanilla.Plantilla);
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
                return planillaAuxiliar;
            }
           else
            {
                throw new cReglaNegociosException("No existe filas para el id de planilla. Funcion: TraerPlanilla");
            }
        }
    }
}
