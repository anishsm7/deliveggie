using DeliVeggie.Services.Products.Repository;
using Microsoft.Extensions.Configuration;
using DeliVeggie.Common.Models;
using DeliVeggie.Common.Models.Messages;
using System.Collections.Generic;
using DeliVeggie.Services.Products.Interfaces;
using System.Linq;
using EasyNetQ;

namespace DeliVeggie.Services.Products.Manager
{
    public class ProductManager : IProductManager
    {
        private IProductRepository productRepository;
        private IBus messageBus;

        public ProductManager(IConfiguration Configuration, IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            messageBus = RabbitHutch.CreateBus(GetRabbitMqConnectionString(Configuration));

            messageBus.Rpc.Respond<ProductsRequest, ProductsResponse>(request => new ProductsResponse
            {
                Products = this.GetProducts()
            });

            messageBus.Rpc.Respond<ProductRequest, ProductResponse>(request => new ProductResponse
            {
                Product = this.GetProduct(request.ProductId)
            });
        }

        public List<ProductDto> GetProducts()
        {
            var result = this.productRepository.GetProducts();
            return result.Select(x => new Common.Models.ProductDto { Id = x.Id, EntryDate = x.EntryDate, Name = x.Name, Price = x.Price }).ToList();
        }

        public Common.Models.ProductDto GetProduct(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
                return null;
            var result = this.productRepository.GetProduct(productId);
            return new Common.Models.ProductDto { Id = result.Id, EntryDate = result.EntryDate, Name = result.Name, Price = result.Price };
        }

        private string GetRabbitMqConnectionString(IConfiguration Configuration)
        {
            return Configuration["RabbitMq:Host"];
        }
    }

}