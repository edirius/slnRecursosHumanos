using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Reportes
{
    public partial class frmAnaliticoPlanilla : Form
    {
        public frmAnaliticoPlanilla()
        {
            InitializeComponent();
           
        }
        CapaDeNegocios.PlanillaNueva.blPlanilla oblPlanilla = new CapaDeNegocios.PlanillaNueva.blPlanilla();
        CapaDeNegocios.PlanillaNueva.cnPlanilla oPlanilla = new CapaDeNegocios.PlanillaNueva.cnPlanilla();


        

        CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
        string FechaTexto = "";
        int sidtfuentefinanciamiento = 0;
        string sfuentefinanciamiento = "";

        private void frmAnaliticoPlanilla_Load(object sender, EventArgs e)
        {
            DateTime Ahora = DateTime.Today;
            CargarMes(Ahora);
            AgregarColumnasDataGrig();
        }


        public void CargarMes(DateTime FechaActual)
        {
            DataTable odtAños = new DataTable();

            string Ahora = Convert.ToString(FechaActual.Date.Month);
            switch (Ahora)
            {
                case "1":
                    {
                        FechaTexto = "ENERO";
                        break;
                    }
                case "2":
                    {
                        FechaTexto = "FEBRERO";
                        break;
                    }
                case "3":
                    {
                        FechaTexto = "MARZO";
                        break;
                    }
                case "4":
                    {
                        FechaTexto = "ABRIL";
                        break;
                    }
                case "5":
                    {
                        FechaTexto = "MAYO";
                        break;
                    }
                case "6":
                    {
                        FechaTexto = "JUNIO";
                        break;
                    }
                case "7":
                    {
                        FechaTexto = "JULIO";
                        break;
                    }
                case "8":
                    {
                        FechaTexto = "AGOSTO";
                        break;
                    }
                case "9":
                    {
                        FechaTexto = "SETIEMBRE";
                        break;
                    }
                case "10":
                    {
                        FechaTexto = "OCTUBRE";
                        break;
                    }
                case "11":
                    {
                        FechaTexto = "NOVIEMBRE";
                        break;
                    }
                case "12":
                    {
                        FechaTexto = "DICIEMBRE";
                        break;
                    }
            }

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
            odtAños = miPlanilla.ListarAñosPlanilla();
            cboAño.DataSource = odtAños;
            cboAño.DisplayMember = "añó";
            cboAño.ValueMember = "año";
            cboMes.Text = FechaTexto;
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

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void AgregarColumnasDataGrig()
        {
            DataGridViewCheckBoxColumn Check = new DataGridViewCheckBoxColumn();//creamos un objeto check
            {
                Check.Name = "☑";//le damos un nombre de cabecera
                dgvPlanilla.Columns.Add(Check);//agregamos los check a cada items
            }
            dgvPlanilla.Columns["☑"].DisplayIndex = 0;
            dgvPlanilla.Columns["☑"].Width = 30;
        }

        private void CargarDatos()
        {
            try
            {
                dgvPlanilla.Rows.Clear();
                DataTable oDataPlanilla = new DataTable();
                oDataPlanilla = miPlanilla.ListarPlanilla();

               
                CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
               
                DataTable oDataFuenteFinanciamiento = new DataTable();
                CapaDeNegocios.cFuenteFinanciamiento miFuenteFinanciamietno = new CapaDeNegocios.cFuenteFinanciamiento();
                oDataFuenteFinanciamiento = miFuenteFinanciamietno.ListarFuenteFinanciamiento();

                CapaDeNegocios.Obras.cMeta oMeta = new CapaDeNegocios.Obras.cMeta();

                foreach (DataRow row in oDataPlanilla.Select("año ='" + cboAño.Text + "' AND mes ='" + cboMes.Text + "'"))
                {
                    oMeta = miMeta.TraerMeta(Convert.ToInt32(row[5].ToString()));
                   
                    foreach (DataRow roww in oDataFuenteFinanciamiento.Select("idtfuentefinanciamiento ='" + row[6].ToString() + "'"))
                    {
                        sidtfuentefinanciamiento = Convert.ToInt32(roww[0]);
                        sfuentefinanciamiento = roww[2].ToString();
                    }
                    dgvPlanilla.Rows.Add(row[0].ToString(), row[1].ToString(), row[8].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), oMeta.Codigo, oMeta.Nombre, oMeta.Numero, sidtfuentefinanciamiento, sfuentefinanciamiento, row[7].ToString(), row[9].ToString());
                }
                if (dgvPlanilla.Rows.Count > 0)
                {
                    DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
                    dgvPlanilla.Rows[0].Selected = true;
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CapaDeNegocios.Reportes.cReporteResumenAnalitico miResumenAnalitico;
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "PDF (*.pdf)|*.pdf";
                fichero.FileName = "ResumenAnalitico_" + DateTime.Now.Month + ".pdf";
                int contador=0;

                foreach (DataGridViewRow row in dgvPlanilla.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["☑"].Value) == true)
                    {
                        contador++;
                    }
                }

                if (contador > 1)
                {
                    MessageBox.Show("Para este reporte solo puede escoger una planilla. Deseleccione las demas planillas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        foreach (DataGridViewRow row in dgvPlanilla.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["☑"].Value) == true)
                            {
                                oPlanilla = oblPlanilla.TraerPlanilla(Convert.ToInt16(Convert.ToInt32(row.Cells[0].Value)));

                                miResumenAnalitico = new CapaDeNegocios.Reportes.cReporteResumenAnalitico(oPlanilla, fichero.FileName);
                            }
                        }
                    }
                }
            }
            catch (Exception m)
            {
                MessageBox.Show("Error al imprimir: " + m.Message, "Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
            }


        }
    }
}
