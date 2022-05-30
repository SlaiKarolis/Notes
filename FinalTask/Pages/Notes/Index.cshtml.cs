using System.Security.Claims;
using FinalTask.Model;
using FinalTask.Repositories;
using FinalTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalTask.Pages.Notes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly NotesRepository _repository;
        

        public IndexModel(NotesRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public List<Note> Notes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchInput { get; set; }
        public SelectList Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedItem { get; set; }

        public void OnGet()
        {
            var categories = _repository.GetCategories();
            Categories = new SelectList(categories);
            Notes = _repository.GetNotes(SearchInput, SelectedItem);
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var notes = _repository.GetNote(id);
            if (notes == null)
            {
                return NotFound();
            }
            _repository.DeleteNote(id);
            return RedirectToPage("Index");
        }
    }
}
