﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ContactosBDEntities : DbContext
    {
        public ContactosBDEntities()
            : base("name=ContactosBDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_Celular> tb_Celular { get; set; }
        public virtual DbSet<tb_contacto> tb_contacto { get; set; }
        public virtual DbSet<tb_medioContacto> tb_medioContacto { get; set; }
        public virtual DbSet<tb_usuario> tb_usuario { get; set; }
    }
}
