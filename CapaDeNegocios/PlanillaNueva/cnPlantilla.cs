using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.PlanillaNueva
{
    
    public class cnPlantilla
    {
        public string Descripcion { get; set; }
        public Boolean Tareo { get; set; }
        public Boolean MetaJornal { get; set; }
        public Boolean DescuentoAfectaTotal { get; set; }

        public List<cnDetallePlantilla> DetallesPantilla { get; set; }

        public cnPlantilla()
        {
            DetallesPantilla = new List<cnDetallePlantilla>();
        }
    }
}
