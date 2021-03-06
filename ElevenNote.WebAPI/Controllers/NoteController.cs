using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    {
        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteservice = new NoteService(userId);
            return noteservice;
        }

        //Get All
        public IHttpActionResult Get()
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNotes();
            return Ok(notes);
        }

        //POST
        public IHttpActionResult Post(NoteCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.CreateNote(note))
                return InternalServerError();

            return Ok();
        }

        //Get by ID
        public IHttpActionResult Get(int id)
        {
            NoteService noteService = CreateNoteService();
            var note = noteService.GetNoteById(id);
            return Ok(note);
        }

        //PUT
        public IHttpActionResult Put(NoteEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.UpdateNote(note))
                return InternalServerError();

            return Ok();
        }

        //Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreateNoteService();

            if (!service.DeleteNote(id))
                return InternalServerError();

            return Ok();
        }

        //Get By IsStarred
        [Route("api/Note/IsStarred")]
        public IHttpActionResult GetIsStarred()
        {
            NoteService noteService = CreateNoteService();
            var note = noteService.GetNoteByIsStarred();
            return Ok(note);

        }

        //Get by Is Not Starred
        [Route("api/Note/IsNotStarred")]
        public IHttpActionResult GetIsNotStarred()
        {
            NoteService noteService = CreateNoteService();
            var note = noteService.GetNoteByIsNotStarred();
            return Ok(note);

        }
    }
}
