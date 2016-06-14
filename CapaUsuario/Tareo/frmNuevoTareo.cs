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
using CapaDeNegocios.Obras;
using CapaDeNegocios.Tareos;

namespace CapaUsuario.Tareo
{
    public partial class frmNuevoTareo : Form
    {
        public frmNuevoTareo()
        {
            InitializeComponent();
        }

        public cTareo miTareo;
        cDetalleTareo miDetalleTareo = new cDetalleTareo();

        cListaAFP miListaAFP = new cListaAFP();
        cAFP miAFP = new cAFP();
        Boolean PrimerDibujo = false;
        int dias;

        private void frmNuevoTareo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            dtpFechaInicio.Value = miTareo.FechaInicio;
            dtpFechaFin.Value = miTareo.FechaFinal;
            cboTipotareo.Items.Add("Mensual");
            cboTipotareo.Items.Add("Quincenal");

            TimeSpan miTiempo = miTareo.FechaFinal - miTareo.FechaInicio;
            dias = miTiempo.Days;

            miTareo.MiDetalleTareo.LLenarDiasTareo();
            DibujarDataGrid(dias);
        }

        private void DibujarDataGrid(int dias)
        {
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "NOMBRE";
            colNombre.Width = 300;

            DataGridViewTextBoxColumn colDNI = new DataGridViewTextBoxColumn();
            colDNI.Name = "DNI";
            colDNI.HeaderText = "DNI";
            colDNI.Width = 100;

            DataGridViewComboBoxColumn cboAFP = new DataGridViewComboBoxColumn();
            cboAFP.Name = "AFP";
            cboAFP.HeaderText = "AFP";
            cboAFP.Width = 100;
            cboAFP.DisplayMember = "nombre";
            cboAFP.ValueMember = "idtafp";
            cboAFP.DataSource = miListaAFP.ObtenerListaAFP ();

            DataGridViewComboBoxColumn cboCategoria = new DataGridViewComboBoxColumn();
            cboCategoria.Name = "Categoria";
            cboCategoria.HeaderText = "Categoria";
            cboCategoria.Width = 100;

            cboCategoria.Items.Add("Peon");
            cboCategoria.Items.Add("Oficial");
            cboCategoria.Items.Add("Operario");
            cboCategoria.Items.Add("Maestro de Obra");

            dtgListaTareos.Columns.Add(colNombre);
            dtgListaTareos.Columns.Add(colDNI);
            dtgListaTareos.Columns.Add(cboAFP);
            dtgListaTareos.Columns.Add(cboCategoria);

            DateTime auxiliar = miTareo.FechaInicio;

            for (int i = 0; i < miTareo.MiDetalleTareo.Dias.Count; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "col" + i.ToString() ;
                string auxiliarDiaSemana ="";
                switch (miTareo.MiDetalleTareo.Dias[i].Fecha.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        auxiliarDiaSemana = "V";
                        break;
                    case DayOfWeek.Monday:
                        auxiliarDiaSemana = "L";
                        break;
                    case DayOfWeek.Saturday:
                        auxiliarDiaSemana = "S";
                        break;
                    case DayOfWeek.Sunday:
                        auxiliarDiaSemana = "D";
                        break;
                    case DayOfWeek.Thursday:
                        auxiliarDiaSemana = "J";
                        break;
                    case DayOfWeek.Tuesday:
                        auxiliarDiaSemana = "M";
                        break;
                    case DayOfWeek.Wednesday:
                        auxiliarDiaSemana = "M";
                        break;
                    default:
                        break;
                }
                col.HeaderText = auxiliarDiaSemana;
                col.Width = 20;
                dtgListaTareos.Columns.Add(col);
            }

            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colDNI.Name = "total";
            colDNI.HeaderText = "T";
            colDNI.Width = 30;
            dtgListaTareos.Columns.Add(colTotal);
        }

        private void dtgListaTareos_Paint(object sender, PaintEventArgs e)
        {
                for (int j = 4; j < (4 + miTareo.MiDetalleTareo.Dias.Count); j++)
                {
                    Rectangle r1 = this.dtgListaTareos.GetCellDisplayRectangle(j, -1, true);
                    //r1.X += 1;
                    r1.Y += 1;
                    //r1.Width = r1.Width * 2 - 2;
                    r1.Height = r1.Height / 2 - 2;
                    e.Graphics.FillRectangle(new SolidBrush(this.dtgListaTareos.ColumnHeadersDefaultCellStyle.BackColor), r1);
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(miTareo.MiDetalleTareo.Dias[j - 4].Fecha.Day.ToString(), this.dtgListaTareos.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(this.dtgListaTareos.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                    //j += 2;
                }
        }
    }
}
