using System.ComponentModel.DataAnnotations;

namespace FinalTask.Model
{
    public class Note
    {
        
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
