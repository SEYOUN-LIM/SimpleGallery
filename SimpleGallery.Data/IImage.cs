using SimpleGallery.Data.Models;
using System.Collections.Generic;

namespace SimpleGallery.Data
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();
        IEnumerable<GalleryImage> GetWithTags(string tag);
        GalleryImage GetById(int id);
        void CreateImage(GalleryImage galleryImage);

    }
}
