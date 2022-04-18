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
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EntityId")
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

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ClientId")
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

                    b.Property<Guid?>("OrganisationId")
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

                    b.HasIndex("OrganisationId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.EmergencyContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AddressId")
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

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("EmergencyContacts");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireExtinguisher", b =>
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

                    b.Property<Guid?>("PropertyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ServicedById")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("ServicedById");

                    b.ToTable("FireExtinguishers");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireHose", b =>
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

                    b.Property<Guid?>("PropertyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ServicedById")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("ServicedById");

                    b.ToTable("FireHoses");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Organisation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PrimaryContactId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SecondaryContactId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("PrimaryContactId");

                    b.HasIndex("SecondaryContactId");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PrimaryContactId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SecondaryContactId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("PrimaryContactId");

                    b.HasIndex("SecondaryContactId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.SmokeAlarm", b =>
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

                    b.Property<Guid?>("PropertyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ServicedById")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.HasIndex("ServicedById");

                    b.ToTable("SmokeAlarms");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Address", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Client", "Client")
                        .WithOne("Address")
                        .HasForeignKey("EmergencyLog.Domain.Entities.Address", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Attendance", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Client", "Client")
                        .WithMany("Attendances")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Client", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Organisation", null)
                        .WithMany("Clients")
                        .HasForeignKey("OrganisationId");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.EmergencyContact", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("EmergencyLog.Domain.Entities.Client", "Client")
                        .WithOne("EmergencyContact")
                        .HasForeignKey("EmergencyLog.Domain.Entities.EmergencyContact", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireExtinguisher", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Property", "Property")
                        .WithMany("FireExtinguishers")
                        .HasForeignKey("PropertyId");

                    b.HasOne("EmergencyLog.Domain.Entities.Organisation", "ServicedBy")
                        .WithMany()
                        .HasForeignKey("ServicedById");

                    b.Navigation("Property");

                    b.Navigation("ServicedBy");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.FireHose", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Property", "Property")
                        .WithMany("FireHoses")
                        .HasForeignKey("PropertyId");

                    b.HasOne("EmergencyLog.Domain.Entities.Organisation", "ServicedBy")
                        .WithMany()
                        .HasForeignKey("ServicedById");

                    b.Navigation("Property");

                    b.Navigation("ServicedBy");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Organisation", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.Client", "PrimaryContact")
                        .WithMany()
                        .HasForeignKey("PrimaryContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyLog.Domain.Entities.Client", "SecondaryContact")
                        .WithMany()
                        .HasForeignKey("SecondaryContactId");

                    b.Navigation("Address");

                    b.Navigation("PrimaryContact");

                    b.Navigation("SecondaryContact");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Property", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("EmergencyLog.Domain.Entities.Client", "PrimaryContact")
                        .WithMany()
                        .HasForeignKey("PrimaryContactId");

                    b.HasOne("EmergencyLog.Domain.Entities.Client", "SecondaryContact")
                        .WithMany()
                        .HasForeignKey("SecondaryContactId");

                    b.Navigation("Address");

                    b.Navigation("PrimaryContact");

                    b.Navigation("SecondaryContact");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.SmokeAlarm", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entities.Property", "Property")
                        .WithMany("SmokeAlarmsCollection")
                        .HasForeignKey("PropertyId");

                    b.HasOne("EmergencyLog.Domain.Entities.Organisation", "ServicedBy")
                        .WithMany()
                        .HasForeignKey("ServicedById");

                    b.Navigation("Property");

                    b.Navigation("ServicedBy");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Client", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Attendances");

                    b.Navigation("EmergencyContact");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Organisation", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entities.Property", b =>
                {
                    b.Navigation("FireExtinguishers");

                    b.Navigation("FireHoses");

                    b.Navigation("SmokeAlarmsCollection");
                });
#pragma warning restore 612, 618
        }
    }
}
