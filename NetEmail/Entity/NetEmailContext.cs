using DirectEmailResults.Entity;
using NetEmail.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Data.SQLite.EF6;

namespace NetMail.Entity
{
    public class NetEmailContext : DbContext
    {
        public NetEmailContext() : base(
            new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NetEmail.db",
                    ForeignKeys = true
                }.ConnectionString
            }, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Setting>().ToTable("Setting");
            modelBuilder.Entity<Email>().ToTable("Email");
            modelBuilder.Entity<BlackListEmails>().ToTable("BlackListEmails");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Template>().ToTable("Template");
            modelBuilder.Entity<Campaign>().ToTable("Campaign");
            modelBuilder.Entity<CampaignCustomer>().ToTable("CampaignCustomer");
            modelBuilder.Entity<EmailQueueLog>().ToTable("EmailQueueLog");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<BlackListEmails> BlackListEmails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignCustomer> CampaignCustomers { get; set; }
        public DbSet<EmailQueueLog> EmailQueueLogs { get; set; }
    }

    public class SQLiteConfiguration : DbConfiguration
    {
        public SQLiteConfiguration()
        {
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }
}
