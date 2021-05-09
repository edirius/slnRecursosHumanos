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

        public frmMantenimientoDetalleTareo()
        {
            InitializeComponent();
        }

        private void frmMantenimientoDetalleTareo_Load(object sender, EventArgs e)
        {
            DibujarDataGrid(miTareo.FechaFin.Day - miTareo.FechaInicio.Day);
            MostrarColumnas();
            oDataTrabajador = miTrabajador.ObtenerListaTrabajadores("Todos");
            oDataAFP = miAFP.ObtenerListaAFP();
            oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(0);
            oDataRegimenTrabajador = miRegimenTrabajor.ListarRegimenTrabajador(0);
            oDataRegimenPensionarioTrabajador = miRegimenPensionarioTrabajor.ListarRegimenPensionarioTrabajador(0);
            oDataCargo = miCargo.ListaCargos();
            CargarDatos();
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
                string FechaInicio = "";
                int IdtCargo = 0;
                string Cargo = "";
                string AFP = "";

                int pIdTTareo = 0;
                int contador = 0;
                int fila = 0;
                dgvDetalleTareo.Rows.Clear();
                pIdTTareo = miTareo.IdTTareo;
                //oDataTareo = miTareo.ListarTareo(miMeta.Codigo);
                //foreach (DataRow row1 in oDataTareo.Select("numero='" + (Convert.ToInt32(txtNumero.Text) - 1) + "' and descripcion='" + miTareo.Descripcion + "'"))
                //{
                //    miTareo.IdTTareo = Convert.ToInt32(row1[0]);
                //}
                miTareo.IdTTareo = fImportarTareo.sidttareoimportar;
                oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(miTareo.IdTTareo);
                foreach (DataRow row in oDataDetalleTareo.Rows)
                {
                    IdtTrabajador = row[4].ToString();
                    if (ComprobarBajaTrabajador(Convert.ToInt32(IdtTrabajador)) == false)
                    {
                        contador += 1;
                        dgvDetalleTareo.Rows.Add();
                        fila = dgvDetalleTareo.RowCount - 1;
                        dgvDetalleTareo.Rows[fila].Cells[1].Value = "I";
                        dgvDetalleTareo.Rows[fila].Cells[3].Value = contador;
                        foreach (DataRow row1 in oDataTrabajador.Select("id_trabajador = '" + IdtTrabajador + "'"))
                        {
                            Nombre = row1[2].ToString() + " " + row1[3].ToString() + ", " + row1[4].ToString();
                            DNI = row1[1].ToString();
                            Sexo = row1[5].ToString();
                            foreach (DataRow rowPeriodoTrabajador in oDataPeriodoTrabajador.Select("idttrabajador = '" + Convert.ToInt32(row1[0].ToString()) + "'"))
                            {
                                FechaInicio = rowPeriodoTrabajador[1].ToString();
                                foreach (DataRow rowRegimenTrabajador in oDataRegimenTrabajador.Select("idtperiodotrabajador = '" + Convert.ToInt32(rowPeriodoTrabajador[0].ToString()) + "'"))
                                {
                                    foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + Convert.ToInt32(rowRegimenTrabajador[15].ToString()) + "'"))
                                    {
                                        IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                                        Cargo = rowCargo[1].ToString();
                                    }
                                }
                                foreach (DataRow rowRegimenPensionarioTrabajador in oDataRegimenPensionarioTrabajador.Select("idtperiodotrabajador = '" + Convert.ToInt32(rowPeriodoTrabajador[0].ToString()) + "'"))
                                {
                                    foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + Convert.ToInt32(rowRegimenPensionarioTrabajador[5].ToString()) + "'"))
                                    {
                                        AFP = rowAFP[1].ToString();
                                    }
                                }
                            }
                            dgvDetalleTareo.Rows[fila].Cells[4].Value = IdtTrabajador;
                            dgvDetalleTareo.Rows[fila].Cells[5].Value = Nombre;
                            dgvDetalleTareo.Rows[fila].Cells[6].Value = DNI;
                            dgvDetalleTareo.Rows[fila].Cells[7].Value = Sexo;
                            dgvDetalleTareo.Rows[fila].Cells[8].Value = Cargo;
                            dgvDetalleTareo.Rows[fila].Cells[10].Value = FechaInicio;
                            dgvDetalleTareo.Rows[fila].Cells[11].Value = AFP;
                            if (miTareo.Descripcion == "PERSONAL TECNICO") { dgvDetalleTareo.Rows[fila].Cells[8].Value = row[1].ToString(); }
                            else { dgvDetalleTareo.Rows[fila].Cells[9].Value = row[1].ToString(); }
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
                        //MessageBox.Show("El trabajador se encuentra de Baja, no se puede agregar al Tareo.", "Gestion de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (MessageBox.Show("Está seguro de poner en aprobacion el Tareo de Obra, ya no podra Modificarlo.", "Confirmar Aprobacion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miTareo.Estado = true;
            miTareo.ModificarTareo(miTareo, miMeta);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnNuevoTrabajador_Click(object sender, EventArgs e)
        {
            Trabajador.frmNuevoObrero fNuevoObrero = new Trabajador.frmNuevoObrero();
            fNuevoObrero.RecibirDatos(miMeta.Codigo);
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
                        if (Convert.ToString(row.Cells[12 + i - contadordias].Value) == "")
                        {
                            diastareo += "0";
                        }
                        diastareo += Convert.ToString(row.Cells[12 + i - contadordias].Value);
                    }
                    else
                    {
                        contadordias += 1;
                        diastareo += "0";
                    }
                }
                miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(row.Cells[0].Value);
                if (miTareo.Descripcion == "PERSONAL TECNICO") { miDetalleTareo.Categoria = Convert.ToString(row.Cells[8].Value); }
                else { miDetalleTareo.Categoria = Convert.ToString(row.Cells[9].Value); }
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
            }
        }

        void GuardarTareoHorasAcumulado()
        {
            try
            {
                //JEFE DE SUPERVISION Y LIQUIDACION DE OBRAS
                //LIQUIDADOR FINANCIERO
                //OBRERO
                //RESIDENTE
                CapaDeNegocios.Tareos.cTareoHorasAcumuladas miTareoHorasAcumuladas = new CapaDeNegocios.Tareos.cTareoHorasAcumuladas();
                double MAESTRO_DE_OBRA = 0;
                double OPERARIO = 0;
                double OFICIAL = 0;
                double PEON = 0;
                double ALMACENERO = 0;
                double GUARDIAN = 0;
                double INGENIERO_RESIDENTE = 0;
                double INSPECTOR_DE_OBRA = 0;
                double ASISTENTE_ADMINISTRATIVO = 0;
                double ASISTENTE_TECNICO = 0;
                double OPERADOR_DE_CAMIONETA = 0;

                foreach (DataGridViewRow row in dgvDetalleTareo.Rows)
                {
                    if (miTareo.Descripcion == "PERSONAL TECNICO")
                    {
                        string xxx = Convert.ToString(row.Cells[8].Value);
                        switch (Convert.ToString(row.Cells[8].Value))
                        {
                            case "INGENIERO RESIDENTE":
                                INGENIERO_RESIDENTE += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                            case "RESIDENTE":
                                INGENIERO_RESIDENTE += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                            case "INSPECTOR DE OBRA":
                                INSPECTOR_DE_OBRA += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                            case "ASISTENTE ADMINISTRATIVO":
                                ASISTENTE_ADMINISTRATIVO += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                            case "ASISTENTE TECNICO":
                                ASISTENTE_TECNICO += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                            case "OPERADOR DE CAMIONETA":
                                OPERADOR_DE_CAMIONETA += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                        }
                    }
                    else
                    {
                        switch (Convert.ToString(row.Cells[9].Value))
                        {
                            case "MAESTRO DE OBRA":
                                MAESTRO_DE_OBRA += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                            case "OPERARIO":
                                OPERARIO += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                            case "OFICIAL":
                                OFICIAL += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                            case "PEON":
                                PEON += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                            case "ALMACENERO":
                                ALMACENERO += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                            case "GUARDIAN":
                                GUARDIAN += Convert.ToDouble(row.Cells[dgvDetalleTareo.ColumnCount - 1].Value);
                                break;
                        }
                    }
                }

                miTareoHorasAcumuladas.EliminarTareoHorasAcumuladas(miTareo.IdTTareo);
                miTareoHorasAcumuladas.Fecha = miTareo.FechaInicio;
                miTareoHorasAcumuladas.Idttareo = miTareo.IdTTareo;
                miTareoHorasAcumuladas.Descripcion = miTareo.Descripcion;
                if (miTareo.Descripcion == "PERSONAL TECNICO")
                {
                    miTareoHorasAcumuladas.Categoria = "INGENIERO RESIDENTE";
                    miTareoHorasAcumuladas.Totalhoras = INGENIERO_RESIDENTE;
                    miTareoHorasAcumuladas.CrearTareoHorasAcumuladas(miTareoHorasAcumuladas);

                    miTareoHorasAcumuladas.Categoria = "INSPECTOR DE OBRA";
                    miTareoHorasAcumuladas.Totalhoras = INSPECTOR_DE_OBRA;
                    miTareoHorasAcumuladas.CrearTareoHorasAcumuladas(miTareoHorasAcumuladas);

                    miTareoHorasAcumuladas.Categoria = "ASISTENTE ADMINISTRATIVO";
                    miTareoHorasAcumuladas.Totalhoras = ASISTENTE_ADMINISTRATIVO;
                    miTareoHorasAcumuladas.CrearTareoHorasAcumuladas(miTareoHorasAcumuladas);

                    miTareoHorasAcumuladas.Categoria = "ASISTENTE TECNICO";
                    miTareoHorasAcumuladas.Totalhoras = ASISTENTE_TECNICO;
                    miTareoHorasAcumuladas.CrearTareoHorasAcumuladas(miTareoHorasAcumuladas);

                    miTareoHorasAcumuladas.Categoria = "OPERADOR DE CAMIONETA";
                    miTareoHorasAcumuladas.Totalhoras = OPERADOR_DE_CAMIONETA;
                    miTareoHorasAcumuladas.CrearTareoHorasAcumuladas(miTareoHorasAcumuladas);
                }
                else
                {
                    miTareoHorasAcumuladas.Categoria = "MAESTRO DE OBRA";
                    miTareoHorasAcumuladas.Totalhoras = MAESTRO_DE_OBRA;
                    miTareoHorasAcumuladas.CrearTareoHorasAcumuladas(miTareoHorasAcumuladas);

                    miTareoHorasAcumuladas.Categoria = "OPERARIO";
                    miTareoHorasAcumuladas.Totalhoras = OPERARIO;
                    miTareoHorasAcumuladas.CrearTareoHorasAcumuladas(miTareoHorasAcumuladas);

                    miTareoHorasAcumuladas.Categoria = "OFICIAL";
                    miTareoHorasAcumuladas.Totalhoras = OFICIAL;
                    miTareoHorasAcumuladas.CrearTareoHorasAcumuladas(miTareoHorasAcumuladas);

                    miTareoHorasAcumuladas.Categoria = "PEON";
                    miTareoHorasAcumuladas.Totalhoras = PEON;
                    miTareoHorasAcumuladas.CrearTareoHorasAcumuladas(miTareoHorasAcumuladas);

                    miTareoHorasAcumuladas.Categoria = "ALMACENERO";
                    miTareoHorasAcumuladas.Totalhoras = ALMACENERO;
                    miTareoHorasAcumuladas.CrearTareoHorasAcumuladas(miTareoHorasAcumuladas);

                    miTareoHorasAcumuladas.Categoria = "GUARDIAN";
                    miTareoHorasAcumuladas.Totalhoras = GUARDIAN;
                    miTareoHorasAcumuladas.CrearTareoHorasAcumuladas(miTareoHorasAcumuladas);
                }
            }
            catch (Exception e)
            { }
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
                if (dgvDetalleTareo.Rows[e.RowIndex].Cells[12].Selected == true)
                {
                    LlenarDias(e.RowIndex, "x");
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[dgvDetalleTareo.ColumnCount - 2].Value = TotalDias(e.RowIndex);
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[dgvDetalleTareo.ColumnCount - 1].Value = TotalHoras(e.RowIndex);
                }
                else if (dgvDetalleTareo.Rows[e.RowIndex].Cells[2].Selected == true)
                {
                    if (Convert.ToString(dgvDetalleTareo.Rows[e.RowIndex].Cells[0].Value) == "")
                    {
                        if (MessageBox.Show("Está seguro que desea quitar al Trabajador del Tareo de Obra", "Gestion de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                        dgvDetalleTareo.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        if (MessageBox.Show("Está seguro que desea eliminar al Trabajador del Tareo de Obra", "Gestion de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                        miDetalleTareo.IdTDetalleTareo = Convert.ToInt32(dgvDetalleTareo.Rows[e.RowIndex].Cells[0].Value);
                        miDetalleTareo.EliminarDetalleTareo(miDetalleTareo.IdTDetalleTareo);
                        CargarDatos();
                    }
                }
            }
        }

        private void dgvDetalleTareo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Selected == true)
            {
                int z = 0;
                int contador = 0;
                string IdtTrabajador = "";
                string Nombre = "";
                string DNI = "";
                string Sexo = "";
                string FechaInicio = "";
                int IdtCargo = 0;
                string Cargo = "";
                string AFP = "";

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
                    if (ComprobarBajaTrabajador(Convert.ToInt32(IdtTrabajador)) == true)
                    {
                        dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value = "";
                        MessageBox.Show("El trabajador se encuentra de Baja, no se puede agregar al Tareo.", "Gestion de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Nombre = row[2].ToString() + " " + row[3].ToString() + ", " + row[4].ToString();
                    DNI = row[1].ToString();
                    Sexo = row[5].ToString();
                    foreach (DataRow rowPeriodoTrabajador in oDataPeriodoTrabajador.Select("idttrabajador = '" + Convert.ToInt32(row[0].ToString()) + "'"))
                    {
                        FechaInicio = rowPeriodoTrabajador[1].ToString();
                        foreach (DataRow rowRegimenTrabajador in oDataRegimenTrabajador.Select("idtperiodotrabajador = '" + Convert.ToInt32(rowPeriodoTrabajador[0].ToString()) + "'"))
                        {
                            foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + Convert.ToInt32(rowRegimenTrabajador[15].ToString()) + "'"))
                            {
                                IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                                Cargo = rowCargo[1].ToString();
                            }
                        }
                        foreach (DataRow rowRegimenPensionarioTrabajador in oDataRegimenPensionarioTrabajador.Select("idtperiodotrabajador = '" + Convert.ToInt32(rowPeriodoTrabajador[0].ToString()) + "'"))
                        {
                            foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + Convert.ToInt32(rowRegimenPensionarioTrabajador[5].ToString()) + "'"))
                            {
                                AFP = rowAFP[1].ToString();
                            }
                        }
                    }
                    if (Convert.ToString(dgvDetalleTareo.Rows[e.RowIndex].Cells[1].Value) == "") { dgvDetalleTareo.Rows[e.RowIndex].Cells[1].Value = "I"; }
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[3].Value = e.RowIndex + 1;
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[4].Value = IdtTrabajador;
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[5].Value = Nombre;
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value = DNI;
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[7].Value = Sexo;
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[8].Value = Cargo;
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[10].Value = FechaInicio;
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[11].Value = AFP;
                }
                if (contador == 0)
                {
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[5].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[6].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[7].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[8].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[10].Value = "";
                    dgvDetalleTareo.Rows[e.RowIndex].Cells[11].Value = "";
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
                MessageBox.Show("No existe el Trabajador, para agregar hacer clic en Nuevo Trabajador", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvDetalleTareo.Rows[e.RowIndex].Cells[dgvDetalleTareo.ColumnCount - 2].Value = TotalDias(e.RowIndex);
            dgvDetalleTareo.Rows[e.RowIndex].Cells[dgvDetalleTareo.ColumnCount - 1].Value = TotalHoras(e.RowIndex);
        }

        private void dgvDetalleTareo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        private void dgvDetalleTareo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgvDetalleTareo.Rows.Add();
                for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
                {
                    auxiliar = miTareo.FechaInicio.AddDays(i);
                    if (auxiliar.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dgvDetalleTareo.Rows[dgvDetalleTareo.RowCount - 1].Cells["col" + i.ToString()].Style.BackColor = Color.Red;
                    }
                }
                dgvDetalleTareo.CurrentCell = dgvDetalleTareo.CurrentRow.Cells[6];
            }
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
            if (pDescripcion == "PERSONAL TECNICO") { btnNuevoTrabajador.Visible = false; }
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
            string FechaInicio = "";
            int IdtCargo = 0;
            string Cargo = "";
            string AFP = "";
            dgvDetalleTareo.Rows.Clear();
            oDataDetalleTareo = miDetalleTareo.ListarDetalleTareo(miTareo.IdTTareo);
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
                    Nombre = row1[2].ToString() + " " + row1[3].ToString() + ", " + row1[4].ToString();
                    DNI = row1[1].ToString();
                    Sexo = row1[5].ToString();
                    foreach (DataRow rowPeriodoTrabajador in oDataPeriodoTrabajador.Select("idttrabajador = '" + Convert.ToInt32(row1[0].ToString()) + "'"))
                    {
                        FechaInicio = rowPeriodoTrabajador[1].ToString();
                        foreach (DataRow rowRegimenTrabajador in oDataRegimenTrabajador.Select("idtperiodotrabajador = '" + Convert.ToInt32(rowPeriodoTrabajador[0].ToString()) + "'"))
                        {
                            foreach (DataRow rowCargo in oDataCargo.Select("idtcargo = '" + Convert.ToInt32(rowRegimenTrabajador[15].ToString()) + "'"))
                            {
                                IdtCargo = Convert.ToInt32(rowCargo[0].ToString());
                                Cargo = rowCargo[1].ToString();
                            }
                        }
                        foreach (DataRow rowRegimenPensionarioTrabajador in oDataRegimenPensionarioTrabajador.Select("idtperiodotrabajador = '" + Convert.ToInt32(rowPeriodoTrabajador[0].ToString()) + "'"))
                        {
                            foreach (DataRow rowAFP in oDataAFP.Select("idtafp = '" + Convert.ToInt32(rowRegimenPensionarioTrabajador[5].ToString()) + "'"))
                            {
                                AFP = rowAFP[1].ToString();
                            }
                        }
                    }
                    dgvDetalleTareo.Rows[fila].Cells[4].Value = IdtTrabajador;
                    dgvDetalleTareo.Rows[fila].Cells[5].Value = Nombre;
                    dgvDetalleTareo.Rows[fila].Cells[6].Value = DNI;
                    dgvDetalleTareo.Rows[fila].Cells[7].Value = Sexo;
                    dgvDetalleTareo.Rows[fila].Cells[8].Value = Cargo;
                    dgvDetalleTareo.Rows[fila].Cells[10].Value = FechaInicio;
                    dgvDetalleTareo.Rows[fila].Cells[11].Value = AFP;
                    if (miTareo.Descripcion == "PERSONAL TECNICO") { dgvDetalleTareo.Rows[fila].Cells[8].Value = row[1].ToString(); }
                    else { dgvDetalleTareo.Rows[fila].Cells[9].Value = row[1].ToString(); }
                }

                contadordias = 0;
                diastareo = row[2].ToString();
                for (int i = 1; i <= 31; i++)
                {
                    r = diastareo.Substring(i - 1, 1);
                    if (i >= miTareo.FechaInicio.Day && i <= miTareo.FechaFin.Day)
                    {
                        dgvDetalleTareo.Rows[fila].Cells[12 + i - contadordias].Value = r;
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
            switch (miTareo.Descripcion)
            {
                case "PERSONAL TECNICO":
                       dgvDetalleTareo.Columns[9].Visible = false;
                    break;
                case "PERSONAL OBRERO":
                    dgvDetalleTareo.Columns[8].Visible = false;
                    break;
                case "RACIONAMIENTO":
                    dgvDetalleTareo.Columns[8].Visible = false;
                    dgvDetalleTareo.Columns[11].Visible = false;
                    break;
                default:
                    break;
            }
            //if (miTareo.Descripcion == "PERSONAL TECNICO")
            //{
            //    dgvDetalleTareo.Columns[9].Visible = false;
            //}
            //else
            //{
            //    dgvDetalleTareo.Columns[8].Visible = false;
            //}
        }

        void LlenarDias(int fila, string caracter)
        {
            for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
            {
                auxiliar = miTareo.FechaInicio.AddDays(i);
                //if (auxiliar.DayOfWeek != DayOfWeek.Sunday)//si es domingo
                //{
                dgvDetalleTareo.Rows[fila].Cells[13 + i].Value = caracter;
                //}
            }
        }

        int TotalDias(int fila)
        {
            int contadordias = 0;
            for (int i = 0; i <= (miTareo.FechaFin.Day - miTareo.FechaInicio.Day); i++)
            {
                if (Convert.ToString(dgvDetalleTareo.Rows[fila].Cells[13 + i].Value) == "x" || Convert.ToString(dgvDetalleTareo.Rows[fila].Cells[13 + i].Value) == "X")
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
                if (dgvDetalleTareo.Rows[fila].Cells[13 + i].Value != null)
                {
                    if (dgvDetalleTareo.Rows[fila].Cells[13 + i].Value.ToString() == "x" || dgvDetalleTareo.Rows[fila].Cells[13 + i].Value.ToString() == "X")
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
            if (sidttrabajador == 0)
            {
                MessageBox.Show("No selecciono a ningun trabajador", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PeriodoTrabajador(sidttrabajador);
            CapaUsuario.Tareo.frmBajaTrabajador fBajaTrabajador = new CapaUsuario.Tareo.frmBajaTrabajador();
            fBajaTrabajador.RecibirDatos(miTareo.FechaInicio, sidtperiodotrabajador);
            fBajaTrabajador.ShowDialog();
        }

        private bool ComprobarBajaTrabajador(int IdtTrabajador)
        {
            bool Baja = false;
            DataTable oDataPeriodoTrabajador = new DataTable();
            oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(IdtTrabajador);
            foreach (DataRow row in oDataPeriodoTrabajador.Rows)
            {
                if (row[2].ToString() != "")
                {
                    Baja = true;
                }
                else
                {
                    Baja = false;
                }
            }
            return Baja;
        }
    }
}
