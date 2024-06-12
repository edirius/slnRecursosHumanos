using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Planillas;
using CapaDeNegocios.Obras;

namespace CapaDeNegocios.Reportes
{
    public class cDetalleReporteBoletaXTrabajador
    {
        private int idtDetallePlanilla;
        private string cargo;
        private DateTime fechaInicio;
        private int diasLaborados;
        private decimal totalIngresos;
        private decimal totalATrabajador;
        private decimal totalDescuentos;
        private decimal totalAEmpleador;
        private decimal netoACobrar;
        private int idtTrabajador;
        private int idtPlanilla;
        private string numero;
        private string mes;
        private string año;
        private DateTime fecha;
        private int idtMeta;
        private int idtFuenteFinanciamiento;
        private int idtRegimenLaboral;
        private string descripcion;
        private string plantilla;
        private string observaciones;

        private cDetallePlanilla detallePlanilla;
        private cPlanilla planilla;
        private cMeta meta;
        private string descripcionMeta;
        private cTrabajador trabajador;

        public cDetallePlanilla DetallePlanilla
        {
            get
            {
                return detallePlanilla;
            }

            set
            {
                detallePlanilla = value;
            }
        }

        public cPlanilla Planilla
        {
            get
            {
                return planilla;
            }

            set
            {
                planilla = value;
            }
        }

        public int IdtDetallePlanilla
        {
            get
            {
                return idtDetallePlanilla;
            }

            set
            {
                idtDetallePlanilla = value;
            }
        }

        public string Cargo
        {
            get
            {
                return cargo;
            }

            set
            {
                cargo = value;
            }
        }

        public DateTime FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }

        public int DiasLaborados
        {
            get
            {
                return diasLaborados;
            }

            set
            {
                diasLaborados = value;
            }
        }

        public decimal TotalIngresos
        {
            get
            {
                return totalIngresos;
            }

            set
            {
                totalIngresos = value;
            }
        }

        public decimal TotalATrabajador
        {
            get
            {
                return totalATrabajador;
            }

            set
            {
                totalATrabajador = value;
            }
        }

        public decimal TotalDescuentos
        {
            get
            {
                return totalDescuentos;
            }

            set
            {
                totalDescuentos = value;
            }
        }

        public decimal TotalAEmpleador
        {
            get
            {
                return totalAEmpleador;
            }

            set
            {
                totalAEmpleador = value;
            }
        }

        public decimal NetoACobrar
        {
            get
            {
                return netoACobrar;
            }

            set
            {
                netoACobrar = value;
            }
        }

        public int IdtTrabajador
        {
            get
            {
                return idtTrabajador;
            }

            set
            {
                idtTrabajador = value;
            }
        }

        public int IdtPlanilla
        {
            get
            {
                return idtPlanilla;
            }

            set
            {
                idtPlanilla = value;
            }
        }

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public string Mes
        {
            get
            {
                return mes;
            }

            set
            {
                mes = value;
            }
        }

        public string Año
        {
            get
            {
                return año;
            }

            set
            {
                año = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int IdtMeta
        {
            get
            {
                return idtMeta;
            }

            set
            {
                idtMeta = value;
            }
        }

        public int IdtFuenteFinanciamiento
        {
            get
            {
                return idtFuenteFinanciamiento;
            }

            set
            {
                idtFuenteFinanciamiento = value;
            }
        }

        public int IdtRegimenLaboral
        {
            get
            {
                return idtRegimenLaboral;
            }

            set
            {
                idtRegimenLaboral = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string Plantilla
        {
            get
            {
                return plantilla;
            }

            set
            {
                plantilla = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
            }
        }

        public cMeta Meta
        {
            get
            {
                return meta;
            }

            set
            {
                meta = value;
            }
        }

        public cTrabajador Trabajador
        {
            get
            {
                return trabajador;
            }

            set
            {
                trabajador = value;
            }
        }

        public string DescripcionMeta
        {
            get
            {
                return descripcionMeta;
            }

            set
            {
                descripcionMeta = value;
            }
        }
    }
}
