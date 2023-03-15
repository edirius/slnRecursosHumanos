using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;


namespace CapaDeNegocios.RentaQuinta
{
    public class cRenta5taAnteriores
    {
        int idtRenta5taAnteriores;
        DateTime fecha;
        decimal ingresos;
        decimal retenciones;
        cTrabajador trabajador;

        public int IdtRenta5taAnteriores
        {
            get
            {
                return idtRenta5taAnteriores;
            }

            set
            {
                idtRenta5taAnteriores = value;
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

        public decimal Ingresos
        {
            get
            {
                return ingresos;
            }

            set
            {
                ingresos = value;
            }
        }

        public decimal Retenciones
        {
            get
            {
                return retenciones;
            }

            set
            {
                retenciones = value;
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


        public cRenta5taAnteriores TraerRenta5taAnteriores (int pidtrenta5taanteriores)
        {
            DataTable tRenta5ta = Conexion.GDatos.TraerDataTable("spTraerRenta5taAnetriores", pidtrenta5taanteriores);
            cRenta5taAnteriores auxiliar = new cRenta5taAnteriores();
            if (tRenta5ta.Rows.Count > 0)
            {
                auxiliar.IdtRenta5taAnteriores = Convert.ToInt32(tRenta5ta.Rows[0][0]);
                auxiliar.Fecha = Convert.ToDateTime(tRenta5ta.Rows[0][1]);
                auxiliar.Ingresos = Convert.ToDecimal(tRenta5ta.Rows[0][2]);
                auxiliar.Retenciones = Convert.ToDecimal(tRenta5ta.Rows[0][3]);
                auxiliar.Trabajador = new cTrabajador();
                auxiliar.Trabajador.IdTrabajador = Convert.ToInt32(tRenta5ta.Rows[0][4]);
                return auxiliar;
            }
            else
            {
                return null;
            }
        }

        public void CrearRenta5taAnterior(cRenta5taAnteriores renta)
        {
            Conexion.GDatos.Ejecutar("spCrearRenta5taAnteriores", renta.Fecha, renta.Ingresos, renta.Retenciones, renta.Trabajador.IdTrabajador);
        }

        public void ModificarRenta5taAnterior(cRenta5taAnteriores renta)
        {
            Conexion.GDatos.Ejecutar("spModificarRenta5taAnteriores", renta.IdtRenta5taAnteriores, renta.Fecha, renta.Ingresos, renta.Retenciones, renta.Trabajador.IdTrabajador);
        }

        public void EliminarRenta5taAnterior(cRenta5taAnteriores renta)
        {
            Conexion.GDatos.Ejecutar("spEliminarRenta5taAnteriores", renta.IdtRenta5taAnteriores);
        }

        public DataTable ListarRenta5taAnteriores(cTrabajador oTrabajador, int year)
        {
            return Conexion.GDatos.TraerDataTable("spListarRenta5taAnteriores", oTrabajador.IdTrabajador, year);
        }
    }
}
