using Microsoft.EntityFrameworkCore;
using ProductMicroservicesProject.Models;

namespace ProductMicroservicesProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            _context.Products.Remove(product);
            Save();
        }

        public Products GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public IEnumerable<Products> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void InsertProduct(Products products)
        {
            _context.Add(products);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateProduct(Products products)
        {
            _context.Entry(products).State = EntityState.Modified;
            Save();
        }
    }
}