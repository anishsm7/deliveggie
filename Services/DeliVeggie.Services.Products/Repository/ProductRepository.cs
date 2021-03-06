using System;
using System.Collections.Generic;
using DeliVeggie.Services.Products.Entities;
using DeliVeggie.Services.Products.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DeliVeggie.Services.Products.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IMongoCollection<ProductMdo> collection;
        public IConfiguration Configuration { get; }
        public ProductRepository(IConfiguration configuration)
        {
            this.collection = this.InitializeMongo(configuration);      
        }

        public IEnumerable<ProductMdo> GetProducts(){

            var filter = Builders<ProductMdo>.Filter.Empty;
            var result =  this.collection.Find(filter);
            return result?.ToList();
        }

        public ProductMdo GetProduct(string productId){

            var filter = Builders<ProductMdo>.Filter.Where(p => p.Id.Equals(productId));
            var result = this.collection.Find(filter);
            return result?.FirstOrDefault();
        }

        private IMongoCollection<ProductMdo> InitializeMongo(IConfiguration configuration){
            string connectionString =  configuration["MongoSettings:ConnectionString"];
            var mongoUrl = new MongoUrl(connectionString);
            var dbname = mongoUrl.DatabaseName;
            var db = new MongoClient(mongoUrl).GetDatabase(dbname);
            return db.GetCollection<ProductMdo>("Product");
        }
    }
}