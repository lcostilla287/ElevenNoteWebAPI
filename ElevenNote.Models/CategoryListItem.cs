using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryListItem
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual List<Note> Notes { get; set; } = new List<Note>();

        //Here you can just put the Id and name
    }
}
