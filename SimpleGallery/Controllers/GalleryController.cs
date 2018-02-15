using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleGallery.Data;
using SimpleGallery.Data.Models;
using SimpleGallery.Models;

namespace SimpleGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;

        public GalleryController(IImage imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            // Mock Data
            //var testImageTags = new List<ImageTag>();
            //var test2ImageTags = new List<ImageTag>();


            //var tag1 = new ImageTag()
            //{
            //    Description = "Animal",
            //    Id = 0
            //};

            //var tag2 = new ImageTag()
            //{
            //    Description = "Cats",
            //    Id = 1
            //};

            //var tag3 = new ImageTag()
            //{
            //    Description = "kitten",
            //    Id = 2
            //};

            //testImageTags.Add(tag1);
            //test2ImageTags.AddRange(new List<ImageTag> { tag2, tag3 });

            //var imageList = new List<GalleryImage>()
            //{

            //    new GalleryImage()
            //    {
            //        Title = "Title 1",
            //        Url = "https://static.pexels.com/photos/209037/pexels-photo-209037.jpeg",
            //        Created = DateTime.Now,
            //        Tags = testImageTags
            //    },
            //    new GalleryImage()
            //    {
            //        Title = "Title 2",
            //        Url = "https://static.pexels.com/photos/55750/wildcat-animal-nature-cat-55750.jpeg",
            //        Created = DateTime.Now,
            //        Tags = test2ImageTags
            //    },
            //    new GalleryImage()
            //    {
            //        Title = "Title 3",
            //        Url = "https://static.pexels.com/photos/751050/pexels-photo-751050.jpeg",
            //        Created = DateTime.Now,
            //        Tags = test2ImageTags
            //    }

            //};

            var imageList = _imageService.GetAll();

            var model = new GalleryIndexModel()
            {
                // Mock Images
                Images = imageList,
                SearchQuery = ""
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var image = _imageService.GetById(id);

            var model = new GalleryDetailModel()
            {
                Id = image.Id,
                Title = image.Title,
                CreatedOn = image.Created,
                Url = image.Url,
                Tags = image.Tags.Select(t => t.Description).ToList()
            };

            return View(model);
        }

        public IActionResult ImgUp()
        {
            return View();
        }
    }
}