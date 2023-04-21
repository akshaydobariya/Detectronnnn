using Azure;
using Azure.AI.TextAnalytics;
using Detectron.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detectron.Controllers
{
    public class TextAnalyticskeyPhrasesController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }



        public async Task<ActionResult> Analyze(TextAnalyticsModel model)
        {

            var credential = new AzureKeyCredential("a1d5f6cfe0c743c29d4ba98db5be732f");
            var endpoint = "https://eiccognitive.cognitiveservices.azure.com/";
            var client = new TextAnalyticsClient(new Uri(endpoint), credential);

            var response = await client.ExtractKeyPhrasesAsync(model.InputText, "en");


            var keyPhrases = response.Value;

            model.Summary = $"Extracted {keyPhrases.Count} key phrases:\n";
            model.Summary += string.Join("\n", keyPhrases);

            return View("Result", model);


        }
    }
}
