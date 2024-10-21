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
    public partial class frmExportarTributosDescuentosTrabajador : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oExportar = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        CapaDeNegocios.PlanillaNueva.blPlanilla oPlanilla = new CapaDeNegocios.PlanillaNueva.blPlanilla();

        string Ingresos, Descuentos, Aportaciones = ""; 
        string Titulo = "";
        string Nromes = "";
        string FechaTexto = "";
        ArrayList milista = new ArrayList();
        ArrayList milistaJornada = new ArrayList();
        ArrayList milistaSCTR = new ArrayList();

        public frmExportarTributosDescuentosTrabajador()
        {
            InitializeComponent();
            txtRuc.Text = Properties.Settings.Default.RUC;
            DateTime Ahora = DateTime.Today;
            CargarMes(Ahora);
            cbMes.Text = FechaTexto;
            CargarAños();
            CargarPlanillas();
            //dgvPlanilla.Visible = false;
            label2.Visible = false;
            label5.Visible = false;
            txtCodForm.Visible = false;
            txtRuc.Visible = false;
            txtRuc.Text = Settings.Default.RUC;
           
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


        private void CargarPlanillas()
        {
            
            //dgvListaPlanillas.DataSource = oExportar.ListarPlanillas();
            
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            milista.Clear();
            milistaJornada.Clear();
            milistaSCTR.Clear();

            if (dgvListaPlanillas.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvListaPlanillas.Rows)
                {
                    if (Convert.ToBoolean(fila.Cells["CHK"].Value) == true)
                    {
                        CapaDeNegocios.PlanillaNueva.cnPlanilla miPlanilla = new CapaDeNegocios.PlanillaNueva.cnPlanilla();
                        miPlanilla = oPlanilla.TraerPlanilla(Convert.ToInt32(fila.Cells["colIdtPlanilla"].Value.ToString()));
                        foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanilla detalle in miPlanilla.ListaDetalle)
                        {
                            string mes = miPlanilla.Mes;
                            string año = miPlanilla.Año;
                            string TipoDoc = "01";
                            string dni = detalle.miTrabajador.Dni;
                            string NHO = "192";
                            string NMO = "";
                            string NHS = "";
                            string NMS = "";

                            string Ruc = txtRuc.Text;
                            string Palo = "|";
                            ConvertirMes(mes);
                            string Jornada = "";
                            Jornada = TipoDoc + Palo + dni + Palo + NHO + Palo + NMO + Palo + NHS + Palo + NMS + Palo;

                            milistaJornada.Add(Jornada);//agregamos los datos concatenados al arreglo(ArrayList)

                            int contadorUnico = 0;
                            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaIngresos ingreso in detalle.ListaDetalleIngresos)
                            {
                                if (!(ingreso.MaestroIngresos.Codigo == "0000" || ingreso.MaestroIngresos.Informativa == true))
                                {
                                    if (miPlanilla.TipoImpresionTardanzaFalta == CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta.AfectaAlSueldo && (ingreso.MaestroIngresos.Codigo == "0122" || ingreso.MaestroIngresos.Codigo == "0121" || ingreso.MaestroIngresos.Codigo == "2039") && contadorUnico==0)
                                    {
                                        contadorUnico++;
                                        double tardanza = 0;
                                        double falta = 0;
                                        foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaEgresos descuento in detalle.ListaDetalleEgresos)
                                        {
                                            if (descuento.MaestroDescuentos.Codigo == "0704")
                                            {
                                                tardanza = descuento.Monto;
                                            }
                                            if (descuento.MaestroDescuentos.Codigo == "0705")
                                            {
                                                falta = descuento.Monto;
                                            }
                                        }
                                        string codigo = ingreso.MaestroIngresos.Codigo;
                                        string MontoDevengado = (ingreso.Monto +tardanza + falta).ToString();
                                        string Monto = (ingreso.Monto + tardanza + falta).ToString();
                                        string codigoform = "0601";
                                        ConvertirMes(mes);
                                        Ingresos = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                                        Titulo = oExportar.ExportarTitulo(codigoform, año, Nromes, Ruc);
                                        milista.Add(Ingresos);//agregamos los datos concatenados al arreglo(ArrayList)
                                    }
                                    else
                                    {
                                        string codigo = ingreso.MaestroIngresos.Codigo;
                                        string MontoDevengado = ingreso.Monto.ToString();
                                        string Monto = ingreso.Monto.ToString();
                                        string codigoform = "0601";
                                        ConvertirMes(mes);
                                        Ingresos = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                                        Titulo = oExportar.ExportarTitulo(codigoform, año, Nromes, Ruc);
                                        milista.Add(Ingresos);//agregamos los datos concatenados al arreglo(ArrayList)
                                    }
                                    
                                }
                            }
                            bool EstaEnSNP = false;

                            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesTrabajador aportacionT in detalle.ListaDetalleAportacionesTrabajador)
                            {
                                //si cumple, esta en SNP
                                if (aportacionT.MaestroAportacionTrabajador.Codigo == "0607" && aportacionT.Monto > 0)
                                {
                                    EstaEnSNP = true;
                                }
                            }

                            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesTrabajador aportacionT in detalle.ListaDetalleAportacionesTrabajador)
                            {
                                //si cumple, esta en SNP
                                if (EstaEnSNP && (aportacionT.MaestroAportacionTrabajador.Codigo == "0608" || aportacionT.MaestroAportacionTrabajador.Codigo == "0601" || aportacionT.MaestroAportacionTrabajador.Codigo == "0606" || aportacionT.MaestroAportacionTrabajador.Codigo == "0607"))
                                {
                                    // no importar
                                }
                                else
                                {
                                    if (!(aportacionT.MaestroAportacionTrabajador.Codigo == "0607" || aportacionT.MaestroAportacionTrabajador.Codigo == "0604"))
                                    {
                                        string codigo = aportacionT.MaestroAportacionTrabajador.Codigo;
                                        string MontoDevengado = aportacionT.Monto.ToString();
                                        string Monto = aportacionT.Monto.ToString();
                                        ConvertirMes(mes);
                                        Aportaciones = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                                        milista.Add(Aportaciones);//agregamos los datos concatenados al arreglo(ArrayList)
                                    }

                                }
                            }

                            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaEgresos descuento in detalle.ListaDetalleEgresos)
                            {
                                if (chkDescuentos.Checked == true)
                                {
                                    string codigo = descuento.MaestroDescuentos.Codigo;
                                    string MontoDevengado = descuento.Monto.ToString();
                                    string Monto = descuento.Monto.ToString();
                                    Descuentos = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                                    milista.Add(Descuentos);//agregamos los datos concatenados al arreglo(ArrayList)
                                }
                                else
                                {
                                    if (descuento.MaestroDescuentos.Codigo != "0704" && descuento.MaestroDescuentos.Codigo != "0705")
                                    {
                                        string codigo = descuento.MaestroDescuentos.Codigo;
                                        string MontoDevengado = descuento.Monto.ToString();
                                        string Monto = descuento.Monto.ToString();
                                        Descuentos = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                                        milista.Add(Descuentos);//agregamos los datos concatenados al arreglo(ArrayList)
                                    }
                                }
                            }

                            foreach (CapaDeNegocios.PlanillaNueva.cnDetallePlanillaAportacionesEmpleador aportacionE in detalle.ListaDetalleAportacionesEmpleador)
                            {
                                //806 es el codigo de essalud
                                if (aportacionE.Monto > 0 && aportacionE.MaestroAportacionesEmpleador.Codigo == "0806")
                                {
                                    ConvertirMes(mes);
                                    string srct = "";
                                    srct = TipoDoc + Palo + dni + Palo + "1" + Palo + "1.53" + Palo;

                                    milistaSCTR.Add(srct);//agregamos los datos concatenados al arreglo(ArrayList)
                                }

                                if (aportacionE.Monto > 0 && (aportacionE.MaestroAportacionesEmpleador.Codigo == "0805" || aportacionE.MaestroAportacionesEmpleador.Codigo == "0810"))
                                {
                                    if (aportacionE.MaestroAportacionesEmpleador.Codigo == "0810")
                                    {
                                        aportacionE.MaestroAportacionesEmpleador.Codigo = "0814";
                                    }
                                    string codigo = aportacionE.MaestroAportacionesEmpleador.Codigo;
                                    string MontoDevengado = aportacionE.Monto.ToString();
                                    string Monto = aportacionE.Monto.ToString();
                                    ConvertirMes(mes);
                                    Aportaciones = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                                    milista.Add(Aportaciones);//agregamos los datos concatenados al arreglo(ArrayList)
                                }
                            }
                        }
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
            else
            {
                MessageBox.Show("No esta seleccionado ninguna planilla.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public ArrayList SumarDuplicados(ArrayList lista)
        {
            string cadena = "";
            ArrayList NuevaLista = new ArrayList();
            Boolean encontrado = false;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                if (lista[i].ToString()!="")
                {
                    cadena = lista[i].ToString().Substring(0, 16);
                }
                else
                {
                    cadena = "";
                }
                encontrado = false;
                for (int j = 0; j < lista.Count; j++)
                {
                    if (i != j )
                    {
                        if ( (lista[j].ToString()!= "") && (cadena == lista[j].ToString().Substring(0, 16)))
                        {
                            encontrado = true;
                            lista[i] = sumarCadenas(lista[i].ToString(), lista[j].ToString());
                            lista[j] = "";
                        }
                    }

                }
            }

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].ToString() !="")
                {
                    NuevaLista.Add(lista[i]);
                }
                
            }
            return NuevaLista;
        }

        private string sumarCadenas(string cadena1, string cadena2)
        {
            string[] valor1 = cadena1.Split('|');
            string[] valor2 = cadena2.Split('|');

            double monto1 = Convert.ToDouble(valor1[4]);
            double monto2 = Convert.ToDouble(valor2[4]);
            string nuevaCadena = oExportar.ExportarTexto(valor1[0], valor1[1], valor1[2], (monto1 + monto2).ToString(), (monto1 + monto2).ToString());
            return nuevaCadena;
        }

        public void CrearCarpeta()
        {
            DirectoryInfo di = Directory.CreateDirectory(@"C:\Users\Usuario\Desktop\Textos SUNAT");//ruta de la carpeta
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


        private void SalvarDatosRem()
        {
            if (chkDuplicados.Checked)
            {
                milista = SumarDuplicados(milista);
            }
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

        private void dgvListaPlanillas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            dgvListaPlanillas.DataSource = oExportar.BuscarPlanillas(cbMes.Text, cbAños.Text);
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void frmExportarTributosDescuentosTrabajador_Load(object sender, EventArgs e)
        {
            pbSunat.SizeMode = PictureBoxSizeMode.StretchImage;
        }

       

        private void dgvListaPlanillas_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void CheckJornada_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnMarcarTodo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dgvListaPlanillas.Rows)
            {
                fila.Cells["CHK"].Value = true;
            }
        }

        private void bntListarTodo_Click(object sender, EventArgs e)
        {
            
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
    }
}
