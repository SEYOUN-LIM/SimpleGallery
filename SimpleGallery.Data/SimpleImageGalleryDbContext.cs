using Microsoft.EntityFrameworkCore;
using SimpleGallery.Data.Models;
using System;

namespace SimpleGallery.Data
{
    public class SimpleGalleryDbContext: DbContext
    {
        public SimpleGalleryDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> Tags { get; set; }

    }
}
