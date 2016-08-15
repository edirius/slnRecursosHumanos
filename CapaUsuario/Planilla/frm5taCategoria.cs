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

namespace CapaUsuario.Planilla
{
    public partial class frm5taCategoria : Form
    {
        //public cTrabajador NombreTrabajador;
        string[] Datos = {
            "RetencionPorRem. Ordinarias",
            "Remuneración Básica",
            "Asignación Familiar",
            "Alimentación",
            "Resto de Mes(Proyección)",
            "Rem.Comp.Mensual",
            "Total Rem.Proyc. Periodo",
            "Gratificación(Julio)",
            "Gratificación(Diciembre)",
            "ConceptosRecibidosMesesAnteriores",
            "Remuneración Meses Anteriores",
            "Bonificación extraordinaria Julio",
            "Bonificación extraordinaria Diciembre",
            "Total de Ingreso Anual Proyectado",
            "Deducción 7UITs",
            "Renta Neta Anual Proyectada",
            "Cálculo del IR anual proyectado",
            "Hasta 5 UIT",
            "PorExc.5 y hasta 20 UITS",
            "PorExc.20 y hasta 35 UITS",
            "PorExc.35 y hasta 45 UITS",
            "PorExceso de 45 UITS",
            "Factor",
            "Retención Mensual"
        };
        public frm5taCategoria()
        {
            InitializeComponent();
            LlenarConceptos();
            
        }
        private void LlenarConceptos()
        {
            for (int i = 0; i < Datos.Length; i++)
            {
                dgvIR5.Rows.Add();
                dgvIR5[0, i].Value = Datos[i].ToString();
                //dgv5taCategoria.Rows[0].DefaultCellStyle.BackColor = Color.DarkBlue;
            }
        }
        private int obtenerIndiceCol(string Mes)
        {
            int NroMes = 0;
            switch (Mes)
            {
                case "Enero":
                    NroMes = 1;
                    break;
                case "Febrero":
                    NroMes = 2;
                    break;
                case "Marzo":
                    NroMes = 3;
                    break;
                case "Abril":
                    NroMes = 4;
                    break;
                case "Mayo":
                    NroMes = 5;
                    break;
                case "Junio":
                    NroMes = 6;
                    break;
                case "Julio":
                    NroMes = 7;
                    break;
                case "Agosto":
                    NroMes = 8;
                    break;
                case "Setiembre":
                    NroMes = 9;
                    break;
                case "Octubre":
                    NroMes = 10;
                    break;
                case "Noviembre":
                    NroMes = 11;
                    break;
                case "Diciembre":
                    NroMes = 12;
                    break;

            }
            return NroMes;
        }
        private int obtenerIndiceFila(string Concepto)
        {
            int ind = 0;
            switch (Concepto)
            {
                case "RetencionPorRem. Ordinarias":
                    ind = 0;
                    break;
                case "Remuneración Básica":
                    ind = 1;
                    break;
                case "Asignación Familiar":
                    ind = 2;
                    break;
                case "Alimentación":
                    ind = 3;
                    break;
                case "Resto de Mes(Proyección)":
                    ind = 4;
                    break;
                case "Rem.Comp.Mensual":
                    ind = 5;
                    break;
                case "Total Rem.Proyc. Periodo":
                    ind = 6;
                    break;
                case "Gratificación(Julio)":
                    ind = 7;
                    break;
                case "Gratificación(Diciembre)":
                    ind = 8;
                    break;
                case "ConceptosRecibidosMesesAnteriores":
                    ind = 9;
                    break;
                case "Remuneración Meses Anteriores":
                    ind = 10;
                    break;
                case "Bonificación extraordinaria Julio":
                    ind = 11;
                    break;
                case "Bonificación extraordinaria Diciembre":
                    ind = 12;
                    break;
                case "Total de Ingreso Anual Proyectado":
                    ind = 13;
                    break;
                case "Deducción 7UITs":
                    ind = 14;
                    break;
                case "Renta Neta Anual Proyectada":
                    ind = 15;
                    break;
                case "Cálculo del IR anual proyectado":
                    ind = 16;
                    break;
                case "Hasta 5 UIT":
                    ind = 17;
                    break;
                case "PorExc.5 y hasta 20 UITS":
                    ind = 18;
                    break;
                case "PorExc.20 y hasta 35 UITS":
                    ind = 19;
                    break;
                case "PorExc.35 y hasta 45 UITS":
                    ind = 20;
                    break;
                case "PorExceso de 45 UITS":
                    ind = 21;
                    break;
                case "Factor":
                    ind = 22;
                    break;
                case "Retención Mensual":
                    ind = 23;
                    break;
            }
            return ind;
        }
        
        private void LlenarUIT()
        {
            
        }

    }
}

