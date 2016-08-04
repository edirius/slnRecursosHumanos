using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios
{
    public class cComisionesAFP
    {
        private decimal codigoComision;

        public decimal CodigoComision
        {
            get { return codigoComision; }
            set { codigoComision = value; }
        }
        private cAFP afp;

        public cAFP Afp
        {
            get { return afp; }
            set { afp = value; }
        }
        private DateTime mes;

        public DateTime Mes
        {
            get { return mes; }
            set { mes = value; }
        }
        private decimal primaSeguros;

        public decimal PrimaSeguros
        {
            get { return primaSeguros; }
            set { primaSeguros = value; }
        }
        private decimal aporteObligatorio;

        public decimal AporteObligatorio
        {
            get { return aporteObligatorio; }
            set { aporteObligatorio = value; }
        }
        private decimal remuneracionAsegurable;

        public decimal RemuneracionAsegurable
        {
            get { return remuneracionAsegurable; }
            set { remuneracionAsegurable = value; }
        }
        private decimal comisionFlujo;

        public decimal ComisionFlujo
        {
            get { return comisionFlujo; }
            set { comisionFlujo = value; }
        }
        private decimal comisionMixta;

        public decimal ComisionMixta
        {
            get { return comisionMixta; }
            set { comisionMixta = value; }
        }

        public DataTable ListarComisionAFP(int IdtAFP)
        {
            return Conexion.GDatos.TraerDataTable("spComisionesXAFP", IdtAFP);
        }
        
    }
}
