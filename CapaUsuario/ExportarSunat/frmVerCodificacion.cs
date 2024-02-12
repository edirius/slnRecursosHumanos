using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Trabajadores;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmVerCodificacion : Form
    {
        public List<cDatosIdentificacion> ListaDatosIdentificacion;
        public List<cDatosTrabajador> ListaDatosTrabajador;
        public List<cDatosPeriodo> ListaDatosPeriodos;
        public DateTime Periodo;

        public frmVerCodificacion()
        {
            InitializeComponent();
        }

        private void frmVerCodificacion_Load(object sender, EventArgs e)
        {
            darFormatoGrid();
            cargarDatos();
        }

        private void darFormatoGrid()
        {
            dtgDatosIdentificacion.Columns.Add("Nro", "Nro");
            dtgDatosIdentificacion.Columns.Add("Col1", "Columna 1 TipoDocumento");
            dtgDatosIdentificacion.Columns.Add("col2", "Columna 2 NumeroDocumento");
            dtgDatosIdentificacion.Columns.Add("col3", "Columna 3 PaisEmisor");
            dtgDatosIdentificacion.Columns.Add("col4", "Columna 4 FechaNacimiento");
            dtgDatosIdentificacion.Columns.Add("col5", "Columna 5 ApellidoPaterno");
            dtgDatosIdentificacion.Columns.Add("col6", "Columna 6 ApellidoMaterno");
            dtgDatosIdentificacion.Columns.Add("col7", "Columna 7 Nombres");
            dtgDatosIdentificacion.Columns.Add("col8", "Columna 8 Sexo");
            dtgDatosIdentificacion.Columns.Add("col9", "Columna 9 Nacionalidad");
            dtgDatosIdentificacion.Columns.Add("col10", "Columna 10 TelefonoFijo");
            dtgDatosIdentificacion.Columns.Add("col11", "Columna 11 Telefono");
            dtgDatosIdentificacion.Columns.Add("col12", "Columna 12 CorreoElectronico");
            dtgDatosIdentificacion.Columns.Add("col13", "Columna 13 TipoVia");
            dtgDatosIdentificacion.Columns.Add("col14", "Columna 14 NombreVia");
            dtgDatosIdentificacion.Columns.Add("col15", "Columna 15 NumeroVia");
            dtgDatosIdentificacion.Columns.Add("col16", "Columna 16 Departamento");
            dtgDatosIdentificacion.Columns.Add("col17", "Columna 17 Interior");
            dtgDatosIdentificacion.Columns.Add("col18", "Columna 18 Manzana");
            dtgDatosIdentificacion.Columns.Add("col19", "Columna 19 Lote");
            dtgDatosIdentificacion.Columns.Add("col20", "Columna 20 Kilometro");
            dtgDatosIdentificacion.Columns.Add("col21", "Columna 21 Block");
            dtgDatosIdentificacion.Columns.Add("col22", "Columna 22 Etapa");
            dtgDatosIdentificacion.Columns.Add("col23", "Columna 23 TipoZona");
            dtgDatosIdentificacion.Columns.Add("col24", "Columna 24 NombreZona");
            dtgDatosIdentificacion.Columns.Add("col25", "Columna 25 Referencia");
            dtgDatosIdentificacion.Columns.Add("col26", "Columna 26 Ubigeo");
            dtgDatosIdentificacion.Columns.Add("col27", "Columna 27 TipoVia2");
            dtgDatosIdentificacion.Columns.Add("col28", "Columna 28 NombreVia2");
            dtgDatosIdentificacion.Columns.Add("col29", "Columna 29 NumeroVia2");
            dtgDatosIdentificacion.Columns.Add("col30", "Columna 30 Departamento2");
            dtgDatosIdentificacion.Columns.Add("col31", "Columna 31 Interior2");
            dtgDatosIdentificacion.Columns.Add("col32", "Columna 32 Manzana2");
            dtgDatosIdentificacion.Columns.Add("col33", "Columna 33 Lote2");
            dtgDatosIdentificacion.Columns.Add("col34", "Columna 34 Kilometro2");
            dtgDatosIdentificacion.Columns.Add("col35", "Columna 35 Block2");
            dtgDatosIdentificacion.Columns.Add("col36", "Columna 36 Etapa2");
            dtgDatosIdentificacion.Columns.Add("col37", "Columna 37 TipoZona2");
            dtgDatosIdentificacion.Columns.Add("col38", "Columna 38 NombreZona2");
            dtgDatosIdentificacion.Columns.Add("col39", "Columna 39 Referencia2");
            dtgDatosIdentificacion.Columns.Add("col40", "Columna 40 Ubigeo2");
            dtgDatosIdentificacion.Columns.Add("col41", "Columna 41 AsistenciaSalud");

            dtgDatosTrabajador.Columns.Add("Nro", "Nro");
            dtgDatosTrabajador.Columns.Add("col1", "Columna 1 TipoDocumento");
            dtgDatosTrabajador.Columns.Add("col2", "Columna 2 NumeroDocumento");
            dtgDatosTrabajador.Columns.Add("col3", "Columna 3 PaisEmisor");
            dtgDatosTrabajador.Columns.Add("col4", "Columna 4 RegimenLaboral");
            dtgDatosTrabajador.Columns.Add("col5", "Columna 5 SituacionEducativa");
            dtgDatosTrabajador.Columns.Add("col6", "Columna 6 Ocupacion");
            dtgDatosTrabajador.Columns.Add("col7", "Columna 7 Discapacidad");
            dtgDatosTrabajador.Columns.Add("col8", "Columna 8 CUSPP");
            dtgDatosTrabajador.Columns.Add("col9", "Columna 9 ScrtPension");
            dtgDatosTrabajador.Columns.Add("col10", "Columna 10 TipoContrato");
            dtgDatosTrabajador.Columns.Add("col11", "Columna 11 RegimenAlternativo");
            dtgDatosTrabajador.Columns.Add("col12", "Columna 12 JornadaMaxima");
            dtgDatosTrabajador.Columns.Add("col13", "Columna 13 HorarioNocturno");
            dtgDatosTrabajador.Columns.Add("col14", "Columna 14 Sindicalizado");
            dtgDatosTrabajador.Columns.Add("col15", "Columna 15 Periocidad");
            dtgDatosTrabajador.Columns.Add("col16", "Columna 16 RemuneracionBasica");
            dtgDatosTrabajador.Columns.Add("col17", "Columna 17 Situacion");
            dtgDatosTrabajador.Columns.Add("col18", "Columna 18 RentaQuintaExonerada");
            dtgDatosTrabajador.Columns.Add("col19", "Columna 19 SituacionEspecial");
            dtgDatosTrabajador.Columns.Add("col20", "Columna 20 TipoPago");
            dtgDatosTrabajador.Columns.Add("col21", "Columna 21 CategoriaOcupacion");
            dtgDatosTrabajador.Columns.Add("col22", "Columna 22 ConvenioDobleTributacion");
            dtgDatosTrabajador.Columns.Add("col23", "Columna 23 RUC");

            dtgDatosPeriodo.Columns.Add("Nro", "Nro");
            dtgDatosPeriodo.Columns.Add("col1", "Columna 1 TipoDocumento");
            dtgDatosPeriodo.Columns.Add("col2", "Columna 2 NumeroDocumento");
            dtgDatosPeriodo.Columns.Add("col3", "Columna 3 PaisEmisor");
            dtgDatosPeriodo.Columns.Add("col4", "Columna 4 Categoria");
            dtgDatosPeriodo.Columns.Add("col5", "Columna 5 TipoRegistro");
            dtgDatosPeriodo.Columns.Add("col6", "Columna 6 FechaInicio");
            dtgDatosPeriodo.Columns.Add("col7", "Columna 7 FechaFin");
            dtgDatosPeriodo.Columns.Add("col8", "Columna 8 IndicadorTipoRegistro");
            dtgDatosPeriodo.Columns.Add("col9", "Columna 9 EPS");
        }

        private void cargarDatos()
        {
            int n = 0;
            foreach (cDatosIdentificacion oDatosIdentificacion in ListaDatosIdentificacion)
            {
                n++;
                DataGridViewRow row = (DataGridViewRow)dtgDatosIdentificacion.Rows[0].Clone();
                row.Cells[0].Value = n.ToString();
                row.Cells[1].Value = oDatosIdentificacion.TipoDocumento.Valor;
                row.Cells[2].Value = oDatosIdentificacion.NumeroDocumento.Valor;
                row.Cells[3].Value = oDatosIdentificacion.PaisEmisor.Valor;
                row.Cells[4].Value = oDatosIdentificacion.FechaNacimiento.Valor;
                row.Cells[5].Value = oDatosIdentificacion.ApellidoPaterno.Valor;
                row.Cells[6].Value = oDatosIdentificacion.ApellidoMaterno.Valor;
                row.Cells[7].Value = oDatosIdentificacion.Nombres.Valor;
                row.Cells[8].Value = oDatosIdentificacion.Sexo.Valor;
                row.Cells[9].Value = oDatosIdentificacion.Nacionalidad.Valor;
                row.Cells[10].Value = oDatosIdentificacion.TelefonoLargaDistancia.Valor;
                row.Cells[11].Value = oDatosIdentificacion.Telefono.Valor;
                row.Cells[12].Value = oDatosIdentificacion.CorreoElectronico.Valor;
                row.Cells[13].Value = oDatosIdentificacion.TipoVia.Valor;
                row.Cells[14].Value = oDatosIdentificacion.NombreVia.Valor;
                row.Cells[15].Value = oDatosIdentificacion.NumeroVia.Valor;
                row.Cells[16].Value = oDatosIdentificacion.Departamento.Valor;
                row.Cells[17].Value = oDatosIdentificacion.Interior.Valor;
                row.Cells[18].Value = oDatosIdentificacion.Manzana.Valor;
                row.Cells[19].Value = oDatosIdentificacion.Lote.Valor;
                row.Cells[20].Value = oDatosIdentificacion.Kilometro.Valor;
                row.Cells[21].Value = oDatosIdentificacion.Block.Valor;
                row.Cells[22].Value = oDatosIdentificacion.Etapa.Valor;
                row.Cells[23].Value = oDatosIdentificacion.TipoZona.Valor;
                row.Cells[24].Value = oDatosIdentificacion.NombreZona.Valor;
                row.Cells[25].Value = oDatosIdentificacion.Referencia.Valor;
                row.Cells[26].Value = oDatosIdentificacion.Ubigeo.Valor;
                row.Cells[27].Value = oDatosIdentificacion.TipoVia2.Valor;
                row.Cells[28].Value = oDatosIdentificacion.NombreVia2.Valor;
                row.Cells[29].Value = oDatosIdentificacion.NumeroVia2.Valor;
                row.Cells[30].Value = oDatosIdentificacion.Departamento2.Valor;
                row.Cells[31].Value = oDatosIdentificacion.Interior2.Valor;
                row.Cells[32].Value = oDatosIdentificacion.Manzana2.Valor;
                row.Cells[33].Value = oDatosIdentificacion.Lote2.Valor;
                row.Cells[34].Value = oDatosIdentificacion.Kilometro2.Valor;
                row.Cells[35].Value = oDatosIdentificacion.Block2.Valor;
                row.Cells[36].Value = oDatosIdentificacion.Etapa2.Valor;
                row.Cells[37].Value = oDatosIdentificacion.TipoZona2.Valor;
                row.Cells[38].Value = oDatosIdentificacion.NombreZona2.Valor;
                row.Cells[39].Value = oDatosIdentificacion.Referencia2.Valor;
                row.Cells[40].Value = oDatosIdentificacion.Ubigeo2.Valor;
                row.Cells[41].Value = oDatosIdentificacion.IndicadorEssalud.Valor;
                dtgDatosIdentificacion.Rows.Add(row);
            }

            n = 0;
            foreach (cDatosTrabajador item in ListaDatosTrabajador)
            {
                n++;
                DataGridViewRow row = (DataGridViewRow)dtgDatosTrabajador.Rows[0].Clone();
                row.Cells[0].Value = n.ToString();
                row.Cells[1].Value = item.TipoDocumento.Valor;
                row.Cells[2].Value = item.NumeroDocumento.Valor;
                row.Cells[3].Value = item.PaisEmisor.Valor;
                row.Cells[4].Value = item.RegimenLaboral.Valor;
                row.Cells[5].Value = item.SituacionEducativa.Valor;
                row.Cells[6].Value = item.Ocupacion.Valor;
                row.Cells[7].Value = item.Discapacidad.Valor;
                row.Cells[8].Value = item.Cuspp.Valor;
                row.Cells[9].Value = item.SctrPension.Valor;
                row.Cells[10].Value = item.TipoContrato.Valor;
                row.Cells[11].Value = item.SujetoRegimenAlternativo.Valor;
                row.Cells[12].Value = item.SujetoJornadaMaxima.Valor;
                row.Cells[13].Value = item.SujetoHorarioNocturno.Valor;
                row.Cells[14].Value = item.Sindicalizado.Valor;
                row.Cells[15].Value = item.PeriocidadIngreso.Valor;
                row.Cells[16].Value = item.MontoRemuneracionBasica.Valor;
                row.Cells[17].Value = item.Situacion.Valor;
                row.Cells[18].Value = item.Renta5taExonerada.Valor;
                row.Cells[19].Value = item.SituacionEspecial.Valor;
                row.Cells[20].Value = item.TipoPago.Valor;
                row.Cells[21].Value = item.CategoriaOcupacion.Valor;
                row.Cells[22].Value = item.ConvenioPagoDobleTributacion.Valor;
                row.Cells[23].Value = item.Ruc.Valor;
                dtgDatosTrabajador.Rows.Add(row);
            }

            n = 0;

            foreach (cDatosPeriodo item in ListaDatosPeriodos)
            {
                n++;
                DataGridViewRow row = (DataGridViewRow)dtgDatosPeriodo.Rows[0].Clone();
                row.Cells[0].Value = n.ToString();
                row.Cells[1].Value = item.TipoDocumento.Valor;
                row.Cells[2].Value = item.NumeroDocumento.Valor;
                row.Cells[3].Value = item.PaisEmisor.Valor;
                row.Cells[4].Value = item.Categoria.Valor;
                row.Cells[5].Value = item.TipoRegistro.Valor;
                row.Cells[6].Value = item.FechaInicio.Valor;
                row.Cells[7].Value = item.FechaFin.Valor;
                row.Cells[8].Value = item.IndicadorTipoRegistro.Valor;
                row.Cells[9].Value = item.EpsServiciosPropios.Valor;
                dtgDatosPeriodo.Rows.Add(row);
            }

            dtgDatosIdentificacion.AllowUserToAddRows = false;
            lblFecha.Text = Periodo.ToString("MMMM/yyyy");
        }

        private void btnCambiarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDatosIdentificacion.SelectedCells.Count > 0)
                {
                    Trabajador.frmNuevoTrabajador fModificarTrabajador = new Trabajador.frmNuevoTrabajador();
                    fModificarTrabajador.modoEdicion = true;
                    fModificarTrabajador.miTrabajador = new CapaDeNegocios.cTrabajador();
                    fModificarTrabajador.miTrabajador = fModificarTrabajador.miTrabajador.BuscarTrabajadorXDNI(dtgDatosIdentificacion.Rows[dtgDatosIdentificacion.SelectedCells[0].RowIndex].Cells[2].Value.ToString());

                    if (fModificarTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        fModificarTrabajador.miTrabajador.ModificarTrabajador(fModificarTrabajador.miTrabajador);
                        MessageBox.Show("Datos Guardados", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No hay datos seleccionados", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);

            }
        }
    }
}
