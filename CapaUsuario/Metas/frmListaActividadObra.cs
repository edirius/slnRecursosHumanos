using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Obras;


namespace CapaUsuario.Metas
{
    public partial class frmListaActividadObra : Form
    {
        public cProgramaPresupuestal oProgramaPresupuestal = new cProgramaPresupuestal();
        public cProductoProyecto oProductoProyecto = new cProductoProyecto();
        public cActividadObra oActividadObra;
        public cCadenaProgramaticaFuncional miCadena = new cCadenaProgramaticaFuncional();

        public frmListaActividadObra()
        {
            InitializeComponent();
        }

        private void frmListaActividadObra_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            cboProgramaPresupuestal.ValueMember = "idtprogramapresupuestal";
            cboProgramaPresupuestal.DisplayMember = "nombre";
            cboProgramaPresupuestal.DataSource = miCadena.ListarProgramaPresupuestal();

            cboProductoProyecto.ValueMember = "idtproductoproyecto";
            cboProductoProyecto.DisplayMember = "nombre";
        }

        private void cboProgramaPresupuestal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProgramaPresupuestal.Text != string.Empty)
            {
                oProgramaPresupuestal.Codigo = Convert.ToInt16(cboProgramaPresupuestal.SelectedValue);
                oProgramaPresupuestal.Nombre = cboProgramaPresupuestal.Text;

                cboProductoProyecto.DataSource = miCadena.ListarProductoProyecto(oProgramaPresupuestal);
            }
        }

        private void cboProductoProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboProductoProyecto.ValueMember = "idtproductoproyecto";
            cboProductoProyecto.DisplayMember = "nombre";
            if (cboProductoProyecto.Text != string.Empty)
            {
                oProductoProyecto.Codigo = Convert.ToInt16(cboProductoProyecto.SelectedValue);
                oProductoProyecto.Nombre = cboProductoProyecto.Text;

                dtgActividadObra.DataSource = miCadena.ListarActividadObra(oProductoProyecto);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (dtgActividadObra.SelectedRows.Count > 0)
            {
                oActividadObra.ProductoProyecto = oProductoProyecto;
                oActividadObra.ProductoProyecto.ProgramaPresupuestal = oProgramaPresupuestal;
                oActividadObra.Codigo = Convert.ToInt16(dtgActividadObra.SelectedRows[0].Cells[0].Value);
                oActividadObra.Nombre = Convert.ToString(dtgActividadObra.SelectedRows[0].Cells[1].Value);
                oActividadObra.ActividadObra = Convert.ToString(dtgActividadObra.SelectedRows[0].Cells[2].Value);
                oActividadObra.Año = Convert.ToInt16(dtgActividadObra.SelectedRows[0].Cells[3].Value);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar una actividad / obra .");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
