using System.ComponentModel.DataAnnotations;

namespace TangyAPI.DTOs
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(15, ErrorMessage = "Category name can not exeed 15 caractors")]
        public required string Name { get; set; }
    }
}
