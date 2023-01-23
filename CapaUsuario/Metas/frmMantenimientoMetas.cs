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
    public partial class frmMantenimientoMetas : Form
    {
        cCadenaProgramaticaFuncional miCadena = new cCadenaProgramaticaFuncional();
        public cMeta miMeta = new cMeta();

        public frmMantenimientoMetas()
        {
            InitializeComponent();
        }

        private void frmMantenimientoMetas_Load(object sender, EventArgs e)
        {
            CargarAños();
        }

        private void Iniciar()
        {
            dtgListaMetas.Rows.Clear();
            if (cboAño.Text != "")
            {
                DataTable oDataMeta = new DataTable();
                CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                oDataMeta = miMeta.ListarMetas();

                foreach (DataRow row in oDataMeta.Select("año = '" + cboAño.Text + "'"))
                {
                    dtgListaMetas.Rows.Add(row[0].ToString(), row[1].ToString(), row[3].ToString(), row[2].ToString(), row[4].ToString(), row[5].ToString());
                }

            }
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Metas.frmMeta fMiMeta = new frmMeta();
            fMiMeta.miMeta = new cMeta();
            fMiMeta.miMeta.Año = DateTime.Now.Year;
            if (fMiMeta.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                miCadena.CrearMeta(fMiMeta.miMeta);
                Iniciar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgListaMetas.SelectedRows.Count > 0)
            {
                Metas.frmMeta fMiMeta = new frmMeta();
                fMiMeta.miMeta = new cMeta();
                fMiMeta.miMeta.ActividadObra = new cActividadObra();
                fMiMeta.miMeta.GrupoFuncional = new cGrupoFuncional();
                fMiMeta.miMeta.Codigo = Convert.ToInt16(dtgListaMetas.SelectedRows[0].Cells[0].Value);
                fMiMeta.miMeta.Año = Convert.ToInt16(dtgListaMetas.SelectedRows[0].Cells[1].Value);
                fMiMeta.miMeta.Numero = Convert.ToInt16(dtgListaMetas.SelectedRows[0].Cells[2].Value);
                fMiMeta.miMeta.Nombre = Convert.ToString(dtgListaMetas.SelectedRows[0].Cells[3].Value);
                fMiMeta.miMeta.GrupoFuncional.Codigo = Convert.ToInt16(dtgListaMetas.SelectedRows[0].Cells[4].Value);
                fMiMeta.miMeta.ActividadObra.Codigo  = Convert.ToInt16(dtgListaMetas.SelectedRows[0].Cells[5].Value);

                if (fMiMeta.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                {
                    miCadena.ModificarMeta(fMiMeta.miMeta);
                    dtgListaMetas.DataSource = miCadena.ListarMetas();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una meta");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgListaMetas.SelectedRows.Count > 0)
            {
                miMeta = new cMeta();
                miMeta.ActividadObra = new cActividadObra();
                miMeta.GrupoFuncional = new cGrupoFuncional();
                miMeta.Codigo = Convert.ToInt16(dtgListaMetas.SelectedRows[0].Cells[0].Value);
                miMeta.Año = Convert.ToInt16(dtgListaMetas.SelectedRows[0].Cells[1].Value);
                miMeta.Numero = Convert.ToInt16(dtgListaMetas.SelectedRows[0].Cells[2].Value);
                miMeta.Nombre = Convert.ToString(dtgListaMetas.SelectedRows[0].Cells[3].Value);
                miMeta.GrupoFuncional.Codigo = Convert.ToInt16(dtgListaMetas.SelectedRows[0].Cells[4].Value);
                miMeta.ActividadObra.Codigo = Convert.ToInt16(dtgListaMetas.SelectedRows[0].Cells[5].Value);
                    miCadena.EliminarMeta(miMeta);
                    dtgListaMetas.DataSource = miCadena.ListarMetas();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una meta");
            }
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = Convert.ToString(DateTime.Now.Year);
        }
    }
}
