using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliVeggie.Services.Products.Manager;
using Microsoft.Extensions.Configuration;

namespace DeliVeggie.Services.Products.Test
{
    [TestClass]
    public class ProductTest
    {        

        public IConfiguration Configuration;
        private ProductManager productManager;

        public ProductTest(){
            this.Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
            this.productManager = new ProductManager(Configuration);
        }

        [TestMethod]
        public void GetProducts_ValidResponse(){
            var products = this.productManager.GetProducts();
            Assert.IsNotNull(products, "Products should not be null");
            Assert.IsTrue(products.Count > 0, "At least one product should be in database");
            
        }
       
    }    
}
