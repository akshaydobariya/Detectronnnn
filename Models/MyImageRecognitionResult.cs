using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detectron.Models
{
    public class MyImageRecognitionResult
    {
        private object recognitionResult;

        public MyImageRecognitionResult(object recognitionResult)
        {
            this.recognitionResult = recognitionResult;
        }

        public string ImagePath { get; set; }
        public string RecognizedText { get; set; }

        
    }
}
