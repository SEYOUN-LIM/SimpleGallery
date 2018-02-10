using SimpleGallery.Data.Models;
using System.Collections.Generic;

namespace SimpleGallery.Models
{
    public class GalleryIndexModel
    {
        public IEnumerable<GalleryImage> Images { get; set; }
        public string SearchQuery { get; set; }
        
    }
}
