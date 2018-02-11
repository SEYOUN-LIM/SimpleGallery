using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleGallery.Data.Models;
using SimpleGallery.Models;

namespace SimpleGallery.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var testImageTags = new List<ImageTag>();
            var test2ImageTags = new List<ImageTag>();
         

            var tag1 = new ImageTag()
            {
                Description = "Animal",
                Id = 0
            };

            var tag2 = new ImageTag()
            {
                Description = "Cats",
                Id = 1
            };

            var tag3 = new ImageTag()
            {
                Description = "kitten",
                Id = 2
            };

            testImageTags.Add(tag1);
            test2ImageTags.AddRange(new List<ImageTag> { tag2, tag3 });

            var imageList = new List<GalleryImage>()
            {

                new GalleryImage()
                {
                    Title = "Title 1",
                    Url = "https://static.pexels.com/photos/209037/pexels-photo-209037.jpeg",
                    Created = DateTime.Now,
                    Tags = testImageTags
                },
                new GalleryImage()
                {
                    Title = "Title 2",
                    Url = "https://static.pexels.com/photos/55750/wildcat-animal-nature-cat-55750.jpeg",
                    Created = DateTime.Now,
                    Tags = test2ImageTags
                },
                new GalleryImage()
                {
                    Title = "Title 3",
                    Url = "https://static.pexels.com/photos/751050/pexels-photo-751050.jpeg",
                    Created = DateTime.Now,
                    Tags = test2ImageTags
                }

            };
            var model = new GalleryIndexModel()
            {
                // Mock Images
                Images = imageList,
                SearchQuery = ""
            };
            return View(model);
        }
    }
}