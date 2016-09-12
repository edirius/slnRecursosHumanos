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
using System.Collections;
using System.IO;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmDatosDelEstablecimiento : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oExpo = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        public frmDatosDelEstablecimiento()
        {
            InitializeComponent();
            CargarGrid();
        }

        public void CargarGrid()
        {
            dgvDatosEstablecimiento.DataSource = oExpo.ListarEstablecimientos(DtDesde.Value, DtHasta.Value);
            dgvDatosEstablecimiento.Columns[0].Width = 270;
            dgvDatosEstablecimiento.Columns[1].Width = 75;
            dgvDatosEstablecimiento.Columns[2].Width = 75;
        }
        public void concatenarDatos()
        {
            ArrayList milista = new ArrayList();

            try
            {
                for (int i = 0; i < dgvDatosEstablecimiento.Rows.Count; i++)
                {
                    string tipoDoc = "01";
                    string dni = dgvDatosEstablecimiento[2,i].Value.ToString();
                    string paisDoc = "604";
                    string ruc = "20226560824";
                    string Contenido = "";
                    string codEstab = "0004";
                    Contenido = oExpo.ExportarEstablecimiento(tipoDoc, dni, paisDoc, ruc, codEstab);
                    milista.Add(Contenido);

                }
            }
            catch
            {
                
            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string RUC = "20226560824";
            string tipoArchivo = ".EST";
            string rp = "RP_";
            string Titulo = rp + RUC + tipoArchivo;
            Guardar.FileName = Titulo;
            string Ruta = "";
            if (Guardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (File.Exists(Guardar.FileName))
                {
                    File.Delete(Guardar.FileName);
                }
                if (Guardar.FileName.Contains(Titulo))
                {
                    Ruta = Guardar.FileName;
                    StreamWriter escribir = new StreamWriter(Ruta);//ruta del guardado
                                                                   //StreamWriter escribir = new StreamWriter(@"C:\Users\Usuario\Desktop\Textos SUNAT\" + Titulo + "");//ruta del guardado
                    for (int k = 0; k < milista.Count; k++)//mientras sea menor al contenido del arreglo(arraylist) guardará cada items k
                    {
                        escribir.WriteLine(milista[k]);//guarda en el bloc de notas 
                    }
                    escribir.Close();//cierra la escritura para que eje manejar por separado el bloc de notas
                    MessageBox.Show("Datos Exportados Exitosamente");//mensaje de cierre exitoso

                }
            }


        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvDatosEstablecimiento.Rows.Count != 0)
            {
                concatenarDatos();
            }
            else
                MessageBox.Show("No hay datos para exportar");
            
        }

        private void DtDesde_ValueChanged(object sender, EventArgs e)
        {
            dgvDatosEstablecimiento.DataSource = oExpo.ListarEstablecimientos(DtDesde.Value, DtHasta.Value);
        }

        private void DtHasta_ValueChanged(object sender, EventArgs e)
        {
            dgvDatosEstablecimiento.DataSource = oExpo.ListarEstablecimientos(DtDesde.Value, DtHasta.Value);
        }
    }
}
