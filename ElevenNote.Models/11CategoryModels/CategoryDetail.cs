using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models._11CategoryModels
{
    public class CategoryDetail
    {
        public int CatergoryId { get; set; }
        public string Subject { get; set; }

        [Display(Name = "Favorites")]
        public bool? FavoriteCatagory { get; set; }
    }
}
