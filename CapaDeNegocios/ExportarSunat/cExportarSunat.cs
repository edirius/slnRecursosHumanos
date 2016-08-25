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

    }
}
