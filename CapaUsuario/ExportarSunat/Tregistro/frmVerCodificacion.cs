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

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public partial class frmVerCodificacion : Form
    {
        public frmVerCodificacion()
        {
            InitializeComponent();
        }

        public List<Tregistro.cTrabajadorAltaTRegistro> ListaTrabajadores;
        public DateTime Mes;
        Tregistro.cCatalogoAltaTRegistro oCatalogo = new cCatalogoAltaTRegistro(cDatosGeneralesEmpresa.RUC);
        List<Tregistro.cFilarDatosJor> ListaDatosJor = new List<cFilarDatosJor>();

        private void frmVerCodificacion_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            dtgJor.DataSource = oCatalogo.TraerArchivoJOR(ListaTrabajadores);
            dtgTra.DataSource = oCatalogo.TraerArchivoTRA(ListaTrabajadores, Mes);
            dtgPer.DataSource = oCatalogo.TraerArchivoPER(ListaTrabajadores, Mes);
        }
    }
}
