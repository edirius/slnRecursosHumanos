using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using CapaDeNegocios;

namespace CapaUsuario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //CapaDeNegocios.RentaQuinta.cQuintaCategoria2017 miNUevaRentaQuintaCategoria2017;



        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            //CapaDeNegocios.RentaQuinta.cQuintaCategoria miQUintaCategoria2017 = new CapaDeNegocios.RentaQuinta.cQuintaCategoria();

            //CapaDeNegocios.RentaQuinta.cRentaQuintaMes RentaEnero = new CapaDeNegocios.RentaQuinta.cRentaQuintaMes();
            //CapaDeNegocios.RentaQuinta.cRentaQuintaMes RentaFebrero = new CapaDeNegocios.RentaQuinta.cRentaQuintaMes();
            //CapaDeNegocios.RentaQuinta.cRentaQuintaMes RentaMarzo = new CapaDeNegocios.RentaQuinta.cRentaQuintaMes();

            //double RentaMes = miQUintaCategoria2017.hallaraRentaQUintaMes( detalleplanilla)
            //double RentaMes = miQUintaCategoria2017.HallarRemuneracionMesesAnteriores(9);

            //double renta = RentaFebrero.remuneracion + RentaFebrero.otrosingresos[0].monto + RentaEnero.remuneracion;
            //double renta = RentaMarzo.remuneracion + RentaMarzo.otrosingresos[0].monto + RentaFebrero.remuneracion + RentaEnero.remuneracion;

            //miQUintaCategoria2017.ListaRentaMeses[0].remuneracion;
            //miQUintaCategoria2017.ListaRentaMeses[0].otrosingresos[0].monto + " " +  miQUintaCategoria2017.ListaRentaMeses[0].otrosingresos[0].descripcion;

            //miQUintaCategoria2017.ListaRentaMeses[0].otrosingresos.Count;

            //miQUintaCategoria2017.ListaRentaMeses[0].otrosingresos.Add(cnuevoIngreso);
            
        }
    }
}
