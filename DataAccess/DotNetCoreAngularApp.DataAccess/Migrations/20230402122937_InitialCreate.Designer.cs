﻿// <auto-generated />
using DotNetCoreAngularApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DotNetCoreAngularApp.DataAccess.Migrations
{
    [DbContext(typeof(DotNetCoreAngularAppDbContext))]
    [Migration("20230402122937_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DotNetCoreAngularApp.DataAccess.Entities.Settings.CountryEntity", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("CountryCode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("Name");

                    b.HasKey("CountryCode");

                    b.ToTable("Country", (string)null);

                    b.HasData(
                        new
                        {
                            CountryCode = "C1",
                            Name = "Country 1"
                        },
                        new
                        {
                            CountryCode = "C2",
                            Name = "Country 2"
                        });
                });

            modelBuilder.Entity("DotNetCoreAngularApp.DataAccess.Entities.Settings.ProvinceEntity", b =>
                {
                    b.Property<int>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ProvinceId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProvinceId"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("character varying(2)")
                        .HasColumnName("CountryCode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("Name");

                    b.HasKey("ProvinceId");

                    b.HasIndex("CountryCode");

                    b.ToTable("Province", (string)null);

                    b.HasData(
                        new
                        {
                            ProvinceId = 1,
                            CountryCode = "C1",
                            Name = "Province 1.1"
                        },
                        new
                        {
                            ProvinceId = 2,
                            CountryCode = "C1",
                            Name = "Province 1.2"
                        },
                        new
                        {
                            ProvinceId = 3,
                            CountryCode = "C2",
                            Name = "Province 2.1"
                        },
                        new
                        {
                            ProvinceId = 4,
                            CountryCode = "C2",
                            Name = "Province 2.2"
                        });
                });

            modelBuilder.Entity("DotNetCoreAngularApp.DataAccess.Entities.User.UserEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<bool>("AcceptTerms")
                        .HasColumnType("boolean")
                        .HasColumnName("AcceptTerms");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("character varying(320)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Password");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("integer")
                        .HasColumnName("ProvinceId");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ProvinceId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DotNetCoreAngularApp.DataAccess.Entities.Settings.ProvinceEntity", b =>
                {
                    b.HasOne("DotNetCoreAngularApp.DataAccess.Entities.Settings.CountryEntity", "Country")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DotNetCoreAngularApp.DataAccess.Entities.User.UserEntity", b =>
                {
                    b.HasOne("DotNetCoreAngularApp.DataAccess.Entities.Settings.ProvinceEntity", "Province")
                        .WithMany("Users")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("DotNetCoreAngularApp.DataAccess.Entities.Settings.CountryEntity", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("DotNetCoreAngularApp.DataAccess.Entities.Settings.ProvinceEntity", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}