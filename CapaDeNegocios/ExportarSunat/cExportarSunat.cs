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
            ConcatenarCuerpo = tipoDoc + "|" + dni + "|" + codigo + "|" + montodevengado + "|" + monto + '\n';
            
            return ConcatenarCuerpo;
            
        }
        public string ExportarTitulo(string codigoform, string año, string mes, string ruc)
        {
            string ConcatenarTitulo = codigoform + año + mes + ruc + ".rem";
            return ConcatenarTitulo;
        }
        public DataTable ListarTrabajadoresPorPlanilla(string numero)
        {
            return Conexion.GDatos.TraerDataTable("spExportarTributosTrabajadores", numero);
        }
        //spListarMaestroIngresosporTipo
        public DataTable ListarMaestroIngresosxTipo(string Tipo)
        {
            return Conexion.GDatos.TraerDataTable("spListarMaestroIngresosporTipo", Tipo);
        }
        public DataTable ListarPlanillas()
        {
            return Conexion.GDatos.TraerDataTable("spListarPlanillas");
        }
        public DataTable BuscarPlanillas(string mes, string año)
        {
            return Conexion.GDatos.TraerDataTable("spBuscarPlanillas", mes, año);
        }
        public DataTable ListarDatosDelTrabajador()
        {
            return Conexion.GDatos.TraerDataTable("spExportarDatosTrabajadores");
        }

        ////////EXPORTAR DATOS DE LOS TRABAJADORES A LA SUNAT//////
        public DataTable ListarTrabajadores()
        {
            return Conexion.GDatos.TraerDataTable("spListarTrabajadoresaExportar");
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

    }
}
