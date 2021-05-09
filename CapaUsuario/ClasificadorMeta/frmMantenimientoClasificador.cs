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

namespace CapaUsuario.ClasificadorMeta
{
    public partial class frmMantenimientoClasificador : Form
    {
        public string sDescripcionPlanilla;

        public CapaDeNegocios.Clasificadores.cEspecifica2 oEspecifica;

        public string Concepto;

       

        public  CapaDeNegocios.ClasificadorMeta.cClasificadorMeta oClasificadorMeta;

        public frmMantenimientoClasificador()
        {
            InitializeComponent();
        }

        private void btnNuevoClasificador_Click(object sender, EventArgs e)
        {
            try
            {
                Clasificadores.frmSeleccionarClasificador fSeleccionaClasificador = new Clasificadores.frmSeleccionarClasificador();


                if (fSeleccionaClasificador.ShowDialog() == DialogResult.OK)
                {
                    oEspecifica = fSeleccionaClasificador.oEspecifica2Seleccionada;
                    txtClasificador.Text = oEspecifica.CampoUnido;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar clasificador: " + ex.Message);
            }
        }

        private void btnSeleccionarConcepto_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarConceptos fSeleccionarConceptos = new frmSeleccionarConceptos();
                fSeleccionarConceptos.sDescripcion = sDescripcionPlanilla;
                if (fSeleccionarConceptos.ShowDialog() == DialogResult.OK)
                {
                    txtConcepto.Text = fSeleccionarConceptos.ConceptoSeleccionado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar conceptos: " + ex.Message);
            }
        }

        private void frmMantenimientoClasificador_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtClasificador.Text = oClasificadorMeta.Especifica.Codigo;
            txtConcepto.Text = oClasificadorMeta.Concepto;
            oEspecifica = oClasificadorMeta.Especifica;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                oClasificadorMeta.Concepto = txtConcepto.Text;
                oClasificadorMeta.Especifica = oEspecifica;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el clasificador por planilla: " + ex.Message);
            }
        }
    }
}
