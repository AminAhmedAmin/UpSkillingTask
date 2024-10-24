using System.ComponentModel.DataAnnotations;
using UpSkillingTask.Models;

namespace UpSkillingTask.DTOs.CategoryDtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
