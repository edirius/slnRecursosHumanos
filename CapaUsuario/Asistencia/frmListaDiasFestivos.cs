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

namespace CapaUsuario.Asistencia
{
    public partial class frmListaDiasFestivos : Form
    {
        CapaDeNegocios.Asistencia.cDiaFestivo oDiaFestivo = new CapaDeNegocios.Asistencia.cDiaFestivo();


        public frmListaDiasFestivos()
        {
            InitializeComponent();
        }

        private void frmListaDiasFestivos_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        public void Iniciar()
        {
            DarFormato();
            for (int i = 0; i < 10; i++)
            {
                cboAño.Items.Add(DateTime.Now.Year - i);
            }
            
        }

        public void DarFormato()
        {
            dtgListaDiasFestivos.Columns.Add("colCodigoDiaFestivo", "Codigo");
            dtgListaDiasFestivos.Columns["colCodigoDiaFestivo"].DataPropertyName = "Codigo";
            dtgListaDiasFestivos.Columns["colCodigoDiaFestivo"].Width = 50;

            dtgListaDiasFestivos.Columns.Add("colNombreDiaFestivo", "Nombre");
            dtgListaDiasFestivos.Columns["colNombreDiaFestivo"].DataPropertyName = "Nombre";
            dtgListaDiasFestivos.Columns["colNombreDiaFestivo"].Width = 200;

            dtgListaDiasFestivos.Columns.Add("colDiaFestivo", "Dia");
            dtgListaDiasFestivos.Columns["colDiaFestivo"].DataPropertyName = "DiaFestivo";
            dtgListaDiasFestivos.Columns["colDiaFestivo"].DefaultCellStyle.Format = "M";
        }

        private void btnNuevoDiaFestivo_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoDiaFestivo fMantenimientoDiaFestivo = new frmMantenimientoDiaFestivo();
                fMantenimientoDiaFestivo.oDiaFestivo = new CapaDeNegocios.Asistencia.cDiaFestivo();
                if (fMantenimientoDiaFestivo.ShowDialog() == DialogResult.OK)
                {
                    fMantenimientoDiaFestivo.oDiaFestivo.AgregarDiaFestivo(fMantenimientoDiaFestivo.oDiaFestivo);
                    dtgListaDiasFestivos.Refresh();
                }
                else
                {
                    MessageBox.Show("Se cancelo la operacion.", "Nuevo Dia Festivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el dia festivo: " + ex.Message, "Agregar Dia Festivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarDiaFestivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaDiasFestivos.SelectedRows.Count > 0)
                {
                    frmMantenimientoDiaFestivo fMantenimientoDiaFestivo = new frmMantenimientoDiaFestivo();
                    fMantenimientoDiaFestivo.oDiaFestivo = new CapaDeNegocios.Asistencia.cDiaFestivo();
                    fMantenimientoDiaFestivo.oDiaFestivo = oDiaFestivo.ListaDiasFestivos(Convert.ToInt16(cboAño.Text.ToString())).Find(miDia => miDia.Codigo == Convert.ToInt16(dtgListaDiasFestivos.SelectedRows[0].Cells["colCodigoDiaFestivo"].Value.ToString()));
                    if (fMantenimientoDiaFestivo.ShowDialog() == DialogResult.OK)
                    {
                        fMantenimientoDiaFestivo.oDiaFestivo.ModificarDiaFestivo(fMantenimientoDiaFestivo.oDiaFestivo);
                        dtgListaDiasFestivos.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la operacion.", "Modificar Dia Festivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un dia festivo para modificarlo.", "Modificar Dia Festivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el dia festivo: " + ex.Message, "Modificar Dia festivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgListaDiasFestivos.DataSource = oDiaFestivo.ListaDiasFestivos(Convert.ToInt16(cboAño.Text.ToString()));
        }
    }
}
