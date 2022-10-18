using Append.Blazor.Sidepanel;
using Client.Extensions;
using Client.Products.Components;
using Microsoft.AspNetCore.Components;
using Shared.Products;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Client.Products
{
    public partial class Detail
    {
        private ProductDto.Detail product;
        private bool isRequestingDelete;
        [Parameter] public int Id { get; set; }
        [Inject] public IProductService ProductService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public ISidepanelService Sidepanel { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await GetProductDetails();
        }

        private async Task GetProductDetails()
        {
            ProductRequest.GetDetail request = new() { ProductId = Id };
            var response = await ProductService.GetDetailAsync(request);
            product = response.Product;
        }

        private void RequestDelete()
        {
            isRequestingDelete = true;
        }

        private void CancelDeleteRequest()
        {
            isRequestingDelete = false;
        }

        private async Task DeleteProductAsync()
        {
            var request = new ProductRequest.Delete { ProductId = Id };
            await ProductService.DeleteAsync(request);
            NavigationManager.NavigateTo("/");
        }

        private void OpenEditForm()
        {
            var callback = EventCallback.Factory.Create(this, GetProductDetails);

            var parameters = new Dictionary<string, object>
            {
                { nameof(Edit.ProductId), product.Id },
                { nameof(Edit.OnProductChanged),callback  }
            };
            Sidepanel.Open<Edit>("Product", "Wijzigen", parameters);
        }

    }
}
