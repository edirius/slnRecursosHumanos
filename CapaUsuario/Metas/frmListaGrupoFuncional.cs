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
    public partial class frmListaGrupoFuncional : Form
    {
        public frmListaGrupoFuncional()
        {
            InitializeComponent();
        }
        
        cCadenaProgramaticaFuncional miCadena = new cCadenaProgramaticaFuncional();
        cFuncion miFuncion = new cFuncion();
        cDivisionFuncional miDivisionFuncional = new cDivisionFuncional();
        public  cGrupoFuncional miGrupoFuncional;

        private void frmListaGrupoFuncional_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            cboFuncion.ValueMember = "idtFuncion";
            cboFuncion.DisplayMember = "nombre";
            cboFuncion.DataSource = miCadena.ListarFunciones();
        }

        private void cboFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            miFuncion.Codigo = Convert.ToInt16(cboFuncion.SelectedValue);
            miFuncion.Nombre = cboFuncion.Text;
            cboDivisionFuncional.ValueMember = "idtDivisionFuncional";
            cboDivisionFuncional.DisplayMember = "nombre";
            cboDivisionFuncional.DataSource = miCadena.ListarDivisionFuncional(miFuncion);
        }

        private void cboDivisionFuncional_SelectedIndexChanged(object sender, EventArgs e)
        {
            miDivisionFuncional.Codigo = Convert.ToInt16(cboDivisionFuncional.SelectedValue);
            miDivisionFuncional.Nombre = cboDivisionFuncional.Text;
            dtgGrupoFuncional.DataSource = miCadena.ListarGrupoFuncional(miDivisionFuncional);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            miGrupoFuncional.Codigo = Convert.ToInt16(dtgGrupoFuncional.SelectedRows[0].Cells[0].Value);
            miGrupoFuncional.Nombre = Convert.ToString(dtgGrupoFuncional.SelectedRows[0].Cells[1].Value);
            miGrupoFuncional.GrupoFuncional = Convert.ToString(dtgGrupoFuncional.SelectedRows[0].Cells[2].Value);
            miGrupoFuncional.Año = Convert.ToInt16(dtgGrupoFuncional.SelectedRows[0].Cells[3].Value);
            miGrupoFuncional.DivisionFuncional = miDivisionFuncional;
            miGrupoFuncional.DivisionFuncional.Funcion = miFuncion;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
