﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EjemploCRUDEntityframework.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TestEntities : DbContext
    {
        public TestEntities()
            : base("name=TestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TablaPersonas> TablaPersonas { get; set; }
        public virtual DbSet<TblArchivos> TblArchivos { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
    
        public virtual int GuardarArchivo(string nombre, byte[] archivo, string size)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var archivoParameter = archivo != null ?
                new ObjectParameter("Archivo", archivo) :
                new ObjectParameter("Archivo", typeof(byte[]));
    
            var sizeParameter = size != null ?
                new ObjectParameter("Size", size) :
                new ObjectParameter("Size", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GuardarArchivo", nombreParameter, archivoParameter, sizeParameter);
        }
    
        public virtual int sp_getPaises(Nullable<int> idpais)
        {
            var idpaisParameter = idpais.HasValue ?
                new ObjectParameter("idpais", idpais) :
                new ObjectParameter("idpais", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_getPaises", idpaisParameter);
        }
    
        public virtual int Sp_GuardarPais(string nombre, string siglas, Nullable<int> entero)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var siglasParameter = siglas != null ?
                new ObjectParameter("Siglas", siglas) :
                new ObjectParameter("Siglas", typeof(string));
    
            var enteroParameter = entero.HasValue ?
                new ObjectParameter("Entero", entero) :
                new ObjectParameter("Entero", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_GuardarPais", nombreParameter, siglasParameter, enteroParameter);
        }
    }
}
