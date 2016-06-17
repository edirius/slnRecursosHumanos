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
using CapaDeNegocios.DatosLaborales;


namespace CapaUsuario.Trabajador
{
    public partial class frmNuevoTipoTrabajador : Form
    {
        public frmNuevoTipoTrabajador()
        {
            InitializeComponent();
        }

        private cTipoTrabajador miTipoTrabajador = new cTipoTrabajador();

        public cPeriodoTipoTrabajador miPeriodoTipoTrabajador; 

        private void frmNuevoTipoTrabajador_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            cboTipoTrabajador.ValueMember = "idtsunattipotrabajador";
            cboTipoTrabajador.DisplayMember = "descripcion";
            cboTipoTrabajador.DataSource = miTipoTrabajador.ListarTiposDeTrabajadores();

            dtpInicioPeriodo.Value = miPeriodoTipoTrabajador.FechaInicio;
            chkFinPeriodo.Checked = miPeriodoTipoTrabajador.FechaFinal.TieneFin;
            cboTipoTrabajador.SelectedValue = miPeriodoTipoTrabajador.TipoTrabajador.Codigo;
            if (miPeriodoTipoTrabajador.FechaFinal.TieneFin)
            {
                dtpFinPeriodo.Value = miPeriodoTipoTrabajador.FechaFinal.FechaFin;
               
            }
           
            
        }

        private void chkFinPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFinPeriodo.Checked == true )
            {
                miPeriodoTipoTrabajador.FechaFinal.TieneFin = true;
                dtpFinPeriodo.Enabled = true;
                dtpFinPeriodo.Format = DateTimePickerFormat.Short;
            }
            else
            {
                miPeriodoTipoTrabajador.FechaFinal.TieneFin = false;
                dtpFinPeriodo.Enabled = false;
                dtpFinPeriodo.Format = DateTimePickerFormat.Custom;
                dtpFinPeriodo.CustomFormat = " ";
            }
        }

        private void dtpInicioPeriodo_ValueChanged(object sender, EventArgs e)
        {
            dtpFinPeriodo.MinDate = dtpInicioPeriodo.Value;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (chkFinPeriodo.Enabled == true)
            {
                miPeriodoTipoTrabajador.FechaInicio = dtpInicioPeriodo.Value;
                miPeriodoTipoTrabajador.FechaFinal.TieneFin = true;
                miPeriodoTipoTrabajador.FechaFinal.FechaFin = dtpFinPeriodo.Value;
                miPeriodoTipoTrabajador.TipoTrabajador.Codigo = Convert.ToInt16(cboTipoTrabajador.SelectedValue);
                miPeriodoTipoTrabajador.TipoTrabajador.Descripcion = Convert.ToString(cboTipoTrabajador.Text);

            }
            else
            {
                miPeriodoTipoTrabajador.FechaInicio = dtpInicioPeriodo.Value;
                miPeriodoTipoTrabajador.FechaFinal.TieneFin = false;
                miPeriodoTipoTrabajador.FechaFinal.FechaFin = dtpFinPeriodo.Value;
                miPeriodoTipoTrabajador.TipoTrabajador.Codigo = Convert.ToInt16(cboTipoTrabajador.SelectedValue);
                miPeriodoTipoTrabajador.TipoTrabajador.Descripcion = Convert.ToString(cboTipoTrabajador.Text);
            }
          
        }
    }
}
