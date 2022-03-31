using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliVeggie.Services.Products.Manager;
using Microsoft.Extensions.Configuration;
using DeliVeggie.Services.Products.Interfaces;
using DeliVeggie.Services.Products.Repository;

namespace DeliVeggie.Services.Products.Test
{
    [TestClass]
    public class ProductTest
    {
        public IConfiguration Configuration;
        private ProductManager productManager;

        public ProductTest()
        {
            this.Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
            IProductRepository productRepository = new ProductRepository(Configuration);
            this.productManager = new ProductManager(Configuration, productRepository);
        }

        [TestMethod]
        public void GetProducts_ValidResponse()
        {
            var products = this.productManager.GetProducts();
            Assert.IsNotNull(products, "Products not null");
            Assert.IsTrue(products.Count > 0, "Product count should not be0");
        }

         [TestMethod]
        public void GetProduct_ValidResponse()
        {
            var product = this.productManager.GetProduct("6241ec2788c657a26d7ccdee");
            Assert.IsNotNull(product, "Product details not null");            
        }

    }
}
