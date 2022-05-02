﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergencyLog.Domain;
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

        public DbSet<Address> Addresses { get; set; }
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
