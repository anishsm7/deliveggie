using DeliVeggie.Common.Models;
using System.Collections.Generic;

namespace DeliVeggie.Services.Products.Interfaces
{
    public interface IProductManager
    {
        List<ProductDto> GetProducts();
        ProductDto GetProduct(string productId);
    }
}