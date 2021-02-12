using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiziApp.WEBUI.Models
{
    public class Serie
    {
        public int SerieId { get; set; }
        [Required]

        public string Title { get; set; }

        public string Description { get; set; }
        [Required]
        public string Director { get; set; }
        public string ImageUrl { get; set; }

        public int? CategoryId { get; set; }


    }
}
