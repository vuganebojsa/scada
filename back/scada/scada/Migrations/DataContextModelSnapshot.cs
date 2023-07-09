﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using scada.Data;

#nullable disable

namespace scada.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("scada.Models.Alarm", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("analogId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("priority")
                        .HasColumnType("int");

                    b.Property<int>("threshHold")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("analogId");

                    b.ToTable("Alarms");
                });

            modelBuilder.Entity("scada.Models.PastTagValues", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("tagId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("timeStamp")
                        .HasColumnType("datetime2");

                    b.Property<float>("value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("tagId");

                    b.ToTable("PastTagValues");
                });

            modelBuilder.Entity("scada.Models.Tag", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("currentValue")
                        .HasColumnType("real");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("tagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Tag");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Tag");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("scada.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("scada.Models.AnalogInput", b =>
                {
                    b.HasBaseType("scada.Models.Tag");

                    b.Property<string>("Driver")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("HighLimit")
                        .HasColumnType("float");

                    b.Property<string>("IOAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LowLimit")
                        .HasColumnType("float");

                    b.Property<bool>("OnOffScan")
                        .HasColumnType("bit");

                    b.Property<int>("ScanTime")
                        .HasColumnType("int");

                    b.Property<string>("Units")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Tag", t =>
                        {
                            t.Property("Driver")
                                .HasColumnName("AnalogInput_Driver");

                            t.Property("HighLimit")
                                .HasColumnName("AnalogInput_HighLimit");

                            t.Property("IOAddress")
                                .HasColumnName("AnalogInput_IOAddress");

                            t.Property("LowLimit")
                                .HasColumnName("AnalogInput_LowLimit");

                            t.Property("OnOffScan")
                                .HasColumnName("AnalogInput_OnOffScan");

                            t.Property("ScanTime")
                                .HasColumnName("AnalogInput_ScanTime");

                            t.Property("Units")
                                .HasColumnName("AnalogInput_Units");
                        });

                    b.HasDiscriminator().HasValue("AnalogInput");
                });

            modelBuilder.Entity("scada.Models.AnalogOutput", b =>
                {
                    b.HasBaseType("scada.Models.Tag");

                    b.Property<double>("HighLimit")
                        .HasColumnType("float");

                    b.Property<string>("IOAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("InitialValue")
                        .HasColumnType("real");

                    b.Property<double>("LowLimit")
                        .HasColumnType("float");

                    b.Property<string>("Units")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Tag", t =>
                        {
                            t.Property("IOAddress")
                                .HasColumnName("AnalogOutput_IOAddress");

                            t.Property("InitialValue")
                                .HasColumnName("AnalogOutput_InitialValue");
                        });

                    b.HasDiscriminator().HasValue("AnalogOutput");
                });

            modelBuilder.Entity("scada.Models.DigitalInput", b =>
                {
                    b.HasBaseType("scada.Models.Tag");

                    b.Property<string>("Driver")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IOAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnOffScan")
                        .HasColumnType("bit");

                    b.Property<int>("ScanTime")
                        .HasColumnType("int");

                    b.ToTable("Tag", t =>
                        {
                            t.Property("IOAddress")
                                .HasColumnName("DigitalInput_IOAddress");
                        });

                    b.HasDiscriminator().HasValue("DigitalInput");
                });

            modelBuilder.Entity("scada.Models.DigitalOutput", b =>
                {
                    b.HasBaseType("scada.Models.Tag");

                    b.Property<string>("IOAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InitialValue")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DigitalOutput");
                });

            modelBuilder.Entity("scada.Models.Alarm", b =>
                {
                    b.HasOne("scada.Models.AnalogInput", "analogInput")
                        .WithMany("Alarms")
                        .HasForeignKey("analogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("analogInput");
                });

            modelBuilder.Entity("scada.Models.PastTagValues", b =>
                {
                    b.HasOne("scada.Models.Tag", "tag")
                        .WithMany()
                        .HasForeignKey("tagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tag");
                });

            modelBuilder.Entity("scada.Models.AnalogInput", b =>
                {
                    b.Navigation("Alarms");
                });
#pragma warning restore 612, 618
        }
    }
}
