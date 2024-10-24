using System.ComponentModel.DataAnnotations;

namespace UpSkillingTask.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Author { get; set; }

        public int Stock { get; set; }

        public  int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
