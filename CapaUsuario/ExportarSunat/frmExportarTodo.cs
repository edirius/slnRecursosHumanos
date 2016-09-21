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
using System.IO;
using System.Collections;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmExportarTodo : Form
    {
        ArrayList milistaIDE = new ArrayList();
        ArrayList milistaTRA = new ArrayList();
        ArrayList milistaPER = new ArrayList();
        ArrayList milistaEST = new ArrayList();
        ArrayList milistaEDU = new ArrayList();
        string FechaTexto = "";
        string ContenidoIDE = "";
        int nroSexo = 0;
        string nroTipoPago = "";
        string nroPeriodicidad = "";

        string tipoDoc = "01";
        string paisDoc = "604";
        string EPS = "";
        string Periodos = "";
        string TipoTrabajador = "";
        string RegimenAseguramiento = "";
        string RegimenPensionario = "";
        string Ruta = "";
        string Titulo = "";
        string RUC = "20226560824";
        string tipoArchivo = ".PER";
        string rp = "RP_";
        string NroRegimenSalud = "";
        string Categoria = "1";
        CapaDeNegocios.ExportarSunat.cExportarSunat oExportar = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        public frmExportarTodo()
        {
            InitializeComponent();
            CargarAños();
            CargarGrid();
            DateTime Ahora = DateTime.Today;
            CargarMes(Ahora);
            cbMes.Text = FechaTexto;
            
        }
        private void CargarGrid()
        {
            dgvListarTrabajadores.DataSource = oExportar.EXPORTARTODO(cbMes.Text, cbAños.Text);
            DataGridViewCheckBoxColumn Check = new DataGridViewCheckBoxColumn();//creamos un objeto check
            {
                Check.Name = "☑";//le damos un nombre de cabecera
                dgvListarTrabajadores.Columns.Add(Check);//agregamos los check a cada items

            }
            dgvListarTrabajadores.Columns["☑"].DisplayIndex = 0;
            dgvListarTrabajadores.Columns["☑"].ReadOnly = false;
            for (int i = 0; i < dgvListarTrabajadores.Columns.Count; i++)
            {
                dgvListarTrabajadores.Columns[i].Visible = false;
                dgvListarTrabajadores.Columns["☑"].Visible = true;
                dgvListarTrabajadores.Columns["☑"].Width = 30;
                dgvListarTrabajadores.Columns["Nro"].Visible = true;
                dgvListarTrabajadores.Columns["Nro"].Width = 40;
                dgvListarTrabajadores.Columns["Nro"].ReadOnly = true;
                dgvListarTrabajadores.Columns["Nombres"].Visible = true;
                dgvListarTrabajadores.Columns["Nombres"].Width = 150;
                dgvListarTrabajadores.Columns["Nombres"].DisplayIndex = 4;
                dgvListarTrabajadores.Columns["Nombres"].ReadOnly = true;
                dgvListarTrabajadores.Columns["ApellidoPaterno"].Visible = true;
                dgvListarTrabajadores.Columns["ApellidoPaterno"].Width = 150;
                dgvListarTrabajadores.Columns["ApellidoPaterno"].ReadOnly = true;
                dgvListarTrabajadores.Columns["ApellidoMaterno"].Visible = true;
                dgvListarTrabajadores.Columns["ApellidoMaterno"].Width = 150;
                dgvListarTrabajadores.Columns["ApellidoMaterno"].ReadOnly = true;
                dgvListarTrabajadores.Columns["DNI"].Visible = true;
                dgvListarTrabajadores.Columns["DNI"].Width = 75;
                dgvListarTrabajadores.Columns["DNI"].ReadOnly = true;
                dgvListarTrabajadores.Columns["Sexo"].Visible = true;
                dgvListarTrabajadores.Columns["Sexo"].Width =50;
                dgvListarTrabajadores.Columns["Sexo"].ReadOnly = true;
                dgvListarTrabajadores.Columns["FechaInicio"].Visible = true;
                dgvListarTrabajadores.Columns["FechaInicio"].Width = 78;
                dgvListarTrabajadores.Columns["FechaInicio"].ReadOnly = true;
            }
        }
        private void ConvertiraNumero(string tipoPago)
        {
            switch (tipoPago)
            {
                case "EFECTIVO":
                    {
                        nroTipoPago = "1";
                        break;
                    }
                case "DEPOSITO":
                    {
                        nroTipoPago = "2";
                        break;
                    }
                case "CHEQUE":
                    {
                        nroTipoPago = "3";
                        break;
                    }
            }
        }        private void ConvertiraNumero2(string periodicidad)
        {
            switch (periodicidad)
            {
                case "MENSUAL":
                    {
                        nroPeriodicidad = "1";
                        break;
                    }
                case "QUINCENAL":
                    {
                        nroPeriodicidad = "2";
                        break;
                    }
                case "SEMANAL":
                    {
                        nroPeriodicidad = "3";
                        break;
                    }
                case "DIARIA":
                    {
                        nroPeriodicidad = "4";
                        break;
                    }
                case "OTROS":
                    {
                        nroPeriodicidad = "5";
                        break;
                    }
            }
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
                        FechaTexto = "SEPTIEMBRE";
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
        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvListarTrabajadores.DataSource = oExportar.EXPORTARTODO(cbMes.Text, cbAños.Text);
            SeleccionarTodo();
        }
        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvListarTrabajadores.DataSource = oExportar.EXPORTARTODO(cbMes.Text, cbAños.Text);
            SeleccionarTodo();
        }
        private void Sexo(string Sexo)
        {
            switch (Sexo)
            {
                case "M":
                    {
                        nroSexo = 1;
                        break;
                    }
                case "F":
                    {
                        nroSexo = 2;
                        break;
                    }
            }
        }
        private void ConvertiraNumeroSalud(string RegimenSalud)
        {
            switch (RegimenSalud)
            {
                case "ESSALUD REGULAR (Exclusivamente)":
                    {
                        NroRegimenSalud = "00";
                        break;
                    }
                case "ESSALUD REGULAR Y EPS/SERV. PROPIOS":
                    {
                        NroRegimenSalud = "01";
                        break;
                    }

                case "ESSALUD AGRARIO/ ACUÍCOLA":
                    {
                        NroRegimenSalud = "04";
                        break;
                    }
            }
        }
        public void concatenarDatosIDE()
        {

            foreach (DataGridViewRow fila in dgvListarTrabajadores.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["☑"].Value) == true)
                {
                    string tipoVia2 = "", nombreVia2 = "", nroVia2 = "", departamento2 = "", interior2 = "", manzana2 = "", lote2 = "",
                    kilometro2 = "", block2 = "", etapa2 = "", tipoZona2 = "", nombreZona2 = "", referencia2 = "",
                    ubigeo2 = "", indicadorAsistenciaESSALUD = "1";
                    // obtenemos los datos de las columnas que queremos
                    string tipoDoc = "01";
                    string dni = fila.Cells["DNI"].Value.ToString();
                    string paisDoc = "604";
                    string apPaterno = fila.Cells["ApellidoPaterno"].Value.ToString();
                    string apMaterno = fila.Cells["ApellidoMaterno"].Value.ToString();
                    string nombres = fila.Cells["Nombres"].Value.ToString();
                    DateTime fechaNac = Convert.ToDateTime(fila.Cells["FechaNac"].Value.ToString());
                    string sexo = fila.Cells["Sexo"].Value.ToString();
                    Sexo(sexo);
                    string nacionalidad = fila.Cells["CodNac"].Value.ToString();
                    string telLargaDistancia = "84";
                    string telefono = fila.Cells["Celular"].Value.ToString();
                    if (telefono == "")
                    {
                        telefono = "000000000";
                    }
                    else;
                    string correo = fila.Cells["Email"].Value.ToString();
                    string tipoVia = fila.Cells["CodTipoVia"].Value.ToString();
                    string nombreVia = fila.Cells["NombreVia"].Value.ToString();
                    string nroVia = fila.Cells["NroVia"].Value.ToString();
                    string departamento = "";
                    string interior = fila.Cells["Departamento"].Value.ToString();

                    string manzana = "";
                    string lote = "";
                    string kilometro = "";
                    string block = "";
                    string etapa = "";
                    string tipoZona = fila.Cells["CodTipoZona"].Value.ToString();
                    string nombreZona = fila.Cells["NombreZona"].Value.ToString();
                    string referencia = fila.Cells["Referencia"].Value.ToString();
                    string ubigeo = fila.Cells["CodUbigeo"].Value.ToString();
                    ContenidoIDE = oExportar.ExportarDatosTrabajador(tipoDoc, dni, paisDoc, fechaNac.ToShortDateString(), apPaterno, apMaterno, nombres, nroSexo.ToString(), nacionalidad, telLargaDistancia, telefono, correo, tipoVia, nombreVia, nroVia, departamento, interior, manzana, lote, kilometro, block, etapa, tipoZona, nombreZona, referencia, ubigeo, tipoVia2, nombreVia2, nroVia2, departamento2, interior2, manzana2, lote2, kilometro2, block2, etapa2, tipoZona2, nombreZona2, referencia2, ubigeo2, indicadorAsistenciaESSALUD);
                    milistaIDE.Add(ContenidoIDE);
                }
            }
            SaveFileDialog Guardar = new SaveFileDialog();
            string RUC = "20226560824";
            string tipoArchivo = ".IDE";
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
                    for (int k = 0; k < milistaIDE.Count; k++)//mientras sea menor al contenido del arreglo(arraylist) guardará cada items k
                    {
                        escribir.WriteLine(milistaIDE[k]);//guarda en el bloc de notas 
                    }
                    escribir.Close();//cierra la escritura para que eje manejar por separado el bloc de notas
                    MessageBox.Show("Datos Exportados Exitosamente");//mensaje de cierre exitoso

                }
            }


        }
        private void concatenarDatosTRA()
        {
            foreach (DataGridViewRow fila in dgvListarTrabajadores.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["☑"].Value) == true)
                {

                    string tipoDoc = fila.Cells["@TipoDoc"].Value.ToString();
                    string dni = fila.Cells["DNI"].Value.ToString();
                    string paisDoc = fila.Cells["@PaisEmisor"].Value.ToString();
                    string RegimenLaboral = fila.Cells["CodRLTRA"].Value.ToString();
                    string SituacionEdu = fila.Cells["@SituacionEdu"].Value.ToString();
                    string Ocupacion = fila.Cells["CodOTRA"].Value.ToString();
                    string Discapacidad = fila.Cells["@Discapacidad"].Value.ToString();
                    string CUSPP = fila.Cells["CUSPP"].Value.ToString();
                    string SCTR = fila.Cells["@SCTR"].Value.ToString();
                    string tipoContrato = fila.Cells["CodTCTRA"].Value.ToString();
                    string regimenAlternativo = fila.Cells["@SRA"].Value.ToString();
                    string jornadaTrabajo = fila.Cells["@SJT"].Value.ToString();
                    string horarioNocturno = fila.Cells["@SHN"].Value.ToString();
                    string sindicalizado = fila.Cells["@Sindicalizado"].Value.ToString();
                    string periodicidad = fila.Cells["PerioRTTRA"].Value.ToString();
                    ConvertiraNumero2(periodicidad);
                    string remBasica = fila.Cells["@MontoRem"].Value.ToString();
                    string situacion = fila.Cells["@Situacion"].Value.ToString();
                    string Renta5ta = fila.Cells["@R5taExo"].Value.ToString();
                    string situacionEsp = fila.Cells["@SE"].Value.ToString();
                    string tipoPago = fila.Cells["TPRTTRA"].Value.ToString();
                    ConvertiraNumero(tipoPago);
                    string catOcupacional = "14";
                    //string catOcupacional = dgvListar[22, i].Value.ToString();
                    string convenio = fila.Cells["@CEDT"].Value.ToString();
                    string RUC = fila.Cells["@RUC"].Value.ToString();
                    string ContenidoTRA = oExportar.ExportarDatosTrabajador2(tipoDoc, dni, paisDoc, RegimenLaboral, SituacionEdu, Ocupacion, Discapacidad, CUSPP, SCTR, tipoContrato, regimenAlternativo, jornadaTrabajo, horarioNocturno, sindicalizado, nroPeriodicidad, remBasica, situacion, Renta5ta, situacionEsp, nroTipoPago, catOcupacional, convenio, RUC);
                    //MessageBox.Show(Contenido);
                    milistaTRA.Add(ContenidoTRA);
                }
            }   
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string ruc = "20226560824";
            string tipoArchivo = ".TRA";
            string rp = "RP_";
            string Titulo = rp + ruc + tipoArchivo;
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
                    for (int k = 0; k < milistaTRA.Count; k++)//mientras sea menor al contenido del arreglo(arraylist) guardará cada items k
                    {
                        escribir.WriteLine(milistaTRA[k]);//guarda en el bloc de notas 
                    }
                    escribir.Close();//cierra la escritura para que eje manejar por separado el bloc de notas
                    MessageBox.Show("Datos Exportados Exitosamente");//mensaje de cierre exitoso

                }
            }

        }
        public void concatenarDatosPER()
        {

            foreach (DataGridViewRow fila in dgvListarTrabajadores.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["☑"].Value) == true)
                {
                    //Periodos
                    string tipoRegistro = "1";
                    string dni = fila.Cells["DNI"].Value.ToString();
                    DateTime fechainicio = Convert.ToDateTime(fila.Cells["FechaInicio"].Value.ToString());
                    string fechafin = fila.Cells["FechaFin"].Value.ToString();
                    string indicadorTipoRegistro = fila.Cells["CodMotivoFin"].Value.ToString();
                    Periodos = oExportar.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, tipoRegistro, fechainicio.ToShortDateString(), fechafin, indicadorTipoRegistro, EPS);
                    milistaPER.Add(Periodos);
                    //TipoTrabajador
                    string tipoRegistro2 = "2";
                    DateTime fechainicio2 = Convert.ToDateTime(fila.Cells["FechaInicio"].Value.ToString());
                    string fechafin2 = fila.Cells["FechaFin"].Value.ToString();
                    string indicadorTipoRegistro2 = fila.Cells["@CodSunatTT"].Value.ToString();
                    TipoTrabajador = oExportar.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, tipoRegistro2, fechainicio2.ToShortDateString(), fechafin2, indicadorTipoRegistro2, EPS);
                    milistaPER.Add(TipoTrabajador);
                    //Regimen Aseguramiento Salud
                    string tipoRegistro3 = "3";
                    string fechainicio3 = fila.Cells["FechaInicioSalud"].Value.ToString();
                    string fechafin3 = fila.Cells["FechaFinSalud"].Value.ToString();
                    string indicadorTipoRegistro3 = fila.Cells["RegimenSalud"].Value.ToString();
                    ConvertiraNumeroSalud(indicadorTipoRegistro3);
                    RegimenAseguramiento = oExportar.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, tipoRegistro3, fechainicio3, fechafin3, NroRegimenSalud, EPS);
                    milistaPER.Add(RegimenAseguramiento);
                    //Regimen Pensionario
                    string tipoRegistro4 = "4";
                    string fechainicio4 = fila.Cells["FechaInicioRegPensionario"].Value.ToString();
                    string fechafin4 = fila.Cells["FechaFinRegPensionario"].Value.ToString();
                    string indicadorTipoRegistro4 = fila.Cells["CodAFP"].Value.ToString();
                    RegimenPensionario = oExportar.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, tipoRegistro4, fechainicio4, fechafin4, indicadorTipoRegistro4, EPS);
                    milistaPER.Add(RegimenPensionario);
                }
            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            Titulo = rp + RUC + tipoArchivo;
            Guardar.FileName = Titulo;
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
                    for (int k = 0; k < milistaPER.Count; k++)//mientras sea menor al contenido del arreglo(arraylist) guardará cada items k
                    {
                        escribir.WriteLine(milistaPER[k]);//guarda en el bloc de notas 
                    }
                    escribir.Close();//cierra la escritura para que eje manejar por separado el bloc de notas
                    MessageBox.Show("Datos Exportados Exitosamente");//mensaje de cierre exitoso

                }
            }
        }
        public void concatenarDatosEST()
        {
            foreach (DataGridViewRow fila in dgvListarTrabajadores.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["☑"].Value) == true)
                {
                    string tipoDoc = fila.Cells["@TipoDoc"].Value.ToString();
                    string dni = fila.Cells["DNI"].Value.ToString();
                    string paisDoc = fila.Cells["@PaisEmisor"].Value.ToString();
                    string ruc = "20226560824";
                    string Establecimientos = "";
                    string codEstab = "0000";
                    Establecimientos = oExportar.ExportarEstablecimiento(tipoDoc, dni, paisDoc, ruc, codEstab);
                    milistaEST.Add(Establecimientos);
                }
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
                    for (int k = 0; k < milistaEST.Count; k++)//mientras sea menor al contenido del arreglo(arraylist) guardará cada items k
                    {
                        escribir.WriteLine(milistaEST[k]);//guarda en el bloc de notas 
                    }
                    escribir.Close();//cierra la escritura para que eje manejar por separado el bloc de notas
                    MessageBox.Show("Datos Exportados Exitosamente");//mensaje de cierre exitoso

                }
            } }
        public void concatenarDatosEDU()
        {
            foreach (DataGridViewRow fila in dgvListarTrabajadores.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["☑"].Value) == true)
                {

                    string tipoDoc = fila.Cells["@TipoDoc"].Value.ToString();
                    string dni = fila.Cells["DNI"].Value.ToString();
                    string paisDoc = fila.Cells["@PaisEmisor"].Value.ToString();
                    string situacionEdu = "11";
                    string indicador = "0";
                    string Estudios = "";
                    string palo = "|";
                    Estudios = tipoDoc + palo + dni + palo + paisDoc + palo + situacionEdu + palo + indicador + palo + palo + palo + palo;
                    milistaEDU.Add(Estudios);

                }
            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string RUC = "20226560824";
            string tipoArchivo = ".EDU";
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
                    for (int k = 0; k < milistaEDU.Count; k++)//mientras sea menor al contenido del arreglo(arraylist) guardará cada items k
                    {
                        escribir.WriteLine(milistaEDU[k]);//guarda en el bloc de notas 
                    }
                    escribir.Close();//cierra la escritura para que eje manejar por separado el bloc de notas
                    MessageBox.Show("Datos Exportados Exitosamente");//mensaje de cierre exitoso

                }
            }


        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            
                if (checkIDE.Checked == true)
                {
                    
                    concatenarDatosIDE();
                    milistaIDE.Clear();
                }
                if (checkTRA.Checked == true)
                {
                   
                    concatenarDatosTRA();
                    milistaTRA.Clear();
                }
                if (checkPER.Checked == true)
                {
                    
                    concatenarDatosPER();
                    milistaPER.Clear();
                }
                if (checkEST.Checked == true)
                {
                    
                    concatenarDatosEST();
                    milistaEST.Clear();
                }
                if (checkEDU.Checked == true)
                {
                    
                    concatenarDatosEDU();
                    milistaEDU.Clear();
                }
                if (checkIDE.Checked == false && checkTRA.Checked == false && checkPER.Checked == false && checkEST.Checked == false && checkEDU.Checked == false)
                {
                    MessageBox.Show("No a seleccionado ningun tipo de texto a exportar");
                }    
        }
        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionarTodo();
        }
        private void SeleccionarTodo()
        {
            if (checkSelectAll.Checked == true)
            {
                for (int i = 0; i < dgvListarTrabajadores.Rows.Count; i++)
                {
                    dgvListarTrabajadores[0, i].Value = true;
                    
                }
            }
            else
                for (int i = 0; i < dgvListarTrabajadores.Rows.Count; i++)
                {
                    dgvListarTrabajadores[0, i].Value = false;
                   
                }
        }
    }
}

