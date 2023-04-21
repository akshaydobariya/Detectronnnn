using Detectron.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detectron.Controllers
{
    public class ImageController : Controller
    {

        private readonly ComputerVisionService _computerVisionService;

        public ImageController()
        {
            // Initialize the Computer Vision API service
            string apiKey = "8e406857b48942e886af80e0761799e2";
            string endpoint = "https://detectrondemo.cognitiveservices.azure.com/";
            _computerVisionService = new ComputerVisionService(apiKey, endpoint);
        }
        public IActionResult Index()
        {
            return View("Image");
        }
        [HttpPost]
        public async Task<IActionResult> Image()
        {
            // Get the uploaded image from the request
            var imageFile = Request.Form.Files["imageFile"];

            if (imageFile != null && imageFile.Length > 0)
            {
                // Call the Computer Vision API to detect tags in the image
                var tags = await _computerVisionService.GetImageTagsAsync(imageFile.OpenReadStream());
               
                // Display the detected tags in the view
                return View(tags);
            }
            else
            {
                ModelState.AddModelError("imageFile", "Please select a file.");
                return View();
            }
        }
    }
}
