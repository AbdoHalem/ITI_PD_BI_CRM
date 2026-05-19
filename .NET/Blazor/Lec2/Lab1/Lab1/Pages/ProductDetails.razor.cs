using Lab1.Models;
using Microsoft.AspNetCore.Components;

namespace Lab1.Pages
{
    public partial class ProductDetails
    {
        // Declaring the route parameter. It must be public and have the [Parameter] attribute
        [Parameter]
        public int Id { get; set; }

        private Product currentProduct;

        // This lifecycle method runs when the parameter is passed to the component
        protected override void OnParametersSet()
        {
            // Fetch the specific product details using the service
            currentProduct = ProductService.GetById(Id);
        }

        private void BackToCatalog()
        {
            NavManager.NavigateTo("/catalog");
        }
    }
}
