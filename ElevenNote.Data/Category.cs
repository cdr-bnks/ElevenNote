using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Subject { get; set; }
        public bool  FavoriteCategory{ get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
