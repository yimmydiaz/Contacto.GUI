//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contacto.ModelBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_medioContacto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_medioContacto()
        {
            this.tb_Celular = new HashSet<tb_Celular>();
        }
    
        public int idmedioContacto { get; set; }
        public string correo { get; set; }
        public string facebook { get; set; }
        public string instagram { get; set; }
        public string cedulaUsuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Celular> tb_Celular { get; set; }
        public virtual tb_usuario tb_usuario { get; set; }
    }
}
