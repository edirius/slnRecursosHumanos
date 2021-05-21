using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cDiaFestivo
    {
        int _Codigo;
        string _Nombre;
        DateTime _DiaFestivo;

        public cDiaFestivo()
        {
            _DiaFestivo = new DateTime(2021, 1, 1);
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public DateTime DiaFestivo
        {
            get
            {
                return _DiaFestivo;
            }

            set
            {
                _DiaFestivo = value;
            }
        }

        public int Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
            }
        }

        public void AgregarDiaFestivo(cDiaFestivo miDiaFestivo)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al crear Dia Festivo: " + ex.Message);
            }
        }

        public void ModificarDiaFestivo(cDiaFestivo miDiaFestivo)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al modificar Dia Festivo: " + ex.Message);
            }
        }

        public void EliminarDiaFestivo(cDiaFestivo miDiaFestivo)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al eliminar el dia festivo.");
            }
        }

        public List<cDiaFestivo> ListaDiasFestivos(int anio)
        {
            try
            {
                List<cDiaFestivo> nuevaLista = new List<cDiaFestivo>();

                //ejemplo
                cDiaFestivo nuevo = new cDiaFestivo();
                nuevo.Nombre = "Cumpleaños";
                nuevo.DiaFestivo = new DateTime(2021, 5, 18);

                nuevaLista.Add(nuevo);
                return nuevaLista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al traer la lista de dias festivos: " + ex.Message);
            }
            

            
        }
    }
}
