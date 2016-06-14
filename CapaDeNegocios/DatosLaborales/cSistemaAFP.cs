using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cSistemaAFP:cSistemaPension 
    {
        DataTable comisiones;

        public DataTable Comisiones
        {
            get { return comisiones; }
            set { comisiones = value; }
        }

        public Boolean TraerComisiones(cSistemaAFP miAFP)
        {
            Conexion.GDatos.TraerDataTable("spComisionesXAFP", miAFP.Codigo);
            return true;
        }

        public DataTable ListarSistemasPension()
        {
            return Conexion.GDatos.TraerDataTable("spListarSistemasPension", "AFP");
        }
    }
}
