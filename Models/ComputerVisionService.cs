using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Detectron.Models
{
    public class ComputerVisionService
    {
        private readonly ComputerVisionClient _client;

        public ComputerVisionService(string apiKey, string endpoint)
        {
            // Create the Computer Vision API client
            _client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(apiKey))
            {
                Endpoint = endpoint
            };
        }

        public async Task<IList<string>> GetImageTagsAsync(Stream imageStream)
        {
            // Call the Computer Vision API to detect tags in the image
            var response = await _client.TagImageInStreamAsync(imageStream);
            return response.Tags.Select(t => t.Name).ToList();

        }
    }
}