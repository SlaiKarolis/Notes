using System.ComponentModel.DataAnnotations;

namespace FinalTask.Model
{
    public class Category
    {
        public string FinalTaskUserId { get; set; }
        public int Id { get; set; }
        [Display(Name="Category Name")]
        public string Name { get; set; }
        public List <Note> Notes { get; set; }
    }
}
