﻿// <auto-generated />
using System;
using EmergencyLog.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EntryComplete")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("OnSite")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeIn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TimeOut")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmergencyContactId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageLarge")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageSmall")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Suburb")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmergencyContactId")
                        .IsUnique();

                    b.HasIndex("OrganisationId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.EmergencyContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mobile")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .HasColumnType("TEXT");

                    b.Property<int>("RelationshipType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Suburb")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EmergencyContacts");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.FireExtinguisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EquipmentType")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastServiced")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NextService")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ServiceOrganisationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("ServiceOrganisationId");

                    b.ToTable("FireExtinguishers");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.FireHose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EquipmentType")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastServiced")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NextService")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ServiceOrganisationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("ServiceOrganisationId");

                    b.ToTable("FireHoses");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.ServiceOrganisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Logo")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceOrganisationName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Suburb")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ServiceOrganisations");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.SmokeAlarm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EquipmentType")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastServiced")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NextService")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ServiceOrganisationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("ServiceOrganisationId");

                    b.ToTable("SmokeAlarms");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrganisationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Logo")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrganisationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Postcode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Suburb")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Attendance", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Client", "Client")
                        .WithMany("Attendances")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Client", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.EmergencyContact", "EmergencyContact")
                        .WithOne("Client")
                        .HasForeignKey("EmergencyLog.Domain.Entities.Client", "EmergencyContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.Organisation", "Organisation")
                        .WithMany("Clients")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmergencyContact");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.FireExtinguisher", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Property", "Property")
                        .WithMany("FireExtinguishers")
                        .HasForeignKey("PropertyId");

                    b.HasOne("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.ServiceOrganisation", "ServiceOrganisation")
                        .WithMany("FireExtinguishers")
                        .HasForeignKey("ServiceOrganisationId");

                    b.Navigation("Property");

                    b.Navigation("ServiceOrganisation");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.FireHose", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Property", "Property")
                        .WithMany("FireHoses")
                        .HasForeignKey("PropertyId");

                    b.HasOne("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.ServiceOrganisation", "ServiceOrganisation")
                        .WithMany("FireHoses")
                        .HasForeignKey("ServiceOrganisationId");

                    b.Navigation("Property");

                    b.Navigation("ServiceOrganisation");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.SmokeAlarm", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Property", "Property")
                        .WithMany("SmokeAlarms")
                        .HasForeignKey("PropertyId");

                    b.HasOne("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.ServiceOrganisation", "ServiceOrganisation")
                        .WithMany("SmokeAlarms")
                        .HasForeignKey("ServiceOrganisationId");

                    b.Navigation("Property");

                    b.Navigation("ServiceOrganisation");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Property", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Organisation", "Organisation")
                        .WithMany("Properties")
                        .HasForeignKey("OrganisationId");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Client", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.EmergencyContact", b =>
                {
                    b.Navigation("Client");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.ServiceOrganisation", b =>
                {
                    b.Navigation("FireExtinguishers");

                    b.Navigation("FireHoses");

                    b.Navigation("SmokeAlarms");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Organisation", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Property", b =>
                {
                    b.Navigation("FireExtinguishers");

                    b.Navigation("FireHoses");

                    b.Navigation("SmokeAlarms");
                });
#pragma warning restore 612, 618
        }
    }
}
