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
    public partial class frmListaTrabajadores : Form
    {
        CapaDeNegocios.Obras.cCadenaProgramaticaFuncional oCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional(); 

        int pidttrabajador = 0;
        string trabajador = "";

        private string filtroRegimeLaboral = "Todos";
        private string filtroSituacionLaboral = "Todos";

        private DataTable tablaAuxiliar;
        private DataTable tablaAuxiliar2;
        public frmListaTrabajadores()
        {
            InitializeComponent();
        }

        public cTrabajador miListaTrabajadores = new cTrabajador();

        private void Iniciar()
        {
            tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, "", "", "", "", filtroRegimeLaboral, "Todos");
            tablaAuxiliar2 = miListaTrabajadores.ObtenerListaTrabajadoresConReloj(filtroSituacionLaboral, "", "", "", "", filtroRegimeLaboral, "Todos",DateTime.Today);

            //tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral);
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
            lblNumeroTrabajadores.Text = "Nro de trabajadores: " +  dtgListaTrabajadores.Rows.Count.ToString();
            //if (dtgListaTrabajadores.Rows.Count > 0)
            //{
            //    DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
            //    dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Selected = true;
            //    dtgListaTrabajadores_CellClick(dtgListaTrabajadores, cea);
            //}

            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = DateTime.Now.Year.ToString();
            cboMeta.DisplayMember = "nombreMeta";
            cboMeta.ValueMember = "idtmeta";
            cboMeta.DataSource = oCadena.ListarMetas(Convert.ToInt16(cboAño.Text));
            treeFiltro.ExpandAll();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListaTrabajadores_Load(object sender, EventArgs e)
        {
             Iniciar();
        }

        private void btnNuevoTrabajador_Click_1(object sender, EventArgs e)
        {
            try
            {
                Trabajador.frmNuevoTrabajador fNuevoTrabajador = new frmNuevoTrabajador();
                fNuevoTrabajador.miTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorServidorPersonal();
                fNuevoTrabajador.miTrabajador.FechaNacimiento = DateTime.Now;
                if (fNuevoTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miListaTrabajadores.AgregarTrabajador(fNuevoTrabajador.miTrabajador);
                    tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral);
                    dtgListaTrabajadores.DataSource = tablaAuxiliar; 
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message); 
            }
        }

        private void btnModificarTrabajador_Click(object sender, EventArgs e)
        {
            try
            {
                Trabajador.frmNuevoTrabajador fModificarTrabajador = new frmNuevoTrabajador();
                fModificarTrabajador.miTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorServidorPersonal();
                fModificarTrabajador.miTrabajador = fModificarTrabajador.miTrabajador.traerTrabajador(Convert.ToInt16(dtgListaTrabajadores.SelectedRows[0].Cells["id_trabajador"].Value.ToString()));

                if (fModificarTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miListaTrabajadores.ModificarTrabajador(fModificarTrabajador.miTrabajador);
                    tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral);
                    dtgListaTrabajadores.DataSource = tablaAuxiliar;
                    lblNumeroTrabajadores.Text = "Nro de trabajadores: " + dtgListaTrabajadores.Rows.Count.ToString();
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message); 
                
            }
        }

       private void btnEliminarTrabajador_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Eliminar", "¿Desea eliminar al trabajador?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    cTrabajador miTrabajador = new cTrabajador();
                    miTrabajador.IdTrabajador = Convert.ToInt16(dtgListaTrabajadores.SelectedRows[0].Cells["id_trabajador"].Value.ToString());
                    miListaTrabajadores.EliminarTrabajador(miTrabajador);
                    tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral);
                    dtgListaTrabajadores.DataSource = tablaAuxiliar; 
                    lblNumeroTrabajadores.Text = "Nro de trabajadores: " + dtgListaTrabajadores.Rows.Count.ToString();
                }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }
        }

        private void dtgListaTrabajadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgListaTrabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReporteContratos_Click(object sender, EventArgs e)
        {
            if (dtgListaTrabajadores.SelectedRows.Count > 0)
            {
                pidttrabajador = Convert.ToInt32(dtgListaTrabajadores.SelectedRows[0].Cells["id_trabajador"].Value);
            }
            CapaUsuario.Reportes.MostrarReportes Reportes = new CapaUsuario.Reportes.MostrarReportes();
            Reportes.ReporteContratos("ReporteContratos", pidttrabajador);
            Reportes.MdiParent = this.MdiParent;
            Reportes.Show();
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            if (dtgListaTrabajadores.SelectedRows.Count > 0)
            {
                pidttrabajador = Convert.ToInt32(dtgListaTrabajadores.SelectedRows[0].Cells["id_trabajador"].Value);
                trabajador = Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["nombres"].Value) + " " + Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["apellidoPaterno"].Value) + " " + Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["apellidoMaterno"].Value);
            }
            CapaUsuario.Contrato.frmMantenimientoContrato fListarContrato = new Contrato.frmMantenimientoContrato();
            fListarContrato.RecibirDatos(pidttrabajador, trabajador);
            fListarContrato.MdiParent = this.MdiParent;
            fListarContrato.Show();
        }

        private void btnDatosLaborales_Click(object sender, EventArgs e)
        {
            if (dtgListaTrabajadores.SelectedRows.Count  > 0)
            {
                pidttrabajador = Convert.ToInt32(dtgListaTrabajadores.SelectedRows[0].Cells["id_trabajador"].Value);
                trabajador = Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["nombres"].Value) + " " + Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["apellidoPaterno"].Value) + " " + Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["apellidoMaterno"].Value);
            }
            CapaUsuario.Trabajador.frmMantenimientoPeriodoTrabajador fPeriodoTrabajador = new CapaUsuario.Trabajador.frmMantenimientoPeriodoTrabajador();
            fPeriodoTrabajador.RecibirDatos(pidttrabajador, trabajador);
            fPeriodoTrabajador.ShowDialog();
        }

        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos");
            tablaAuxiliar2 = miListaTrabajadores.ObtenerListaTrabajadoresConReloj(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos", DateTime.Today);
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
            lblNumeroTrabajadores.Text = "Nro de trabajadores: " + dtgListaTrabajadores.Rows.Count.ToString();
        }

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos");
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
            lblNumeroTrabajadores.Text = "Nro de trabajadores: " + dtgListaTrabajadores.Rows.Count.ToString();
        }

        private void btnBuscarAPaterno_Click(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos");
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
            lblNumeroTrabajadores.Text = "Nro de trabajadores: " + dtgListaTrabajadores.Rows.Count.ToString();
        }

        private void btnBuscarAMaterno_Click(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos");
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
            lblNumeroTrabajadores.Text = "Nro de trabajadores: " + dtgListaTrabajadores.Rows.Count.ToString();
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMeta.DisplayMember = "nombreMeta";
            cboMeta.ValueMember = "idtmeta";
            cboMeta.DataSource = oCadena.ListarMetas(Convert.ToInt16(cboAño.Text));
        }

        private void treeFiltro_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                switch (e.Node.Parent.Text)
                {
                    case "Situacion Laboral":
                        foreach (TreeNode fnode in e.Node.Parent.Nodes)
                        {
                            fnode.BackColor = Color.White;
                        }
                        switch (e.Node.Text)
                        {
                            case "Todos":
                                e.Node.BackColor = Color.Teal;
                                filtroSituacionLaboral = "Todos";
                                break;
                            case "Activos":
                                e.Node.BackColor = Color.Teal;
                                filtroSituacionLaboral = "Activos";
                                break;
                            case "Inactivos":
                                e.Node.BackColor = Color.Teal;
                                filtroSituacionLaboral = "Inactivos";
                                break;
                            case "Sin Periodo Laboral":
                                e.Node.BackColor = Color.Teal;
                                filtroSituacionLaboral = "Sin Periodo Laboral";
                                break;
                        }
                        break;
                        
                    case "Regimen Laboral":
                        foreach (TreeNode fnode in e.Node.Parent.Nodes )
                        {
                            fnode.BackColor = Color.White;
                        }
                        switch (e.Node.Text)
                        {
                            case "Todos":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "Todos";
                                break;
                            case "Regimen CAS":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "CAS";
                                break;
                            case "DL. 276":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "276";
                                break;
                            case "DL. 728":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "728";
                                break;
                            case "Racionamiento":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "racionamiento";
                                break;
                            case "DL. 30057":
                                e.Node.BackColor = Color.Teal;
                                filtroRegimeLaboral = "30057";
                                break;
                        }
                        break;
                }
                tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, "", "", "", "", filtroRegimeLaboral, "Todos");
                tablaAuxiliar2 = miListaTrabajadores.ObtenerListaTrabajadoresConReloj(filtroSituacionLaboral, "", "", "", "", filtroRegimeLaboral, "Todos",DateTime.Today);
                dtgListaTrabajadores.DataSource = tablaAuxiliar;
                lblNumeroTrabajadores.Text = "Nro de trabajadores: " + dtgListaTrabajadores.Rows.Count.ToString();
            }
        }

        private void btnBuscarXMeta_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Text = "";
            txtBuscarApellidoPaterno.Text = "";
            txtBuscarApellidoMaterno.Text = "";
            txtBuscarNombre.Text = "";
            if (cboMeta.SelectedIndex >= 0)
            {
                tablaAuxiliar = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, cboMeta.SelectedValue.ToString());
                tablaAuxiliar2 = miListaTrabajadores.ObtenerListaTrabajadoresConReloj(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, cboMeta.SelectedValue.ToString(),DateTime.Today);
                dtgListaTrabajadores.DataSource = tablaAuxiliar;
                lblNumeroTrabajadores.Text = "Nro de trabajadores: " + dtgListaTrabajadores.Rows.Count.ToString();
            }
        }

        private void menuCopiarDNI_Click(object sender, EventArgs e)
        {
            if (dtgListaTrabajadores.SelectedRows.Count> 0 )
            {
                Clipboard.SetDataObject(dtgListaTrabajadores.SelectedRows[0].Cells["dni"].Value.ToString() );
            }
        }

        private void menuCopiarNombreCompleto_Click(object sender, EventArgs e)
        {
            if (dtgListaTrabajadores.SelectedRows.Count > 0)
            {
                Clipboard.SetDataObject(dtgListaTrabajadores.SelectedRows[0].Cells["nombres"].Value.ToString() + ' ' + dtgListaTrabajadores.SelectedRows[0].Cells["apellidoPaterno"].Value.ToString() + ' ' + dtgListaTrabajadores.SelectedRows[0].Cells["apellidoMaterno"].Value.ToString());
            }
        }

        private void menuCopiarNombre_Click(object sender, EventArgs e)
        {
            if (dtgListaTrabajadores.SelectedRows.Count > 0)
            {
                Clipboard.SetDataObject(dtgListaTrabajadores.SelectedRows[0].Cells["nombres"].Value.ToString());
            }
        }

        private void menuCopiarPaterno_Click(object sender, EventArgs e)
        {
            if (dtgListaTrabajadores.SelectedRows.Count > 0)
            {
                Clipboard.SetDataObject(dtgListaTrabajadores.SelectedRows[0].Cells["apellidoPaterno"].Value.ToString() );
            }
        }

        private void menuApellidoMaterno_Click(object sender, EventArgs e)
        {
            if (dtgListaTrabajadores.SelectedRows.Count > 0)
            {
                Clipboard.SetDataObject(dtgListaTrabajadores.SelectedRows[0].Cells["apellidoMaterno"].Value.ToString());
            }
        }

        private void txtDNI_Enter(object sender, EventArgs e)
        {
            txtBuscarNombre.Text = "";
            txtBuscarApellidoMaterno.Text = "";
            txtBuscarApellidoPaterno.Text = "";
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscarDNI.Focus();
            }
        }

        private void txtBuscarNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscarNombre.Focus(); 
            }
        }

        private void txtBuscarApellidoPaterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscarAPaterno.Focus();
            }
        }

        private void txtBuscarApellidoMaterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscarAMaterno.Focus();
            }
        }

        private void treeFiltro_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void txtBuscarNombre_Enter(object sender, EventArgs e)
        {
            txtDNI.Text = "";
            txtBuscarApellidoPaterno.Text = "";
            txtBuscarApellidoMaterno.Text = "";
        }

        private void txtBuscarApellidoPaterno_Enter(object sender, EventArgs e)
        {
            txtDNI.Text = "";
            txtBuscarNombre.Text = "";
            txtBuscarApellidoMaterno.Text = "";
        }

        private void txtBuscarApellidoMaterno_Enter(object sender, EventArgs e)
        {
            txtDNI.Text = "";
            txtBuscarApellidoPaterno.Text = "";
            txtBuscarNombre.Text = "";
        }

        private void btnImprimirLista_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.PDF.cPDF miPDF = new CapaDeNegocios.PDF.cPDF();

                miPDF.ImprimirListaTrabajadores(tablaAuxiliar, "Situacion Laboral: " + filtroSituacionLaboral + " Regimen:  " + filtroRegimeLaboral);


                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = @"c:\PDFs\listaTrabajadores.pdf";
                proc.Start();

                //ReporteTrabajador.rptReporteTrabajador objRpt;
                //objRpt = new ReporteTrabajador.rptReporteTrabajador();


                //// LA DE ARRIBA ES NUESTRA CADENA DE CONEXION DEL SERVIDOR

                //ReporteTrabajador.dsTrabajador Ds = new ReporteTrabajador.dsTrabajador(); // ESTE ES EL NOMBRE DE NUESTRO DATASET
                //Ds.Tables.Add(miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, cboMeta.SelectedValue.ToString()));  // ESTE Reportes ES EL NOMBRE DE NUESTRA TABLA DE DATOS QUE ESTA DENTRO DE NUESTRO DATASET

                //objRpt.SetDataSource(tablaAuxiliar); // dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos")); 
                //ReporteTrabajador.frmReporteListaTrabajadores fReporteListaTrabajadores = new ReporteTrabajador.frmReporteListaTrabajadores(); // ES EL FORM DONDE ESTA NUESTRO CRYSTAL REPORT VIEWER
                //fReporteListaTrabajadores.crystalReportViewer1.ReportSource = objRpt; // ESTE ES NUESTRO REPORT VIEWER
                //fReporteListaTrabajadores.ShowDialog(); // AQUI LO MUESTRA
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir la lista de trabajadores: " + ex.Message);
                
            }
            
        }

        private void btnDatosFijosxTrabajador_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaTrabajadores.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un trabajador:", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cTrabajador oTrabajador = new cTrabajador();
                    oTrabajador.IdTrabajador = Convert.ToInt32(dtgListaTrabajadores.SelectedRows[0].Cells["id_trabajador"].Value);
                    oTrabajador.Nombres = Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["nombres"].Value);
                    oTrabajador.ApellidoPaterno = Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["apellidoPaterno"].Value);
                    oTrabajador.ApellidoMaterno = Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["apellidoMaterno"].Value);
                    frmListaDatosFijos fListaDatosFijos = new frmListaDatosFijos();
                    fListaDatosFijos.oTrabajador = oTrabajador;
                    if (fListaDatosFijos.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos fijos del trabajador: frmListaTrabajadores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeFiltro_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnCambiarMeta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaTrabajadores.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un trabajador:", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cTrabajador oTrabajador = new cTrabajador();
                    oTrabajador.IdTrabajador = Convert.ToInt32(dtgListaTrabajadores.SelectedRows[0].Cells["id_trabajador"].Value);
                    oTrabajador.Nombres = Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["nombres"].Value);
                    oTrabajador.ApellidoPaterno = Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["apellidoPaterno"].Value);
                    oTrabajador.ApellidoMaterno = Convert.ToString(dtgListaTrabajadores.SelectedRows[0].Cells["apellidoMaterno"].Value);

                    CapaDeNegocios.DatosLaborales.cPeriodoTrabajador oPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                    oPeriodoTrabajador = oPeriodoTrabajador.traerUltimoPeriodoTrabajador(oTrabajador.IdTrabajador);

                    CapaDeNegocios.DatosLaborales.cRegimenTrabajador oRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                    oRegimenTrabajador = oRegimenTrabajador.TraerUltimoRegimenTrabajador(oPeriodoTrabajador.IdtPeriodoTrabajador);

                    CapaDeNegocios.PlanillaNueva.blPlanilla oblPlanilla = new CapaDeNegocios.PlanillaNueva.blPlanilla();

                    Trabajador.frmCambiarMeta fCambiarMeta = new frmCambiarMeta();
                    fCambiarMeta.oMeta =  new CapaDeNegocios.Obras.cMeta();
                    fCambiarMeta.oMeta = oblPlanilla.TraerMeta(oRegimenTrabajador.IdtMeta);

                    fCambiarMeta.oTrabajador = oTrabajador;
                    if (fCambiarMeta.ShowDialog() == DialogResult.OK)
                    {
                        oRegimenTrabajador.IdtMeta = fCambiarMeta.oMeta.Codigo;
                        oRegimenTrabajador.ModificarRegimenTrabajador(oRegimenTrabajador);
                        MessageBox.Show("Se ha realizado el cambio a la meta: " + fCambiarMeta.oMeta.Numero + " - " + fCambiarMeta.oMeta.Nombre, "Cambio Meta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la operacion", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la lista de metas: " + ex.Message, "Meta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirListaReloj_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.PDF.cPDF miPDF = new CapaDeNegocios.PDF.cPDF();

                
                miPDF.ImprimirListaTrabajadoresConReloj(tablaAuxiliar2, "Situacion Laboral: " + filtroSituacionLaboral + " Regimen:  " + filtroRegimeLaboral);


                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = @"c:\PDFs\listaTrabajadores.pdf";
                proc.Start();

                //ReporteTrabajador.rptReporteTrabajador objRpt;
                //objRpt = new ReporteTrabajador.rptReporteTrabajador();


                //// LA DE ARRIBA ES NUESTRA CADENA DE CONEXION DEL SERVIDOR

                //ReporteTrabajador.dsTrabajador Ds = new ReporteTrabajador.dsTrabajador(); // ESTE ES EL NOMBRE DE NUESTRO DATASET
                //Ds.Tables.Add(miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, cboMeta.SelectedValue.ToString()));  // ESTE Reportes ES EL NOMBRE DE NUESTRA TABLA DE DATOS QUE ESTA DENTRO DE NUESTRO DATASET

                //objRpt.SetDataSource(tablaAuxiliar); // dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(filtroSituacionLaboral, txtBuscarNombre.Text, txtBuscarApellidoPaterno.Text, txtBuscarApellidoMaterno.Text, txtDNI.Text, filtroRegimeLaboral, "Todos")); 
                //ReporteTrabajador.frmReporteListaTrabajadores fReporteListaTrabajadores = new ReporteTrabajador.frmReporteListaTrabajadores(); // ES EL FORM DONDE ESTA NUESTRO CRYSTAL REPORT VIEWER
                //fReporteListaTrabajadores.crystalReportViewer1.ReportSource = objRpt; // ESTE ES NUESTRO REPORT VIEWER
                //fReporteListaTrabajadores.ShowDialog(); // AQUI LO MUESTRA
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir la lista de trabajadores: " + ex.Message);

            }

        }
    }
}