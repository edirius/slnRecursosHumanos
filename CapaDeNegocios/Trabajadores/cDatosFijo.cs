using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios.Trabajadores
{
    public class cDatosFijo
    {
        private int codigo;
        private int codigoTrabajador;
        private int codigoMaestro;
        private string tipoMaestro;
        private double monto;

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

        public int CodigoTrabajador
        {
            get
            {
                return codigoTrabajador;
            }

            set
            {
                codigoTrabajador = value;
            }
        }

        public int CodigoMaestro
        {
            get
            {
                return codigoMaestro;
            }

            set
            {
                codigoMaestro = value;
            }
        }

        public string TipoMaestro
        {
            get
            {
                return tipoMaestro;
            }

            set
            {
                tipoMaestro = value;
            }
        }

        public double Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public cDatosFijo(int _CodigoTrabajador)
        {
            CodigoTrabajador = _CodigoTrabajador;
        }

        public DataTable ListaDatosFijos()
        {
            try
            {
                return Conexion.GDatos.TraerDataTable("spListarDatosFijosxTrabajador", CodigoTrabajador);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al obtener la lista Datos Fijos: cDatosFijo.cs: " + ex.Message);
            }
        }

        public Boolean AgregarDatosFijos(cDatosFijo nuevoDatoFijo)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spCrearDatosFijosxTrabajador", nuevoDatoFijo.CodigoTrabajador, nuevoDatoFijo.CodigoMaestro, nuevoDatoFijo.TipoMaestro, nuevoDatoFijo.Monto);
                return true;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al agregar datos fijos: cDatosFijo.cs " + ex.Message);
            }
        }

        public Boolean EliminarDatosFijo(int codigoDatoFijo)
        {
            try
            {
                Conexion.GDatos.Ejecutar("spEliminarDatosFijosxTrabajador", codigoDatoFijo);
                return true;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al eliminar datos fijos: cDatosFijo.cs: " + ex.Message);
            }
        }

        public DataTable ListarConceptos (string tipoConcepto)
        {
            try
            {
                switch (tipoConcepto)
                {
                    case "INGRESOS":
                        return Conexion.GDatos.TraerDataTable("spListarConceptos", "ingreso");
                    case "DESCUENTOS":
                        return Conexion.GDatos.TraerDataTable("spListarConceptos", "descuento");

                    case "Aportacion Empleador":
                        return Conexion.GDatos.TraerDataTable("spListarConceptos", "aportacionempleador");

                    case "Aportacion Trabajador":
                        return Conexion.GDatos.TraerDataTable("spListarConceptos", "aportaciontrabajador");

                    default:
                        return null;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al listar tipo conceptos: cDatosFijos.cs: " + ex.Message);
            }
        }


        public Boolean TieneDatoFijo (int idtTrabajador, int codigoConcepto, string tipoConcepto)
        {
            try
            {
                if (Conexion.GDatos.TraerDataTable("spTraerDatoFijo", idtTrabajador, codigoConcepto, tipoConcepto).Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
           
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al obtener el dato dijo para el trabajador: " + idtTrabajador.ToString()
                    + " y el concepto :" + codigoConcepto + " y tipo Concepto: " + tipoConcepto + ": " + ex.Message);
            }
        }


        public decimal TraerDatoFijo(int idtTrabajador, int codigoConcepto, string tipoConcepto)
        {
            try
            {
                return Convert.ToDecimal(Conexion.GDatos.TraerDataTable("spTraerDatoFijo", idtTrabajador, codigoConcepto, tipoConcepto).Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al obtener el dato dijo para el trabajador: " + idtTrabajador.ToString()
                    + " y el concepto :" + codigoConcepto + " y tipo Concepto: " + tipoConcepto + ": " + ex.Message);
            }
        }
    }
}
