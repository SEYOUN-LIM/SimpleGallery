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
            return _ctx.GalleryImages.Find(id);
        }

        public IEnumerable<GalleryImage> GetWithTags(string tag)
        {
            return GetAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }
    }
}
