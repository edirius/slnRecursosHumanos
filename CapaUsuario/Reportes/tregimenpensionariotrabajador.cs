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
    
    public partial class tregimenpensionariotrabajador
    {
        public int idtregimenpensionariotrabajador { get; set; }
        public string fechainicio { get; set; }
        public string fechafin { get; set; }
        public string CUSPP { get; set; }
        public string tipocomision { get; set; }
        public Nullable<int> idtafp { get; set; }
        public Nullable<int> idtperiodotrabajador { get; set; }
    
        public virtual tafp tafp { get; set; }
        public virtual tperiodotrabajador tperiodotrabajador { get; set; }
    }
}