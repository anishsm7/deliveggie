using DeliVeggie.Common.Models;
using System.Collections.Generic;
using DeliVeggie.Services.Products.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DeliVeggie.Services.Products.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductMdo> GetProducts();
        ProductMdo GetProduct(string productId);        
    }
}