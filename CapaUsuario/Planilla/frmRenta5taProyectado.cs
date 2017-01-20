using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Planilla
{
    public partial class frmRenta5taProyectado : Form
    {
        int sidttrabajador = 0;

        public frmRenta5taProyectado()
        {
            InitializeComponent();
        }

        private void frmRenta5taProyectado_Load(object sender, EventArgs e)
        {
            MostrarFilas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void RecibirDatos(int pidtplanilla, int pidttrabajador, int pmes, string paño, double pRemuneracionActual, double pIngresosActual, decimal pUIT)
        {
            //sidtplanilla = pidtplanilla;
            //txtNumero.Text = pnumero;
            //smes = pmes;
            //saño = paño;
            //txtFecha.Text = pmes + " - " + paño;
            //sidtmeta = pidtmeta;
            //txtMeta.Text = pmeta;
        }

        private void MostrarFilas()
        {
            dgv5taCat.Rows.Add(5);
            dgv5taCat.Rows[0].Cells[0].Value = "REMUNERACION";
            dgv5taCat.Rows[1].Cells[0].Value = "OTROS INGRESOS";
            dgv5taCat.Rows[2].Cells[0].Value = "RENTA PROYECTADA";
            dgv5taCat.Rows[3].Cells[0].Value = "RENTA IMPONIBLE";
            dgv5taCat.Rows[4].Cells[0].Value = "IMPUESTO A PAGAR";
        }
    }
}
