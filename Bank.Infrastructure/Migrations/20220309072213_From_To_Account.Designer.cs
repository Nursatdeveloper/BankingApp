﻿// <auto-generated />
using System;
using Bank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bank.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220309072213_From_To_Account")]
    partial class From_To_Account
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Bank.Core.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("text");

                    b.Property<string>("AccountType")
                        .HasColumnType("text");

                    b.Property<DateTime>("ActivatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Balance")
                        .HasColumnType("integer");

                    b.Property<string>("CurrencyType")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean");

                    b.Property<string>("OwnerIIN")
                        .HasColumnType("text");

                    b.Property<string>("OwnerName")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("AccountId");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Bank.Core.Entities.BankOperation", b =>
                {
                    b.Property<int>("BankOperationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("BankOperationMaker")
                        .HasColumnType("text");

                    b.Property<int>("BankOperationMakerId")
                        .HasColumnType("integer");

                    b.Property<int>("BankOperationMoneyAmount")
                        .HasColumnType("integer");

                    b.Property<string>("BankOperationParticipant")
                        .HasColumnType("text");

                    b.Property<DateTime>("BankOperationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("BankOperationType")
                        .HasColumnType("text");

                    b.Property<string>("FromAccount")
                        .HasColumnType("text");

                    b.Property<string>("ToAccount")
                        .HasColumnType("text");

                    b.HasKey("BankOperationId");

                    b.HasIndex("AccountId");

                    b.ToTable("BankOperations");
                });

            modelBuilder.Entity("Bank.Core.Entities.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsSeen")
                        .HasColumnType("boolean");

                    b.Property<string>("NotificationText")
                        .HasColumnType("text");

                    b.Property<DateTime>("NotificationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Bank.Core.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CardNumber")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("IIN")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Bank.Core.Entities.Account", b =>
                {
                    b.HasOne("Bank.Core.Entities.User", null)
                        .WithMany("Accounts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Bank.Core.Entities.BankOperation", b =>
                {
                    b.HasOne("Bank.Core.Entities.Account", null)
                        .WithMany("BankOperations")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("Bank.Core.Entities.Notification", b =>
                {
                    b.HasOne("Bank.Core.Entities.User", null)
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bank.Core.Entities.Account", b =>
                {
                    b.Navigation("BankOperations");
                });

            modelBuilder.Entity("Bank.Core.Entities.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
