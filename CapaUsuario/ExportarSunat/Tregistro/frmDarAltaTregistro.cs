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
using CapaDeNegocios.ExportarSunat;
using System.Collections;
using System.IO;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public partial class frmDarAltaTregistro : Form
    {
        Tregistro.cCatalogoAltaTRegistro oCatalogo = new cCatalogoAltaTRegistro(cDatosGeneralesEmpresa.RUC);
        List<Tregistro.cTrabajadorAltaTRegistro> ListaTrabajadoresAltaTRegistro = new List<cTrabajadorAltaTRegistro>();
        CapaDeNegocios.Utilidades.cUtilidades oUtilidades = new CapaDeNegocios.Utilidades.cUtilidades();
        CapaDeNegocios.DatosLaborales.cRegimenTrabajador oRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();

        public frmDarAltaTregistro()
        {
            InitializeComponent();
        }

        private void frmDarAltaTregistro_Load(object sender, EventArgs e)
        {
            CargarAños();
        }

        private void CargarAños()
        {
            string años = "";
            for (int i = DateTime.Now.Year; i >= 2020; i--)
            {
                cbAños.Items.Add(i);
            }
            cbAños.Text = años;
            cbAños.Text = Convert.ToString(DateTime.Now.Year);
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                if (cbAños.SelectedIndex != -1 && cbMes.SelectedIndex != -1)
                {
                    ListaTrabajadoresAltaTRegistro = oCatalogo.TraerListaTrabajadoresTRegistro(cbMes.Text, cbAños.Text);
                    dtgListaTrabajadores.DataSource = ListaTrabajadoresAltaTRegistro;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en cargar datos: " + ex.Message);
            }
        }

        private void btnVerCodificacion_Click(object sender, EventArgs e)
        {
            Tregistro.frmVerCodificacion fVerCodificacion = new frmVerCodificacion();
            fVerCodificacion.ListaTrabajadores = ListaTrabajadoresAltaTRegistro;
            fVerCodificacion.Mes = new DateTime(Convert.ToInt16(cbAños.Text), oUtilidades.ConvertirMesANumero(cbMes.Text), 1);
            if (fVerCodificacion.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkIDE.Checked)
                {
                    string NombreArchivo = "RP_" + cDatosGeneralesEmpresa.RUC + ".IDE";
                    ArrayList ListaIDE = oCatalogo.GenerarListaIDE(ListaTrabajadoresAltaTRegistro);
                    GuardarArchivo(ListaIDE, NombreArchivo);
                }

                if (chkTRA.Checked)
                {
                    string NombreArchivo = "RP_" + cDatosGeneralesEmpresa.RUC + ".TRA";
                    ArrayList ListaTRA = oCatalogo.GenerarListaTRA(ListaTrabajadoresAltaTRegistro);
                    GuardarArchivo(ListaTRA, NombreArchivo);
                }
                if (chkPER.Checked)
                {
                    string NombreArchivo = "RP_" + cDatosGeneralesEmpresa.RUC + ".PER";
                    ArrayList ListaPER = oCatalogo.GenerarListaPER(ListaTrabajadoresAltaTRegistro);
                    GuardarArchivo(ListaPER, NombreArchivo);
                }
                if (chkEST.Checked)
                {
                    string NombreArchivo = "RP_" + cDatosGeneralesEmpresa.RUC + ".EST";
                    ArrayList ListaEST = oCatalogo.GenerarListaEST(ListaTrabajadoresAltaTRegistro);
                    GuardarArchivo(ListaEST, NombreArchivo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar los acrhivos: " + ex.Message);
                throw;
            }
        }

        private void GuardarArchivo(ArrayList Lista, string nombreArchivo)
        {
            try
            {
                //CrearCarpeta();
                SaveFileDialog Guardar = new SaveFileDialog();
                Guardar.FileName = nombreArchivo;
                string Ruta = "";
                if (Guardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                    if (File.Exists(Guardar.FileName))
                    {
                        File.Delete(Guardar.FileName);
                    }
                    if (Guardar.FileName.Contains(nombreArchivo))
                    {
                        Ruta = Guardar.FileName;
                        StreamWriter escribir = new StreamWriter(Ruta);//ruta del guardado
                                                                       //StreamWriter escribir = new StreamWriter(@"C:\Users\Usuario\Desktop\Textos SUNAT\" + Titulo + "");//ruta del guardado
                        for (int k = 0; k < Lista.Count; k++)//mientras sea menor al contenido del arreglo(arraylist) guardará cada items k
                        {
                            escribir.WriteLine(Lista[k]);//guarda en el bloc de notas 
                        }
                        escribir.Close();//cierra la escritura para que eje manejar por separado el bloc de notas
                        MessageBox.Show("Datos Exportados Exitosamente");//mensaje de cierre exitoso
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo: " + nombreArchivo + ": " + ex.Message);
                throw;
            }
        }

        private void btnCambiarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaTrabajadores.SelectedRows.Count > 0)
                {
                    cTrabajadorAltaTRegistro tra = (cTrabajadorAltaTRegistro)dtgListaTrabajadores.SelectedRows[0].DataBoundItem;

                    
                    oRegimenTrabajador = oRegimenTrabajador.TraerRegimenTrabajadorXId(((CapaDeNegocios.DatosLaborales.cRegimenTrabajador)dtgListaTrabajadores.SelectedRows[0].Cells["colRegimenTrabajador"].Value).IdtRegimenTrabajador);
                    CapaUsuario.Trabajador.frmRegimenTrabajador fRegimenTrabajador = new Trabajador.frmRegimenTrabajador();
                    fRegimenTrabajador.RecibirDatos(oRegimenTrabajador.IdtRegimenTrabajador, 
                        oRegimenTrabajador.Condicion, 
                        oRegimenTrabajador.ServidorConfianza, 
                        oRegimenTrabajador.NumeroDocumento, 
                        oRegimenTrabajador.Periodicidad, 
                        oRegimenTrabajador.TipoPago, 
                        oRegimenTrabajador.MontoPago, 
                        oRegimenTrabajador.FechaInicio, 
                        oRegimenTrabajador.FechaFin, 
                        oRegimenTrabajador.RUC, 
                        oRegimenTrabajador.IdtRegimenLaboral,
                        tra.DatosTrabajador[0].RegimenLaboral.Descripcion,
                        oRegimenTrabajador.IdtTipoTrabajador, 
                        tra.DatosTrabajador[0].TipoTrabajador.Descripcion, // stipotrabajador,
                        oRegimenTrabajador.IdtTipoContrato,
                        tra.DatosTrabajador[0].TipoContrato.Descripcion,//stipocontrato,
                        oRegimenTrabajador.IdtCategoriaOcupacional,
                        tra.DatosTrabajador[0].CategoriaOcupacionalTrabajador.Descripcion,//scategoriaocupacional,
                        oRegimenTrabajador.IdtOcupacion,
                        tra.DatosTrabajador[0].Ocupacion.Nombre,//socupacion,
                        oRegimenTrabajador.IdtCargo,
                        tra.DatosTrabajador[0].Cargo.Descripcion,//scargo,
                        oRegimenTrabajador.IdtMeta,
                         "",//smeta,
                        oRegimenTrabajador.IdtPeriodoTrabajador,
                        2, 
                        oRegimenTrabajador.FechaInicio, 
                        oRegimenTrabajador.FechaFin);
                    if (fRegimenTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //CargarDatos();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un trabajador para cambiar sus datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al camabiar los datos: " + ex.Message);
            }
        }

        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSelectAll.Checked == true)
            {
                for (int i = 0; i < dtgListaTrabajadores.Rows.Count; i++)
                {
                    dtgListaTrabajadores[0, i].Value = true;

                }
            }
            else
                for (int i = 0; i < dtgListaTrabajadores.Rows.Count; i++)
                {
                    dtgListaTrabajadores[0, i].Value = false;
                }
        }
    }
}
