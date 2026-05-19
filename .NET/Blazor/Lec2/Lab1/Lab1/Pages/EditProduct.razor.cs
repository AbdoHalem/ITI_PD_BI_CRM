using Lab1.Models;
using Microsoft.AspNetCore.Components;

namespace Lab1.Pages
{
    public partial class EditProduct
    {
        [Parameter]
        public int Id { get; set; }

        // Object to hold the edited data
        private Product productToEdit;

        // List to populate the categories dropdown
        private List<Category> categories = new();

        protected override void OnInitialized()
        {
            // Load categories for the dropdown
            categories = CategoryService.GetAll();
        }

        protected override void OnParametersSet()
        {
            // Get the original product from the service
            var originalProduct = ProductService.GetById(Id);

            if (originalProduct != null)
            {
                // IMPORTANT: Create a COPY of the product.
                // If we bind directly to the service's reference, changes will reflect instantly 
                // even if the user cancels, because we are using a static list in memory!
                productToEdit = new Product
                {
                    Id = originalProduct.Id,
                    Name = originalProduct.Name,
                    Price = originalProduct.Price,
                    CatID = originalProduct.CatID,
                    Image = originalProduct.Image
                };
            }
        }

        private void SaveChanges()
        {
            // Send the updated copy back to the service
            ProductService.Update(Id, productToEdit);

            // Navigate back to the catalog after saving
            NavManager.NavigateTo("/catalog");
        }

        private void CancelEdit()
        {
            // Just go back without saving
            NavManager.NavigateTo("/catalog");
        }
    }
}
