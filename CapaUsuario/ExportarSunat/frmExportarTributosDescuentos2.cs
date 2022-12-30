using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaUsuario.Properties;
using System.IO;
using System.Collections;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmExportarTributosDescuentos2 : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oExportar = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        string Ingresos, Descuentos, Aportaciones = "";
        string Titulo = "";
        string Nromes = "";
        string FechaTexto = "";
        ArrayList milista = new ArrayList();
        ArrayList milistaJornada = new ArrayList();
        ArrayList milistaSCTR = new ArrayList();

        public frmExportarTributosDescuentos2()
        {
            InitializeComponent();
            txtRuc.Text = Properties.Settings.Default.RUC;
            DateTime Ahora = DateTime.Today;
            CargarMes(Ahora);
            cbMes.Text = FechaTexto;
            CargarAños();
          
            label2.Visible = false;
            label5.Visible = false;
            txtCodForm.Visible = false;
            txtRuc.Visible = false;
            txtRuc.Text = Settings.Default.RUC;
        }

        private void CargarAños()
        {
            string años = "";
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cbAños.Items.Add(i);
            }
            cbAños.Text = años;
            cbAños.Text = Convert.ToString(DateTime.Now.Year);
        }

        private void CargarMes(DateTime FechaActual)
        {
            string Ahora = Convert.ToString(FechaActual.Date.Month);
            switch (Ahora)
            {
                case "1":
                    {
                        FechaTexto = "ENERO";
                        break;
                    }
                case "2":
                    {
                        FechaTexto = "FEBRERO";
                        break;
                    }
                case "3":
                    {
                        FechaTexto = "MARZO";
                        break;
                    }
                case "4":
                    {
                        FechaTexto = "ABRIL";
                        break;
                    }
                case "5":
                    {
                        FechaTexto = "MAYO";
                        break;
                    }
                case "6":
                    {
                        FechaTexto = "JUNIO";
                        break;
                    }
                case "7":
                    {
                        FechaTexto = "JULIO";
                        break;
                    }
                case "8":
                    {
                        FechaTexto = "AGOSTO";
                        break;
                    }
                case "9":
                    {
                        FechaTexto = "SETIEMBRE";
                        break;
                    }
                case "10":
                    {
                        FechaTexto = "OCTUBRE";
                        break;
                    }
                case "11":
                    {
                        FechaTexto = "NOVIEMBRE";
                        break;
                    }
                case "12":
                    {
                        FechaTexto = "DICIEMBRE";
                        break;
                    }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmExportarTributosDescuentos2_Load(object sender, EventArgs e)
        {
            pbSunat.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            milista.Clear();
            milistaJornada.Clear();
            if (dgvListaPlanillas.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvListaPlanillas.Rows)
                {
                    if (Convert.ToBoolean(fila.Cells["CHK"].Value) == true)
                    {

                        string numero = "";
                        numero = fila.Cells["colIdtPlanilla"].Value.ToString();
                        dgvIngresos.DataSource = oExportar.ListarTrabajadoresPorPlanillaIngresos(numero);
                        dgvDescuentos.DataSource = oExportar.ListarTrabajadoresPorPlanillaDescuentos(numero);
                        dgvAportaciones.DataSource = oExportar.ListarTrabajadoresPorPlanillaAportaciones(numero);
                        dgvJornadaLaboral.DataSource = oExportar.ListarJornadaLaboralTrabajadores(numero);

                        if (CheckJornada.Checked == true)
                        {
                            concatenarDatosJornadaLaboral();
                            if (chkSCTR.Checked)
                            {
                                concatenarDatosSCTR();
                            }

                            concatenarDatos();

                        }
                        else if (dgvIngresos.Rows.Count != 0)
                        {
                            if (chkSCTR.Checked)
                            {
                                concatenarDatosSCTR();
                            }
                            concatenarDatos();
                        }

                        else MessageBox.Show("La planilla no tiene trabajadores para exportar");
                    }
                }

                SalvarDatosRem();
                if (CheckJornada.Checked == true)
                {
                    SalvarDatosJornadaLaboral();
                }

                if (chkSCTR.Checked)
                {
                    SalvarDatosSRCT();
                }
            }
           
        }

        private void Buscar()
        {
            dgvListaPlanillas.DataSource = oExportar.BuscarPlanillas(cbMes.Text, cbAños.Text);
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        public void CrearCarpeta()
        {
            DirectoryInfo di = Directory.CreateDirectory(@"C:\Users\Usuario\Desktop\Textos SUNAT");//ruta de la carpeta
        }
        public void concatenarDatosJornadaLaboral()
        {

           
            try
            {
                for (int i = 0; i < dgvJornadaLaboral.Rows.Count; i++)
                {
                    //obtenemos los datos de las columnas que queremos
                    string mes = cbMes.Text;
                    string año = cbAños.Text;
                    string TipoDoc = dgvJornadaLaboral[0, i].Value.ToString();
                    string dni = dgvJornadaLaboral[1, i].Value.ToString();
                    string NHO = dgvJornadaLaboral[2, i].Value.ToString();
                    string NMO = dgvJornadaLaboral[3, i].Value.ToString();
                    string NHS = dgvJornadaLaboral[4, i].Value.ToString();
                    string NMS = dgvJornadaLaboral[5, i].Value.ToString();
                   
                    string Ruc = txtRuc.Text;
                    string Palo = "|";
                    ConvertirMes(mes);
                    string Jornada = "";
                    Jornada = TipoDoc + Palo + dni + Palo + NHO + Palo + NMO + Palo + NHS + Palo + NMS + Palo;
                   
                    milistaJornada.Add(Jornada);//agregamos los datos concatenados al arreglo(ArrayList)
                }

            }
            catch { }
           
        }

        public void SalvarDatosJornadaLaboral()
        {
            string año = cbAños.Text;
            string codigoformjornada = "0601";
            string TituloJornada = "";
            TituloJornada = codigoformjornada + año + Nromes + txtRuc.Text + ".jor";
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.FileName = TituloJornada;
            string Ruta = "";
            if (TituloJornada != "")
            {
                if (Guardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (File.Exists(Guardar.FileName))
                    {
                        File.Delete(Guardar.FileName);
                    }
                    if (Guardar.FileName.Contains(TituloJornada))
                    {
                        Ruta = Guardar.FileName;
                        StreamWriter escribir = new StreamWriter(Ruta);//ruta del guardado
                        //StreamWriter escribir = new StreamWriter(@"C:\Users\Usuario\Desktop\Textos SUNAT\" + Titulo + "");//ruta del guardado
                        for (int k = 0; k < milistaJornada.Count; k++)//mientras sea menor al contenido del arreglo(arraylist) guardará cada items k
                        {
                            escribir.WriteLine(milistaJornada[k]);//guarda en el bloc de notas 
                        }
                        escribir.Close();//cierra la escritura para que eje manejar por separado el bloc de notas
                        MessageBox.Show("Datos de Jornada laboral exportados Exitosamente");//mensaje de cierre exitoso

                    }
                }
            }
        }

        public void concatenarDatosSCTR()
        {

           
            try
            {
                for (int i = 0; i < dgvJornadaLaboral.Rows.Count; i++)
                {
                    //obtenemos los datos de las columnas que queremos
                    string mes = cbMes.Text;
                    string año = cbAños.Text;
                    string TipoDoc = dgvJornadaLaboral[0, i].Value.ToString();
                    string dni = dgvJornadaLaboral[1, i].Value.ToString();

                   
                    string Ruc = txtRuc.Text;
                    string Palo = "|";
                    ConvertirMes(mes);
                    string Jornada = "";
                    Jornada = TipoDoc + Palo + dni + Palo + "1" + Palo + "1.53" + Palo;
                   
                    milistaSCTR.Add(Jornada);//agregamos los datos concatenados al arreglo(ArrayList)
                }

            }
            catch { }
           
        }

        public void SalvarDatosSRCT()
        {
            string TituloJornada = "";
            string codigoformjornada = "0601";
            string año = cbAños.Text;
            TituloJornada = codigoformjornada + año + Nromes + txtRuc.Text + ".tas";
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.FileName = TituloJornada;
            string Ruta = "";
            if (TituloJornada != "")
            {
                if (Guardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (File.Exists(Guardar.FileName))
                    {
                        File.Delete(Guardar.FileName);
                    }
                    if (Guardar.FileName.Contains(TituloJornada))
                    {
                        Ruta = Guardar.FileName;
                        StreamWriter escribir = new StreamWriter(Ruta);//ruta del guardado
                        //StreamWriter escribir = new StreamWriter(@"C:\Users\Usuario\Desktop\Textos SUNAT\" + Titulo + "");//ruta del guardado
                        for (int k = 0; k < milistaSCTR.Count; k++)//mientras sea menor al contenido del arreglo(arraylist) guardará cada items k
                        {
                            escribir.WriteLine(milistaSCTR[k]);//guarda en el bloc de notas 
                        }
                        escribir.Close();//cierra la escritura para que eje manejar por separado el bloc de notas
                        MessageBox.Show("Datos de STRC exportados Exitosamente");//mensaje de cierre exitoso

                    }
                }
            }
        }
        public void concatenarDatos()
        {

            try
            {
                for (int i = 0; i < dgvIngresos.Rows.Count; i++)
                {
                    //obtenemos los datos de las columnas que queremos
                    string mes = dgvIngresos[1, i].Value.ToString();
                    string año = dgvIngresos[2, i].Value.ToString();
                    string dni = dgvIngresos[3, i].Value.ToString();
                    string codigo = dgvIngresos[4, i].Value.ToString();
                    string MontoDevengado = dgvIngresos[5, i].Value.ToString();
                    string Monto = dgvIngresos[5, i].Value.ToString();
                    string TipoDoc = "01";
                    string codigoform = txtCodForm.Text;
                    string Ruc = txtRuc.Text;
                    ConvertirMes(mes);
                    Ingresos = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                    Titulo = oExportar.ExportarTitulo(codigoform, año, Nromes, Ruc);
                    milista.Add(Ingresos);//agregamos los datos concatenados al arreglo(ArrayList)
                }
            }
            catch
            {
            }
            try
            {
                for (int i = 0; i < dgvDescuentos.Rows.Count; i++)
                {
                    //obtenemos los datos de las columnas que queremos
                    string mes = dgvDescuentos[1, i].Value.ToString();
                    string año = dgvDescuentos[2, i].Value.ToString();
                    string dni = dgvDescuentos[3, i].Value.ToString();
                    string codigo = dgvDescuentos[4, i].Value.ToString();
                    string MontoDevengado = dgvDescuentos[5, i].Value.ToString();
                    string Monto = dgvDescuentos[5, i].Value.ToString();
                    string TipoDoc = "01";
                    Descuentos = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                    milista.Add(Descuentos);//agregamos los datos concatenados al arreglo(ArrayList)
                }
            }
            catch
            {
            }

            try
            {
                for (int i = 0; i < dgvAportaciones.Rows.Count; i++)
                {
                    //obtenemos los datos de las columnas que queremos
                    string mes = dgvAportaciones[1, i].Value.ToString();
                    string año = dgvAportaciones[2, i].Value.ToString();
                    string dni = dgvAportaciones[3, i].Value.ToString();
                    string codigo = dgvAportaciones[4, i].Value.ToString();
                    string MontoDevengado = dgvAportaciones[5, i].Value.ToString();
                    string Monto = dgvAportaciones[5, i].Value.ToString();
                    string TipoDoc = "01";
                    string codigoform = txtCodForm.Text;
                    string Ruc = txtRuc.Text;
                    ConvertirMes(mes);

                    Aportaciones = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                    if ((codigo == "0704" || codigo == "0705") && Settings.Default.RUC == "20177432360")
                    {

                    }
                    else
                    {
                        milista.Add(Aportaciones);//agregamos los datos concatenados al arreglo(ArrayList)
                    }

                }
            }
            catch
            {
            }
            //CrearCarpeta();
          

        }

        private void SalvarDatosRem()
        {
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.FileName = Titulo;
            string Ruta = "";
            if (Titulo != "")
            {
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
                        MessageBox.Show("Datos de tributos y descuentos del trabajador exportados Exitosamente");//mensaje de cierre exitoso

                    }
                }
            }
            else
                MessageBox.Show("No hay datos para Exportar");
        }

        private void ConvertirMes(string MES)
        {
            switch (MES)
            {
                case "ENERO":
                    {
                        Nromes = "01";
                        break;
                    }
                case "FEBRERO":
                    {
                        Nromes = "02";
                        break;
                    }
                case "MARZO":
                    {
                        Nromes = "03";
                        break;
                    }
                case "ABRIL":
                    {
                        Nromes = "04";
                        break;
                    }
                case "MAYO":
                    {
                        Nromes = "05";
                        break;
                    }
                case "JUNIO":
                    {
                        Nromes = "06";
                        break;
                    }
                case "JULIO":
                    {
                        Nromes = "07";
                        break;
                    }
                case "AGOSTO":
                    {
                        Nromes = "08";
                        break;
                    }
                case "SETIEMBRE":
                    {
                        Nromes = "09";
                        break;
                    }
                case "OCTUBRE":
                    {
                        Nromes = "10";
                        break;
                    }
                case "NOVIEMBRE":
                    {
                        Nromes = "11";
                        break;
                    }
                case "DICIEMBRE":
                    {
                        Nromes = "12";
                        break;
                    }

            }
        }
    }
}
