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

namespace CapaUsuario.Reportes
{
    public partial class Reportes : Form
    {
        //string Reportes;

        public Reportes()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bdpersonal.spTareoObras' Puede moverla o quitarla según sea necesario.
            this.spTareoObrasTableAdapter.Fill(this.bdpersonal.spTareoObras);
            //this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            //this.reportViewer1.LocalReport.ReportPath = "D:/SISTEMA DE RECURSOS HUMANOS/slnRecursosHumanos/CapaUsuario/Reportes/Report1.rdlc";

            //ReportDataSource datos = new ReportDataSource();
            //datos.Name = "TareoObras";

            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(datos);
            this.reportViewer1.RefreshReport();
        }

        void password()
        {
            //crTableLogonInfos = new TableLogOnInfos();
            //crTableLogonInfo = new TableLogOnInfo();
            //crConnectionInfo = new ConnectionInfo();
            //crConnectionInfo.ServerName = "SERVER";
            //crConnectionInfo.DatabaseName = "BD_Calificación";
            //crConnectionInfo.UserID = "ISTTA";
            //crConnectionInfo.Password = "IESTP-T@%2014";
            //crTableLogonInfo.ConnectionInfo = crConnectionInfo;
            //crTableLogonInfo.TableName = "BD_Calificación";
            //crTableLogonInfos.Add(crTableLogonInfo);
            //crTableLogonInfo.TableName = "BD_Calificación";
            //crTableLogonInfos.Add(crTableLogonInfo);
            //crystalReportViewer1.LogOnInfo = crTableLogonInfos;
        }
    }
}
