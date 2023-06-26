using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.DatosLaborales;

namespace CapaDeNegocios.Planillas
{
    public class cMaestroIngresos
    {
        int id;
        string codigo;
        string descripcion;
        bool essalud;
        bool essaludSCRT;
        bool sistemaNacionalPensiones;
        bool sistemaPrivadoPensiones;
        bool rentaQuintaCategoria;
        bool essaludPensionista;
        bool contribucionSolidaria;
        string formula;
        string abreviacion;
        bool informativa;
        string tipo;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

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

        public bool Essalud
        {
            get
            {
                return essalud;
            }

            set
            {
                essalud = value;
            }
        }

        public bool EssaludSCRT
        {
            get
            {
                return essaludSCRT;
            }

            set
            {
                essaludSCRT = value;
            }
        }

        public bool SistemaNacionalPensiones
        {
            get
            {
                return sistemaNacionalPensiones;
            }

            set
            {
                sistemaNacionalPensiones = value;
            }
        }

        public bool SistemaPrivadoPensiones
        {
            get
            {
                return sistemaPrivadoPensiones;
            }

            set
            {
                sistemaPrivadoPensiones = value;
            }
        }

        public bool RentaQuintaCategoria
        {
            get
            {
                return rentaQuintaCategoria;
            }

            set
            {
                rentaQuintaCategoria = value;
            }
        }

        public bool EssaludPensionista
        {
            get
            {
                return essaludPensionista;
            }

            set
            {
                essaludPensionista = value;
            }
        }

        public bool ContribucionSolidaria
        {
            get
            {
                return contribucionSolidaria;
            }

            set
            {
                contribucionSolidaria = value;
            }
        }

        public string Formula
        {
            get
            {
                return formula;
            }

            set
            {
                formula = value;
            }
        }

        public string Abreviacion
        {
            get
            {
                return abreviacion;
            }

            set
            {
                abreviacion = value;
            }
        }

        public bool Informativa
        {
            get
            {
                return informativa;
            }

            set
            {
                informativa = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }
    }
}
