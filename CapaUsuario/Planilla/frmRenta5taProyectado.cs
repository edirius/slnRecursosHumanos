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
        string smes = "";
        string saño = "";
        int sidtplanilla = 0;
        int sidttrabajador = 0;
        double sRemuneracionBasica = 0;
        double sRemuneracionActual = 0;
        double sIngresosActual = 0;
        double sUIT = 0;

        public frmRenta5taProyectado()
        {
            InitializeComponent();
        }

        private void frmRenta5taProyectado_Load(object sender, EventArgs e)
        {
            MostrarFilas();
            Calculo5taProyectada();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void RecibirDatos(int pidtplanilla, int pidttrabajador, string pmes, string paño, double pRemuneracionActual, double pIngresosActual, decimal pUIT)
        {
            sidtplanilla = pidtplanilla;
            sidttrabajador = pidttrabajador;
            smes = pmes;
            saño = paño;
            //sRemuneracionBasica = 0;
            sRemuneracionActual = pRemuneracionActual;
            sIngresosActual = pIngresosActual;
            sUIT = Convert.ToDouble(pUIT);
        }

        private void Calculo5taProyectada()
        {
            CapaDeNegocios.RentaQuinta.cRentaQuinta miQuintaCategoria = new CapaDeNegocios.RentaQuinta.cRentaQuinta();
            miQuintaCategoria.idttrabajador = sidttrabajador;
            miQuintaCategoria.mes = Convert.ToInt32(Mes(smes));
            miQuintaCategoria.año = Convert.ToInt32(saño);
            miQuintaCategoria.remuneracion = 6000;
            miQuintaCategoria.ingresos = 0;
            miQuintaCategoria.UIT = sUIT;
            miQuintaCategoria.RentaQuintaCategoria();
            for (int i = 0; i < 12; i++)
            {
                dgv5taCat.Rows[0].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].remuneracion);
                dgv5taCat.Rows[1].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].sumatoriaingresosproyectables());
                dgv5taCat.Rows[2].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].xnumeromeses);
                dgv5taCat.Rows[3].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].remuneracionanteriores);
                dgv5taCat.Rows[4].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].sumatoriaingresosnoproyectables());
                dgv5taCat.Rows[5].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].rentanetaproyectada);
                dgv5taCat.Rows[6].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].uit7);
                dgv5taCat.Rows[7].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].rentanetaimponible);
                dgv5taCat.Rows[8].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].PrimeraDeduccion);
                dgv5taCat.Rows[9].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].SegundaDeduccion);
                dgv5taCat.Rows[10].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].TerceraDeduccion);
                dgv5taCat.Rows[11].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].CuartaDeduccion);
                dgv5taCat.Rows[12].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].QuintaDeduccion);
                dgv5taCat.Rows[13].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].impuestaanual);
                dgv5taCat.Rows[14].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].retencionesanteriores);
                dgv5taCat.Rows[15].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].impuestocalculado);
                dgv5taCat.Rows[16].Cells[i + 1].Value = string.Format("{0:0.00}", miQuintaCategoria.ListaRentaMensual[i].impuestomensualapagar);
            }
        }

        private void MostrarFilas()
        {
            dgv5taCat.Rows.Add(17);
            dgv5taCat.Rows[0].Cells[0].Value = "REMUNERACION";
            dgv5taCat.Rows[1].Cells[0].Value = "INGRESOS";
            dgv5taCat.Rows[2].Cells[0].Value = "X NUMERO DE MESES";
            dgv5taCat.Rows[3].Cells[0].Value = "REMUNERACIONES ANTERIORES";
            dgv5taCat.Rows[4].Cells[0].Value = "OTROS INGRESOS";
            dgv5taCat.Rows[5].Cells[0].Value = "RENTA NETA PROYECTADA";
            dgv5taCat.Rows[6].Cells[0].Value = "MENOS 7 UIT";
            dgv5taCat.Rows[7].Cells[0].Value = "RENTA NETA IMPONIBLE";
            dgv5taCat.Rows[8].Cells[0].Value = "HASTA 5 UIT 8%";
            dgv5taCat.Rows[9].Cells[0].Value = "MAS DE 5 HASTA 20 UIT 14%";
            dgv5taCat.Rows[10].Cells[0].Value = "MAS DE 20 HASTA 35 UIT 17%";
            dgv5taCat.Rows[11].Cells[0].Value = "MAS DE 35 HASTA 45 UIT 20%";
            dgv5taCat.Rows[12].Cells[0].Value = "MAS DE 45 UIT 30%";
            dgv5taCat.Rows[13].Cells[0].Value = "IMPUESTO ANUAL";
            dgv5taCat.Rows[14].Cells[0].Value = "RETENCIONES ANTERIORES";
            dgv5taCat.Rows[15].Cells[0].Value = "IMPUESTO CALCULADO";
            dgv5taCat.Rows[16].Cells[0].Value = "IMPUESTO MENSUAL A PAGAR";
        }

        string Mes(string pmes)
        {
            string x = "";
            switch (pmes)
            {
                case "ENERO":
                    x = "01";
                    break;
                case "FEBRERO":
                    x = "02";
                    break;
                case "MARZO":
                    x = "03";
                    break;
                case "ABRIL":
                    x = "04";
                    break;
                case "MAYO":
                    x = "05";
                    break;
                case "JUNIO":
                    x = "06";
                    break;
                case "JULIO":
                    x = "07";
                    break;
                case "AGOSTO":
                    x = "08";
                    break;
                case "SETIEMBRE":
                    x = "09";
                    break;
                case "OCTUBRE":
                    x = "10";
                    break;
                case "NOVIEMBRE":
                    x = "11";
                    break;
                case "DICIEMBRE":
                    x = "12";
                    break;
            }
            return x;
        }
    }
}
