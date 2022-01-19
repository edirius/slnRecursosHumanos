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

namespace CapaUsuario.Trabajador
{
    public partial class frmCambiarMeta : Form
    {
        public CapaDeNegocios.Obras.cMeta oMeta;
        public CapaDeNegocios.cTrabajador oTrabajador;

        public frmCambiarMeta()
        {
            InitializeComponent();
        }

        private void frmCambiarMeta_Load(object sender, EventArgs e)
        {
            Iniciar();
        }


        public void Iniciar()
        {
            if (oTrabajador != null)
            {
                lblNombredelTrabajador.Text = oTrabajador.Nombres + " " + oTrabajador.ApellidoPaterno + " " + oTrabajador.ApellidoMaterno; 
            }
            else
            {
                MessageBox.Show("No se puede obtener el nombre del trabajador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cboMeta.DisplayMember = "Value";
            cboMeta.ValueMember = "Key";
            CargarAños();
            CargarMetaInicial();
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
        }

        private void CargarMetaInicial()
        {
            try
            {
                cboAño.Text = oMeta.Año.ToString();
                cboMeta.SelectedValue = oMeta.Codigo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar meta inicial: " + ex.Message, "Meta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMeta()
        {
            try
            {
                //CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                //cboMeta.DataSource = miMeta.ListarMetas();
                //cboMeta.DisplayMember = "nombre";
                //cboMeta.ValueMember = "idtmeta";
                //if (smeta == "") { cboMeta.SelectedIndex = -1; }
                //else { cboMeta.Text = smeta; }

                if (cboAño.Text != "")
                {
                    int anio = Convert.ToInt16(cboAño.Text);
                    DataTable oDataMeta = new DataTable();
                    CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                    oDataMeta = miMeta.ListarMetas(anio);

                    if (oDataMeta.Rows.Count == 0)
                    {
                        MessageBox.Show("El año no tiene metas", "Error al listar metas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboMeta.DataSource = null;
                    }
                    else
                    {
                        Dictionary<string, string> test = new Dictionary<string, string>();
                        foreach (DataRow row in oDataMeta.Rows)
                        {
                            test.Add(row[0].ToString(), row[1].ToString());
                        }

                        cboMeta.DataSource = new BindingSource(test, null);
                        cboMeta.DisplayMember = "Value";
                        cboMeta.ValueMember = "Key";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las metas: " + ex.Message);
                throw;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMeta.SelectedValue.ToString() != "0")
                {
                    oMeta.Codigo = Convert.ToInt32(cboMeta.SelectedValue.ToString());
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Seleccione una meta para cambiarla o click en cancelar", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar: " + ex.Message, "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cboMeta.SelectedValue != null)
            //    {
            //        oMeta.Codigo = Convert.ToInt32(cboMeta.SelectedValue.ToString());
            //    }
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al seleccionar: " + ex.Message, "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMeta();
        }
    }

    
}
