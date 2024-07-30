using ProductMicroservicesProject.Models;

namespace ProductMicroservicesProject.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetProducts();

        Products GetProductById(int product);

        void InsertProduct(Products products);

        void DeleteProduct(int productId);

        void UpdateProduct(Products products);

        void Save();
    }
}