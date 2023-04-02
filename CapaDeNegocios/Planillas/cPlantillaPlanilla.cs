using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;
using CapaDeNegocios.DatosLaborales;

namespace CapaDeNegocios.Planillas
{
    public class cPlantillaPlanilla
    {
        int sidtplantillaplanilla;
        string sdescripcion;
        int sorden;
        string stipo;
        int scodigo;
        bool stareo;
        bool smetaJornal;
        bool sdescuentoAfectaTotal;

        public int IdtPlantillaPlanilla
        {
            get { return sidtplantillaplanilla; }
            set { sidtplantillaplanilla = value; }
        }
        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }
        public int Orden
        {
            get { return sorden; }
            set { sorden = value; }
        }
        public string Tipo
        {
            get { return stipo; }
            set { stipo = value; }
        }
        public int Codigo
        {
            get { return scodigo; }
            set { scodigo = value; }
        }

        public bool Tareo
        {
            get
            {
                return stareo;
            }

            set
            {
                stareo = value;
            }
        }

        public bool MetaJornal
        {
            get
            {
                return smetaJornal;
            }

            set
            {
                smetaJornal = value;
            }
        }

        public bool DescuentoAfectaTotal
        {
            get
            {
                return sdescuentoAfectaTotal;
            }

            set
            {
                sdescuentoAfectaTotal = value;
            }
        }

        public DataTable ListarDescripcionPlantillaPlanilla()
        {
            return Conexion.GDatos.TraerDataTable("spListarDescripcionPlantillaPlanilla");
        }

        public DataTable ListarPlantillaPlanilla(string Descripcion)
        {
            return Conexion.GDatos.TraerDataTable("spListarPlantillaPlanilla", Descripcion);
        }

        public Boolean CrearPlantillaPlanilla(cPlantillaPlanilla miPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spCrearPlantillaPlanilla", miPlantillaPlanilla.Descripcion, miPlantillaPlanilla.Orden, miPlantillaPlanilla.Tipo, miPlantillaPlanilla.Codigo, miPlantillaPlanilla.Tareo, miPlantillaPlanilla.MetaJornal, miPlantillaPlanilla.DescuentoAfectaTotal);
            return true;
        }

        public Boolean ModificarPlantillaPlanilla(cPlantillaPlanilla miPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spModificarPlantillaPlanilla", miPlantillaPlanilla.IdtPlantillaPlanilla, miPlantillaPlanilla.Descripcion, miPlantillaPlanilla.Orden, miPlantillaPlanilla.Tipo, miPlantillaPlanilla.Codigo, miPlantillaPlanilla.Tareo, miPlantillaPlanilla.MetaJornal, DescuentoAfectaTotal);
            return true;
        }

        public Boolean EliminarPlantillaPlanilla(int IdtPlantillaPlanilla)
        {
            Conexion.GDatos.Ejecutar("spELiminarPlantillaPlanilla", IdtPlantillaPlanilla);
            return true;
        }

        public cPlantillaPlanilla TraerPlantillaxDescripcion(string pdescripcion)
        {
            DataTable auxiliar = Conexion.GDatos.TraerDataTable("spListarPlantillaPlanilla", pdescripcion);
            if (auxiliar.Rows.Count > 0)
            {
                cPlantillaPlanilla oPlantilla = new cPlantillaPlanilla();
                oPlantilla.IdtPlantillaPlanilla = Convert.ToInt32(auxiliar.Rows[0][0].ToString());
                oPlantilla.Descripcion = auxiliar.Rows[0][1].ToString();
                oPlantilla.Orden = Convert.ToInt32(auxiliar.Rows[0][2].ToString());
                oPlantilla.Tipo = auxiliar.Rows[0][3].ToString();
                oPlantilla.Codigo = Convert.ToInt32(auxiliar.Rows[0][4]);
                oPlantilla.Tareo = Convert.ToBoolean(auxiliar.Rows[0][5]);
                oPlantilla.MetaJornal = Convert.ToBoolean(auxiliar.Rows[0][6]);
                oPlantilla.DescuentoAfectaTotal = Convert.ToBoolean(auxiliar.Rows[0][7]);
                return oPlantilla;
            }
            else
            {
                return null;
            }
        }
    }
}
