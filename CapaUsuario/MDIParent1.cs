﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeDatos;
using CapaDeNegocios.Obras;
using cWord;
using CapaUsuario.Properties;
using CapaDeNegocios;
using MySql.Data.MySqlClient;

namespace CapaUsuario
{
    public partial class frmPrincipal : Form
    {
        public static CapaDeNegocios.Reloj.cServidorReloj oServidorReloj = new CapaDeNegocios.Reloj.cServidorReloj();

        public static string NombreEmpresa;

        public static string RUCEmpresa;

        

        public frmPrincipal()
        {
            InitializeComponent();
           
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                Conexion.IniciarSesion(Settings.Default.ConexionMySql, "bdpersonal", "root", "root");
                NombreEmpresa = Settings.Default.Empresa;
                RUCEmpresa = Settings.Default.RUC;
               
                //MessageBox.Show(String.Format("{0}", "Se conecto exitosamente"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Usuarios.frmListaTrabajadores fMantenimientoUsuarios = new Usuarios.frmListaTrabajadores();
            fMantenimientoUsuarios.MdiParent = this;
            fMantenimientoUsuarios.Show();

            //Metas.frmProgramaPresupuestal fProgramaPresupuestal = new Metas.frmProgramaPresupuestal();
            //fProgramaPresupuestal.MdiParent = this;
            //fProgramaPresupuestal.Show();
        }

        private void ShowProgramaPresupuestal(object sender, EventArgs e)
        {
            Metas.frmProgramaPresupuestal fProgramaPresupuestal = new Metas.frmProgramaPresupuestal();
            fProgramaPresupuestal.MdiParent = this;
            fProgramaPresupuestal.Show();
        }
       

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Metas.frmProductoProyecto fProductoProyecto = new Metas.frmProductoProyecto();
            fProductoProyecto.MdiParent = this;
            fProductoProyecto.Show();
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Metas.frmActividadObra fActividadObra = new Metas.frmActividadObra();
            fActividadObra.MdiParent = this;
            fActividadObra.Show();
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Metas.frmFuncion fFuncion = new Metas.frmFuncion();
            fFuncion.MdiParent = this;
            fFuncion.Show();
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Metas.frmGrupoFuncional fGrupo = new Metas.frmGrupoFuncional();
            fGrupo.MdiParent = this;
            fGrupo.Show();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Metas.frmDivisionFuncional fDivisionFuncional = new Metas.frmDivisionFuncional();
            fDivisionFuncional.MdiParent = this;
            fDivisionFuncional.Show();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AFP.frmComisionesAFP fComisionesAFP = new AFP.frmComisionesAFP();

            fComisionesAFP.miListaAFP = new CapaDeNegocios.cListaAFP();
            
            fComisionesAFP.miListaAFP.ObtenerListaAFP();
            fComisionesAFP.MdiParent = this;
            fComisionesAFP.Show();
            //hh
        }

        private void mantenimientoDeTrabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trabajador.frmListaTrabajadores fListaTrabajadores = new Trabajador.frmListaTrabajadores();
            fListaTrabajadores.MdiParent = this;
            fListaTrabajadores.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tareo.frmMantenimientoTareo fTareo = new Tareo.frmMantenimientoTareo();
            fTareo.MdiParent = this;
            fTareo.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Metas.frmMantenimientoMetas fMeta = new Metas.frmMantenimientoMetas();
            fMeta.MdiParent = this;
            fMeta.Show();
        }

        private void metaJornalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResidenteMeta.frmMetaJornal fMetaJornal = new ResidenteMeta.frmMetaJornal();
            fMetaJornal.MdiParent = this;
            fMetaJornal.Show();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AFP.frmListaAFPs fListaAFP = new AFP.frmListaAFPs();

            fListaAFP.MdiParent = this;
            fListaAFP.Show();
        }

        private void mantenimientoDeCargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trabajador.frmListaCargo miListaCargos = new Trabajador.frmListaCargo();
            miListaCargos.Show();
        }

        private void residenteMetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResidenteMeta.frmMantenimientoResidenteMeta fMantenimientoResidenteMeta = new ResidenteMeta.frmMantenimientoResidenteMeta();
            fMantenimientoResidenteMeta.MdiParent = this;
            fMantenimientoResidenteMeta.Show();
        }

        private void maestroIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sunat.frmMantenimientoMaestroIngresos fMantenimientoMaestroIngresos = new Sunat.frmMantenimientoMaestroIngresos();
            fMantenimientoMaestroIngresos.MdiParent = this;
            fMantenimientoMaestroIngresos.Show();
        }

        private void maestroAportacionesTrabajadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sunat.frmMantenimientoMaestroAportacionesTrabajador fMantenimientoMaestroAportacionesTrabajador = new Sunat.frmMantenimientoMaestroAportacionesTrabajador();
            fMantenimientoMaestroAportacionesTrabajador.MdiParent = this;
            fMantenimientoMaestroAportacionesTrabajador.Show();
        }

        private void maestroDescuentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sunat.frmMantenimientoMaestroAportacionesEmpleador fMantenimientoMaestroAportacionesEmpleador = new Sunat.frmMantenimientoMaestroAportacionesEmpleador();
            fMantenimientoMaestroAportacionesEmpleador.MdiParent = this;
            fMantenimientoMaestroAportacionesEmpleador.Show();
        }

        private void maestroDescuentosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sunat.frmMantenimientoMaestroDescuentos fMantenimientoMaestroDescuentos = new Sunat.frmMantenimientoMaestroDescuentos();
            fMantenimientoMaestroDescuentos.MdiParent = this;
            fMantenimientoMaestroDescuentos.Show();
        }

        private void planillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planilla.frmMatenimientoPlanilla fPlanilla = new Planilla.frmMatenimientoPlanilla();
            fPlanilla.MdiParent = this;
            fPlanilla.Show();
        }

        private void plantillaPlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planilla.frmMantenimientoPlantillaPlanilla fPlantillaPlanilla = new Planilla.frmMantenimientoPlantillaPlanilla();
            fPlantillaPlanilla.MdiParent = this;
            fPlantillaPlanilla.Show();
        }

        cDocumentoWord cMiword;

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cMiword = new cDocumentoWord();
                cMiword.trabajador = "Edward Crisologo Roman Castro";
                cMiword.dni = "41919785";
                cMiword.direccion = "Urb.Balconcillo B-1";
                cMiword.distrito = "Cusco";
                cMiword.provincia = "Cusco";
                cMiword.departamento = "Cusco";
                cMiword.direccion = "Urb. Balconcillo B-1";
                cMiword.cargo = "Jefe de la Unidad de Recursos Humanos";
                cMiword.monto = "S/. 1500.00 (Mil quinientos Nuevos Soles)";
                cMiword.fecha = DateTime.Now.ToLongDateString();
                cMiword.Iniciar();
            }
            catch { }
            
        }

        private void variablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Variables.frmMantenimientoVariables fMantenimientoVariables = new Variables.frmMantenimientoVariables();
            fMantenimientoVariables.MdiParent = this;
            fMantenimientoVariables.Show();
        }

        private void fuenteFinanciamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Variables.frmMantenimientoFuenteFinanciamiento fMantenimientoFuenteFinanciamiento = new Variables.frmMantenimientoFuenteFinanciamiento();
            fMantenimientoFuenteFinanciamiento.MdiParent = this;
            fMantenimientoFuenteFinanciamiento.Show();
        }

        private void IR5taCategoriatoolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Planilla.frmImpuestoAlaRentaDe5taCategoria f5ta = new Planilla.frmImpuestoAlaRentaDe5taCategoria();
            f5ta.MdiParent = this;
            f5ta.Show();
        }

        private void tributosYDescuentosDelTrabajadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarSunat.frmExportarTributosDescuentosTrabajador frmExportarTDT = new ExportarSunat.frmExportarTributosDescuentosTrabajador();
            frmExportarTDT.MdiParent = this;
            frmExportarTDT.Show();
        }

        private void exportarAExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarSunat.frmExportarExcel frmExcel = new ExportarSunat.frmExportarExcel();
            frmExcel.MdiParent = this;
            frmExcel.Show();
        }

        private void boletaPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void planillaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void boletaPagoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CapaUsuario.Reportes.frmBoletaPago fBoletaPago = new CapaUsuario.Reportes.frmBoletaPago();
            fBoletaPago.MdiParent = this;
            fBoletaPago.Show();
        }

        private void planillaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CapaUsuario.Reportes.frmPlanilla fPlanilla = new CapaUsuario.Reportes.frmPlanilla();
            fPlanilla.MdiParent = this;
            fPlanilla.Show();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaUsuario.Reportes.frmTrabajadores fTrabajador = new CapaUsuario.Reportes.frmTrabajadores();
            fTrabajador.MdiParent = this;
            fTrabajador.Show();
        }

        private void boletaPagoPorPlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaUsuario.Reportes.frmBoletaPagoXPlanilla fBoletaPagoXPlanilla = new CapaUsuario.Reportes.frmBoletaPagoXPlanilla();
            fBoletaPagoXPlanilla.MdiParent = this;
            fBoletaPagoXPlanilla.Show();
        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaUsuario.Reportes.frmPersonal fPersonal = new CapaUsuario.Reportes.frmPersonal();
            fPersonal.MdiParent = this;
            fPersonal.Show();
        }

        private void datosDelPensionistaPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarSunat.frmDatosDelPensionista frmDatosdelPensionista = new ExportarSunat.frmDatosDelPensionista();
            frmDatosdelPensionista.MdiParent = this;
            frmDatosdelPensionista.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void exportarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarSunat.frmExportarTodo frmTodo = new ExportarSunat.frmExportarTodo();
            frmTodo.MdiParent = this;
            frmTodo.Show();
        }

        private void darDeBajaAlTrabajadorTREGISTROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarSunat.frmDarDeBajaTrabajador FRMDEBAJA = new ExportarSunat.frmDarDeBajaTrabajador();
            FRMDEBAJA.MdiParent = this;
            FRMDEBAJA.Show();
        }

        private void reportesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void declaraciónJuradaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaUsuario.Reportes.frmDeclaracionJurada frmDeclaracionJurada = new CapaUsuario.Reportes.frmDeclaracionJurada();
            frmDeclaracionJurada.MdiParent = this;
            frmDeclaracionJurada.Show();
        }

        private void consultaMasivaAFPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarSunat.frmConsultaMasivaSunat frmMASIVA = new ExportarSunat.frmConsultaMasivaSunat();
            frmMASIVA.MdiParent = this;
            frmMASIVA.Show();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            CapaUsuario.Usuarios.frmLogin frmLogin = new Usuarios.frmLogin();
            Application.Exit();
        }
        //Dar privilegios al usuario según su cargo
        CapaUsuario.Usuarios.frmLogin FrmLogin = new CapaUsuario.Usuarios.frmLogin();
        CapaDeNegocios.Usuario.cUsuario oUsu = new CapaDeNegocios.Usuario.cUsuario();
        bool menuAFP, menuUsuario, menuTrabajadores, menuTareos, menuMeta, menuPlanillas, menuSunatTablasParametricas, menuExportarDatosSunat, menuReportes, menuBoletas, habilitado;

        private void restaurarCopiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value="";

            if (MessageBox.Show("Con esta accion se borrara toda la informacion actual: Desea restaurar el backup???", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                
                var dialogResult = DialogResult2.InputBox("Password", "Ingrese el password del admin:", ref value);

                if (dialogResult == DialogResult.OK)
                {
                    if (value == "12345678")
                    {
                        RestaurarBBDDMySql();
                    }
                    else
                    {
                        MessageBox.Show("Error en el password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                
            }
        }

        private void trabajadoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Trabajador.frmListaTrabajadores fListaTrabajadores = new Trabajador.frmListaTrabajadores();
            fListaTrabajadores.MdiParent = this;
            fListaTrabajadores.Show();
        }

        private void numeraciónContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Contrato.frmNumeracionContrato fNumeracionContrato = new Contrato.frmNumeracionContrato();
            //fNumeracionContrato.MdiParent = this;
            //fNumeracionContrato.Show();
        }

        private void impresionPlanillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.frmPlanilla2 fPlanillas = new Reportes.frmPlanilla2();
            fPlanillas.MdiParent = this;
            fPlanillas.Show();
        }

        private void mnuResumenXDetallePlanillas_Click(object sender, EventArgs e)
        {
            Reportes.frmResumenDetallePlanilla fResumenDetalle = new Reportes.frmResumenDetallePlanilla();
            fResumenDetalle.MdiParent = this;
            fResumenDetalle.Show();
        }

        private void residenteMetaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ResidenteMeta.frmMantenimientoResidenteMeta fMantenimientoResidenteMeta = new ResidenteMeta.frmMantenimientoResidenteMeta();
            fMantenimientoResidenteMeta.MdiParent = this;
            fMantenimientoResidenteMeta.Show();
        }

        private void horasHombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tareo.frmHorasHombre fHorasHombre = new Tareo.frmHorasHombre();
            fHorasHombre.MdiParent = this;
            fHorasHombre.Show();
        }

        private void toolImportadorExcel_Click(object sender, EventArgs e)
        {
            ImportadorExcel.frmImportadorExcel fImportadorExcel = new ImportadorExcel.frmImportadorExcel();
            fImportadorExcel.MdiParent = this;
            fImportadorExcel.Show();
        }

        private void menuClasificadores_Click(object sender, EventArgs e)
        {
            Clasificadores.frmListaClasificadoresGasto fListaClasificadorGasto = new Clasificadores.frmListaClasificadoresGasto();
            fListaClasificadorGasto.MdiParent = this;
            fListaClasificadorGasto.Show();
        }

        private void asignarClasificadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClasificadorMeta.frmClasificadorMeta fClasificadorMeta = new ClasificadorMeta.frmClasificadorMeta();

            if (fClasificadorMeta.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void mnuListaHorarios_Click(object sender, EventArgs e)
        {
            try
            {
                Asistencia.frmMantenimientoHorario fMantenimientoHorario = new Asistencia.frmMantenimientoHorario();
                if (fMantenimientoHorario.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostra la lista de horario: " + ex.Message);
            }
        }

        private void mnuListaTurnosXDia_Click(object sender, EventArgs e)
        {
            try
            {
                Asistencia.frmListaTurnosDia fListaTurnosDia = new Asistencia.frmListaTurnosDia();
                if (fListaTurnosDia.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la lista de turnos x dia: " + ex.Message);
            }
        }

        private void mnuListaTurnos_Click(object sender, EventArgs e)
        {
            try
            {
                Asistencia.frmListaTurnos fListaTurnos = new Asistencia.frmListaTurnos();
                if (fListaTurnos.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la lista de turnos: " + ex.Message);
            }
        }

        private void mnuListaDiasFestivos_Click(object sender, EventArgs e)
        {
            try
            {
                Asistencia.frmListaDiasFestivos fListaDiasFestivos = new Asistencia.frmListaDiasFestivos();
                if (fListaDiasFestivos.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la lista de dias festivos: " + ex.Message);
            }
        }

        private void mnuAsistenciaTrabajador_Click(object sender, EventArgs e)
        {
            try
            {
                Asistencia.frmTrabajadorExcepcion fTrabajadoresExcepcion = new Asistencia.frmTrabajadorExcepcion();
                if (fTrabajadoresExcepcion.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la asistencia de trabajadores: " + ex.Message);
            }
        }

        private void btnConexionReloj_Click(object sender, EventArgs e)
        {
            try
            {
                Reloj.frmAdministrarReloj fAdministrarReloj = new Reloj.frmAdministrarReloj();
                fAdministrarReloj.oServidorReloj = oServidorReloj;
                if (fAdministrarReloj.ShowDialog() == DialogResult.OK)
                {
                    oServidorReloj = fAdministrarReloj.oServidorReloj;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la conexion del reloj: " + ex.Message);
            }
        }

        private void btnDescargarDatosReloj_Click(object sender, EventArgs e)
        {
            try
            {
                Reloj.frmAsistenciaReloj fAsistenciareloj = new Reloj.frmAsistenciaReloj();
                fAsistenciareloj.oServidorReloj = oServidorReloj;

                if (fAsistenciareloj.ShowDialog() == DialogResult.OK)
                {
                    oServidorReloj = fAsistenciareloj.oServidorReloj;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del reloj: " + ex.Message);
            }
        }

        private void servidorIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios.frmModificarServidor fModificarUsuarios = new Usuarios.frmModificarServidor();
            fModificarUsuarios.ShowDialog();
        }

        private void cargaInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargaInicial.frmCargaInicial fCargaInicial = new CargaInicial.frmCargaInicial();
            fCargaInicial.ShowDialog();
        }

        private void tributosYDescuentosDelTrabajadorPDTPLAME2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarSunat.frmExportarTributosDescuentos2 frmExportarTDT = new ExportarSunat.frmExportarTributosDescuentos2();
            frmExportarTDT.MdiParent = this;
            frmExportarTDT.Show();
        }

        private void plantillaDeTareosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tareo.frmListaPlantillaTareos fListaTareos = new Tareo.frmListaPlantillaTareos();
            fListaTareos.MdiParent = this;
            fListaTareos.Show();
        }

        private void analiticoPlanillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.frmAnaliticoPlanilla fAnaliticoPlanilla = new Reportes.frmAnaliticoPlanilla();
            fAnaliticoPlanilla.MdiParent = this;
            fAnaliticoPlanilla.Show();
        }

        private void boletaPago2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.frmBoletaPagoxTrabajador fBoletaPagoXTrabajador = new Reportes.frmBoletaPagoxTrabajador();
            fBoletaPagoXTrabajador.MdiParent = this;
            fBoletaPagoXTrabajador.Show();
        }

        private void planilla2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.frmPlanilla2 fPlanilla2 = new Reportes.frmPlanilla2();
            fPlanilla2.MdiParent = this;
            fPlanilla2.Show();
        }

        private void verficadorDNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportadorExcel.frmVerificadorDNI fVerificadorDNI = new ImportadorExcel.frmVerificadorDNI();
            fVerificadorDNI.Show();
        }

        private void mnuPrivilegios_Click(object sender, EventArgs e)
        {
            Usuarios.frmListaPrivilegios fListaPrivilegios = new Usuarios.frmListaPrivilegios();
            if (fListaPrivilegios.ShowDialog()== DialogResult.OK)
            {

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About.AboutBox1 fSobre = new About.AboutBox1();
            fSobre.ShowDialog();
        }

        private void listaTiposSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Asistencia.frmListaTiposSalida fListaTipoSalida = new Asistencia.frmListaTiposSalida();
            fListaTipoSalida.MdiParent = this;
            fListaTipoSalida.Show();
        }

        private void darDeAltaAlTrabajadorV2TREGISTROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarSunat.Tregistro.frmDarAltaTregistro fDarAltaTregistro = new ExportarSunat.Tregistro.frmDarAltaTregistro();
            fDarAltaTregistro.MdiParent = this;
            fDarAltaTregistro.Show();
        }

        private void listaRelojesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reloj.frmListaRelojes fListaRelojes = new Reloj.frmListaRelojes();
            fListaRelojes.MdiParent = this;
            fListaRelojes.Show();
        }

        private void mnuTrabajadoresSinPlanilla_Click(object sender, EventArgs e)
        {
            Planilla.TrabajadoresSinPlanilla.frmTrabajadoresSinPlanilla fTrabajadoresSinPlanilla = new Planilla.TrabajadoresSinPlanilla.frmTrabajadoresSinPlanilla();
            fTrabajadoresSinPlanilla.MdiParent = this;
            fTrabajadoresSinPlanilla.Show();
        }

        private void reporteTrabajadoreXAñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.ReporteTrabaxAño.frmReporteTrabajadorXAño fReporteTrabajadorXAño = new Reportes.ReporteTrabaxAño.frmReporteTrabajadorXAño();
            fReporteTrabajadorXAño.MdiParent = this;
            fReporteTrabajadorXAño.Show();
        }

        private void bajarDatosDelRelojToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reloj.frmBajarDatosReloj fBajarDatosReloj = new Reloj.frmBajarDatosReloj();
            fBajarDatosReloj.MdiParent = this;
            fBajarDatosReloj.Show();
        }

        private void gruposParaAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Asistencia.GrupoAsistencia.frmListaGrupoAsistencia fListaGrupoAsistencia = new Asistencia.GrupoAsistencia.frmListaGrupoAsistencia();
            fListaGrupoAsistencia.MdiParent = this;
            fListaGrupoAsistencia.Show();
        }

        private void mnuResidenteMeta_Click(object sender, EventArgs e)
        {
            ResidenteMeta.frmMantenimientoResidenteMeta fMantenimientoResidenteMeta = new ResidenteMeta.frmMantenimientoResidenteMeta();
            fMantenimientoResidenteMeta.MdiParent = this;
            fMantenimientoResidenteMeta.Show();
        }

        private void generarCopiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupBBDDMySQL();
        }

        private void tipoDeSuspencionLaboralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sunat.frmMantenimientoTipoSuspencionLaboral fMantenimientoTipoSuspencionLaboral = new Sunat.frmMantenimientoTipoSuspencionLaboral();
            fMantenimientoTipoSuspencionLaboral.MdiParent = this;
            fMantenimientoTipoSuspencionLaboral.Show();
        }

        private void asistentiaDeTrabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Asistencia.frmAsistenciaTrabajadores fAsistenciaTrabajadores = new Asistencia.frmAsistenciaTrabajadores();
            fAsistenciaTrabajadores.MdiParent = this;
            fAsistenciaTrabajadores.Show();
        }

        private void globalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaUsuario.Reportes.frmResumenPlanillas frmPlanillaGlobal  = new CapaUsuario.Reportes.frmResumenPlanillas();
            frmPlanillaGlobal.MdiParent = this;
            frmPlanillaGlobal.Show();
        }

        private void certificadoDeRetencionesDeQuintaCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaUsuario.Reportes.frmCertificado frmCertificado = new CapaUsuario.Reportes.frmCertificado();
            frmCertificado.MdiParent = this;
            frmCertificado.Show();
        }

        public void DarPrivilegios(string UsuarioLogin)
        {
            string Usuario = "";
            string Cargo = "";
            dgvCargo.DataSource = oUsu.ObtenerPrivilegios(UsuarioLogin);

            foreach (DataGridViewRow fila in dgvCargo.Rows)
            {
                Usuario = "Usuario: " + fila.Cells["Usuario"].Value.ToString();
                Cargo = "Cargo: " + fila.Cells["Cargo"].Value.ToString();
                menuAFP = Convert.ToBoolean(fila.Cells["menuAFP"].Value);
                menuUsuario = Convert.ToBoolean(fila.Cells["menuUsuario"].Value);
                menuTrabajadores = Convert.ToBoolean(fila.Cells["menuTrabajadores"].Value);
                menuTareos = Convert.ToBoolean(fila.Cells["menuTareos"].Value);
                menuMeta = Convert.ToBoolean(fila.Cells["menuMeta"].Value);
                menuPlanillas = Convert.ToBoolean(fila.Cells["menuPlanillas"].Value);
                menuSunatTablasParametricas = Convert.ToBoolean(fila.Cells["menuSunatTablasParametricas"].Value);
                menuExportarDatosSunat = Convert.ToBoolean(fila.Cells["menuExportarDatosSunat"].Value);
                menuReportes = Convert.ToBoolean(fila.Cells["menuReportes"].Value);
                menuBoletas = Convert.ToBoolean(fila.Cells["menuBoletas"].Value);
                habilitado = Convert.ToBoolean(fila.Cells["habilitado"].Value);
                toolStripStatusLabel1.Text = Usuario;
                toolStripStatusLabel2.Text = Cargo;
                cTrabajador TrabajadorLogueado = new cTrabajador();
                if (cVariablesUsuario.v_idtrabajador != "1" & cVariablesUsuario.v_idtrabajador != "")
                {
                    TrabajadorLogueado = TrabajadorLogueado.traerTrabajador(Convert.ToInt16(cVariablesUsuario.v_idtrabajador));
                    toolStripStatusLabel3.Text = "Nombre Trabajador: " + TrabajadorLogueado.Nombres + " " + TrabajadorLogueado.ApellidoPaterno + " " + TrabajadorLogueado.ApellidoMaterno;
                }
                
                cVariablesUsuario.v_cargo = fila.Cells["Cargo"].Value.ToString();
                OcultarMenu();
            }
        }

        public void OcultarMenu()
        {
            if (habilitado == true)
            {
                if (menuAFP == true) { fileMenu.Visible = true; }
                else { fileMenu.Visible = false; newToolStripButton.Visible = false; }
                if (menuUsuario == true) { editMenu.Visible = true; }
                else { editMenu.Visible = false; }
                if (menuTrabajadores == true) { viewMenu.Visible = true; }
                else { viewMenu.Visible = false; helpToolStripButton.Visible = false; }
                if (menuTareos == true) { toolsMenu.Visible = true; }
                else { toolsMenu.Visible = false; }
                if (menuMeta == true) { windowsMenu.Visible = true; }
                else { windowsMenu.Visible = false; }
                if (menuPlanillas == true) {
                    planillasToolStripMenuItem.Visible = true;
                    printPreviewToolStripButton.Visible = true;
                    printToolStripButton.Visible = true;
                    toolImportadorExcel.Visible = true;
                    contratosToolStripMenuItem.Visible = true;
                }
                else {
                    planillasToolStripMenuItem.Visible = false;
                    printPreviewToolStripButton.Visible = false;
                    printToolStripButton.Visible = false;
                    toolImportadorExcel.Visible = false;
                    contratosToolStripMenuItem.Visible = false;
                }
                if (menuSunatTablasParametricas == true) { sUNATToolStripMenuItem.Visible = true; }
                else { sUNATToolStripMenuItem.Visible = false; }
                if (menuExportarDatosSunat == true) { exportarTextoSUNATToolStripMenuItem.Visible = true; }
                else { exportarTextoSUNATToolStripMenuItem.Visible = false; }
               
                if (menuBoletas == true)
                {
                    reportesToolStripMenuItem1.Visible = true;
                    planilla2ToolStripMenuItem.Visible = false;
                    planillaToolStripMenuItem2.Visible = false;
                    personalToolStripMenuItem.Visible = false;
                    trabajadoresToolStripMenuItem.Visible = false;
                    globalToolStripMenuItem.Visible = false;
                    impresionPlanillasToolStripMenuItem.Visible = false;
                    mnuResumenXDetallePlanillas.Visible = false;
                    analiticoPlanillasToolStripMenuItem.Visible = false;
                    declaraciónJuradaDeToolStripMenuItem.Visible = false;
                }
                else
                {
                    reportesToolStripMenuItem1.Visible = false; printToolStripButton.Visible = false;
                }

                if (menuReportes == true)
                {
                    reportesToolStripMenuItem1.Visible = true;
                    planilla2ToolStripMenuItem.Visible = true;
                    planillaToolStripMenuItem2.Visible = true;
                    personalToolStripMenuItem.Visible = true;
                    trabajadoresToolStripMenuItem.Visible = true;
                    globalToolStripMenuItem.Visible = true;
                    impresionPlanillasToolStripMenuItem.Visible = true;
                    mnuResumenXDetallePlanillas.Visible = true;
                    analiticoPlanillasToolStripMenuItem.Visible = true;
                    declaraciónJuradaDeToolStripMenuItem.Visible = true;
                }
                else {
                    if (menuBoletas)
                    {
                        reportesToolStripMenuItem1.Visible = true;
                    }
                    else
                    {
                        reportesToolStripMenuItem1.Visible = false;
                    }
                    printToolStripButton.Visible = false;
                }
            }
            else
            {
                const string message = "El usuario no se encuentra habilitado. Póngase en contacto con el administrador del sistema.";
                const string caption = "Usuario Deshabilitado";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        private void BackupBBDDMySQL()
        {
            try
            {
                //SaveFileDialog fd;
                //fd = new SaveFileDialog();
                //DialogResult dialogo;
                //dialogo = fd.ShowDialog();
                //if (dialogo == DialogResult.OK)
                //{
                //    if (fd.FileName != String.Empty)
                //    {
                //        String linea;
                //        fichero = fd.FileName;
                //        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                //        proc.EnableRaisingEvents = false;
                //        proc.StartInfo.UseShellExecute = false;
                //        proc.StartInfo.RedirectStandardOutput = true;
                //        proc.StartInfo.FileName = "mysqldump";
                //        proc.StartInfo.Arguments = "base_datos --single-transaction --host=ip_del_servidor --user=usuario --password=clave";
                //        Process miProceso;
                //        miProceso = Process.Start(proc.StartInfo);
                //        StreamReader sr = miProceso.StandardOutput;
                //        TextWriter tw = new StreamWriter(fd.FileName, false, Encoding.Default);
                //        while ((linea = sr.ReadLine()) != null)
                //        {
                //            tw.WriteLine(linea);
                //        }
                //        tw.Close();
                //        MessageBox.Show("Copia de seguridad realizada con éxito");
                //    }
                //}

                
                string constring = "server=" + Settings.Default.ConexionMySql + ";user=root;pwd=root;database=bdpersonal;CharSet=utf8;";
                string file =  "D:\\backup.sql";

                dlgSalvarArchivo.Filter = "Archivo sql (*.sql)|*.SQL|Todos los archivos (*.*)|*.*";
                if (dlgSalvarArchivo.ShowDialog() == DialogResult.OK)
                {
                    file = dlgSalvarArchivo.FileName;
                    using (MySqlConnection conn = new MySqlConnection(constring))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ExportToFile(file);
                                conn.Close();
                                MessageBox.Show("Backup creado con exito.");
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Se ha cancelado la operacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Se ha producido un error al realizar la copia de seguridad: " + exc.Message);
            }
        }

        private void RestaurarBBDDMySql()
        {
            try
            {
                //Process miProceso;
                //miProceso = new Process();
                ////Es necesario que el fichero mysql.exe esté en el PATH del sistema
                //miProceso.StartInfo.FileName = "mysql";
                //miProceso.StartInfo.Arguments = "--host=ip_servidor --database=bbdd --user=usuario --password=clave";
                //miProceso.StartInfo.RedirectStandardInput = true;
                //miProceso.StartInfo.UseShellExecute = false;
                //miProceso.Start();

                //StreamWriter myStreamWriter = miProceso.StandardInput;
                //myStreamWriter.Write(File.ReadAllText(path_fichero_mysqldump, Encoding.Default));
                //myStreamWriter.Close();

                //miProceso.WaitForExit();
                //miProceso.Close();
                //MessageBox.Show("Se ha finalizado la restauración de datos con éxito");

                

               
                string constring = "server="+ Settings.Default.ConexionMySql + "; user=root; pwd=root;database=bdpersonal;CharSet=utf8;";
                string file = "D:\\backup.sql";
                dlgAbrirArchivo.Filter = "Archivo sql (*.sql)|*.SQL|Todos los archivos (*.*)|*.*";
                if (dlgAbrirArchivo.ShowDialog() == DialogResult.OK)
                {
                    file = dlgAbrirArchivo.FileName;
                
                    using (MySqlConnection conn = new MySqlConnection(constring))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ImportFromFile(file);
                                conn.Close();
                                MessageBox.Show("Restauracion Exitosa");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Se ha cancelado la operacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Se ha producido un error. Mensaje: " + exc.Message);
            }
        }
    }
}
