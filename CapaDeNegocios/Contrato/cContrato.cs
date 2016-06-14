using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;
namespace CapaDeNegocios.Contrato
{
    public class cContrato
    {
        int codigo;

        DateTime fechaInicio;

        DateTime fechaFinal;

        cTipoTrabajador miTipoTrabajador;

        cTrabajador miTrabajador;

        int numeroContrato;

        cMeta miMeta;

        cTipoContrato tipoContrato;

       

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

        public DateTime FechaFinal
        {
            get
            {
                return fechaFinal;
            }

            set
            {
                fechaFinal = value;
            }
        }

        public cTipoTrabajador MiTipoTrabajador
        {
            get
            {
                return miTipoTrabajador;
            }

            set
            {
                miTipoTrabajador = value;
            }
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public cTrabajador MiTrabajador
        {
            get
            {
                return miTrabajador;
            }

            set
            {
                miTrabajador = value;
            }
        }

        public int NumeroContrato
        {
            get
            {
                return numeroContrato;
            }

            set
            {
                numeroContrato = value;
            }
        }

        public cMeta MiMeta
        {
            get
            {
                return miMeta;
            }

            set
            {
                miMeta = value;
            }
        }

        public cTipoContrato TipoContrato
        {
            get
            {
                return tipoContrato;
            }

            set
            {
                tipoContrato = value;
            }
        }

        public Boolean AgregarContrato(cContrato miContrato)
        {
            Conexion.GDatos.Ejecutar("spCrearContrato", miContrato.miTrabajador.IdTrabajador, miTipoTrabajador.Codigo, fechaInicio, fechaFinal, miContrato.numeroContrato, miContrato.miMeta.Codigo);
            return true;
        }

        public Boolean ModificarContrato(cContrato miContrato)
        {
            Conexion.GDatos.Ejecutar("spModificarContrato", miContrato.codigo, miContrato.miTrabajador.IdTrabajador, miTipoTrabajador.Codigo, fechaInicio, fechaFinal, miContrato.numeroContrato, miContrato.miMeta.Codigo);
            return true;
        }

        public Boolean EliminarContrato(cContrato miContrato)
        {
            Conexion.GDatos.Ejecutar("spEliminarContrato", miContrato.codigo);
            return true;
        }

        public DataTable ListaContrato (cTrabajador miTrabajador)
        {
            return Conexion.GDatos.TraerDataTable("spListarContratos", miTrabajador.IdTrabajador);
            
        }

        public int ObtenerUltimoNumeroDeContrato(cTipoContrato miTipoContrato)
        {
            return Convert.ToInt16(Conexion.GDatos.TraerValorEscalar("spTraerUltimoContrato", miTipoContrato.Codigo));
        }
    }
}
