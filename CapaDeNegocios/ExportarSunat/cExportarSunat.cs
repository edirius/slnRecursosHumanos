using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;
using System.IO;
using System.Collections;

namespace CapaDeNegocios.ExportarSunat
{
    public class cExportarSunat
    {
        string Palo = "|";
        public string ExportarTexto(string tipoDoc, string dni, string codigo, string montodevengado, string monto)
        {
            
            string ConcatenarCuerpo = "";
            ConcatenarCuerpo = tipoDoc + "|" + dni + "|" + codigo + "|" + montodevengado + "|" + monto + Palo;
            
            return ConcatenarCuerpo;
            
        }
        public string ExportarTitulo(string codigoform, string año, string mes, string ruc)
        {
            string ConcatenarTitulo = codigoform + año + mes + ruc + ".rem";
            return ConcatenarTitulo;
        }
        public DataTable ListarTrabajadoresPorPlanillaIngresos(string numero)
        {
            return Conexion.GDatos.TraerDataTable("spExportarIngresos", numero);
        }
        public DataTable ListarTrabajadoresPorPlanillaDescuentos(string numero)
        {
            return Conexion.GDatos.TraerDataTable("spExportarDescuentos", numero);
        }
        public DataTable ListarTrabajadoresPorPlanillaAportaciones(string numero)
        {
            return Conexion.GDatos.TraerDataTable("spExportarAportaciones", numero);
        }
        //spListarMaestroIngresosporTipo
        public DataTable ListarMaestroIngresosxTipo(string Tipo)
        {
            return Conexion.GDatos.TraerDataTable("spListarMaestroIngresosporTipo", Tipo);
        }
        public DataTable ListarPlanillas(string aAño)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillasExportar", aAño);
        }
        
        public DataTable ListarExportarAFPaExcel(string idplanilla)
        {
            return Conexion.GDatos.TraerDataTable("spExportarAFPaExcel", idplanilla);
        }
        
        public DataTable ListarTodoExportarAFPaExcel()
        {
            return Conexion.GDatos.TraerDataTable("spListarTodoExportarAFP");
        }
        public DataTable BuscarPlanillas(string mes, string año)
        {
            return Conexion.GDatos.TraerDataTable("spBuscarPlanillasExportar", mes, año);
        }
        
        public DataTable ListarDatosDelTrabajadorporFecha(string mes, string año)
        {
            return Conexion.GDatos.TraerDataTable("spExportarDatosTrabajador", mes, año);
        }
        public DataTable ListarDatosDelPensionistaporFecha(DateTime fecha1, DateTime fecha2)
        {
            return Conexion.GDatos.TraerDataTable("spExportarPensionistas", fecha1, fecha2);
        }

        ////////EXPORTAR DATOS DE LOS TRABAJADORES A LA SUNAT//////

        public DataTable ListarTrabajadoresporFechaInicio(string aMes, string aAño)
        {
            return Conexion.GDatos.TraerDataTable("spListarTrabajadoresporFecha", aMes, aAño);
        }
        public string ExportarDatosTrabajador(string tipoDoc, string dni, string paisEmisor, string fechaNac, string apPaterno, string apMaterno,
        string nombres, string sexo, string nacionalidad, string telLargaDis, string tel, string correo, string tipoVia, string nombreVia, string nroVia,
        string departamento, string interior, string manzana, string lote, string kilometro, string block, string etapa, string tipoZona, string nombreZona,
        string referencia, string ubigeo, string tipoVia2, string nombreVia2, string nroVia2, string departamento2, string interior2, string manzana2, string lote2,
        string kilometro2, string block2, string etapa2, string tipoZona2, string nombreZona2, string referencia2,
        string ubigeo2, string indicadorAsistenciaESSALUD)
        {
            string ConcatenarContenido = tipoDoc + Palo + dni + "|" + paisEmisor + "|" + fechaNac + "|" + apPaterno + "|" + apMaterno + "|" + nombres +
                "|" + sexo + "|" + nacionalidad + "|" + telLargaDis + "|" + tel + "|" + correo + "|" + tipoVia + "|" + nombreVia + "|" + nroVia + "|" +
                 departamento + "|" + interior + "|" + manzana + "|" + lote + "|" + kilometro + "|" + block + "|" + etapa + "|" + tipoZona + "|" + nombreZona + "|" + referencia + "|" + 
                ubigeo + "|" + tipoVia2 + "|" + nombreVia2 + "|" + nroVia2 + "|" + departamento2 + "|" + interior2 + "|" + manzana2 + "|" + lote2 + "|" +
                  kilometro2 + "|" + block2 + "|" + etapa2 + "|" + tipoZona2 + "|" + nombreZona2 + "|" + referencia2 + "|" + ubigeo2 + "|" + indicadorAsistenciaESSALUD + "|";
            return ConcatenarContenido;
        }
        public string ExportarDatosTrabajador2(string tipoDoc, string dni, string paisDoc, string regimenlaboral, string situacionEdu, string ocupacion, string discapacidad, string CUSPP, string SCTRpension, string tipoContrato, string regimenAlternativo, string jornadaTrabajo, string horarioNocturno, string sindicalizado, string periodicidad, string remBasica, string situacion, string Renta5ta, string situacionEsp, string tipoPago, string catOcupacional, string convenio, string RUC)
        {
            string ConcatenarDatos = tipoDoc + Palo + dni + Palo + paisDoc + Palo + regimenlaboral + Palo + situacionEdu + Palo + ocupacion + Palo + discapacidad + Palo + CUSPP + Palo + SCTRpension + Palo + tipoContrato + Palo + regimenAlternativo + Palo + jornadaTrabajo + Palo + horarioNocturno + Palo + sindicalizado + Palo + periodicidad + Palo + remBasica + Palo + situacion + Palo + Renta5ta + Palo + situacionEsp + Palo + tipoPago + Palo + catOcupacional + Palo + convenio + Palo + RUC + Palo;
            return ConcatenarDatos;
        }
        public string ExportarPeriodos(string tipoDoc, string dni, string paisDoc, string Categoria, string tipoRegistro, string fechainicio, string fechafin, string indicadorTipoRegistro, string EPS)
        {
            string Concatenar = tipoDoc + Palo + dni + Palo + paisDoc + Palo + Categoria + Palo + tipoRegistro + Palo + fechainicio + Palo + fechafin + Palo + indicadorTipoRegistro + Palo + EPS + Palo;
            return Concatenar;
        }
        public string ExportarEstablecimiento(string tipoDoc, string dni, string paisDoc, string ruc, string codEstab)
        {
            string Concatenar = tipoDoc + Palo + dni + Palo + paisDoc + Palo + ruc + Palo + codEstab + Palo;
            return Concatenar;
        }
        public DataTable ListarPeriodos(string mes, string año)
        {
            return Conexion.GDatos.TraerDataTable("spExportarPeriodos", mes, año);
        }
        public DataTable ListarEstablecimientos(string mes, string año)
        {
            return Conexion.GDatos.TraerDataTable("spExportarEstablecimientos", mes, año);
        }
        public DataTable EXPORTARTODO(string aMes, string aAño)
        {
            return Conexion.GDatos.TraerDataTable("spExportarTodo", aMes, aAño);
        }
    }
}
