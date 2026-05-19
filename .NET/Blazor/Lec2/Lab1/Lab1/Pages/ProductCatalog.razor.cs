using Lab1.Models;
using Microsoft.AspNetCore.Components;

namespace Lab1.Pages
{
    public partial class ProductCatalog
    {
        // 1. Declare the state variables
        private List<Category> catAll = new();
        private List<Product> ProductResult = new();

        // Store the currently selected Category ID
        private int CatID = 0;

        // 2. Initialize data when the component loads
        protected override void OnInitialized()
        {
            // Fetching data from the injected services instead of hardcoded lists
            catAll = CategoryService.GetAll();
            ProductResult = ProductService.GetAll();
        }

        // 3. Handle the dropdown selection change
        private void FilterProducts(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value?.ToString(), out int selectedId))
            {
                CatID = selectedId;

                if (CatID == 0)
                {
                    ProductResult = ProductService.GetAll();
                }
                else
                {
                    // Using the specific service method we defined in IProductService
                    ProductResult = ProductService.GetProductsByCategoryId(CatID);
                }
            }
        }

        private void NavigateToDetails(int productId)
        {
            // Programmatic routing using NavigationManager
            NavManager.NavigateTo($"/product/{productId}");
        }

        private void NavigateToEdit(int productId)
        {
            NavManager.NavigateTo($"/edit-product/{productId}");
        }
    }
}
