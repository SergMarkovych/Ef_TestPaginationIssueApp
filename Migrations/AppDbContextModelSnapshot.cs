﻿// <auto-generated />
using System;
using Ef_TestPaginationIssueApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ef_TestPaginationIssueApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ef_TestPaginationIssueApp.Types.Child", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Child", (string)null);
                });

            modelBuilder.Entity("Ef_TestPaginationIssueApp.Types.Parent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("ChildId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PhoneId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("PhoneId");

                    b.ToTable("Parent");
                });

            modelBuilder.Entity("Ef_TestPaginationIssueApp.Types.Phone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AreaCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("Ef_TestPaginationIssueApp.Types.Child", b =>
                {
                    b.OwnsOne("Ef_TestPaginationIssueApp.Types.InfoData", "InfoData", b1 =>
                        {
                            b1.Property<long>("ChildId")
                                .HasColumnType("bigint");

                            b1.HasKey("ChildId");

                            b1.ToTable("Child");

                            b1.ToJson("InfoData");

                            b1.WithOwner()
                                .HasForeignKey("ChildId");

                            b1.OwnsMany("Ef_TestPaginationIssueApp.Types.Field", "Fields", b2 =>
                                {
                                    b2.Property<long>("InfoDataChildId")
                                        .HasColumnType("bigint");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    b2.Property<string>("Code")
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int?>("Value")
                                        .HasColumnType("int");

                                    b2.HasKey("InfoDataChildId", "Id");

                                    b2.ToTable("Child");

                                    b2.WithOwner()
                                        .HasForeignKey("InfoDataChildId");
                                });

                            b1.Navigation("Fields");
                        });

                    b.Navigation("InfoData")
                        .IsRequired();
                });

            modelBuilder.Entity("Ef_TestPaginationIssueApp.Types.Parent", b =>
                {
                    b.HasOne("Ef_TestPaginationIssueApp.Types.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildId");

                    b.HasOne("Ef_TestPaginationIssueApp.Types.Phone", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneId");

                    b.Navigation("Child");

                    b.Navigation("Phone");
                });
#pragma warning restore 612, 618
        }
    }
}