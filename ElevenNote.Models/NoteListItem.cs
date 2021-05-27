using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteListItem
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }

        //This will display the Name "Created" instead of "CreatedUtc"
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
