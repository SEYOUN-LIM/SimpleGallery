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

            var imageList = new List<GalleryImage>()
            {
                new GalleryImage()
                {
                                    Title = "Title 1",
                Url = "",
                Created = DateTime.Now,
                Tags = testImageTags
                }

            };
            var model = new GalleryIndexModel()
            {
                // Mock Images
                Images = imageList
            };
            return View(model);
        }
    }
}