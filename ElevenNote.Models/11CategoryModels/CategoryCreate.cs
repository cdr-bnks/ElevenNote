using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models._11CategoryModels
{
    public class CategoryCreate
    {
        [Required]
        [MaxLength(35, ErrorMessage ="Too many characters within this response.")]
        public string Subject { get; set; }
    }
}
