using Append.Blazor.Sidepanel;
using Client.Products.Components;
using Microsoft.AspNetCore.Components;
using Shared.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Products
{
    public partial class Index
    {
        [Inject] public ISidepanelService Sidepanel { get; set; }
        [Inject] public IProductService ProductService { get; set; }
        private List<ProductDto.Index> products;

        protected override async Task OnInitializedAsync()
        {
            ProductRequest.GetIndex request = new();
            var response = await ProductService.GetIndexAsync(request);
            products = response.Products;
        }

        private void OpenCreateForm()
        {
            Sidepanel.Open<Create>("Product", "Toevoegen");
        }
    }
}
