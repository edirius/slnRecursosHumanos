using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;

using CrystalDecisions.Shared;
using CrystalDecisions.Windows;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Data.SqlClient;
//using System.Data.SqlClient.SqlConnection;
using System.Data.OleDb;
//using System.Web.UI.Page;

namespace CapaUsuario.Reportes
{
    public partial class MostrarReportes : Form
    {
        TableLogOnInfos crTableLogonInfos;
        TableLogOnInfo crTableLogonInfo;
        ConnectionInfo crConnectionInfo;
        ParameterFieldDefinitions crParameterFieldDefinitions;
        ParameterFieldDefinition crParameterFieldDefinition;
        ParameterValues crParameterValues = new ParameterValues();
        ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

        //string ruta = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        string Reporte = ""; string sestado; int sidtplanilla;

        public MostrarReportes()
        {
            InitializeComponent();
        }

        private void MostrarReportes_Load(object sender, EventArgs e)
        {
            //this.spTareoObrasTableAdapter.Fill(this.bdpersonal.spTareoObras, sidtmeta, IdTTareo);

            //ReportDataSource NuevaFuenteDatos = new ReportDataSource();
            ////reportViewer1.LocalReport.DataSources.Clear();
            //if (Reporte == "TareoObras")
            //{
            //    reportViewer1.LocalReport.ReportEmbeddedResource = "TareoObras.rdlc";
            //    NuevaFuenteDatos.Name = "TareoObras";
            //    NuevaFuenteDatos.Value = spTareoObrasBindingSource;
            //    reportViewer1.LocalReport.DataSources.Add(NuevaFuenteDatos);
            //}
            //this.crystalReportViewer1.RefreshReport();

            try
            {
                if (Reporte == "ResumenPlanillas")
                {
                    CapaUsuario.Reportes.crResumenPlanillas crResumenPlanillas = new crResumenPlanillas();

                    crParameterDiscreteValue.Value = sestado;
                    crParameterFieldDefinitions = crResumenPlanillas.DataDefinition.ParameterFields;
                    crParameterFieldDefinition = crParameterFieldDefinitions["pestado"];
                    crParameterValues.Add(crParameterDiscreteValue);
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                    crParameterDiscreteValue.Value = sidtplanilla;
                    crParameterFieldDefinitions = crResumenPlanillas.DataDefinition.ParameterFields;
                    crParameterFieldDefinition = crParameterFieldDefinitions["pidtplanilla"];
                    crParameterValues.Add(crParameterDiscreteValue);
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                    crystalReportViewer1.ReportSource = crResumenPlanillas;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        public void ResumenPlanillas(string tipo, string pestado, int pidtplanilla)
        {
            Reporte = tipo;
            sestado = pestado;
            sidtplanilla = pidtplanilla;
        }

        private void EstadoPlanillaTotal(object reporte, object r)
        {
            
        }

        private void Idtplanilla(object r)
        {
            //crtParamDiscreteValue = new ParameterDiscreteValue();
            //crtParamField = new ParameterField();
            //crtParamFields = new ParameterFields();

            //crtParamField.ParameterValueType = ParameterValueKind.NumberParameter;
            //crtParamField.ParameterFieldName = "pidtplanilla";
            //crtParamDiscreteValue.Value = r;
            //crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            //crtParamFields.Add(crtParamField);
        }

        private void password()
        {
            TableLogOnInfos crTableLogonInfos = new TableLogOnInfos();
            TableLogOnInfo crTableLogonInfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = "192.168.1.60";
            crConnectionInfo.DatabaseName = "bdpersonal";
            crConnectionInfo.UserID = "root";
            crConnectionInfo.Password = "root";
            crTableLogonInfo.ConnectionInfo = crConnectionInfo;
            crTableLogonInfo.TableName = "bdpersonal";
            crTableLogonInfos.Add(crTableLogonInfo);
            crTableLogonInfo.TableName = "bdpersonal";
            crTableLogonInfos.Add(crTableLogonInfo);
            crystalReportViewer1.LogOnInfo = crTableLogonInfos;
        }
    }
}
