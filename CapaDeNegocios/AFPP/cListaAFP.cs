using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios
{
    public class cListaAFP
    {
        public Boolean AgregarAfp(cAFP afp)
        {
            DataTable Auxiliar = new DataTable();
            Auxiliar = Conexion.GDatos.TraerDataTable("spCrearAFP", afp.Nombre, afp.Codigosunat, afp.Tipo);
            if (Convert.ToString (Auxiliar.Rows[0][0]) == "0")
            {
                return true;
            }
            else
            {
                throw new cReglaNegociosException(Convert.ToString(Auxiliar.Rows[0][1]));
            }
        }

        public Boolean EliminarAfp(cAFP afp)
        {
            try
            {
                if (Conexion.GDatos.Ejecutar("spEliminarAFP", afp.CodigoAFP) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new cReglaNegociosException("Error Eliminar AFP. Detalles: " + e.Message, e);
            }
            
        }

        public Boolean ModificarAfp(cAFP afp)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spModificarAFP", afp.CodigoAFP, afp.Nombre, afp.Codigosunat, afp.Tipo);
                return true;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error Modificar AFP. Detalles: " + ex.Message);
            }
            
        }

        private Boolean ComisionRepetida(cComisionesAFP miComision)
        {
            DataTable Auxiliar = Conexion.GDatos.TraerDataTable("spComisionesXAFP", miComision.Afp.CodigoAFP);
            DateTime fecha;
            Boolean error = false;
            

            for (int i = 0; i < Auxiliar.Rows.Count; i++)
            {
                fecha = Convert.ToDateTime(Auxiliar.Rows[i][2]);
                if(miComision.Mes.Month == fecha.Month & miComision.Mes.Year == fecha.Year)
                {
                    error = true;
                }
            }
            return error;
        }

        public Boolean AgregarComision(cComisionesAFP miComsion)
        {
            if (ComisionRepetida (miComsion ))
            {
                throw new cReglaNegociosException("RN: Ya existe una comision para el mes señalado");
            }

            Conexion.GDatos.Ejecutar ("spCrearComision", miComsion.Afp.CodigoAFP, miComsion.Mes, miComsion.PrimaSeguros, miComsion.AporteObligatorio, miComsion.RemuneracionAsegurable, miComsion.ComisionFlujo, miComsion.ComisionMixta    );
            return true;
        }

        public Boolean ModificarComision(cComisionesAFP miComsion)
        {
            Conexion.GDatos.Ejecutar("spModificarComisiones", miComsion.CodigoComision, miComsion.Afp.CodigoAFP, miComsion.Mes, miComsion.PrimaSeguros, miComsion.AporteObligatorio, miComsion.RemuneracionAsegurable, miComsion.ComisionFlujo, miComsion.ComisionMixta);
            return true;
        }
        public Boolean ELiminarComision(cComisionesAFP miComision)
        {
            Conexion.GDatos.Ejecutar("spEliminarComisiones", miComision.CodigoComision);
            return true;
        }

        public DataTable ObtenerListaAFP()
        {
            return Conexion.GDatos.TraerDataTable("listarAFP");
            
        }

        public List<cAFP> TraerListaAFPS()
        {
            List<cAFP> afps = new List<cAFP>();
            DataTable lista = Conexion.GDatos.TraerDataTable("listarAFP");
            foreach (DataRow item in lista.Rows)
            {
                cAFP afp = new cAFP();
                afp.CodigoAFP = Convert.ToInt32(item[0]);
                afp.Nombre = Convert.ToString(item[1]);
                afps.Add(afp);
            }
            return afps;
        }

        public cAFP TraerSNP()
        {
            DataTable lista = Conexion.GDatos.TraerDataTable("listarAFP");
            cAFP snp=new cAFP();
            foreach (DataRow item in lista.Rows)
            {
                if (item[1].ToString() =="SNP")
                {
                    snp = new cAFP();
                    snp.CodigoAFP = Convert.ToInt32(item[0]);
                    snp.Nombre = Convert.ToString(item[1]);
                }
                
            }
            return snp;
        }

        public List<cAFP> TraerListaAFPSSinSNP()
        {
            List<cAFP> afps = new List<cAFP>();
            DataTable lista = Conexion.GDatos.TraerDataTable("listarAFP");
            foreach (DataRow item in lista.Rows)
            {
                if (Convert.ToString(item[1]) != "SNP")
                {
                    cAFP afp = new cAFP();
                    afp.CodigoAFP = Convert.ToInt32(item[0]);
                    afp.Nombre = Convert.ToString(item[1]);
                    afps.Add(afp);
                }
            }
            return afps;
        }
    }
}
