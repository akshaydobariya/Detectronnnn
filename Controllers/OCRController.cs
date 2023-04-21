using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Threading;
using System;

namespace Detectron.Controllers
{
    public class OCRController : Controller
    {

        private const string subscriptionKey = "8e406857b48942e886af80e0761799e2";
        private const string endpoint = "https://detectrondemo.cognitiveservices.azure.com/";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RecognizeText(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not selected.");
            }

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;

            var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
            {
                Endpoint = endpoint
            };

            var result = await client.RecognizePrintedTextInStreamAsync(true, stream, OcrLanguages.En);
            return View("Index",result);
        }
    }
}
