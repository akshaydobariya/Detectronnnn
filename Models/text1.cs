using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Detectron.Models
{
    public class text1
    {
        [Required(ErrorMessage = "Please enter some text to analyze.")]
        public string InputText { get; set; }

        public string Summary { get; set; }
    }
}
