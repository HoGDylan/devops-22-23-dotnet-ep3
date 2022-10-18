using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using Shared.Products;
using System.Threading.Tasks;

namespace Client.Products.Components
{
    public partial class Edit
    {
        private ProductDto.Mutate product = new();
        [Parameter] public int ProductId { get; set; }
        [Parameter] public EventCallback OnProductChanged { get; set; }
        [Inject] public IProductService ProductService { get; set; }
        [Inject] public ISidepanelService Sidepanel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ProductRequest.GetDetail request = new()
            {
                ProductId = ProductId,
            };

            var response = await ProductService.GetDetailAsync(request);
            product = new ProductDto.Mutate
            {
                Category = response.Product.CategoryName,
                Description = response.Product.Description,
                InStock = response.Product.IsInStock,
                Name = response.Product.Name,
                Price = response.Product.Price,
            };
        }

        private async Task EditProductAsync()
        {
            ProductRequest.Edit request = new ProductRequest.Edit
            {
                Product = product,
                ProductId = ProductId,
            };

            var response = await ProductService.EditAsync(request);
            await OnProductChanged.InvokeAsync();
            Sidepanel.Close();
        }
    }
}
