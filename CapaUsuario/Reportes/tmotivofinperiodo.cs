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
    
    public partial class tmotivofinperiodo
    {
        public tmotivofinperiodo()
        {
            this.tperiodotrabajador = new HashSet<tperiodotrabajador>();
        }
    
        public int idtmotivofinperiodo { get; set; }
        public string codigosunat { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<tperiodotrabajador> tperiodotrabajador { get; set; }
    }
}
