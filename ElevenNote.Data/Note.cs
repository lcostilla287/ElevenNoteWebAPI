using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note
    {

        //key will always be a unique number
        [Key]
        public int NoteId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

        //VALIDATION ATTRIBUTES
        //can use [Range(1,5, ErrorMessage="please choose a number between 1 and 5")]
        //It can help when looking for a specific range

        //Can also use [MaxLength(100, ErrorMessage="there are too many characters in this field.")]
        //limits the number of characters

        //DISPLAY ATTRIBUTE
        //[Display] or [Display(Name)] to change the name the user is shown for the property
        //example
        //[Display(Name = "Your Note")]
    }
}
