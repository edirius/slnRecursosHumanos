using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro.TablasParametricas
{
    public class cCargo
    {
        private int idtCargo;
        private string descripcion;

        public int IdtCargo
        {
            get
            {
                return idtCargo;
            }

            set
            {
                idtCargo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
    }
}
