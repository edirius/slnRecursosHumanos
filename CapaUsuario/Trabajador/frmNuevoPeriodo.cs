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
    public partial class frmNuevoPeriodo : Form
    {
        public cPeriodo miPeriodo;

        cMotivoFinPeriodo miMotivoFinPeriodo = new cMotivoFinPeriodo();

        public frmNuevoPeriodo()
        {
            InitializeComponent();
        }

        private void dtpFinPeriodo_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void frmNuevoPeriodo_Load(object sender, EventArgs e)
        {
            cboMotivoFinPeriodo.ValueMember = "idtmotivofinperiodo";
            cboMotivoFinPeriodo.DisplayMember = "descripcion";
            cboMotivoFinPeriodo.DataSource = miMotivoFinPeriodo.ListaMotivosFinPeriodos();
            Iniciar();
        }

        private void Iniciar()
        {
            dtpInicioPeriodo.Value = miPeriodo.FechaInicio;
            chkFinPeriodo.Checked = miPeriodo.FechaFin.TieneFin;
            if (miPeriodo.FechaFin.TieneFin)
            {
                dtpFinPeriodo.Value = miPeriodo.FechaFin.FechaFin;
                cboMotivoFinPeriodo.SelectedValue = miPeriodo.MotivoFinPeriodo.Codigo;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cMotivoFinPeriodo miMotivoFinPeriodo = new cMotivoFinPeriodo();
            cFinPeriodo miFinPeriodo = new cFinPeriodo();

            miPeriodo.FechaInicio = dtpInicioPeriodo.Value;
            if (chkFinPeriodo.Checked  == false)
            {
                miPeriodo.FechaFin.TieneFin = false;
                miPeriodo.FechaFin.FechaFin  = DateTime.MinValue;
                miPeriodo.MotivoFinPeriodo = null;
            }
            else
            {
                miFinPeriodo.TieneFin = true;
                miFinPeriodo.FechaFin = dtpFinPeriodo.Value;
                miPeriodo.FechaFin = miFinPeriodo;
                
                miPeriodo.MotivoFinPeriodo.Codigo = Convert.ToInt16(cboMotivoFinPeriodo.SelectedValue.ToString()); 
            }


            miPeriodo.MotivoFinPeriodo = miMotivoFinPeriodo.TraerMotivoFinPeriodo(Convert.ToInt16(cboMotivoFinPeriodo.SelectedValue.ToString())); ;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void chkFinPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFinPeriodo.Checked == true)
            {
                gbFinPeriodo.Enabled = true;
                miPeriodo.FechaFin.TieneFin  = true;
                dtpFinPeriodo.Format = DateTimePickerFormat.Short;
                
            }
            else
            {
                gbFinPeriodo.Enabled = false;
                miPeriodo.FechaFin.TieneFin = false;
                dtpFinPeriodo.Format = DateTimePickerFormat.Custom;
                dtpFinPeriodo.CustomFormat = " ";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dtpInicioPeriodo_ValueChanged(object sender, EventArgs e)
        {
            dtpFinPeriodo.MinDate = dtpInicioPeriodo.Value;
        }
    }
}
