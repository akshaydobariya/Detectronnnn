
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
    public class TextAnalyticsSummaryController : Controller
    {
        //private readonly TextAnalyticsClient _client;

        //public TextAnalyticsSummaryController()
        //{
        //    var endpoint = "https://eiccognitive.cognitiveservices.azure.com/";
        //    var apiKey = "a1d5f6cfe0c743c29d4ba98db5be732f";
        //    var credentials = new AzureKeyCredential(apiKey);
        //    _client = new TextAnalyticsClient(new Uri(endpoint), credentials);
        //}
        private const string SubscriptionKey = "a1d5f6cfe0c743c29d4ba98db5be732f";
        private const string Endpoint = "https://eiccognitive.cognitiveservices.azure.com/";
        private static readonly AzureKeyCredential Credentials = new AzureKeyCredential(SubscriptionKey);
        private static readonly TextAnalyticsClient Client = new TextAnalyticsClient(new Uri(Endpoint), Credentials);

        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Analyze(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
            {
                ModelState.AddModelError("inputText", "Please enter some text to analyze.");
                return View();
            }

            var result = await Client.ExtractKeyPhrasesAsync(inputText);
            var response = await Client.ExtractKeyPhrasesAsync(inputText, "en");


            var model = new text1
            {
                InputText = inputText,
                Summary = GenerateSummary(response.Value)
            };

            return View("Result", model);
        }

        private string GenerateSummary(IEnumerable<string> keyPhrases)
        {
            // Use a third-party library or service to generate a summary using the key phrases.
            // Here's an example of how you can concatenate the key phrases into a summary string:

            var summary = string.Join("    ,", keyPhrases);

            return summary.Length > 200 ? summary.Substring(0, 200) + "..." : summary;
        }
    }
}
