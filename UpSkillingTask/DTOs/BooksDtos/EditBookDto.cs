using System.ComponentModel.DataAnnotations;

namespace UpSkillingTask.DTOs.BooksDtos
{
    public class EditBookDto
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The Name field cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The Price must be a non-negative value.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Author field is required.")]
        public string Author { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The Stock must be a non-negative value.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "The CategoryId field is required.")]
        public int CategoryId { get; set; }
    }
}
