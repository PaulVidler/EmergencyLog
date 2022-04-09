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
    [Migration("20220409013459_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("EmergencyLog.Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<int>("EntityRelationId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Guid")
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

            modelBuilder.Entity("EmergencyLog.Domain.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EntityId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EntryComplete")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Guid")
                        .HasColumnType("TEXT");

                    b.Property<bool>("OnSite")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeIn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TimeOut")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmergencyContactId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Guid")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageLarge")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageSmall")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mobile")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("EmergencyContactId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Guid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mobile")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Entity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Entity");
                });

            modelBuilder.Entity("EmergencyLog.Domain.EmergencyContact", b =>
                {
                    b.HasBaseType("EmergencyLog.Domain.Entity");

                    b.Property<int?>("EntityRelationshipId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RelationshipType")
                        .HasColumnType("INTEGER");

                    b.HasIndex("EntityRelationshipId");

                    b.HasDiscriminator().HasValue("EmergencyContact");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Attendance", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");

                    b.Navigation("Entity");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Client", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("EmergencyLog.Domain.EmergencyContact", "EmergencyContact")
                        .WithMany()
                        .HasForeignKey("EmergencyContactId");

                    b.Navigation("Address");

                    b.Navigation("EmergencyContact");
                });

            modelBuilder.Entity("EmergencyLog.Domain.Entity", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("EmergencyLog.Domain.EmergencyContact", b =>
                {
                    b.HasOne("EmergencyLog.Domain.Entity", "EntityRelationship")
                        .WithMany()
                        .HasForeignKey("EntityRelationshipId");

                    b.Navigation("EntityRelationship");
                });
#pragma warning restore 612, 618
        }
    }
}
