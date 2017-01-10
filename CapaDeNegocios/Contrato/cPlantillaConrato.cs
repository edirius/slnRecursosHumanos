using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Contrato
{
    public class cPlantillaContrato
    {
        int sidtplantillacontrato;
        string sdescripcion;
        string sdireccion;

        public int IdTPlantillaContrato
        {
            get { return sidtplantillacontrato; }
            set { sidtplantillacontrato = value; }
        }
        public string Descripcion
        {
            get { return sdescripcion; }
            set { sdescripcion = value; }
        }
        public string Direccion
        {
            get { return sdireccion; }
            set { sdireccion = value; }
        }

        public DataTable ListarPlantillaContrato()
        {
            return Conexion.GDatos.TraerDataTable("spListarPlantillaContrato");
        }

        public Boolean CrearPlantillaContrato(cPlantillaContrato miPlantillaContrato)
        {
            Conexion.GDatos.Ejecutar("spCrearPlantillaContrato", miPlantillaContrato.Descripcion, miPlantillaContrato.Direccion);
            return true;
        }

        public Boolean ModificarPlantillaContrato(cPlantillaContrato miPlantillaContrato)
        {
            Conexion.GDatos.Ejecutar("spModificarPlantillaContrato", miPlantillaContrato.IdTPlantillaContrato, miPlantillaContrato.Descripcion, miPlantillaContrato.Direccion);
            return true;
        }

        public Boolean EliminarPlantillaContrato(int IdTPlantillaContrato)
        {
            Conexion.GDatos.Ejecutar("spELiminarPlantillaContrato", IdTPlantillaContrato);
            return true;
        }
    }
}
