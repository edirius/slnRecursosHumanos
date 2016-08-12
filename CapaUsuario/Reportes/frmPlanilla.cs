using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace CapaUsuario.Reportes
{
    public partial class frmPlanilla : Form
    {
        

        string numeroPlanilla = "";

        public frmPlanilla()
        {
            InitializeComponent();
        }

        private void crvPlanilla_Load(object sender, EventArgs e)
        {
             
        }

        private void frmPlanilla_Load(object sender, EventArgs e)
        {
            bdpersonalEntities pe = new bdpersonalEntities();
            crPlanilla cr1 = new crPlanilla();
            //numero de planilla
            CrystalDecisions.CrystalReports.Engine.TextObject to = (CrystalDecisions.CrystalReports.Engine.TextObject)cr1.ReportDefinition.ReportObjects["toNumero"];
            to.Text = numeroPlanilla;
            //this.crvPlanilla.ReportSource = cr1;
            //regimen laboral
            //cr1.SetParameterValue("pnumero", numeroPlanilla);
            ReportDocument oRep = new ReportDocument();
            ParameterField oPf = new ParameterField();
            ParameterFields oPfs = new ParameterFields();
            ParameterDiscreteValue oPdv = new ParameterDiscreteValue();

            oPf.Name = "pnumero";
            oPdv.Value = numeroPlanilla;
            oPf.CurrentValues.Add(oPdv);
            oPfs.Add(oPf);
            this.crvPlanilla.ParameterFieldInfo = oPfs;
            oRep.Load("C:/Users/ADVANCE/Source/Repos/slnRecursosHumanos/CapaUsuario/Reportes/crPlanilla.rpt");
            //this.crvPlanilla.ReportSource = oRep;
            this.crvPlanilla.ReportSource = cr1;

            //plantilla datos usuario

            //plantilla ingresos 

            //plantilla aportes empleador

            //plantilla aportes trabajador

            //plantilla aportes descuentos

            /*
            cr1.SetDataSource(pe.tplanilla.Select(c => new
            {
                Id = c.idtplanilla,
                Numero = c.numero
            }).ToList());
            this.crvPlanilla.ReportSource = cr1;
            */
        }

        public void RecibirDatos(string pnumeroPlanilla)
        {
            this.numeroPlanilla = pnumeroPlanilla;
        }

    }
}
