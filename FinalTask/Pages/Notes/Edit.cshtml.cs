using FinalTask.Areas.Identity.Data;
using FinalTask.Model;
using FinalTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalTask.Pages.Notes
{
    public class EditModel : CategorySelectModel
    {
        private readonly NotesRepository _notesRepository;

        public EditModel(NotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        [BindProperty]
        public Note Note { get; set; }
        [BindProperty]
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Note = _notesRepository.GetNote(id);
        }
        public IActionResult OnPost()
        {
            if (Note.Title == null || Category.Name == null)
            {
                return Page();
            }

            var noteFromDb = _notesRepository.GetNote(Note.Id);         
            noteFromDb.Title = Note.Title;
            noteFromDb.Content = Note.Content;
            noteFromDb.Category.Name = Category.Name;
            _notesRepository.Update(noteFromDb);

            return RedirectToPage("Index");
            
        }
    }
}
