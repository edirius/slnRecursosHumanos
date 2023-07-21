using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;
using System.IO;

namespace CapaUsuario.Reportes
{
    public partial class frmPlanilla2 : Form
    {
        CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

        public frmPlanilla2()
        {
            InitializeComponent();
        }

        private void frmPlanilla2_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        public void CargarDatos()
        {
        
            cboMes.DisplayMember = "Name";
            cboMes.ValueMember = "Id";

            cboMes.Items.Add(new Item("ENERO", 1));
            cboMes.Items.Add(new Item("FEBRERO", 2));
            cboMes.Items.Add(new Item("MARZO", 3));
            cboMes.Items.Add(new Item("ABRIL", 4));
            cboMes.Items.Add(new Item("MAYO", 5));
            cboMes.Items.Add(new Item("JUNIO", 6));
            cboMes.Items.Add(new Item("JULIO", 7));
            cboMes.Items.Add(new Item("AGOSTO", 8));
            cboMes.Items.Add(new Item("SETIEMBRE", 9));
            cboMes.Items.Add(new Item("OCTUBRE", 10));
            cboMes.Items.Add(new Item("NOVIEMBRE", 11));
            cboMes.Items.Add(new Item("DICIEMBRE", 12));

            cboMes.SelectedIndex = 0;
        
            cboAño.DataSource = miPlanilla.ListarAñosPlanilla(); 
            cboAño.DisplayMember = "añó";
            cboAño.ValueMember = "año";
        }

        class Item
        {
            string _Name;
            int _Id;



            public Item(string name, int id)
            {
                _Name = name;
                _Id = id;
            }

            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }


            public int Id
            {
                get { return _Id; }
                set { _Id = value; }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dtgListaPlanillas.DataSource = miPlanilla.ListarPLanillasXmesYaño2(cboMes.GetItemText(this.cboMes.SelectedItem), cboAño.GetItemText(this.cboAño.SelectedItem));
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CapaDeNegocios.PlanillaNueva.blPlanilla oblPlanilla = new CapaDeNegocios.PlanillaNueva.blPlanilla();
            CapaDeNegocios.PlanillaNueva.cnPlanilla oPlanilla = new CapaDeNegocios.PlanillaNueva.cnPlanilla();
            CapaDeNegocios.PDF.cPDF miPdf = new CapaDeNegocios.PDF.cPDF();

            oPlanilla = oblPlanilla.TraerPlanilla(Convert.ToInt16(dtgListaPlanillas.SelectedRows[0].Cells[0].Value));

            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "PDF (*.pdf)|*.pdf";
            fichero.FileName = "PLANILLA_" + oPlanilla.numeroPlanilla + "_" + oPlanilla.Mes + "_" + oPlanilla.Año + ".pdf";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                //miPdf.ImprimirPlanilla(oPlanilla, fichero.FileName);

                CapaDeNegocios.Reportes.cReportePlanilla oReportePlanilla = new CapaDeNegocios.Reportes.cReportePlanilla();

                oReportePlanilla.ImprimirPLanilla(oPlanilla, fichero.FileName, 7);

                FileInfo file = new FileInfo(fichero.FileName);
                bool estaAbierto = false;
                estaAbierto = IsFileinUse(file, fichero.FileName);

                if (!estaAbierto)
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = fichero.FileName;
                    proc.Start();
                }
            }
        }

      protected virtual bool IsFileinUse(FileInfo file, string path)
        {
            FileStream stream = null;

            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                try
                {
                    stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                }
                catch (IOException)
                {
                    //the file is unavailable because it is:
                    //still being written to
                    //or being processed by another thread
                    //or does not exist (has already been processed)
                    return true;

                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
                return false;
            }
        }
    }
    
}
