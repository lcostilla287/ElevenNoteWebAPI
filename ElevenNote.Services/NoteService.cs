using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace ElevenNote.Services
{
    public class NoteService
    {
        private readonly Guid _userId;

        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        //CREATE(POST)
        public bool CreateNote(NoteCreate model)
        {
            var entity =
                new Note()
                {
                    //placeholder   //equal to foreignkey
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    IsStarred = model.IsStarred,
                    CategoryId = model.CategoryId,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //READ(GET)
        public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Notes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new NoteListItem
                                {
                                    NoteId = e.NoteId,
                                    Title = e.Title,
                                    IsStarred = e.IsStarred,
                                    CategoryId = e.CategoryId,
                                    CreatedUtc = e.CreatedUtc
                                    //CategoryName = e.Category.Name
                                }
                         );
                return query.ToArray();
            }
        }

        //GetNoteById
        public NoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == id && e.OwnerId == _userId);
                return
                    new NoteDetail
                    {
                        NoteId = entity.NoteId,
                        Title = entity.Title,
                        Content = entity.Content,
                        IsStarred = entity.IsStarred,
                        CategoryId = entity.CategoryId,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                        //category = new CategoryListItem() {CategoryId = entity.Category.CategoryId, Name = entity.Category.Name}
                    };
            }
        }

        //Put
        //UpdateNote
        public bool UpdateNote(NoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.IsStarred = model.IsStarred;
                entity.CategoryId = model.CategoryId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                //entity.CategoryId = model.CategoryId

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Method
        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Notes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //Get IsStarred
        public IEnumerable<NoteListItem> GetNoteByIsStarred()
        {
            //bool starred = bool.Parse(isStarred);
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Notes
                        .Where(e => e.IsStarred && e.OwnerId == _userId)
                        .Select(
                            e =>
                                new NoteListItem
                                {
                                    NoteId = e.NoteId,
                                    Title = e.Title,
                                    IsStarred = e.IsStarred,
                                    CategoryId = e.CategoryId,
                                    CreatedUtc = e.CreatedUtc
                                }
                         );
                return query.ToArray();
            }
        }

        //Get IsNotStarred
        public IEnumerable<NoteListItem> GetNoteByIsNotStarred()
        {
            //bool starred = bool.Parse(isStarred);
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Notes
                        .Where(e => e.IsStarred == false && e.OwnerId == _userId)
                        .Select(
                            e =>
                                new NoteListItem
                                {
                                    NoteId = e.NoteId,
                                    Title = e.Title,
                                    IsStarred = e.IsStarred,
                                    CategoryId = e.CategoryId,
                                    CreatedUtc = e.CreatedUtc
                                }
                         );
                return query.ToArray();
            }
        }

        //PUT IsStarred
        public bool UpdateIsStarredNote(NoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.IsStarred = model.IsStarred;
                entity.CategoryId = model.CategoryId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
