using SampleProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace SampleProject
{
public class ProductRepository
{
    private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 50000 },
        new Product { Id = 2, Name = "Mouse", Price = 500 },
        new Product { Id = 3, Name = "Keyboard", Price = 1000 }
    };

    public List<Product> GetAll() => _products;

    public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product)
    {
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
    }

    public void Update(Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Id == product.Id);

        if (existing != null)
        {
            existing.Name = product.Name;
            existing.Price = product.Price;
        }
    }

    public void Delete(int id) => _products.RemoveAll(p => p.Id == id);
}

}