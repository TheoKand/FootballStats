﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoalsWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mochahost : DbContext
    {
        public mochahost()
            : base("name=mochahost")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<fmatch> fmatches { get; set; }
        public DbSet<goal> goals { get; set; }
        public DbSet<matchevent> matchevents { get; set; }
        public DbSet<pendingmatch> pendingmatches { get; set; }
        public DbSet<region> regions { get; set; }
        public DbSet<season> seasons { get; set; }
        public DbSet<seasontable> seasontables { get; set; }
        public DbSet<team> teams { get; set; }
        public DbSet<tournament> tournaments { get; set; }
    }
}
