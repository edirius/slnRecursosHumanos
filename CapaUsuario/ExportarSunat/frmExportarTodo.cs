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
using CapaUsuario.Properties;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmExportarTodo : Form
    {
        ArrayList milistaIDE = new ArrayList();
        ArrayList milistaTRA = new ArrayList();
        ArrayList milistaPER = new ArrayList();
        ArrayList milistaEST = new ArrayList();
        ArrayList milistaEDU = new ArrayList();

        List<cDatosIdentificacion> ListaDatosIdentificacion = new List<ExportarSunat.cDatosIdentificacion>();
        List<cDatosTrabajador> ListaDatosTrabajador = new List<cDatosTrabajador>();
        List<cDatosPeriodo> ListaDatosPeriodo = new List<cDatosPeriodo>();
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
        string SRCT = "";
        string Ruta = "";
        string Titulo = "";
        string RUC = Settings.Default.RUC;
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
                dgvListarTrabajadores.Columns["Nombres"].Width = 140;
                dgvListarTrabajadores.Columns["Nombres"].DisplayIndex = 4;
                dgvListarTrabajadores.Columns["Nombres"].ReadOnly = true;
                dgvListarTrabajadores.Columns["ApellidoPaterno"].Visible = true;
                dgvListarTrabajadores.Columns["ApellidoPaterno"].Width = 140;
                dgvListarTrabajadores.Columns["ApellidoPaterno"].ReadOnly = true;
                dgvListarTrabajadores.Columns["ApellidoMaterno"].Visible = true;
                dgvListarTrabajadores.Columns["ApellidoMaterno"].Width = 140;
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
                dgvListarTrabajadores.Columns["PlanillaD"].Visible = true;
                dgvListarTrabajadores.Columns["PlanillaD"].Width = 180;
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
        }
        private void ConvertiraNumero2(string periodicidad)
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
                    cDatosIdentificacion oDatosIdenticacion = new cDatosIdentificacion();

                    string tipoVia2 = "", nombreVia2 = "", nroVia2 = "", departamento2 = "", interior2 = "", manzana2 = "", lote2 = "",
                    kilometro2 = "", block2 = "", etapa2 = "", tipoZona2 = "", nombreZona2 = "", referencia2 = "",
                    ubigeo2 = "", indicadorAsistenciaESSALUD = "1";
                    oDatosIdenticacion.IndicadorEssalud.Valor = indicadorAsistenciaESSALUD;

                    // obtenemos los datos de las columnas que queremos
                    string tipoDoc = "01";
                    oDatosIdenticacion.TipoDocumento.Valor = tipoDoc;
                    string dni = fila.Cells["DNI"].Value.ToString();
                    oDatosIdenticacion.NumeroDocumento.Valor = dni;
                    string paisDoc = "604";
                    oDatosIdenticacion.PaisEmisor.Valor = paisDoc;
                    string apPaterno = fila.Cells["ApellidoPaterno"].Value.ToString();
                    oDatosIdenticacion.ApellidoPaterno.Valor = apPaterno;
                    string apMaterno = fila.Cells["ApellidoMaterno"].Value.ToString();
                    oDatosIdenticacion.ApellidoMaterno.Valor = apMaterno;
                    string nombres = fila.Cells["Nombres"].Value.ToString();
                    oDatosIdenticacion.Nombres.Valor = nombres;
                    DateTime fechaNac = Convert.ToDateTime(fila.Cells["FechaNac"].Value.ToString());
                    oDatosIdenticacion.FechaNacimiento.Valor = fechaNac.ToShortDateString();
                    string sexo = fila.Cells["Sexo"].Value.ToString();
                    Sexo(sexo);
                    oDatosIdenticacion.Sexo.Valor = nroSexo.ToString();
                    string nacionalidad = fila.Cells["CodNac"].Value.ToString();
                    oDatosIdenticacion.Nacionalidad.Valor = nacionalidad;
                    string telLargaDistancia = "";
                    oDatosIdenticacion.TelefonoLargaDistancia.Valor = telLargaDistancia;
                    string telefono = fila.Cells["Celular"].Value.ToString();
                    if (telefono == "")
                    {
                        telefono = "984696969";
                    }
                    else;
                    oDatosIdenticacion.Telefono.Valor = telefono;
                    string correo = fila.Cells["Email"].Value.ToString();
                    if (correo == "")
                    {
                        correo = nombres.Substring(0,3).Trim() + apPaterno.Substring(0,3).Trim() + apMaterno.Substring(0,3).Trim() + "@gmail.com";
                    }
                    oDatosIdenticacion.CorreoElectronico.Valor = correo;
                    string tipoVia = fila.Cells["CodTipoVia"].Value.ToString();
                    oDatosIdenticacion.TipoVia.Valor = tipoVia;
                    string nombreVia = fila.Cells["NombreVia"].Value.ToString();
                    
                    string nroVia = fila.Cells["NroVia"].Value.ToString();
                    
                    if (nombreVia == "")
                    {
                        nombreVia = "0";
                    }
                    oDatosIdenticacion.NombreVia.Valor = nombreVia;
                    if (nroVia == "")
                    {
                        nroVia = "0";
                    }
                    oDatosIdenticacion.NumeroVia.Valor = nroVia;
                    string departamento = "";
                    oDatosIdenticacion.Departamento.Valor = departamento;
                    string interior = fila.Cells["Departamento"].Value.ToString();
                    oDatosIdenticacion.Interior.Valor = interior;
                    string manzana = "";
                    oDatosIdenticacion.Manzana.Valor = manzana;
                    string lote = "";
                    oDatosIdenticacion.Lote.Valor = lote;
                    string kilometro = "";
                    oDatosIdenticacion.Kilometro.Valor = kilometro;
                    string block = "";
                    oDatosIdenticacion.Block.Valor = block;
                    string etapa = "";
                    oDatosIdenticacion.Etapa.Valor = etapa;
                    string tipoZona = fila.Cells["CodTipoZona"].Value.ToString();
                    oDatosIdenticacion.TipoZona.Valor = tipoZona;
                    string nombreZona = fila.Cells["NombreZona"].Value.ToString();
                    if (nombreZona == "")
                    {
                        nombreZona = "0";
                    }
                    oDatosIdenticacion.NombreZona.Valor = nombreZona;
                    string referencia = fila.Cells["Referencia"].Value.ToString();
                    oDatosIdenticacion.Referencia.Valor = referencia;
                    string ubigeo = fila.Cells["CodUbigeo"].Value.ToString();
                    oDatosIdenticacion.Ubigeo.Valor = ubigeo;
                    ContenidoIDE = oExportar.ExportarDatosTrabajador(tipoDoc, dni, paisDoc, fechaNac.ToShortDateString(), apPaterno, apMaterno, nombres, nroSexo.ToString(), nacionalidad, telLargaDistancia, telefono, correo, tipoVia, nombreVia, nroVia, departamento, interior, manzana, lote, kilometro, block, etapa, tipoZona, nombreZona, referencia, ubigeo, tipoVia2, nombreVia2, nroVia2, departamento2, interior2, manzana2, lote2, kilometro2, block2, etapa2, tipoZona2, nombreZona2, referencia2, ubigeo2, indicadorAsistenciaESSALUD);
                    milistaIDE.Add(ContenidoIDE);
                    ListaDatosIdentificacion.Add(oDatosIdenticacion);
                   
                }
                
            }

            SaveFileDialog Guardar = new SaveFileDialog();
            string RUC = Settings.Default.RUC; 
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
                    //Periodos
                    string tipoRegistro = "1";
                    string dni = fila.Cells["DNI"].Value.ToString();
                    DateTime fechainicio = Convert.ToDateTime(fila.Cells["FechaInicio"].Value.ToString());
                    //string fechafin = fila.Cells["FechaFin"].Value.ToString();
                    string fechafin = "";
                    string indicadorTipoRegistro = fila.Cells["CodMotivoFin"].Value.ToString();
                    cDatosPeriodo oDatoPeriodo = new cDatosPeriodo();

                    oDatoPeriodo.TipoDocumento.Valor = tipoDoc;
                    oDatoPeriodo.NumeroDocumento.Valor = dni;
                    oDatoPeriodo.PaisEmisor.Valor = paisDoc;
                    oDatoPeriodo.Categoria.Valor = Categoria;
                    oDatoPeriodo.TipoRegistro.Valor = tipoRegistro;
                    oDatoPeriodo.FechaInicio.Valor = fechainicio.ToShortDateString();
                    oDatoPeriodo.FechaFin.Valor = fechafin;
                    oDatoPeriodo.IndicadorTipoRegistro.Valor = indicadorTipoRegistro;
                    oDatoPeriodo.EpsServiciosPropios.Valor = EPS;
                    ListaDatosPeriodo.Add(oDatoPeriodo);

                    Periodos = oExportar.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, tipoRegistro, fechainicio.ToShortDateString(), fechafin, indicadorTipoRegistro, EPS);
                    milistaPER.Add(Periodos);
                    //TipoTrabajador
                    string tipoRegistro2 = "2";
                    DateTime fechainicio2 = Convert.ToDateTime(fila.Cells["FechaInicio"].Value.ToString());
                    //string fechafin2 = fila.Cells["FechaFin"].Value.ToString();
                    string fechafin2 = "";
                    string indicadorTipoRegistro2 = fila.Cells["CodSunatTT"].Value.ToString();

                    cDatosPeriodo oDatoPeriodo2 = new cDatosPeriodo();
                    oDatoPeriodo2.TipoDocumento.Valor = tipoDoc;
                    oDatoPeriodo2.NumeroDocumento.Valor = dni;
                    oDatoPeriodo2.PaisEmisor.Valor = paisDoc;
                    oDatoPeriodo2.Categoria.Valor = Categoria;
                    oDatoPeriodo2.TipoRegistro.Valor = tipoRegistro2;
                    oDatoPeriodo2.FechaInicio.Valor = fechainicio2.ToShortDateString();
                    oDatoPeriodo2.FechaFin.Valor = fechafin2;
                    oDatoPeriodo2.IndicadorTipoRegistro.Valor = indicadorTipoRegistro2;
                    oDatoPeriodo2.EpsServiciosPropios.Valor = EPS;
                    ListaDatosPeriodo.Add(oDatoPeriodo2);

                    TipoTrabajador = oExportar.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, tipoRegistro2, fechainicio2.ToShortDateString(), fechafin2, indicadorTipoRegistro2, EPS);
                    milistaPER.Add(TipoTrabajador);
                    //Regimen Aseguramiento Salud
                    string tipoRegistro3 = "3";
                    DateTime fechainicio3 = Convert.ToDateTime(fila.Cells["FechaInicioSalud"].Value.ToString());
                    string fechafin3 = "";
                    //string fechafin3 = fila.Cells["FechaFinSalud"].Value.ToString();
                    string indicadorTipoRegistro3 = fila.Cells["RegimenSalud"].Value.ToString();
                    ConvertiraNumeroSalud(indicadorTipoRegistro3);

                    cDatosPeriodo oDatoPeriodo3 = new cDatosPeriodo();
                    oDatoPeriodo3.TipoDocumento.Valor = tipoDoc;
                    oDatoPeriodo3.NumeroDocumento.Valor = dni;
                    oDatoPeriodo3.PaisEmisor.Valor = paisDoc;
                    oDatoPeriodo3.Categoria.Valor = Categoria;
                    oDatoPeriodo3.TipoRegistro.Valor = tipoRegistro3;
                    oDatoPeriodo3.FechaInicio.Valor = fechainicio3.ToShortDateString();
                    oDatoPeriodo3.FechaFin.Valor = fechafin3;
                    oDatoPeriodo3.IndicadorTipoRegistro.Valor = NroRegimenSalud;
                    oDatoPeriodo3.EpsServiciosPropios.Valor = EPS;
                    ListaDatosPeriodo.Add(oDatoPeriodo3);

                    RegimenAseguramiento = oExportar.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, tipoRegistro3, fechainicio3.ToShortDateString(), fechafin3, NroRegimenSalud, EPS);
                    milistaPER.Add(RegimenAseguramiento);
                    //Regimen Pensionario
                    string tipoRegistro4 = "4";
                    DateTime fechainicio4 = Convert.ToDateTime(fila.Cells["FechaInicioRegPensionario"].Value.ToString());
                    string fechafin4 = "";
                    //string fechafin4 = fila.Cells["FechaFinRegPensionario"].Value.ToString();
                    string indicadorTipoRegistro4 = fila.Cells["CodAFP"].Value.ToString();

                    cDatosPeriodo oDatoPeriodo4 = new cDatosPeriodo();

                    oDatoPeriodo4.TipoDocumento.Valor = tipoDoc;
                    oDatoPeriodo4.NumeroDocumento.Valor = dni;
                    oDatoPeriodo4.PaisEmisor.Valor = paisDoc;
                    oDatoPeriodo4.Categoria.Valor = Categoria;
                    oDatoPeriodo4.TipoRegistro.Valor = tipoRegistro4;
                    oDatoPeriodo4.FechaInicio.Valor = fechainicio4.ToShortDateString();
                    oDatoPeriodo4.FechaFin.Valor = fechafin4;
                    oDatoPeriodo4.IndicadorTipoRegistro.Valor = indicadorTipoRegistro4;
                    oDatoPeriodo4.EpsServiciosPropios.Valor = EPS;
                    ListaDatosPeriodo.Add(oDatoPeriodo4);

                    RegimenPensionario = oExportar.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, tipoRegistro4, fechainicio4.ToShortDateString(), fechafin4, indicadorTipoRegistro4, EPS);
                    milistaPER.Add(RegimenPensionario);

                    //SRCT
                    if (chkSRCT.Checked)
                    {
                        string tipoRegistro5 = "5";
                        DateTime fechainicio5 = Convert.ToDateTime(fila.Cells["FechaInicioSalud"].Value.ToString());
                        string fechafin5 = "";
                        //string fechafin5 = fila.Cells["FechaFinSalud"].Value.ToString();
                        string indicadorTipoRegistro5 = "1";

                        if (RUC == "20200737211")
                        {
                            indicadorTipoRegistro5 = "2";
                        }
                        cDatosPeriodo oDatoPeriodo5 = new cDatosPeriodo();

                        oDatoPeriodo5.TipoDocumento.Valor = tipoDoc;
                        oDatoPeriodo5.NumeroDocumento.Valor = dni;
                        oDatoPeriodo5.PaisEmisor.Valor = paisDoc;
                        oDatoPeriodo5.Categoria.Valor = Categoria;
                        oDatoPeriodo5.TipoRegistro.Valor = tipoRegistro5;
                        oDatoPeriodo5.FechaInicio.Valor = fechainicio5.ToShortDateString();
                        oDatoPeriodo5.FechaFin.Valor = fechafin5;
                        oDatoPeriodo5.IndicadorTipoRegistro.Valor = indicadorTipoRegistro5;
                        oDatoPeriodo5.EpsServiciosPropios.Valor = EPS;
                        ListaDatosPeriodo.Add(oDatoPeriodo5);

                        SRCT = oExportar.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, tipoRegistro5, fechainicio5.ToShortDateString(), fechafin5, indicadorTipoRegistro5, EPS);
                        milistaPER.Add(SRCT);
                    }


                   // parte periodos
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
                    string catOcupacional;
                    //string catOcupacional = "14";
                    //fila.Cells["CodCOTRA"].Value.ToString(); ;
                    if (indicadorTipoRegistro2 == "20")
                    {
                        catOcupacional = "";
                    }
                    else
                    {
                        catOcupacional = fila.Cells["CodCOTRA"].Value.ToString();
                    }
                    //CAS
                    if (indicadorTipoRegistro2== "67")
                    {
                        tipoContrato = "14";
                    }

                    string convenio = fila.Cells["@CEDT"].Value.ToString();
                    string RUCTrabajador = fila.Cells["RUC"].Value.ToString();

                    if (indicadorTipoRegistro2 == "67" || indicadorTipoRegistro2 == "23" || indicadorTipoRegistro2 == "66" || indicadorTipoRegistro2 == "71" || indicadorTipoRegistro2 == "73" || indicadorTipoRegistro2 == "77")
                    {
                        Renta5ta = "";
                        convenio = "";
                    }

                    cDatosTrabajador oDataTrabajador = new cDatosTrabajador();
                    oDataTrabajador.TipoDocumento.Valor = tipoDoc;
                    oDataTrabajador.NumeroDocumento.Valor = dni;
                    oDataTrabajador.PaisEmisor.Valor = paisDoc;
                    oDataTrabajador.RegimenLaboral.Valor = RegimenLaboral;
                    oDataTrabajador.SituacionEducativa.Valor = SituacionEdu;
                    oDataTrabajador.Ocupacion.Valor = Ocupacion;
                    oDataTrabajador.Discapacidad.Valor = Discapacidad;
                    oDataTrabajador.Cuspp.Valor = CUSPP;
                    oDataTrabajador.SctrPension.Valor = SCTR;
                    oDataTrabajador.TipoContrato.Valor = tipoContrato;
                    oDataTrabajador.SujetoRegimenAlternativo.Valor = regimenAlternativo;
                    oDataTrabajador.SujetoJornadaMaxima.Valor = jornadaTrabajo;
                    oDataTrabajador.SujetoHorarioNocturno.Valor = horarioNocturno;
                    oDataTrabajador.Sindicalizado.Valor = sindicalizado;
                    oDataTrabajador.PeriocidadIngreso.Valor = nroPeriodicidad;
                    oDataTrabajador.MontoRemuneracionBasica.Valor = remBasica;
                    oDataTrabajador.Situacion.Valor = situacion;
                    oDataTrabajador.Renta5taExonerada.Valor = Renta5ta;
                    oDataTrabajador.SituacionEspecial.Valor = situacionEsp;
                    oDataTrabajador.TipoPago.Valor = nroTipoPago;
                    oDataTrabajador.CategoriaOcupacion.Valor = catOcupacional;
                    oDataTrabajador.ConvenioPagoDobleTributacion.Valor = convenio;
                    oDataTrabajador.Ruc.Valor = RUCTrabajador;
                    ListaDatosTrabajador.Add(oDataTrabajador);

                    string ContenidoTRA = oExportar.ExportarDatosTrabajador2(tipoDoc, dni, paisDoc, RegimenLaboral, SituacionEdu, Ocupacion, Discapacidad, CUSPP, SCTR, tipoContrato, regimenAlternativo, jornadaTrabajo, horarioNocturno, sindicalizado, nroPeriodicidad, remBasica, situacion, Renta5ta, situacionEsp, nroTipoPago, catOcupacional, convenio, RUCTrabajador);
                    //MessageBox.Show(Contenido);
                    milistaTRA.Add(ContenidoTRA);
                }
            }   
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string ruc = Settings.Default.RUC;
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
                    string ruc = Settings.Default.RUC;
                    string Establecimientos = "";
                    string codEstab = "0000";
                    Establecimientos = oExportar.ExportarEstablecimiento(tipoDoc, dni, paisDoc, ruc, codEstab);
                    milistaEST.Add(Establecimientos);
                }
            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string RUC = Settings.Default.RUC;
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
            string RUC = Settings.Default.RUC;
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

        private void frmExportarTodo_Load(object sender, EventArgs e)
        {
            tipMensaje.SetToolTip(checkIDE, "Incluir Datos de Identificacion");
            tipMensaje.SetToolTip(checkPER, "Incluir Datos de Periodos");
            tipMensaje.SetToolTip(checkEST, "Incluir Datos de Establecimiento");
            tipMensaje.SetToolTip(checkTRA, "Incluir Datos de Trabajo");
            tipMensaje.SetToolTip(checkEDU, "Incluir Datos de Educacion");
            tipMensaje.SetToolTip(chkSRCT, "Incluir Datos de SRCT");
        }

        private void btnVerCodificacion_Click(object sender, EventArgs e)
        {
            frmVerCodificacion fVerCodificacion = new frmVerCodificacion();
            fVerCodificacion.ListaDatosIdentificacion = ListaDatosIdentificacion;
            fVerCodificacion.ListaDatosTrabajador = ListaDatosTrabajador;
            fVerCodificacion.ListaDatosPeriodos = ListaDatosPeriodo;
            fVerCodificacion.Periodo = new DateTime(Convert.ToInt16(cbAños.Text), ConvertirMes(cbMes.Text), 1);
            if (fVerCodificacion.ShowDialog() == DialogResult.OK)
            {

            }                
        }

        private int ConvertirMes(string mes)
        {
            int numeroMes = 0;
            switch (mes)
            {
                case "ENERO":
                    {
                        numeroMes = 1;
                        break;
                    }
                case "FEBRERO":
                    {
                        numeroMes = 2;
                        break;
                    }
                case "MARZO":
                    {
                        numeroMes = 3;
                        break;
                    }
                case "ABRIL":
                    {
                        numeroMes = 4;
                        break;
                    }
                case "MAYO":
                    {
                        numeroMes = 5;
                        break;
                    }
                case "JUNIO":
                    {
                        numeroMes = 6;
                        break;
                    }
                case "JULIO":
                    {
                        numeroMes = 7;
                        break;
                    }
                case "AGOSTO":
                    {
                        numeroMes = 8;
                        break;
                    }
                case "SETIEMBRE":
                    {
                        numeroMes = 9;
                        break;
                    }
                case "OCTUBRE":
                    {
                        numeroMes = 10;
                        break;
                    }
                case "NOVIEMBRE":
                    {
                        numeroMes = 11;
                        break;
                    }
                case "DICIEMBRE":
                    {
                        numeroMes =12;
                        break;
                    }
            }
            return numeroMes;
        }
    }
}

