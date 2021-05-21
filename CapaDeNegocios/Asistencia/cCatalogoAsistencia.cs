using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cCatalogoAsistencia
    {
        public cAsistenciaMes  LLenarAsistencia(cTrabajador miTrabajador, int mes, int año)
        {
            cAsistenciaMes oAsistenciaMes = new cAsistenciaMes();
            oAsistenciaMes.InicioMes = new DateTime(año, mes, 1);
            oAsistenciaMes.FinMes = new DateTime(año, mes, 1).AddMonths(1).AddDays(-1);
            DataTable ListaTrabajadores = new DataTable();

            foreach (DataRow item in ListaTrabajadores.Rows)
            {
                

            }
            //ejemplo
            cAsistenciaDia oAsistenciaDia = new cAsistenciaDia();
            oAsistenciaDia.Dia = new DateTime(2021, 5, 18);

            cPicado oPicado = new cPicado();
            oPicado.Picado = new DateTime(2021, 5, 18, 8, 1, 0);
            oPicado.Trabajador = miTrabajador;

            oAsistenciaDia.ListaPicados.Add(oPicado);

            oAsistenciaMes.ListaAsistenciaDia.Add(oAsistenciaDia);

            return oAsistenciaMes;
        }
    }
}
