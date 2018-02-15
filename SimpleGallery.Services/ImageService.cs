using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleGallery.Data;
using SimpleGallery.Data.Models;

namespace SimpleGallery.Services
{
    public class ImageService : IImage
    {
        private readonly SimpleGalleryDbContext _ctx;

        public ImageService(SimpleGalleryDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<GalleryImage> GetAll()
        {
            return _ctx.GalleryImages.Include(img => img.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return GetAll().Where(img => img.Id == id).First();
        }

        public IEnumerable<GalleryImage> GetWithTags(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }

        public void CreateImage(GalleryImage galleryImage)
        {
            _ctx.Add(galleryImage);
            _ctx.SaveChanges();
        }
    }
}
