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

            miPdf.ImprimirPlanilla(oPlanilla);

        
        }
    }
}
