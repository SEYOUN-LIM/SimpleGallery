using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleGallery.Data;
using SimpleGallery.Data.Models;
using SimpleGallery.Models;

namespace SimpleGallery.Controllers
{
    public class ImageController : Controller
    {
        private readonly SimpleGalleryDbContext _context;
        private readonly IHostingEnvironment _environment;
        private readonly IImage _image;

        public ImageController(
            IHostingEnvironment environment,
            IImage image,
            SimpleGalleryDbContext context
        )
        {
            _image = image;
            _environment = environment;
            _context = context;
        }


        public IActionResult Upload()
        {
            var model = new UploadImageModel();
            return View(model);
        }


        //[Route("api/upload")]
        [HttpPost]
        public async Task<IActionResult> UploadNewImage(UploadImageModel uploadImage)
        {
            if (ModelState.IsValid)
            {
                // uploading path
                var path = Path.Combine(_environment.WebRootPath, @"images");

                var fileName = uploadImage.ImageUpload.FileName;
                using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    await uploadImage.ImageUpload.CopyToAsync(fileStream);
                }

                var tags = uploadImage.Tags.Split(',');

                var model = new GalleryImage
                {
                    Title = uploadImage.Title,
                    Url = "/images/" + fileName,
                    Created = new DateTime(),
                };


                _context.GalleryImages.Add(model);
                _context.SaveChanges();
            };
            return RedirectToAction("Index", "Gallery");
        }
    }
}