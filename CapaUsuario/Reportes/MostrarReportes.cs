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
    public partial class MostrarReportes : Form
    {
        string Reporte = "TareoObras";

        int sidtmeta;
        int sidttareo;

        public int IdTMeta
        {
            get { return sidtmeta; }
            set { sidtmeta = value; }
        }

        public int IdTTareo
        {
            get { return sidttareo; }
            set { sidttareo = value; }
        }

        public MostrarReportes()
        {
            InitializeComponent();
        }

        private void MostrarReportes_Load(object sender, EventArgs e)
        {
            this.spTareoObrasTableAdapter.Fill(this.bdpersonal.spTareoObras, sidtmeta, IdTTareo);

            //ReportDataSource NuevaFuenteDatos = new ReportDataSource();
            ////reportViewer1.LocalReport.DataSources.Clear();
            //if (Reporte == "TareoObras")
            //{
            //    reportViewer1.LocalReport.ReportEmbeddedResource = "TareoObras.rdlc";
            //    NuevaFuenteDatos.Name = "TareoObras";
            //    NuevaFuenteDatos.Value = spTareoObrasBindingSource;
            //    reportViewer1.LocalReport.DataSources.Add(NuevaFuenteDatos);
            //}

            this.reportViewer1.RefreshReport();
        }

        private void spTareoObrasBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
