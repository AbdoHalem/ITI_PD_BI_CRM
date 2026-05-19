using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class Product
    {
        public int Id { get; set; }

        // Ensure Name is not empty and has a minimum length
        [Required(ErrorMessage = "Product name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string Name { get; set; }

        // Ensure Price is valid
        [Required(ErrorMessage = "Price is required")]
        [Range(1, 100000, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        public string Image { get; set; }

        // Foreign key to link product to its category
        // Ensure a valid Category is selected (assuming ID 0 is invalid)
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public int CatID { get; set; }
    }
}
