﻿using CapaUsuario.ResidenteMeta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Tareo
{
    public partial class frmMantenimientoDetalleTareo : Form
    {
        int sidttrabajador = 0;
        string fechaInicioTrabajador = "";
        int sidtperiodotrabajador = 0;
        DateTime auxiliar;

        DataTable oDataTrabajador = new DataTable();
        DataTable oDataAFP = new DataTable();
        DataTable oDataDetalleTareo = new DataTable();
        DataTable oDataTareo = new DataTable();
        DataTable oDataPeriodoTrabajador = new DataTable();
        DataTable oDataRegimenTrabajador = new DataTable();
        DataTable oDataRegimenPensionarioTrabajador = new DataTable();
        DataTable oDataCargo = new DataTable();

        CapaDeNegocios.Tareos.cTareo miTareo = new CapaDeNegocios.Tareos.cTareo();
        CapaDeNegocios.Tareos.cDetalleTareo miDetalleTareo = new CapaDeNegocios.Tareos.cDetalleTareo();
        CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
        CapaDeNegocios.cListaAFP miAFP = new CapaDeNegocios.cListaAFP();
        CapaDeNegocios.Obras.cMeta miMeta = new CapaDeNegocios.Obras.cMeta();
        CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
        CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajor = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
        CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajor = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
        CapaDeNegocios.Contrato.cCargo miCargo = new CapaDeNegocios.Contrato.cCargo();

        CapaDeNegocios.Tareos.cPlantillaTareo oPlantillatareo = new CapaDeNegocios.Tareos.cPlantillaTareo();

        public frmMantenimientoDetalleTareo()
        {
            InitializeComponent();
        }

        private void frmMantenimientoDetalleTareo_Load(object sender, EventArgs e)
        {
            cargarListaCategorias(); // carga las categoria que estan creadas para la meta
            DibujarDataGrid(miTareo.FechaFin.Day - miTareo.FechaInicio.Day);
            MostrarColumnas();
            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
            oDataAFP = miAFP.ObtenerListaAFP();
            oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
            oDataRegimenTrabajador = miRegimenTrabajor.ListarRegimenTrabajador(0);
            oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
            oDataCargo = miCargo.ListaCargos();
            CargarDatos();
            if (cDatosGeneralesEmpresa.RUC == "20170325185")
            {
                btnImportartareo.Visible = true;
            }
        }


        private void cargarListaCategorias()
        {
            DataTable ListaCategorias = miDetalleTareo.ListarCategoriaTrabajador(miMeta.Codigo);
            bool encontrado = false;
            foreach (DataRow item in ListaCategorias.Rows)
            {
                encontrado = false;
                for (int i = 0; i < cboCategoria.Items.Count; i++)
                {
                    if (cboCategoria.Items[i].ToString() == item[0].ToString())
                    {
                        encontrado = true;
                    }
                }
                if (encontrado == false)
                {
                    cboCategoria.Items.Add(item[0].ToString());
                }
            }

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            CapaUsuario.Tareo.frmImportarTareo fImportarTareo = new CapaUsuario.Tareo.frmImportarTareo();
            fImportarTareo.RecibirDatos(miTareo.IdTTareo, miTareo.Descripcion, miMeta.Codigo);
            if (fImportarTareo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string IdtTrabajador = "";
                string Nombre = "";
                string DNI = "";
                string Sexo = "";
                int IdtCargo = 0;
                string Cargo = "";


                int pIdTTareo = 0;
                int contador = 0;
                int fila = 0;
                dgvDetalleTareo.Rows.Clear();
                pIdTTareo = miTareo.IdTTareo;
          
                miTareo.IdTTareo = fImportarTareo.sidttareoimportar;
                oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(miTareo.IdTTareo);
                foreach (DataRow row in oDataDetalleTareo.Rows)
                {
                    IdtTrabajador = row[4].ToString();
                    if (ComprobarBajaTrabajador(Convert.ToInt32(IdtTrabajador), miTareo.FechaInicio) == false)
                    {
                        contador += 1;
                        dgvDetalleTareo.Rows.Add();
                        fila = dgvDetalleTareo.RowCount - 1;
                        dgvDetalleTareo.Rows[fila].Cells[1].Value = "I";
                        dgvDetalleTareo.Rows[fila].Cells[3].Value = contador;
                        foreach (DataRow row1 in oDataTrabajador.Select("id_trabajador = '" + IdtTrabajador + "'"))
                        {
                            Nombre = row1[3].ToString() + " " + row1[4].ToString() + ", " + row1[2].ToString();
                            DNI = row1[1].ToString();
                            Sexo = row1[5].ToString();
                            CapaDeNegocios.Tareos.cDetalleTareo midetalletareo = LlenarDetalletareo(Convert.ToInt32(IdtTrabajador), Nombre);

                            foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + midetalletareo.PeriodoRegimen.IdtCargo.ToString() + "'"))
                            {
                                IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                                Cargo = rowCargo[1].ToString();
                            }

                            dgvDetalleTareo.Rows[fila].Cells[4].Value = IdtTrabajador;
                            dgvDetalleTareo.Rows[fila].Cells[5].Value = Nombre;
                            dgvDetalleTareo.Rows[fila].Cells[6].Value = DNI;
                            dgvDetalleTareo.Rows[fila].Cells[7].Value = Sexo;
                            dgvDetalleTareo.Rows[fila].Cells[8].Value = Cargo;
                            dgvDetalleTareo.Rows[fila].Cells[10].Value = midetalletareo.PeriodoTrabajador.FechaInicio;
                            dgvDetalleTareo.Rows[fila].Cells[11].Value = midetalletareo.PeriodoTrabajador.FechaFin;
                            if (midetalletareo.Afp != null)
                            {
                                dgvDetalleTareo.Rows[fila].Cells[12].Value = midetalletareo.Afp.Nombre;
                            }
                            else
                            {
                                dgvDetalleTareo.Rows[fila].Cells[12].Value = "";
                            }

                            if (oPlantillatareo.Jornal == false)
                            {
                                dgvDetalleTareo.Rows[fila].Cells[8].Value = row[1].ToString();
                            }
                            else
                            {
                                dgvDetalleTareo.Rows[fila].Cells[9].Value = row[1].ToString();
                            }
                        }
                        for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                        {
                            auxiliar = miTareo.FechaInicio.AddDays(i);
                            if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                            {
                                dgvDetalleTareo.Rows[fila].Cells["col" + i.ToString()].Style.BackColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow row1 in oDataTrabajador.Select("id_trabajador = '" + IdtTrabajador + "'"))
                        {
                            Nombre = row1[2].ToString() + " " + row1[3].ToString() + ", " + row1[4].ToString();
                            DNI = row1[1].ToString();
                        }
                        MessageBox.Show("El trabajador: " + DNI + ": " + Nombre + " se encuentra de Baja, no se puede agregar al Tareo.", "Gestion de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (contador == 0)
                {
                    dgvDetalleTareo.Rows.Add();
                    for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                    {
                        auxiliar = miTareo.FechaInicio.AddDays(i);
                        if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                        {
                            dgvDetalleTareo.Rows[fila].Cells["col" + i.ToString()].Style.BackColor = Color.Red;
                        }
                    }
                }
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
                btnImportar.Enabled = false;
                miTareo.IdTTareo = pIdTTareo;
            }
        }

        private void btnAprobacion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de poner en aprobacion el Tareo de Obra, ya no podra Modificarlo.", "Confirmar Aprobacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                miTareo.Estado = true;
                miTareo.ModificarTareo(miTareo, miMeta);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnNuevoTrabajador_Click(object sender, EventArgs e)
        {
            Trabajador.frmNuevoObrero fNuevoObrero = new Trabajador.frmNuevoObrero();
            fNuevoObrero.RecibirDatos(miMeta.Codigo);
            fNuevoObrero.fechaInicio = miTareo.FechaInicio;
            fNuevoObrero.fechaFin = miTareo.FechaFin;
            if (fNuevoObrero.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
                oDataAFP = miAFP.ObtenerListaAFP();
                oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
                oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                bool bOk = false;
                string diastareo = "";
                int contadordias = 0;
                foreach (DataGridViewRow row in dgvDetalleTareo.Rows)
                {
                    contadordias = 0;
                    diastareo = "";
                    for (int i = 1; i <= 31; i++)
                    {
                        if (i >= miTareo.FechaInicio.Day && i <= miTareo.FechaFin.Day)
                        {
                            if (Convert.ToString(row.Cells[13 + i - contadordias].Value) == "")
                            {
                                diastareo += "0";
                            }
                            diastareo += Convert.ToString(row.Cells[13 + i - contadordias].Value);
                        }
                        else
                        {
                            contadordias += 1;
                            diastareo += "0";
                        }
                    }
                    miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(row.Cells[0].Value);
                    if (oPlantillatareo.Jornal == false)
                    {
                        miDetalleTareo.Categoria = Convert.ToString(row.Cells[8].Value);
                    }
                    else
                    {
                        miDetalleTareo.Categoria = Convert.ToString(row.Cells[9].Value);
                    }

                    miDetalleTareo.DiasTareo = diastareo;
                    miDetalleTareo.TotalDias = Convert.ToInt32(row.Cells[dgvDetalleTareo.ColumnCount - 2].Value);
                    miDetalleTareo.IdtTrabajador = Convert.ToInt32(row.Cells[4].Value);
                    miDetalleTareo.IdtTareo = miTareo.IdTTareo;
                    if (Convert.ToString(row.Cells[1].Value) == "I")
                    {
                        miDetalleTareo.CrearDetalleTareo(miDetalleTareo);
                        oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(miTareo.IdTTareo);
                        miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(oDataDetalleTareo.Compute("MAX(idtdetalletareo)", ""));
                        row.Cells[0].Value = miDetalleTareo.IdTDetalleTareo.ToString();
                        row.Cells[1].Value = "M";
                        bOk = true;
                    }
                    if (Convert.ToString(row.Cells[1].Value) == "M")
                    {
                        miDetalleTareo.ModificarDetalleTareo(miDetalleTareo);
                        bOk = true;
                    }
                }
                GuardarTareoHorasAcumulado();
                if (bOk == false)
                {
                    MessageBox.Show("No existen datos que se puedan registrar", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CargarDatos();
                    MessageBox.Show("Datos guardados", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en guardar tareo, verifique que no exista filas vacias: " + ex.Message);
            }
            
        }

        void GuardarTareoHorasAcumulado()
        {
      
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dgvDetalleTareo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetalleTareo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                sidttrabajador = Convert.ToInt32(dgvDetalleTareo.Rows[e.RowIndex].Cells[4].Value);
                if (dgvDetalleTareo.Rows[e.RowIndex].Cells[10].Value == null)
                {
                    fechaInicioTrabajador = "";
                }
                else
                {
                    fechaInicioTrabajador = dgvDetalleTareo.Rows[e.RowIndex].Cells[10].Value.ToString();
                }
                
                //Codigo para llenar las x
                if (dgvDetalleTareo.Rows[e.RowIndex].Cells[13].Selected == true)
                {
                    LlenarDias(e.RowIndex, "x");
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[dgvDetalleTareo.ColumnCount - 2].Value = TotalDias(e.RowIndex);
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[dgvDetalleTareo.ColumnCount - 1].Value = TotalHoras(e.RowIndex);
                }
                else if (dgvDetalleTareo.Rows[e.RowIndex].Cells[2].Selected == true)
                {
                    //if (Convert.ToString(dgvDetalleTareo.Rows[e.RowIndex].Cells[0].Value) == "")
                    //{
                    //    if (MessageBox.Show("Está seguro que desea quitar al Trabajador del Tareo de Obra", "Gestion de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    //    {
                    //        return;
                    //    }
                    //    dgvDetalleTareo.Rows.RemoveAt(e.RowIndex);
                    //}
                    //else
                    //{
                    //    if (MessageBox.Show("Está seguro que desea eliminar al Trabajador del Tareo de Obra", "Gestion de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    //    {
                    //        return;
                    //    }
                    //    miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(dgvDetalleTareo.Rows[e.RowIndex].Cells[0].Value);
                    //    miDetalleTareo.EliminarDetalleTareo(miDetalleTareo.IdTDetalleTareo);
                    //    CargarDatos();
                    //}
                }
                else if (e.ColumnIndex > 13 && dgvDetalleTareo.CurrentCell.ColumnIndex < (dgvDetalleTareo.ColumnCount - 2))
                {
                    if (dgvDetalleTareo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dgvDetalleTareo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "0")
                    {
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "X";
                    }
                    else
                    {
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    }
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[dgvDetalleTareo.ColumnCount - 2].Value = TotalDias(e.RowIndex);
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[dgvDetalleTareo.ColumnCount - 1].Value = TotalHoras(e.RowIndex);
                }
            }
        }

        private void dgvDetalleTareo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Selected == true && dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value != null && dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value.ToString() != "")
                {
                    int z = 0;
                    int contador = 0;
                    string IdtTrabajador = "";
                    string Nombre = "";
                    string DNI = "";
                    string Sexo = "";
                    int IdtCargo = 0;
                    string Cargo = "";

                    int fila = e.RowIndex;
                    string DNIingresado = dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value.ToString();

                    for (int i = 0; i < dgvDetalleTareo.Rows.Count - 1; i++)
                    {
                        if (i != fila)
                        {
                            if (Convert.ToString(dgvDetalleTareo.Rows[i].Cells[6].Value) == DNIingresado)
                            {
                                z = 1;
                            }
                        }
                    }
                    if (z != 0)
                    {
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value = "";
                        MessageBox.Show("El trabajador ya se encuentra en el tareo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                   
                    foreach (DataRow row in oDataTrabajador.Select("dni = '" + dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value + "'"))
                    {
                        contador += 1;
                        IdtTrabajador = row[0].ToString();
                        //Parte para comprobar si el trabajador esta en otro tareo
                        List<CapaDeNegocios.Tareos.cTareo> TareosConTrabajadorDuplicado = miTareo.BuscarTrabajadorTareo(miTrabajador.traerTrabajador(Convert.ToInt32(IdtTrabajador)), miTareo.FechaInicio);
                        if ( TareosConTrabajadorDuplicado.Count > 0)
                        {
                            foreach (CapaDeNegocios.Tareos.cTareo item in TareosConTrabajadorDuplicado)
                            {
                                if (item.IdTTareo != miTareo.IdTTareo)
                                {
                                    MessageBox.Show("El trabajador que esta ingresando ya se encuentra en el tareo: " + item.Descripcion + " de la meta: " + item.Meta.Numero + ": " +
                                    item.Meta.Nombre + "con " + item.ListaDetallesTareo[0].TotalDias + " dias, con el siguiente detalle de tareo " + item.ListaDetallesTareo[0].DiasTareo, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            
                        }

                        if (ComprobarBajaTrabajador(Convert.ToInt32(IdtTrabajador), miTareo.FechaInicio) == true)
                        {
                            dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value = "";
                            if (MessageBox.Show("El trabajador se encuentra de Baja, desea darle de alta?", "Gestion de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                            {
                                if (oPlantillatareo.Racionamiento == false)
                                {
                                    Trabajador.frmNuevoObrero fNuevoObrero = new Trabajador.frmNuevoObrero();
                                    fNuevoObrero.RecibirDatos(miMeta.Codigo);
                                    fNuevoObrero.miTrabajador = miTrabajador.traerTrabajador(Convert.ToInt32(IdtTrabajador));


                                    fNuevoObrero.miPeriodoTrabajador = miPeriodoTrabajador.traerUltimoPeriodoTrabajador(fNuevoObrero.miTrabajador.IdTrabajador);
                                    fNuevoObrero.miPeriodoTrabajador.FechaInicio = miTareo.FechaInicio.ToShortDateString();
                                    fNuevoObrero.miPeriodoTrabajador.FechaFin = "";


                                    CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador AuxiliarRegimenPensionario = miRegimenPensionarioTrabajor.TraerUltimoRegimenPensionario(fNuevoObrero.miPeriodoTrabajador.IdtPeriodoTrabajador);
                                    if (AuxiliarRegimenPensionario != null)
                                    {
                                        fNuevoObrero.miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                                        fNuevoObrero.miRegimenPensionarioTrabajador.CUSPP = AuxiliarRegimenPensionario.CUSPP;
                                        fNuevoObrero.miRegimenPensionarioTrabajador.IdtAFP = AuxiliarRegimenPensionario.IdtAFP;
                                        fNuevoObrero.miRegimenPensionarioTrabajador.TipoComision = AuxiliarRegimenPensionario.TipoComision;
                                        fNuevoObrero.miRegimenPensionarioTrabajador.FechaInicio = miTareo.FechaInicio.ToShortDateString();

                                    }
                                    else
                                    {
                                        MessageBox.Show("El trabajador no tiene un sistema pensionario, debe llenar sus datos", "Regimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        fNuevoObrero.miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                                    }


                                    fNuevoObrero.miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();

                                    fNuevoObrero.miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                                    fNuevoObrero.fechaInicio = miTareo.FechaInicio;
                                    fNuevoObrero.fechaFin = miTareo.FechaFin;
                                    fNuevoObrero.modoEdicion = true;
                                    fNuevoObrero.modoAltaTrabajador = true;
                                    if (Convert.ToDateTime(fNuevoObrero.miPeriodoTrabajador.FechaInicio) < fNuevoObrero.fechaInicio)
                                    {
                                        MessageBox.Show("No se puede modificar trabajadores que ya han sido ingresados en tareos anteriores o con fecha de inicio anterior a la fecha del tareo.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        if (fNuevoObrero.ShowDialog() == DialogResult.OK)
                                        {
                                            MessageBox.Show("Trabajador Agregado");

                                            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
                                            oDataAFP = miAFP.ObtenerListaAFP();
                                            oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
                                            oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Se cancelo la operacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }

                                }
                                else
                                {
                                    Trabajador.frmNuevoObreroRacionamiento fNuevoObreroRacionamiento = new Trabajador.frmNuevoObreroRacionamiento();
                                    fNuevoObreroRacionamiento.RecibirDatos(miMeta.Codigo);
                                    fNuevoObreroRacionamiento.miTrabajador = miTrabajador.traerTrabajador(Convert.ToInt32(IdtTrabajador));

                                    fNuevoObreroRacionamiento.miPeriodoTrabajador = miPeriodoTrabajador.traerUltimoPeriodoTrabajador(fNuevoObreroRacionamiento.miTrabajador.IdTrabajador);
                                    fNuevoObreroRacionamiento.miPeriodoTrabajador.FechaInicio = miTareo.FechaInicio.ToShortDateString();
                                    fNuevoObreroRacionamiento.miPeriodoTrabajador.FechaFin = "";

                                    fNuevoObreroRacionamiento.fechaInicio = miTareo.FechaInicio;
                                    fNuevoObreroRacionamiento.fechaFin = miTareo.FechaFin;
                                    fNuevoObreroRacionamiento.modoEdicion = true;
                                    fNuevoObreroRacionamiento.modoAltatrabajador = true;
                                    if (Convert.ToDateTime(fNuevoObreroRacionamiento.miPeriodoTrabajador.FechaInicio) < fNuevoObreroRacionamiento.fechaInicio)
                                    {
                                        MessageBox.Show("No se puede modificar trabajadores que ya han sido ingresados en tareos anteriores o con fecha de inicio anterior a la fecha del tareo.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    else
                                    {
                                        if (fNuevoObreroRacionamiento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                        {
                                            MessageBox.Show("Trabajador agregado");

                                            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
                                            oDataAFP = miAFP.ObtenerListaAFP();
                                            oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
                                            oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
                                        }
                                    }

                                }
                            }
                            else
                            {
                                return;
                            }

                        }
                        Nombre = row[3].ToString() + " " + row[4].ToString() + ", " + row[2].ToString();
                        DNI = row[1].ToString();
                        Sexo = row[5].ToString();

                        dgvDetalleTareo.Rows[e.RowIndex].Cells[3].Value = e.RowIndex + 1;
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[4].Value = IdtTrabajador;
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[5].Value = Nombre;
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value = DNI;
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[7].Value = Sexo;

                        if (Convert.ToString(dgvDetalleTareo.Rows[e.RowIndex].Cells[1].Value) == "") { dgvDetalleTareo.Rows[e.RowIndex].Cells[1].Value = "I"; }

                        CapaDeNegocios.Tareos.cDetalleTareo midetalletareo = LlenarDetalletareo(Convert.ToInt32(IdtTrabajador), Nombre);
                        if (midetalletareo.PeriodoTrabajador == null)
                        {

                        }

                        foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + midetalletareo.PeriodoRegimen.IdtCargo.ToString() + "'"))
                        {
                            IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                            Cargo = rowCargo[1].ToString();
                        }

                       
                        
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[8].Value = Cargo;
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[10].Value = midetalletareo.PeriodoTrabajador.FechaInicio;
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[11].Value = midetalletareo.PeriodoTrabajador.FechaFin;

                        if (midetalletareo.Afp != null)
                        {
                            dgvDetalleTareo.Rows[fila].Cells[12].Value = midetalletareo.Afp.Nombre;
                        }
                        else
                        {
                            dgvDetalleTareo.Rows[fila].Cells[12].Value = "";
                        }

                   
                    }
                    if (contador == 0)
                    {
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[5].Value = "";
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value = "";
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[7].Value = "";
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[8].Value = "";
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[10].Value = "";
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[11].Value = "";
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[12].Value = "";
                        MessageBox.Show("No existe el Trabajador, para agregar hacer clic en Nuevo Trabajador", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (TotalDias(e.RowIndex) == 0)
                        {
                            LlenarDias(e.RowIndex, "0");
                        }
                    }
                }
                else if (Convert.ToString(dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value) == "")
                {
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    return;
                }
                dgvDetalleTareo.Rows[e.RowIndex].Cells[dgvDetalleTareo.ColumnCount - 2].Value = TotalDias(e.RowIndex);
                dgvDetalleTareo.Rows[e.RowIndex].Cells[dgvDetalleTareo.ColumnCount - 1].Value = TotalHoras(e.RowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en buscar el dni: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvDetalleTareo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDetalleTareo.CurrentCell.ColumnIndex == 6)
            {
                string titleText = dgvDetalleTareo.Columns[6].HeaderText;
                if (titleText.Equals("DNI"))
                {
                    TextBox autoText = e.Control as TextBox;
                    if (autoText != null)
                    {
                        autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                        autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                        CargarTrabajador(DataCollection);
                        autoText.AutoCompleteCustomSource = DataCollection;
                    }
                }
            }
            else
            {

            }
           
        }

        private void dgvDetalleTareo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    int indiceFila;
            //    if (dgvDetalleTareo.CurrentCell.RowIndex == 0)
            //    {
            //        indiceFila = dgvDetalleTareo.CurrentCell.RowIndex + 1;
            //    }
            //    else
            //    {
            //        indiceFila = dgvDetalleTareo.CurrentCell.RowIndex;
            //    }
                
            //    dgvDetalleTareo.Rows.Insert(indiceFila,1);
            //    for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
            //    {
            //        auxiliar = miTareo.FechaInicio.AddDays(i);
            //        if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
            //        {
            //            dgvDetalleTareo.Rows[indiceFila].Cells["col" + i.ToString()].Style.BackColor = Color.Red;
            //        }
            //    }
            //    dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
            //}
        }

        public void RecibirDatos(int pIdTTareo, int pNumero, DateTime pFechaInicio, DateTime pFechaFin, string pDescripcion, string pNombre, int pIdTMeta)
        {
            miTareo.IdTTareo = pIdTTareo;
            miTareo.Numero = pNumero;
            txtNumero.Text = Convert.ToString(pNumero);
            txtDesdeHasta.Text = Convert.ToString(pFechaInicio.ToLongDateString()) + "   -   " + Convert.ToString(pFechaFin.ToLongDateString());
            miTareo.FechaInicio = pFechaInicio;
            miTareo.FechaFin = pFechaFin;
            miTareo.Descripcion = pDescripcion;
            txtMeta.Text = pNombre;
            miMeta.Codigo = pIdTMeta;

            oPlantillatareo = oPlantillatareo.TraerPlantillaTareoXNombre(pDescripcion);

            if (oPlantillatareo != null)
            {
                if (oPlantillatareo.Obrero == false)
                {
                    btnNuevoTrabajador.Visible = false;
                    btnNuevoTrabajadorRacionamiento.Visible = false;
                    btnNuevoTrabajadorTecnico.Visible = true;
                }
                else
                {
                    btnNuevoTrabajador.Visible = true;
                    btnNuevoTrabajadorRacionamiento.Visible = false;
                    btnNuevoTrabajadorTecnico.Visible = false;
                }
                if (oPlantillatareo.Racionamiento == true)
                {
                    btnNuevoTrabajador.Visible = false;
                    btnNuevoTrabajadorRacionamiento.Visible = true;
                    btnNuevoTrabajadorTecnico.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("No se encuentra Plantilla para el tareo: " + pDescripcion + ". Debe agregarlo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private DataTable OrdenarPorCategoria(DataTable odata)
        {
            DataTable AUXILIAR = odata.Clone();
            foreach (DataRow item in odata.Rows)
            {
                if (item[1].ToString() == "MAESTRO DE OBRA")
                {
                    AUXILIAR.ImportRow(item);
                }
            }

            foreach (DataRow item in odata.Rows)
            {
                if (item[1].ToString() == "ALMACENERO")
                {
                    AUXILIAR.ImportRow(item);
                }
            }

            foreach (DataRow item in odata.Rows)
            {
                DataRow nueva;
                nueva = item;
                if (item[1].ToString() == "OPERARIO")
                {
                    AUXILIAR.ImportRow(item);
                }
            }

            foreach (DataRow item in odata.Rows)
            {
                if (item[1].ToString().Contains("OFICIAL"))
                {
                    AUXILIAR.ImportRow(item);
                }
            }

            foreach (DataRow item in odata.Rows)
            {
                if (item[1].ToString() != "MAESTRO DE OBRA" && item[1].ToString() != "ALMACENERO" && item[1].ToString() != "OPERARIO" && !item[1].ToString().Contains("OFICIAL"))
                {
                    AUXILIAR.ImportRow(item);
                }
            }
            if (odata.Rows.Count != AUXILIAR.Rows.Count)
            {
                MessageBox.Show("Error al ordenar el tareo: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return odata;
            }
            else
            {
                return AUXILIAR;
            }
            
        }

        private void CargarDatos()
        {
            int contador = 0, contadordias = 0;
            int fila = 0;
            int j, k = 0;
            string r = "";
            string diastareo = "";
            string IdtTrabajador = "";
            string Nombre = "";
            string DNI = "";
            string Sexo = "";
            int IdtCargo = 0;
            string Cargo = "";
            dgvDetalleTareo.Rows.Clear();
            oDataDetalleTareo = OrdenarPorCategoria(miDetalleTareo.ListarDetalleTareo(miTareo.IdTTareo));
            foreach (DataRow row in oDataDetalleTareo.Rows)
            {
                contador += 1;
                dgvDetalleTareo.Rows.Add();
                fila = dgvDetalleTareo.RowCount - 1;
                dgvDetalleTareo.Rows[fila].Cells[0].Value = row[0].ToString();
                dgvDetalleTareo.Rows[fila].Cells[1].Value = "M";
                dgvDetalleTareo.Rows[fila].Cells[3].Value = contador;
                foreach (DataRow row1 in oDataTrabajador.Select("id_trabajador = '" + row[4].ToString() + "'"))
                {
                    IdtTrabajador = row1[0].ToString();
                    Nombre =  row1[3].ToString() + " " +  row1[4].ToString() + ", " + row1[2].ToString();
                    DNI = row1[1].ToString();
                    Sexo = row1[5].ToString();

                    CapaDeNegocios.Tareos.cDetalleTareo midetalletareo = LlenarDetalletareo(Convert.ToInt32(IdtTrabajador), Nombre);
                    if (midetalletareo.PeriodoTrabajador != null)
                    {
                        foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + midetalletareo.PeriodoRegimen.IdtCargo.ToString() + "'"))
                        {
                            IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                            Cargo = rowCargo[1].ToString();
                        }
                        dgvDetalleTareo.Rows[fila].Cells[8].Value = Cargo;
                        dgvDetalleTareo.Rows[fila].Cells[10].Value = midetalletareo.PeriodoTrabajador.FechaInicio;
                        dgvDetalleTareo.Rows[fila].Cells[11].Value = midetalletareo.PeriodoTrabajador.FechaFin;

                        if (midetalletareo.Afp != null)
                        {
                            dgvDetalleTareo.Rows[fila].Cells[12].Value = midetalletareo.Afp.Nombre;
                        }
                        else
                        {
                            dgvDetalleTareo.Rows[fila].Cells[12].Value = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe periodo para el trabajador: " + DNI + ": " + Nombre + "para el mes de este tareo " + miTareo.FechaInicio.ToString("MMMM") + "/" + miTareo.FechaInicio.ToString("yyyy") + ": Eliminelo con el Boton Eliminar Fila o dele de alta con la tecla Enter en su DNI","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvDetalleTareo.Rows[fila].Cells[8].Value = Cargo;
                        dgvDetalleTareo.Rows[fila].Cells[10].Value = "SIN PERIODO";
                        dgvDetalleTareo.Rows[fila].Cells[10].ErrorText = "No se tiene periodo para el trabajador para este tareo, eliminelo de la fila, o reingrese al trabajador en su DNI con enter";
                        //dgvDetalleTareo.Rows[fila].Cells[10].Style = DataGridViewCellStyle
                        dgvDetalleTareo.Rows[fila].Cells[11].Value = "";
                    }

                    dgvDetalleTareo.Rows[fila].Cells[4].Value = IdtTrabajador;
                    dgvDetalleTareo.Rows[fila].Cells[5].Value = Nombre;
                    dgvDetalleTareo.Rows[fila].Cells[6].Value = DNI;
                    dgvDetalleTareo.Rows[fila].Cells[7].Value = Sexo;

                    
                    

                    if (oPlantillatareo.Jornal == false)
                    {
                        dgvDetalleTareo.Rows[fila].Cells[8].Value = row[1].ToString();
                    }
                    else
                    {
                        dgvDetalleTareo.Rows[fila].Cells[9].Value = row[1].ToString();
                    }
                }

                contadordias = 0;
                diastareo = row[2].ToString();
                for (int i = 1; i <= 31; i++)
                {
                    r = diastareo.Substring(i - 1, 1);
                    if (i >= miTareo.FechaInicio.Day && i <= miTareo.FechaFin.Day)
                    {
                        dgvDetalleTareo.Rows[fila].Cells[13 + i - contadordias].Value = r;
                        auxiliar = miTareo.FechaInicio.AddDays(i - contadordias - 1);
                        if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                        {
                            int K = 0;
                            k = i - contadordias - 1;
                            dgvDetalleTareo.Rows[fila].Cells["col" + k.ToString()].Style.BackColor = Color.Red;
                            //dgvDetalleTareo.Rows[fila].Cells[9 + i - contadordias].Value = "D";
                        }
                    }
                    else
                    {
                        contadordias += 1;
                    }
                }
                dgvDetalleTareo.Rows[fila].Cells[dgvDetalleTareo.ColumnCount - 2].Value = row[3].ToString();
                dgvDetalleTareo.Rows[fila].Cells[dgvDetalleTareo.ColumnCount - 1].Value = TotalHoras(fila);
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
            }
            if (contador == 0)
            {
                dgvDetalleTareo.Rows.Add();
                for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                {
                    auxiliar = miTareo.FechaInicio.AddDays(i);
                    if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dgvDetalleTareo.Rows[fila].Cells["col" + i.ToString()].Style.BackColor = Color.Red;
                        //dgvDetalleTareo.Rows[fila].Cells[10 + i].Value = "D";
                    }
                }
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
                btnImportar.Enabled = true;
            }
            else
            {
                btnImportar.Enabled = false;
            }
        }

        private CapaDeNegocios.Tareos.cDetalleTareo LlenarDetalletareo(int pidttrabajador, string pNombre)
        {

            CapaDeNegocios.Tareos.cDetalleTareo oDetalletareo = new CapaDeNegocios.Tareos.cDetalleTareo();

            List<CapaDeNegocios.DatosLaborales.cPeriodoTrabajador> AuxiliarPeriodoTrabajador = miPeriodoTrabajador.traerPeriodosMesTrabajador(Convert.ToInt32(pidttrabajador), miTareo.FechaInicio);
            List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador> ListaRegimenTrabajador = new List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador>();
            List<CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador> ListaPeriodoAFP = new List<CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador>();

            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador PeriodoElegido = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            CapaDeNegocios.DatosLaborales.cRegimenTrabajador RegimenElegido = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
            CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador AFPElegido = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();

            if (AuxiliarPeriodoTrabajador.Count == 0)
            {
                MessageBox.Show("No hay periodos para el trabajador: " + pNombre + "para el mes " + miTareo.FechaInicio.ToShortDateString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (AuxiliarPeriodoTrabajador.Count > 0)
            {
                foreach (CapaDeNegocios.DatosLaborales.cPeriodoTrabajador item in AuxiliarPeriodoTrabajador)
                {
                    CapaDeNegocios.DatosLaborales.cRegimenTrabajador auxiliarRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();

                    ListaRegimenTrabajador = auxiliarRegimenTrabajador.TraerRegimenTrabajadorMes(item.IdtPeriodoTrabajador, miTareo.FechaInicio);
                    ListaPeriodoAFP = AFPElegido.TraerRegimenPensionarioxMes(item.IdtPeriodoTrabajador, miTareo.FechaInicio);

                    if (ListaRegimenTrabajador.Count > 0)
                    {
                        foreach (CapaDeNegocios.DatosLaborales.cRegimenTrabajador item2 in ListaRegimenTrabajador)
                        {
                            if (item2.IdtMeta == miMeta.Codigo)
                            {
                                oDetalletareo.PeriodoTrabajador = item;
                                oDetalletareo.PeriodoRegimen = item2;
                            }
                        }
                        //error cuando no encuentra un periodo = a la meta
                        if (oDetalletareo.PeriodoTrabajador == null)
                        {
                            oDetalletareo.PeriodoTrabajador = item;
                            foreach (CapaDeNegocios.DatosLaborales.cRegimenTrabajador item2 in ListaRegimenTrabajador)
                            {
                                oDetalletareo.PeriodoRegimen = item2;
                            }
                        }

                        if (!oPlantillatareo.Racionamiento)
                        {
                            if (ListaPeriodoAFP.Count > 0)
                            {
                                oDetalletareo.PeriodoAFP = ListaPeriodoAFP[ListaPeriodoAFP.Count - 1];
                                oDetalletareo.Afp = new CapaDeNegocios.cAFP();

                                foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + oDetalletareo.PeriodoAFP.IdtAFP.ToString() + "'"))
                                {
                                    oDetalletareo.Afp.CodigoAFP = oDetalletareo.PeriodoAFP.IdtAFP;
                                    oDetalletareo.Afp.Nombre = rowAFP[1].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No hay Periodo de afp para el el trabajador: " + pNombre + "para el mes " + miTareo.FechaInicio.ToShortDateString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay ningun Regimen para el trabajador: " + pNombre + "para el mes " + miTareo.FechaInicio.ToShortDateString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    

                }
            }
            return oDetalletareo;
        }


        public void CargarTrabajador(AutoCompleteStringCollection col)
        {
            foreach (DataRow row in oDataTrabajador.Rows)
            {
                col.Add(row[1].ToString());
            }
        }

        private void DibujarDataGrid(int pDias)
        {
            int j = dgvDetalleTareo.ColumnCount;
            for (int i = 0; i <= pDias; i++)
            {
                auxiliar = miTareo.FechaInicio.AddDays(i);
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "col" + i.ToString();
                string auxiliarDiaSemana = "";
                switch (auxiliar.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        auxiliarDiaSemana = "L " + auxiliar.Day;
                        break;
                    case DayOfWeek.Tuesday:
                        auxiliarDiaSemana = "M " + auxiliar.Day;
                        break;
                    case DayOfWeek.Wednesday:
                        auxiliarDiaSemana = "M " + auxiliar.Day;
                        break;
                    case DayOfWeek.Friday:
                        auxiliarDiaSemana = "V " + auxiliar.Day;
                        break;
                    case DayOfWeek.Thursday:
                        auxiliarDiaSemana = "J " + auxiliar.Day;
                        break;
                    case DayOfWeek.Saturday:
                        auxiliarDiaSemana = "S " + auxiliar.Day;
                        break;
                    case DayOfWeek.Sunday:
                        auxiliarDiaSemana = "D " + auxiliar.Day;
                        break;
                    default:
                        break;
                }
                col.HeaderText = auxiliarDiaSemana;
                col.Width = 20;
                dgvDetalleTareo.Columns.Add(col);
                if (oPlantillatareo.Obrero)
                {
                    btnNuevoTrabajador.Visible = true;
                    btnNuevoTrabajadorTecnico.Visible = false;
                    btnNuevoTrabajadorRacionamiento.Visible = false;
                }
                else
                {
                    btnNuevoTrabajador.Visible = false;
                    btnNuevoTrabajadorTecnico.Visible = true;
                    btnNuevoTrabajadorRacionamiento.Visible = false;
                }

                if (oPlantillatareo.Racionamiento == true)
                {
                    btnNuevoTrabajador.Visible = false;
                    btnNuevoTrabajadorTecnico.Visible = false;
                    btnNuevoTrabajadorRacionamiento.Visible = true;
                }
            }
            DataGridViewTextBoxColumn TotalDias = new DataGridViewTextBoxColumn();
            TotalDias.Name = "txtTotalDias";
            TotalDias.HeaderText = "Total Dias";
            TotalDias.Width = 40;
            dgvDetalleTareo.Columns.Add(TotalDias);
            DataGridViewTextBoxColumn TotalHoras = new DataGridViewTextBoxColumn();
            TotalHoras.Name = "txtTotalHoras";
            TotalHoras.HeaderText = "Total Horas";
            TotalHoras.Width = 40;
            dgvDetalleTareo.Columns.Add(TotalHoras);

          
        }

        private void MostrarColumnas()
        {
            if (oPlantillatareo.Jornal == false)
            {
                dgvDetalleTareo.Columns[9].Visible = false;
            }
            else
            {
                dgvDetalleTareo.Columns[8].Visible = false;
            }

            if (oPlantillatareo.Racionamiento == true)
            {
                dgvDetalleTareo.Columns[8].Visible = false;
                dgvDetalleTareo.Columns[12].Visible = false;
            }
         }

        void LlenarDias(int fila, string caracter)
        {
            for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
            {
                auxiliar = miTareo.FechaInicio.AddDays(i);
                //if (auxiliar.DayOfWeek != DayOfWeek.Sunday)//si es domingo
                //{
                dgvDetalleTareo.Rows[fila].Cells[14 + i].Value = caracter;
                //}
            }
        }

        int TotalDias(int fila)
        {
            int contadordias = 0;
            for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
            {
                if (Convert.ToString(dgvDetalleTareo.Rows[fila].Cells[14 + i].Value) == "x" || Convert.ToString(dgvDetalleTareo.Rows[fila].Cells[14 + i].Value) == "X")
                {
                    contadordias += 1;
                }
            }
            return contadordias;
        }

        double TotalHoras(int fila)
        {
            double contadorhoras = 0;
            for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
            {
                if (dgvDetalleTareo.Rows[fila].Cells[14 + i].Value != null)
                {
                    if (dgvDetalleTareo.Rows[fila].Cells[14 + i].Value.ToString() == "x" || dgvDetalleTareo.Rows[fila].Cells[14 + i].Value.ToString() == "X")
                    {
                        auxiliar = miTareo.FechaInicio.AddDays(i);
                        if (auxiliar.DayOfWeek == DayOfWeek.Sunday)//si es domingo
                        {
                            contadorhoras += 0;
                        }
                        else if (auxiliar.DayOfWeek == DayOfWeek.Saturday)//si es sabado
                        {
                            contadorhoras += 5.5;
                        }
                        else
                        {
                            contadorhoras += 8.5;
                        }
                    }
                }
            }
            return contadorhoras;
        }

        private void PeriodoTrabajador(int pidttrabajador)
        {
            foreach (DataRow rowPeriodoTrabajador in oDataPeriodoTrabajador.Select("idttrabajador = '" + pidttrabajador + "'"))
            {
                sidtperiodotrabajador = Convert.ToInt32(rowPeriodoTrabajador[0].ToString());
            }
        }

        private void btnBajaTrabajador_Click(object sender, EventArgs e)
        {
            try
            {
                if (sidttrabajador == 0)
                {
                    MessageBox.Show("No selecciono a ningun trabajador", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<CapaDeNegocios.Tareos.cTareo> TareosConTrabajadorDuplicado = miTareo.BuscarTrabajadorTareo(miTrabajador.traerTrabajador(Convert.ToInt32(sidttrabajador)), miTareo.FechaInicio);
                bool trabajadorEncontrado = false;
                if (TareosConTrabajadorDuplicado.Count > 0)
                {

                    foreach (CapaDeNegocios.Tareos.cTareo item in TareosConTrabajadorDuplicado)
                    {
                        if (item.IdTTareo != miTareo.IdTTareo)
                        {
                            trabajadorEncontrado = true;
                            MessageBox.Show("El trabajador que quiere dar  de baja ya se encuentra en el tareo: " + item.Descripcion + " de la meta: " + item.Meta.Numero + ": " +
                            item.Meta.Nombre + "con " + item.ListaDetallesTareo[0].TotalDias + " dias, con el siguiente detalle de tareo " + item.ListaDetallesTareo[0].DiasTareo, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }

                }

                if (!trabajadorEncontrado)
                {
                    PeriodoTrabajador(sidttrabajador);
                    CapaUsuario.Tareo.frmBajaTrabajador fBajaTrabajador = new CapaUsuario.Tareo.frmBajaTrabajador();
                    fBajaTrabajador.RecibirDatos(miTareo.FechaInicio, sidtperiodotrabajador, fechaInicioTrabajador, Convert.ToInt32(sidttrabajador));
                    if (fBajaTrabajador.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Se dio de baja al trabajador con fecha: " + fBajaTrabajador.sfechafin, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int indiceFila;
                        indiceFila = dgvDetalleTareo.CurrentCell.RowIndex;
                        if ((Convert.ToDateTime(fBajaTrabajador.sfechafin).Month == miTareo.FechaInicio.Month) && (Convert.ToDateTime(fBajaTrabajador.sfechafin).Year == miTareo.FechaInicio.Year))
                        {
                            dgvDetalleTareo.Rows[indiceFila].Cells[11].Value = fBajaTrabajador.sfechafin;
                        }
                        else
                        {
                            miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(dgvDetalleTareo.Rows[indiceFila].Cells[0].Value);
                            miDetalleTareo.EliminarDetalleTareo(miDetalleTareo.IdTDetalleTareo);
                            MessageBox.Show("Se quito al trabajador del tareo, porque su fecha de baja: " + fBajaTrabajador.sfechafin + ", es menor a la fecha del tareo: " + miTareo.FechaInicio.ToString("MMMM/yyyy") , "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos();
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de baja al trabajador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ComprobarBajaTrabajador(int IdtTrabajador, DateTime mesBuscadoTareo)
        {
            bool Baja = false;
            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador oPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            List<CapaDeNegocios.DatosLaborales.cPeriodoTrabajador> AuxiliarPeriodoTrabajador = oPeriodoTrabajador.traerPeriodosMesTrabajador(IdtTrabajador, mesBuscadoTareo);

            if (AuxiliarPeriodoTrabajador.Count > 0 )
            {
                Baja = false;
            }
            else
            {
                Baja = true;
            }

            return Baja;
        }

        private void btnNuevoTrabajadorRacionamiento_Click(object sender, EventArgs e)
        {
            Trabajador.frmNuevoObreroRacionamiento fNuevoObreroRacionamiento = new Trabajador.frmNuevoObreroRacionamiento();
            fNuevoObreroRacionamiento.RecibirDatos(miMeta.Codigo);
            fNuevoObreroRacionamiento.fechaInicio = miTareo.FechaInicio;
            fNuevoObreroRacionamiento.fechaFin = miTareo.FechaFin;
            if (fNuevoObreroRacionamiento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
                oDataAFP = miAFP.ObtenerListaAFP();
                oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
                oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
            }
        }

        private void btnModificarTrabajador_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvDetalleTareo.SelectedCells.Count > 0)
                {
                    miTrabajador = miTrabajador.traerTrabajador(Convert.ToInt16(dgvDetalleTareo.Rows[dgvDetalleTareo.SelectedCells[0].RowIndex].Cells[4].Value));
                    List<CapaDeNegocios.DatosLaborales.cPeriodoTrabajador> ListaPeriodos = miPeriodoTrabajador.traerPeriodosMesTrabajador(miTrabajador.IdTrabajador, miTareo.FechaInicio);
                    CapaDeNegocios.DatosLaborales.cPeriodoTrabajador auxiliarPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
                    CapaDeNegocios.DatosLaborales.cRegimenTrabajador auxiliarRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                    CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador auxiliarRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                    CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador auxiliarSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();

                    if (ListaPeriodos.Count > 0)
                    {
                        foreach (CapaDeNegocios.DatosLaborales.cPeriodoTrabajador item in ListaPeriodos)
                        {
                            List<CapaDeNegocios.DatosLaborales.cRegimenTrabajador> ListaRegimenes = auxiliarRegimenTrabajador.TraerRegimenTrabajadorMes(item.IdtPeriodoTrabajador, miTareo.FechaInicio);


                            if (ListaRegimenes.Count > 0)
                            {
                                foreach (CapaDeNegocios.DatosLaborales.cRegimenTrabajador item2 in ListaRegimenes)
                                {
                                    if (item2.IdtMeta == miMeta.Codigo)
                                    {
                                        auxiliarPeriodoTrabajador = item;
                                        auxiliarRegimenTrabajador = item2;
                                    }
                                }
                                //error cuando no encuentra un periodo = a la meta
                                if (auxiliarPeriodoTrabajador.IdtPeriodoTrabajador == 0)
                                {
                                    auxiliarPeriodoTrabajador = item;
                                    foreach (CapaDeNegocios.DatosLaborales.cRegimenTrabajador item2 in ListaRegimenes)
                                    {
                                        auxiliarRegimenTrabajador = item2;
                                    }
                                }
                            }
                            else
                            {
                                auxiliarPeriodoTrabajador = item;
                                auxiliarRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                                auxiliarRegimenTrabajador.IdtPeriodoTrabajador = item.IdtPeriodoTrabajador;
                                auxiliarRegimenTrabajador.FechaInicio = item.FechaInicio;
                            }

                            if (!oPlantillatareo.Racionamiento)
                            {
                                List<CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador> ListaPeriodoAFP = auxiliarRegimenPensionarioTrabajador.TraerRegimenPensionarioxMes(auxiliarPeriodoTrabajador.IdtPeriodoTrabajador, miTareo.FechaInicio);
                                List<CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador> ListaSalud = auxiliarSaludTrabajador.ListaPeriodosSalud(auxiliarPeriodoTrabajador.IdtPeriodoTrabajador);
                                if (ListaPeriodoAFP.Count > 0)
                                {
                                    auxiliarRegimenPensionarioTrabajador = ListaPeriodoAFP[ListaPeriodoAFP.Count - 1];
                                }
                                else
                                {
                                    auxiliarRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                                    auxiliarRegimenPensionarioTrabajador.IdtPeriodoTrabajador = item.IdtPeriodoTrabajador;
                                    auxiliarRegimenPensionarioTrabajador.FechaInicio = item.FechaInicio;
                                }

                                if (ListaSalud.Count > 0)
                                {
                                    auxiliarSaludTrabajador = ListaSalud[ListaSalud.Count - 1];
                                }
                                else
                                {
                                    auxiliarSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
                                    auxiliarSaludTrabajador.FechaInicio = item.FechaInicio;
                                    auxiliarSaludTrabajador.IdtPeriodoTrabajador = item.IdtPeriodoTrabajador;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe periodos para el trabajador, ingrese nuevo periodo con enter en el dni.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    if (oPlantillatareo.Racionamiento == true)
                    {
                        Trabajador.frmNuevoObreroRacionamiento fNuevoObreroRacionamiento = new Trabajador.frmNuevoObreroRacionamiento();
                        fNuevoObreroRacionamiento.RecibirDatos(miMeta.Codigo);
                        fNuevoObreroRacionamiento.miTrabajador = miTrabajador;
                        fNuevoObreroRacionamiento.miPeriodoTrabajador = auxiliarPeriodoTrabajador;
                        fNuevoObreroRacionamiento.miRegimenTrabajador = auxiliarRegimenTrabajador;
                        fNuevoObreroRacionamiento.fechaInicio = miTareo.FechaInicio;
                        fNuevoObreroRacionamiento.fechaFin = miTareo.FechaFin;
                        fNuevoObreroRacionamiento.modoEdicion = true;

                        if (Convert.ToDateTime(fNuevoObreroRacionamiento.miPeriodoTrabajador.FechaInicio) < fNuevoObreroRacionamiento.fechaInicio)
                        {
                            MessageBox.Show("No se puede modificar trabajadores que ya han sido ingresados en tareos anteriores o con fecha de inicio anterior a la fecha del tareo.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            if (fNuevoObreroRacionamiento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                fNuevoObreroRacionamiento.miTrabajador.ModificarTrabajador(fNuevoObreroRacionamiento.miTrabajador);
                                fNuevoObreroRacionamiento.miPeriodoTrabajador.ModificarPeriodoTrabajador(fNuevoObreroRacionamiento.miPeriodoTrabajador);
                                if (fNuevoObreroRacionamiento.miRegimenTrabajador.IdtRegimenTrabajador == 0)
                                {
                                    fNuevoObreroRacionamiento.miRegimenTrabajador.CrearRegimenTrabajador(fNuevoObreroRacionamiento.miRegimenTrabajador);
                                }
                                else
                                {
                                    fNuevoObreroRacionamiento.miRegimenTrabajador.ModificarRegimenTrabajador(fNuevoObreroRacionamiento.miRegimenTrabajador);
                                }
                                oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
                                oDataAFP = miAFP.ObtenerListaAFP();
                                oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
                                oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
                            }
                        }
                    }
                    else
                    {
                        Trabajador.frmNuevoTecnico fNuevoTecnico = new Trabajador.frmNuevoTecnico();
                        fNuevoTecnico.RecibirDatos(miMeta.Codigo);
                        fNuevoTecnico.miTrabajador = miTrabajador;
                        fNuevoTecnico.miPeriodoTrabajador = auxiliarPeriodoTrabajador;
                        fNuevoTecnico.miRegimenPensionarioTrabajador = auxiliarRegimenPensionarioTrabajador ;
                        fNuevoTecnico.miRegimenSaludTrabajador = auxiliarSaludTrabajador ;
                        fNuevoTecnico.miRegimenTrabajador = auxiliarRegimenTrabajador;
                        fNuevoTecnico.fechaInicio = miTareo.FechaInicio;
                        fNuevoTecnico.fechaFin = miTareo.FechaFin;
                        fNuevoTecnico.modoEdicion = true;
                        if (Convert.ToDateTime(fNuevoTecnico.miPeriodoTrabajador.FechaInicio) < fNuevoTecnico.fechaInicio)
                        {
                            MessageBox.Show("No se puede modificar trabajadores que ya han sido ingresados en tareos anteriores o con fecha de inicio anterior a la fecha del tareo.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (fNuevoTecnico.ShowDialog() == DialogResult.OK)
                            {
                                fNuevoTecnico.miTrabajador.ModificarTrabajador(fNuevoTecnico.miTrabajador);
                                fNuevoTecnico.miPeriodoTrabajador.ModificarPeriodoTrabajador(fNuevoTecnico.miPeriodoTrabajador);
                                if (fNuevoTecnico.miRegimenPensionarioTrabajador.IdtRegimenPensionarioTrabajador == 0)
                                {
                                    fNuevoTecnico.miRegimenPensionarioTrabajador.CrearRegimenPensionarioTrabajador(fNuevoTecnico.miRegimenPensionarioTrabajador);
                                }
                                else
                                {
                                    fNuevoTecnico.miRegimenPensionarioTrabajador.ModificarRegimenPensionarioTrabajador(fNuevoTecnico.miRegimenPensionarioTrabajador);
                                }

                                if (fNuevoTecnico.miRegimenSaludTrabajador.IdtRegimenSaludTrabajador == 0)
                                {
                                    fNuevoTecnico.miRegimenSaludTrabajador.CrearRegimenSaludTrabajador(fNuevoTecnico.miRegimenSaludTrabajador);
                                }
                                else
                                {
                                    fNuevoTecnico.miRegimenSaludTrabajador.ModificarRegimenSaludTrabajador(fNuevoTecnico.miRegimenSaludTrabajador);
                                }

                                if (fNuevoTecnico.miRegimenTrabajador.IdtRegimenTrabajador == 0)
                                {
                                    fNuevoTecnico.miRegimenTrabajador.CrearRegimenTrabajador(fNuevoTecnico.miRegimenTrabajador);
                                }
                                else
                                {
                                    fNuevoTecnico.miRegimenTrabajador.ModificarRegimenTrabajador(fNuevoTecnico.miRegimenTrabajador);
                                }
                                

                                oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
                                oDataAFP = miAFP.ObtenerListaAFP();
                                oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
                                oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un obrero para modificarlo", "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el trabajador: " + ex.Message);
            }
        }

        private void btnInsertarNuevaFila_Click(object sender, EventArgs e)
        {
           
                int indiceFila;
            //if (dgvDetalleTareo.CurrentCell.RowIndex == 0)
            //{
            //    indiceFila = dgvDetalleTareo.CurrentCell.RowIndex + 1;
            //}
            //else
            //{
            //    indiceFila = dgvDetalleTareo.CurrentCell.RowIndex;
            //}
            indiceFila = dgvDetalleTareo.CurrentCell.RowIndex + 1;
          
            dgvDetalleTareo.Rows.Insert(indiceFila, 1);
                for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                {
                    auxiliar = miTareo.FechaInicio.AddDays(i);
                    if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dgvDetalleTareo.Rows[indiceFila].Cells["col" + i.ToString()].Style.BackColor = Color.Red;
                    }
                }
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
            
        }

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            int indiceFila;

            indiceFila = dgvDetalleTareo.CurrentCell.RowIndex;

            
                if (Convert.ToString(dgvDetalleTareo.Rows[indiceFila].Cells[0].Value) == "")
                {
                    if (MessageBox.Show("Está seguro que desea quitar al Trabajador del Tareo de Obra", "Gestion de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    dgvDetalleTareo.Rows.RemoveAt(indiceFila);
                }
                else
                {
                    if (MessageBox.Show("Está seguro que desea eliminar al Trabajador del Tareo de Obra", "Gestion de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(dgvDetalleTareo.Rows[indiceFila].Cells[0].Value);
                    miDetalleTareo.EliminarDetalleTareo(miDetalleTareo.IdTDetalleTareo);
                    CargarDatos();
                }
            
        }

        private void btnNuevoTrabajadorTecnico_Click(object sender, EventArgs e)
        {
            Trabajador.frmNuevoTecnico fNuevoTecnico = new Trabajador.frmNuevoTecnico();
            fNuevoTecnico.RecibirDatos(miMeta.Codigo);
            fNuevoTecnico.fechaInicio = miTareo.FechaInicio;
            fNuevoTecnico.fechaFin = miTareo.FechaFin;
            if (fNuevoTecnico.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
                oDataAFP = miAFP.ObtenerListaAFP();
                oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
                oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
                oDataRegimenTrabajador = miRegimenTrabajor.ListarRegimenTrabajador(0);
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Recuerde que la Nueva Categoria que va a agregar debe ser acorde a su expediente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)== DialogResult.OK)
                {
                    frmNuevaJornal fNuevaCategoriaJornal = new frmNuevaJornal();
                    fNuevaCategoriaJornal.oMetaJornal = new CapaDeNegocios.Obras.cMetaJornal();
                    fNuevaCategoriaJornal.oMetaJornal.Meta.Codigo = miMeta.Codigo;
                    if (fNuevaCategoriaJornal.ShowDialog() == DialogResult.OK)
                    {
                        fNuevaCategoriaJornal.oMetaJornal.CrearMetaJornal(fNuevaCategoriaJornal.oMetaJornal, fNuevaCategoriaJornal.oMetaJornal.Meta);
                        cargarListaCategorias();
                        MessageBox.Show("Categoria agregada: ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Operacion cancelada ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la categoria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportartareo_Click(object sender, EventArgs e)
        {
            if (miDetalleTareo.ListarDetalleTareo(miTareo.IdTTareo).Rows.Count == 0)
            {
                Tareo.frmImportarExcel fImportarExcel = new frmImportarExcel();
                fImportarExcel.oMeta = miMeta;
                fImportarExcel.otareo = miTareo;
                fImportarExcel.ShowDialog();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("El tareo debe estar vacio para importar los datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
