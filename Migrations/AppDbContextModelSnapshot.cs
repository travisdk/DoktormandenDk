﻿// <auto-generated />
using System;
using DoktormandenDk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoktormandenDk.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoktormandenDk.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<string>("AppointmentMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AppointmentTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("GPId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("GPId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentId = 1,
                            AppointmentMessage = "Hul i hovedet",
                            AppointmentTime = new DateTime(2023, 11, 11, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Category = 0,
                            GPId = 1,
                            PatientId = 2
                        },
                        new
                        {
                            AppointmentId = 2,
                            AppointmentMessage = "Smerter i lysken når jeg bukker mig ned, venstre side",
                            AppointmentTime = new DateTime(2023, 11, 11, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            Category = 0,
                            GPId = 1,
                            PatientId = 1
                        },
                        new
                        {
                            AppointmentId = 3,
                            AppointmentMessage = "",
                            AppointmentTime = new DateTime(2023, 11, 1, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            Category = 2,
                            GPId = 2,
                            PatientId = 2
                        });
                });

            modelBuilder.Entity("DoktormandenDk.Models.EConsultation", b =>
                {
                    b.Property<int>("EConsultationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EConsultationId"));

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("AnswerTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Closed")
                        .HasColumnType("bit");

                    b.Property<int>("GPId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("QuestionTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("EConsultationId");

                    b.HasIndex("GPId");

                    b.HasIndex("PatientId");

                    b.ToTable("EConsultations");
                });

            modelBuilder.Entity("DoktormandenDk.Models.GP", b =>
                {
                    b.Property<int>("GPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GPId"));

                    b.Property<string>("License")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GPId");

                    b.ToTable("GPs");

                    b.HasData(
                        new
                        {
                            GPId = 1,
                            License = "AB3532Z",
                            Name = "Børge Ordrup",
                            UserName = "Læge 1"
                        },
                        new
                        {
                            GPId = 2,
                            License = "ZZ9922B",
                            Name = "Klaus Spellenberg",
                            UserName = "Læge 2"
                        });
                });

            modelBuilder.Entity("DoktormandenDk.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            BirthDay = new DateTime(1959, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Peter Hansen",
                            UserName = "Patient A"
                        },
                        new
                        {
                            PatientId = 2,
                            BirthDay = new DateTime(1976, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ole Jensen",
                            UserName = "Patient B"
                        });
                });

            modelBuilder.Entity("DoktormandenDk.Models.Appointment", b =>
                {
                    b.HasOne("DoktormandenDk.Models.GP", "GP")
                        .WithMany("Appointments")
                        .HasForeignKey("GPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoktormandenDk.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GP");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DoktormandenDk.Models.EConsultation", b =>
                {
                    b.HasOne("DoktormandenDk.Models.GP", "GP")
                        .WithMany("EConsultations")
                        .HasForeignKey("GPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoktormandenDk.Models.Patient", "Patient")
                        .WithMany("EConsultations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GP");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DoktormandenDk.Models.GP", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("EConsultations");
                });

            modelBuilder.Entity("DoktormandenDk.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("EConsultations");
                });
#pragma warning restore 612, 618
        }
    }
}
