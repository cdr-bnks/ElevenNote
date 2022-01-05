using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models._11CategoryModels
{
    public class CategoryListItem
    {
        public int CategoryId { get; set; }

        [Display(Name ="Enter Category:")]
        public string Subject { get; set; }
    }
}
