using System.ComponentModel.DataAnnotations;

namespace UpSkillingTask.DTOs.CategoryDtos
{
    public class AddCategoryDto
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }  
    }
}
