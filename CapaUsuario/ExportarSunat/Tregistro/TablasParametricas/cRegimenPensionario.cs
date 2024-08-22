using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro.TablasParametricas
{
    /// <summary>
    /// Tabla Parametrica Nº 11
    /// </summary>
    public class cRegimenPensionario
    {
        private string numero;
        private string descripcion;
        private string descripcionAbreviada;
        private string sectorPrivado;
        private string sectorPublico;
        private string otrasEntidades;

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

        public string DescripcionAbreviada
        {
            get
            {
                return descripcionAbreviada;
            }

            set
            {
                descripcionAbreviada = value;
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
