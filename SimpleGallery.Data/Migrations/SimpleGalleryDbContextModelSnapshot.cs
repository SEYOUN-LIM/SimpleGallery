﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SimpleGallery.Data;
using System;

namespace SimpleGallery.Data.Migrations
{
    [DbContext(typeof(SimpleGalleryDbContext))]
    partial class SimpleGalleryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleGallery.Data.Models.GalleryImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("GalleryImages");
                });

            modelBuilder.Entity("SimpleGallery.Data.Models.ImageTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("GalleryImageId");

                    b.HasKey("Id");

                    b.HasIndex("GalleryImageId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SimpleGallery.Data.Models.ImageTag", b =>
                {
                    b.HasOne("SimpleGallery.Data.Models.GalleryImage")
                        .WithMany("Tags")
                        .HasForeignKey("GalleryImageId");
                });
#pragma warning restore 612, 618
        }
    }
}