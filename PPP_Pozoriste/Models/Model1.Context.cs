﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPP_Pozoriste.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PozoristeEntities1 : DbContext
    {
        public PozoristeEntities1()
            : base("name=PozoristeEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Glumac> Glumac { get; set; }
        public virtual DbSet<Glumi> Glumi { get; set; }
        public virtual DbSet<Mesec> Mesec { get; set; }
        public virtual DbSet<Predstava> Predstava { get; set; }
        public virtual DbSet<Repertoar> Repertoar { get; set; }
        public virtual DbSet<StavkaRepertoara> StavkaRepertoara { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}