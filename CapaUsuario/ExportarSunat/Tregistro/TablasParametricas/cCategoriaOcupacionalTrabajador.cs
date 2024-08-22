using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro.TablasParametricas
{
    /// <summary>
    /// Tabla Parametrica Nro. 24
    /// </summary>
    public class cCategoriaOcupacionalTrabajador
    {
        private string codigo;
        private string descripcion;
        private string sectorPrivado;
        private string sectorPublico;
        private string otrasEntidades;

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

        public string SectorPrivado
        {
            get
            {
                return sectorPrivado;
            }

            set
            {
                sectorPrivado = value;
            }
        }

        public string SectorPublico
        {
            get
            {
                return sectorPublico;
            }

            set
            {
                sectorPublico = value;
            }
        }

        public string OtrasEntidades
        {
            get
            {
                return otrasEntidades;
            }

            set
            {
                otrasEntidades = value;
            }
        }
    }
}
