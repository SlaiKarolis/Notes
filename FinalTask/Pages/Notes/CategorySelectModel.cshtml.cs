using FinalTask.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalTask.Pages.Notes
{
    public class CategorySelectModel : PageModel
    {
        public SelectList CategoriesNames { get; set; }
        public void GenerateCategoriesList(FinalTaskContext context, object selectedCategory = null)
        {
            var categoriesQuery = context.Categories.OrderBy(c => c.Name);
            CategoriesNames = new SelectList(categoriesQuery.AsNoTracking(), "Id", "Name", selectedCategory);
        }
    }
}
