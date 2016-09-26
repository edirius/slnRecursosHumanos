using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp;
using System.Runtime.InteropServices;

namespace CapaUsuario.Reportes
{
    public partial class frmDeclaracionJurada : Form
    {
        string paño = "";

        public frmDeclaracionJurada()
        {
            InitializeComponent();
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

        private void frmDeclaracionJurada_Load(object sender, EventArgs e)
        {
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
            DataTable odtAños = new DataTable();

            odtAños = oPlanilla.ListarAñosPlanilla();
            cboAño.DataSource = odtAños;
            cboAño.DisplayMember = "añó";
            cboAño.ValueMember = "año";

            if (odtAños.Rows.Count > 0)
                cboAño.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CapaDeNegocios.Trabajadores.cTrabajadorCas oTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorCas();
            //DataTable odtTrabajador = new 

            paño = cboAño.GetItemText(this.cboAño.SelectedItem);
            dgvDeclaracionJurada.DataSource = oTrabajador.ListarTrabajadoresParaDeclaracionJurada(paño);


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
