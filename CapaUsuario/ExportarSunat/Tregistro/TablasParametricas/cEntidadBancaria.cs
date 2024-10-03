using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro.TablasParametricas
{
    public class cEntidadBancaria
    {
        private string codigo;
        private string entidadSistemaFinanciero;

        public string Codigo
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

        public string EntidadSistemaFinanciero
        {
            get
            {
                return entidadSistemaFinanciero;
            }

            set
            {
                entidadSistemaFinanciero = value;
            }
        }
    }
}
