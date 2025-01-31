using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Name jest wymagane!")]
        public string Name { get; set; }

        public List<Book>? Books { get; set; } = new List<Book>();
    }
}