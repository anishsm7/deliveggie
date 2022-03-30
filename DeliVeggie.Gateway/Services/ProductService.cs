using System;
using System.Collections.Generic;
using System.Linq;
using DeliVeggie.Common.Models;
using DeliVeggie.Common.Models.Messages;
using DeliVeggie.Gateway.Models;
using EasyNetQ;
using Microsoft.Extensions.Configuration;

namespace DeliVeggie.Gateway.Services
{
    public class ProductService
    {
        public IConfiguration Configuration;
        public ProductService(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            var request = new ProductsRequest();
            var response = GetResponse<ProductsRequest, ProductsResponse>(request);
            return response.Products.Select(x => MapProductResponseToModel(x)).ToList();
        }

        public ProductModel GetProduct(string ProductId)
        {
            var request = new ProductRequest() { ProductId = ProductId };
            var response = GetResponse<ProductRequest, ProductResponse>(request);
            return MapProductResponseToModel(response.Product);
        }

        private ProductModel MapProductResponseToModel(ProductDto productDto){
            return new ProductModel{Id = productDto.Id, Name = productDto.Name, EntryDate = productDto.EntryDate, Price = productDto.Price};
        }

        private string GetConnectionString(){
            return Configuration["RabbitMq:Host"];
        }

        private T GetResponse<R, T>(R request)
        {
            using (var bus = RabbitHutch.CreateBus(this.GetConnectionString()))
            {
                return bus.Rpc.Request<R, T>(request);
            }
        }
    }

    
}
