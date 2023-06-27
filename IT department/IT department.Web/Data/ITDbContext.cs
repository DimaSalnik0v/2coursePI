using Microsoft.EntityFrameworkCore;
using IT_department.Web.Models.Domain;
namespace IT_department.Web.Data
{
    public class ITDbContext: DbContext
    {
        public ITDbContext(DbContextOptions <ITDbContext> options) : base(options) { }
        public DbSet<Service_companies> Service_companies { get; set; }
        public DbSet<Printers> Printers { get; set; }
        public DbSet<Technical_conditions> Technical_conditions { get; set; }
        public DbSet<JobTitles> JobTitles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Equipments> Equipments { get; set; }
        public DbSet<Cartridge_states> Cartridge_states { get; set; }
        public DbSet<Cartridges> Cartridges { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Printers>()
                 .HasOne(e => e.Technical_condition)
                 .WithMany()
                 .HasForeignKey(e => e.state)
                 .HasPrincipalKey(j => j.Id);
            modelBuilder.Entity<Printers>()
                .HasOne(e => e.Service_company)
                .WithMany()
                .HasForeignKey(e => e.id_service_company)
                .HasPrincipalKey(j => j.Id_company);

            modelBuilder.Entity<Users>()
                 .HasOne(e => e.JobTitle)
                 .WithMany()
                 .HasForeignKey(e => e.code_job_title)
                 .HasPrincipalKey(j => j.Id);

            modelBuilder.Entity<Equipments>()
                 .HasOne(e => e.Technical_condition)
                 .WithMany()
                 .HasForeignKey(e => e.state)
                 .HasPrincipalKey(j => j.Id);
            modelBuilder.Entity<Equipments>()
                .HasOne(e => e.Service_company)
                .WithMany()
                .HasForeignKey(e => e.id_service_company)
                .HasPrincipalKey(j => j.Id_company);

            modelBuilder.Entity<Cartridges>()
                .HasOne(e => e.Printer)
                .WithMany()
                .HasForeignKey(e => e.printer_id)
                .HasPrincipalKey(j => j.Id);
            modelBuilder.Entity<Cartridges>()
                .HasOne(e => e.Cartridge_state)
                .WithMany()
                .HasForeignKey(e => e.state)
                .HasPrincipalKey(j => j.Id);
        }
    }
}