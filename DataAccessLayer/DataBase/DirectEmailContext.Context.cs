﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DirectEmailerEntities : DbContext
    {
        public DirectEmailerEntities()
            : base("name=DirectEmailerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ApplicationSetting> ApplicationSettings { get; set; }
        public DbSet<CampaignCustomer> CampaignCustomers { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<BlockListEmail> BlockListEmails { get; set; }
        public DbSet<OurEmailList> OurEmailLists { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<EmailQueueLog> EmailQueueLogs { get; set; }
        public DbSet<OurEmailListMaxPerDay> OurEmailListMaxPerDays { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
