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
    
    public partial class tmetajornal
    {
        public int idtmetajornal { get; set; }
        public string categoria { get; set; }
        public Nullable<int> jornal { get; set; }
        public Nullable<int> idtmeta { get; set; }
    
        public virtual tmeta tmeta { get; set; }
    }
}