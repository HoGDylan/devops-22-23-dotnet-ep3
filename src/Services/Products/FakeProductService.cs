using Domain.Common;
using Domain.Products;
using Shared.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Products
{
    public class FakeProductService : IProductService
    {
        private static readonly List<Product> products = new();
        static FakeProductService()
        {
            var productFaker = new ProductFaker();
            products = productFaker.Generate(10);
        }

        public async Task<ProductResponse.GetDetail> GetDetailAsync(ProductRequest.GetDetail request)
        {
            await Task.Delay(100);
            ProductResponse.GetDetail response = new();
            response.Product = products.Select(x => new ProductDto.Detail
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price.Value,
                IsEnabled = x.IsEnabled,
                IsInStock = x.InStock,
                Imagepath = x.ImageUrl,
                CategoryName = x.Category.Name,
            }).SingleOrDefault(x => x.Id == request.ProductId);
            return response;
        }

        public async Task<ProductResponse.GetIndex> GetIndexAsync(ProductRequest.GetIndex request)
        {
            await Task.Delay(100);
            ProductResponse.GetIndex response = new();
            response.Products = products.Select(x => new ProductDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price.Value,
                Imagepath = x.ImageUrl,
            }).ToList();
            return response;
        }

        public async Task DeleteAsync(ProductRequest.Delete request)
        {
            await Task.Delay(100);
            var p = products.SingleOrDefault(x => x.Id == request.ProductId);
            products.Remove(p);
        }

        public async Task<ProductResponse.Create> CreateAsync(ProductRequest.Create request)
        {
            await Task.Delay(100);
            ProductResponse.Create response = new();

            var model = request.Product;
            var price = new Money(model.Price);
            var category = new Category(model.Category);
            var product = new Product(model.Name, model.Description, price, model.InStock, null, category)
            {
                Id = products.Max(x => x.Id) + 1
            };

            products.Add(product);
            response.ProductId = product.Id;

            return response;
        }

        public async Task<ProductResponse.Edit> EditAsync(ProductRequest.Edit request)
        {
            await Task.Delay(100);
            var product = products.Single(x => x.Id == request.ProductId);

            product.InStock = request.Product.InStock;
            product.Name = request.Product.Name;
            product.Description = request.Product.Description;
            product.Category = new(request.Product.Category);
            product.Price = new(request.Product.Price);

            ProductResponse.Edit response = new();
            response.ProductId = product.Id;
            return response;
        }
    }

}
