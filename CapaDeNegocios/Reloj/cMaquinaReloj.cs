﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reloj
{
    public class cMaquinaReloj
    {
        public int IdtReloj { get; set; }
        public string Descripcion { get; set; }
        public string Ip { get; set; }
        public string Puerto { get; set; }
        public Boolean Activo { get; set; }
        public Boolean Seleccion { get; set; }

        public cMaquinaReloj()
        {
            Puerto = "4370";
        }
    }
}
