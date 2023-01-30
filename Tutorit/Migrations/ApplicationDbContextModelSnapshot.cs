﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tutorit.Persistance;

#nullable disable

namespace Tutorit.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Tutorit.Models.Account", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<bool>("RememberMe")
                        .HasColumnType("boolean");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Username");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Tutorit.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Tutorit.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("RegisteredAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("TokenCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("TokenExpires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Tutorit.Models.UserSubject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("BelongsTo")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeChosen")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("SubjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSubject");
                });

            modelBuilder.Entity("Tutorit.Models.Student", b =>
                {
                    b.HasBaseType("Tutorit.Models.User");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("Tutorit.Models.Teacher", b =>
                {
                    b.HasBaseType("Tutorit.Models.User");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("Tutorit.Models.Account", b =>
                {
                    b.HasOne("Tutorit.Models.User", null)
                        .WithOne("Account")
                        .HasForeignKey("Tutorit.Models.Account", "UserId");
                });

            modelBuilder.Entity("Tutorit.Models.UserSubject", b =>
                {
                    b.HasOne("Tutorit.Models.Subject", "Subject")
                        .WithMany("UserSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tutorit.Models.User", "User")
                        .WithMany("UserSubjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tutorit.Models.Student", b =>
                {
                    b.HasOne("Tutorit.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Tutorit.Models.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutorit.Models.Teacher", b =>
                {
                    b.HasOne("Tutorit.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Tutorit.Models.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutorit.Models.Subject", b =>
                {
                    b.Navigation("UserSubjects");
                });

            modelBuilder.Entity("Tutorit.Models.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("UserSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}