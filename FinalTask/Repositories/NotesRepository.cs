using FinalTask.Areas.Identity.Data;
using FinalTask.Model;
using FinalTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalTask.Repositories
{
    public class NotesRepository
        
    {
        private readonly FinalTaskContext _dbContext;
        private readonly UserService _userService;

        public NotesRepository(FinalTaskContext dbContext, UserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public Note GetNote(int id)
        {
            return _dbContext.Notes.Include(n=>n.Category).FirstOrDefault(x => x.Id == id);
        }

        public void CreateCategory(Category category)
        {
            category.FinalTaskUserId = _userService.GetUserId();
            _dbContext.Add(category);
            _dbContext.SaveChanges();
        }

        public List<Note> GetNotes(string title = null, string category = null)
        {
            var userId = _userService.GetUserId();
            var categories = _dbContext.Categories.Where(u => u.FinalTaskUserId == userId).Include(u => u.Notes).ToList();
            var notes = categories.SelectMany(x => x.Notes);

            if (!string.IsNullOrEmpty(title))
            {
                notes = notes.Where(n => n.Title.Contains(title));
            }
            if (!string.IsNullOrEmpty(category))
            {
                notes = notes.Where(n => n.Category.Name.Contains(category));
            }
            return notes.ToList();
        }

        public void CreateNote(Note note)
        {
            _dbContext.Add(note);
            _dbContext.SaveChanges();
        }
        public void Update(Note note)
        {

            _dbContext.Entry(note).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteNote(int id)
        {
            var note = _dbContext.Notes.FirstOrDefault(x => x.Id == id);
            if (note != null)
            {
                _dbContext.Notes.Remove(note);
                _dbContext.SaveChanges();
            }
        }

        public List<String> GetCategories()
        {
            var userId = _userService.GetUserId();
            return _dbContext.Notes.Where(u=>u.Category.FinalTaskUserId == userId).Include(n => n.Category).Select(n => n.Category.Name).Distinct().ToList();
        }
    }

}
