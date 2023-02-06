using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.Obras;

namespace CapaDeNegocios.Obras
{
    public class cMetaJornal
    {
        int sidtmetajornal;
        string scategoria;
        double sjornal;
        double smensual;
        Boolean sopcion;

        cMeta _Meta;

        public cMetaJornal()
        {
            _Meta = new cMeta();
        }

        public int IdtMetaJornal
        {
            get { return sidtmetajornal; }
            set { sidtmetajornal = value; }
        }
        public string Categoria
        {
            get { return scategoria; }
            set { scategoria = value; }
        }
        public double Jornal
        {
            get { return sjornal; }
            set { sjornal = value; }
        }

        public cMeta Meta
        {
            get
            {
                return _Meta;
            }

            set
            {
                _Meta = value;
            }
        }

        public double Mensual
        {
            get
            {
                return smensual;
            }

            set
            {
                smensual = value;
            }
        }


        //false = jornal true = mensual
        public bool Opcion
        {
            get
            {
                return sopcion;
            }

            set
            {
                sopcion = value;
            }
        }

        public DataTable ListarMetaJornal(int Codigo)
        {
            return Conexion.GDatos.TraerDataTable("spListarMetaJornal", Codigo);
        }

        public Boolean CrearMetaJornal(cMetaJornal miMetaJornal, cMeta miMeta)
        {
            Conexion.GDatos.Ejecutar("spCrearMetaJornal", miMetaJornal.Categoria, miMetaJornal.Jornal, miMeta.Codigo, miMetaJornal.Mensual, miMetaJornal.Opcion);
            return true;
        }

        public Boolean ModificarMetaJornal(cMetaJornal miMetaJornal, cMeta miMeta)
        {
            Conexion.GDatos.Ejecutar("spModificarMetaJornal", miMetaJornal.IdtMetaJornal, miMetaJornal.Categoria, miMetaJornal.Jornal, miMeta.Codigo, miMetaJornal.Mensual, miMetaJornal.Opcion);
            return true;
        }

        public Boolean EliminarMetaJornal(int IdtMetaJornal)
        {
            Conexion.GDatos.Ejecutar("spELiminarMetaJornal", IdtMetaJornal);
            return true;
        }

        public cMetaJornal TraerMetaJornal(int idMetaJornal)
        {
            DataTable oTabla = Conexion.GDatos.TraerDataTable("spTraerMetaJornal", idMetaJornal);
            if (oTabla.Rows.Count > 0)
            {
                cMetaJornal miMeta = new cMetaJornal();
                miMeta.IdtMetaJornal = Convert.ToInt16(oTabla.Rows[0][0].ToString());
                miMeta.Categoria = oTabla.Rows[0][1].ToString();
                miMeta.Jornal = Convert.ToDouble(oTabla.Rows[0][2].ToString());
                if (oTabla.Rows[0][4].ToString() == "")
                {
                    miMeta.Mensual = 0;
                }
                else
                {
                    miMeta.Mensual = Convert.ToDouble(oTabla.Rows[0][4].ToString());
                }
                if (oTabla.Rows[0][5].ToString() == "")
                {
                    miMeta.Opcion = false;
                }
                else
                {
                    miMeta.Opcion = Convert.ToBoolean(oTabla.Rows[0][4]);
                }
                return miMeta;
            }
            else
            {
                return null;
            }
        }
    }
}
