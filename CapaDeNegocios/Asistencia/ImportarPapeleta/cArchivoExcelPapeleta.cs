using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia.ImportarPapeleta
{
    public class cArchivoExcelPapeleta
    {
        
        string columnaNombres;
        string columnaDNI;
        int filaDescansoMedico;
        int filaAtencionMedica;
        int filaPermisoSinContraprestacion;
        int filaComisionServicio;
        int filaVacaciones;
        int filaCapacitacionOficializada;
        int filaFechaInicio;
        int filaFechaFin;
        int filaHoraInicio;
        int filaHoraFin;
        int filaInicioJustificacion;
        int filaFinJustificacion;
        string nombreHoja;

        public string ColumnaNombres
        {
            get
            {
                return columnaNombres;
            }

            set
            {
                columnaNombres = value;
            }
        }

        public string ColumnaDNI
        {
            get
            {
                return columnaDNI;
            }

            set
            {
                columnaDNI = value;
            }
        }

        public int FilaDescansoMedico
        {
            get
            {
                return filaDescansoMedico;
            }

            set
            {
                filaDescansoMedico = value;
            }
        }

        public int FilaAtencionMedica
        {
            get
            {
                return filaAtencionMedica;
            }

            set
            {
                filaAtencionMedica = value;
            }
        }

        public int FilaPermisoSinContraprestacion
        {
            get
            {
                return filaPermisoSinContraprestacion;
            }

            set
            {
                filaPermisoSinContraprestacion = value;
            }
        }

        public int FilaComisionServicio
        {
            get
            {
                return filaComisionServicio;
            }

            set
            {
                filaComisionServicio = value;
            }
        }

        public int FilaVacaciones
        {
            get
            {
                return filaVacaciones;
            }

            set
            {
                filaVacaciones = value;
            }
        }

        public int FilaCapacitacionOficializada
        {
            get
            {
                return filaCapacitacionOficializada;
            }

            set
            {
                filaCapacitacionOficializada = value;
            }
        }

        public int FilaFechaInicio
        {
            get
            {
                return filaFechaInicio;
            }

            set
            {
                filaFechaInicio = value;
            }
        }

        public int FilaFechaFin
        {
            get
            {
                return filaFechaFin;
            }

            set
            {
                filaFechaFin = value;
            }
        }

        public int FilaHoraInicio
        {
            get
            {
                return filaHoraInicio;
            }

            set
            {
                filaHoraInicio = value;
            }
        }

        public int FilaHoraFin
        {
            get
            {
                return filaHoraFin;
            }

            set
            {
                filaHoraFin = value;
            }
        }

        public int FilaInicioJustificacion
        {
            get
            {
                return filaInicioJustificacion;
            }

            set
            {
                filaInicioJustificacion = value;
            }
        }

        public int FilaFinJustificacion
        {
            get
            {
                return filaFinJustificacion;
            }

            set
            {
                filaFinJustificacion = value;
            }
        }

        public string NombreHoja
        {
            get
            {
                return nombreHoja;
            }

            set
            {
                nombreHoja = value;
            }
        }
    }
}
