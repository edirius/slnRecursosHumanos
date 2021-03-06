﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;


namespace CapaDeNegociosTramite.Tramite
{
    public class cTramite
    {
        public int CodigoTramite{ get; set; }

        public int CodigoLocalSede { get; set; }

        public DateTime FechaHora { get; set; }

        public int CodigoOperacion { get; set; }

        public int CodigoOficina { get; set; }

        public int CodigoOficinaTrabajador { get; set; }
        
        public int UnidadDestino { get; set; }

        public int UsuarioDestino { get; set; }

        public string Proveido { get; set; }

        public int CodigoDocumento { get; set; }

        public DataTable AgregarTramite()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteInsertarTramite", CodigoLocalSede, FechaHora, CodigoOperacion, CodigoOficina, CodigoOficinaTrabajador, UnidadDestino, UsuarioDestino, Proveido, CodigoDocumento);
        }
        public DataTable ModificarTramite()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteModificarTramite", CodigoTramite, CodigoLocalSede, FechaHora, CodigoOperacion, CodigoOficina, CodigoOficinaTrabajador, UnidadDestino, UsuarioDestino, Proveido, CodigoDocumento);
        }
        public DataTable EliminarTramite()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteEliminarTramite", CodigoTramite);
        }
        public DataTable ListarTramite()
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarTramite");
        }
        public DataTable ListarTrabajadoresPorOficina(string  Oficina)
        {
            return Conexion.GDatos.TraerDataTable("spTramiteListarTrabajadorPorOficina", Oficina);
        }

    }
}
