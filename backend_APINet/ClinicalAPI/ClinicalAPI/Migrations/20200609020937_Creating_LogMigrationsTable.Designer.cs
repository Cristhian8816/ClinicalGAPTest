﻿// <auto-generated />
using System;
using ClinicalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicalAPI.Migrations
{
    [DbContext(typeof(UsersContext))]
    [Migration("20200609020937_Creating_LogMigrationsTable")]
    partial class Creating_LogMigrationsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicalAPI.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .HasColumnName("AppoitmentId")
                        .HasColumnType("int");

                    b.Property<string>("AppointmentType")
                        .HasColumnName("AppointmentType")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("Date")
                        .HasColumnName("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientId")
                        .HasColumnName("PatientId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.ToTable("Appoiments");
                });

            modelBuilder.Entity("ClinicalAPI.Models.MigrationHistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasColumnName("MigrationId")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("ProductVersion")
                        .HasColumnName("ProductVersion")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("MigrationId");

                    b.ToTable("MigrationsHistory");
                });

            modelBuilder.Entity("ClinicalAPI.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnName("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnName("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
