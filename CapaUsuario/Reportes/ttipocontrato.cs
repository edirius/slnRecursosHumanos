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
    
    public partial class ttipocontrato
    {
        public ttipocontrato()
        {
            this.tregimentrabajador = new HashSet<tregimentrabajador>();
        }
    
        public int idttipocontrato { get; set; }
        public string descripcion { get; set; }
        public string codigosunat { get; set; }
    
        public virtual ICollection<tregimentrabajador> tregimentrabajador { get; set; }
    }
}