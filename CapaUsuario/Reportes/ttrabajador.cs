//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaUsuario.Reportes
{
    using System;
    using System.Collections.Generic;
    
    public partial class ttrabajador
    {
        public ttrabajador()
        {
            this.tdetalleplanilla = new HashSet<tdetalleplanilla>();
            this.tdetalletareo = new HashSet<tdetalletareo>();
            this.tperiodotrabajador = new HashSet<tperiodotrabajador>();
            this.tresidentemeta = new HashSet<tresidentemeta>();
        }
    
        public int id_trabajador { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string sexo { get; set; }
        public string estadoCivil { get; set; }
        public string direccion { get; set; }
        public string dni { get; set; }
        public string celular { get; set; }
        public string celularInstitucional { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public byte[] foto { get; set; }
        public string correoElectronico { get; set; }
        public Nullable<int> idtipovia { get; set; }
        public string nombreVia { get; set; }
        public string numeroVia { get; set; }
        public string departamento { get; set; }
        public Nullable<int> idtzona { get; set; }
        public string nombreZona { get; set; }
        public string referencia { get; set; }
        public Nullable<int> idtdistrito { get; set; }
        public Nullable<int> idtnacionalidad { get; set; }
    
        public virtual ICollection<tdetalleplanilla> tdetalleplanilla { get; set; }
        public virtual ICollection<tdetalletareo> tdetalletareo { get; set; }
        public virtual tdistrito tdistrito { get; set; }
        public virtual tnacionalidad tnacionalidad { get; set; }
        public virtual ICollection<tperiodotrabajador> tperiodotrabajador { get; set; }
        public virtual ICollection<tresidentemeta> tresidentemeta { get; set; }
        public virtual ttipovia ttipovia { get; set; }
    }
}
