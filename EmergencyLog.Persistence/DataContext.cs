using EmergencyLog.Domain.Entities;
using EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities;
using EmergencyLog.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmergencyLog.Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // this is required to stop an error with IdentityContext needing this when overriding OnModelCreating

            //modelBuilder.Entity<EmergencyContact>()
            //    .HasOne(c => c.Client)
            //    .WithOne(b => b.EmergencyContact)
            //    .HasForeignKey<Client>(b => b.EmergencyContactId);

            modelBuilder.Entity<Client>()
                .HasMany(p => p.Attendances)
                .WithOne(o => o.Client);
            
            modelBuilder.Entity<Organisation>()
                .HasMany(p => p.Properties)
                .WithOne(o => o.Organisation);

            modelBuilder.Entity<Organisation>()
                .HasMany(p => p.Clients)
                .WithOne(o => o.Organisation)
                .IsRequired();

            modelBuilder.Entity<Property>()
                .HasMany(s => s.FireExtinguishers)
                .WithOne(p => p.Property);

            modelBuilder.Entity<Property>()
                .HasMany(s => s.FireHoses)
                .WithOne(p => p.Property);

            modelBuilder.Entity<Property>()
                .HasMany(s => s.SmokeAlarms)
                .WithOne(p => p.Property);

            modelBuilder.Entity<ServiceOrganisation>()
                .HasMany(s => s.SmokeAlarms)
                .WithOne(p => p.ServiceOrganisation);

            modelBuilder.Entity<ServiceOrganisation>()
                .HasMany(s => s.FireExtinguishers)
                .WithOne(p => p.ServiceOrganisation);

            modelBuilder.Entity<ServiceOrganisation>()
                .HasMany(s => s.FireHoses)
                .WithOne(p => p.ServiceOrganisation);
        }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<FireExtinguisher> FireExtinguishers { get; set; }
        public DbSet<FireHose> FireHoses { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<SmokeAlarm> SmokeAlarms { get; set; }
        public DbSet<ServiceOrganisation> ServiceOrganisations { get; set; }
    }
}
