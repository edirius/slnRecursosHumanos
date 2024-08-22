using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro.TablasParametricas
{
    /// <summary>
    /// Tabla Parametrica Nº 14
    /// </summary>
    public class cEntidadesPrestadorasSalud
    {
        private string numero;
        private string ruc;
        private string descripcion;

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public string Ruc
        {
            get
            {
                return ruc;
            }

            set
            {
                ruc = value;
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
