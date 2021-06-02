﻿using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual List<Note> Notes { get; set; } = new List<Note>();
        //can use the NoteListItem entity instead of notes don't need to instantiate a new list
    }
}
