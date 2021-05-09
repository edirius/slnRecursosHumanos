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



namespace CapaUsuario.Clasificadores
{
    public partial class frmSeleccionarClasificador : Form
    {
        public CapaDeNegocios.Clasificadores.cEspecifica2 oEspecifica2Seleccionada;
        public CapaDeNegocios.Clasificadores.cSubgenerica oSubgenericaSeleccionada;
        public CapaDeNegocios.Clasificadores.cSubgenerica2 oSubgenerica2Seleccionada;
        public CapaDeNegocios.Clasificadores.cEspecifica oEspecificaSeleccionada;
        public CapaDeNegocios.Clasificadores.cGenerica oGenericaSeleccionada;

        private CapaDeNegocios.Clasificadores.cClasificadorGasto oClasificadorGasto = new CapaDeNegocios.Clasificadores.cClasificadorGasto();

        public frmSeleccionarClasificador()
        {
            InitializeComponent();
        }

        private void frmSeleccionarClasificador_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            cboGenerica.ValueMember = "Idtgenerica";
            cboGenerica.DisplayMember = "CampoUnido";
            cboGenerica.DataSource = oClasificadorGasto.ObtenerListaGenericas();
        }

        private void cboGenerica_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboGenerica.SelectedIndex != -1)
                {
                    oGenericaSeleccionada = (CapaDeNegocios.Clasificadores.cGenerica)cboGenerica.SelectedItem;
                    cboSubGenerica.ValueMember = "Idtsubgenerica";
                    cboSubGenerica.DisplayMember = "CampoUnido";
                    cboSubGenerica.DataSource = oClasificadorGasto.ObtenerListaSubgenericas(oGenericaSeleccionada);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar subgenericas: " + ex.Message);
            }
        }

        private void cboSubGenerica_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboSubGenerica.SelectedIndex != -1)
                {
                    oSubgenericaSeleccionada = (CapaDeNegocios.Clasificadores.cSubgenerica)cboSubGenerica.SelectedItem;
                    cboSubGenerica2.ValueMember = "Idtsubgenerica2";
                    cboSubGenerica2.DisplayMember = "CampoUnido";
                    cboSubGenerica2.DataSource = oClasificadorGasto.ObtenerListaSubgenericas2(oSubgenericaSeleccionada);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar subgenericas level 2: " + ex.Message);
            }
        }

        private void cboSubGenerica2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboSubGenerica2.SelectedIndex != -1)
                {
                    oSubgenerica2Seleccionada = (CapaDeNegocios.Clasificadores.cSubgenerica2)cboSubGenerica2.SelectedItem;
                    cboEspecifica.ValueMember = "Idtespecifica";
                    cboEspecifica.DisplayMember = "CampoUnido";
                    cboEspecifica.DataSource = oClasificadorGasto.ListaEspecificas(oSubgenerica2Seleccionada);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar especifica: " + ex.Message);
            }
        }

        private void cboEspecifica_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboEspecifica.SelectedIndex != -1)
                {
                    oEspecificaSeleccionada = (CapaDeNegocios.Clasificadores.cEspecifica)cboEspecifica.SelectedItem;
                    cboEspecifica2.ValueMember = "Idtespecifica2";
                    cboEspecifica2.DisplayMember = "CampoUnido";
                    cboEspecifica2.DataSource = oClasificadorGasto.ListaEspecificas2(oEspecificaSeleccionada);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar especifica level 2: " + ex.Message);
            }
        }

        private void cboEspecifica2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboEspecifica2.SelectedIndex != -1)
                {
                    oEspecifica2Seleccionada = (CapaDeNegocios.Clasificadores.cEspecifica2)cboEspecifica2.SelectedItem;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al escoger especifica level 2: " + ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (oEspecifica2Seleccionada != null)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna especifica level 2");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
