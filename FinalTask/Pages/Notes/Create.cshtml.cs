using FinalTask.Areas.Identity.Data;
using FinalTask.Model;
using FinalTask.Repositories;
using FinalTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalTask.Pages.Notes
{
    public class CreateModel : CategorySelectModel
    {
        private readonly NotesRepository _notesRepository;
        private readonly FinalTaskContext _context;

        [BindProperty]
        public Note Note { get; set; }

        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(NotesRepository notesRepository, FinalTaskContext context)
        {
            _notesRepository = notesRepository;
            _context = context;
        }

        public IActionResult OnGet()
        {
            GenerateCategoriesList(_context);
            return Page();
        }


        public IActionResult OnPost()
        {
            if (Note.Title == null)
            {
                return Page();
            }

            _notesRepository.CreateCategory(Category);
            Note.CategoryId = Category.Id;
            _notesRepository.CreateNote(Note);

            return RedirectToPage("Index");
            
        }

    }
}
