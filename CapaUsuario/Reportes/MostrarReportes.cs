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
using CapaUsuario.Properties;

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

        string Reporte = ""; string sestado; int sidtmeta; int sidttareo; int sidtplanilla; int sidttrabajador; string smunicipalidad;

        public MostrarReportes()
        {
            InitializeComponent();
        }

        private void MostrarReportes_Load(object sender, EventArgs e)
        {
            try
            {
                if (Reporte == "ReporteTareosResumen")
                {
                    CapaUsuario.Reportes.crTareoResumen crReporteTareos = new crTareoResumen();
                    IdtMeta(crReporteTareos, sidtmeta);
                    IdtTareo(crReporteTareos, sidttareo);
                    crystalReportViewer1.ReportSource = crReporteTareos;
                    crystalReportViewer1.Refresh();
                }
                else if(Reporte == "ReporteTareos")
                {
                    CapaUsuario.Reportes.crTareo crReporteTareos = new crTareo();
                    IdtMeta(crReporteTareos, sidtmeta);
                    IdtTareo(crReporteTareos, sidttareo);
                    crystalReportViewer1.ReportSource = crReporteTareos;
                    crystalReportViewer1.Refresh();
                }
                else if (Reporte == "ResumenPlanillas")
                {
                    CapaUsuario.Reportes.crResumenPlanillas crResumenPlanillas = new crResumenPlanillas();
                    Estado(crResumenPlanillas, sestado);
                    IdtPlanilla(crResumenPlanillas, sidtplanilla);
                    Municipalidad(crResumenPlanillas, smunicipalidad);
                    crystalReportViewer1.ReportSource = crResumenPlanillas;
                    crystalReportViewer1.Refresh();
                }
                else if (Reporte == "ReporteContratos")
                {
                    Reportes.crReporteContratos crReporteContratos = new crReporteContratos();
                    IdtTrabajador(crReporteContratos, sidttrabajador);
                    crystalReportViewer1.ReportSource = crReporteContratos;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        public void ReporteTareos(string tipo, int pidtmeta, int pidttareo)
        {
            Reporte = tipo;
            sidtmeta = pidtmeta;
            sidttareo = pidttareo;
        }

        public void ResumenPlanillas(string tipo, string pestado, int pidtplanilla, string pmunicipalidad)
        {
            Reporte = tipo;
            sestado = pestado;
            sidtplanilla = pidtplanilla;
            smunicipalidad = pmunicipalidad;
        }

        public void ReporteContratos(string tipo, int pidttrabajador)
        {
            Reporte = tipo;
            sidttrabajador = pidttrabajador;
        }

        private void Estado(ReportClass rpt, string pestado)
        {
            crParameterDiscreteValue.Value = pestado;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["pestado"];
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }

        private void Municipalidad(ReportClass rpt, string pmunicipalidad)
        {
            crParameterDiscreteValue.Value = pmunicipalidad;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["pMunicipalidad"];
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }

        private void IdtMeta(ReportClass rpt, int pidtmeta)
        {
            crParameterDiscreteValue.Value = pidtmeta;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["pidtmeta"];
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }

        private void IdtTareo(ReportClass rpt, int pidttareo)
        {
            crParameterDiscreteValue.Value = pidttareo;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["pidttareo"];
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }

        private void IdtPlanilla(ReportClass rpt, int pidtplanilla)
        {
            crParameterDiscreteValue.Value = pidtplanilla;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["pidtplanilla"];
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }

        private void IdtTrabajador(ReportClass rpt, int pidttrabajador)
        {
            crParameterDiscreteValue.Value = pidttrabajador;
            crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["pidttrabajador"];
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }

        private void password()
        {
            TableLogOnInfos crTableLogonInfos = new TableLogOnInfos();
            TableLogOnInfo crTableLogonInfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = Settings.Default.ConexionMySql;
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
