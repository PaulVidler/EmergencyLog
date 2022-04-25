﻿// <auto-generated />
using System;
using EmergencyLog.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220425065014_redefineRelationships12")]
    partial class redefineRelationships12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Suburb")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EntryComplete")
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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageLarge")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageSmall")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mobile")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrganisationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.EmergencyContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mobile")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<int>("RelationshipType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("EmergencyContacts");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.FireExtinguisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EquipmentType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastServiced")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NextService")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ServicedOrganisationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("ServicedOrganisationId");

                    b.ToTable("FireExtinguishers");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.FireHose", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EquipmentType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastServiced")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NextService")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ServicedOrganisationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("ServicedOrganisationId");

                    b.ToTable("FireHoses");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.ServiceOrganisation", b =>
                {
                    b.Property<Guid>("ServiceOrganisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logo")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PrimaryContactId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceOrganisationName")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("ServiceOrganisationId");

                    b.HasIndex("AddressId");

                    b.HasIndex("PrimaryContactId");

                    b.ToTable("ServiceOrganisations");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.SmokeAlarm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EquipmentType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastServiced")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NextService")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ServicedOrganisationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("ServicedOrganisationId");

                    b.ToTable("SmokeAlarms");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Organisation", b =>
                {
                    b.Property<Guid>("OrganisationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logo")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OrganisationId");

                    b.HasIndex("AddressId");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrganisationId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PrimaryContactId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("PrimaryContactId");

                    b.ToTable("Properties");
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
                    b.HasOne("EmergencyLog.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.Organisation", null)
                        .WithMany("Clients")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.EmergencyContact", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.Client", "Client")
                        .WithOne("EmergencyContact")
                        .HasForeignKey("EmergencyLog.Domain.Entities.EmergencyContact", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.FireExtinguisher", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Property", "Property")
                        .WithMany("FireExtinguishers")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.ServiceOrganisation", "ServicedOrganisation")
                        .WithMany()
                        .HasForeignKey("ServicedOrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("ServicedOrganisation");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.FireHose", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Property", "Property")
                        .WithMany("FireHoses")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.ServiceOrganisation", "ServicedOrganisation")
                        .WithMany()
                        .HasForeignKey("ServicedOrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("ServicedOrganisation");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.ServiceOrganisation", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.Client", "PrimaryContact")
                        .WithMany()
                        .HasForeignKey("PrimaryContactId");

                    b.Navigation("Address");

                    b.Navigation("PrimaryContact");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.SmokeAlarm", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Property", "Property")
                        .WithMany("SmokeAlarms")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.FireSafetyEquipmentEntities.ServiceOrganisation", "ServicedOrganisation")
                        .WithMany()
                        .HasForeignKey("ServicedOrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("ServicedOrganisation");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Organisation", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Property", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.Organisation", "Organisation")
                        .WithMany("Properties")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.Client", "PrimaryContact")
                        .WithMany()
                        .HasForeignKey("PrimaryContactId");

                    b.Navigation("Address");

                    b.Navigation("Organisation");

                    b.Navigation("PrimaryContact");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Client", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("EmergencyContact");
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
