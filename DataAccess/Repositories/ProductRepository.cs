using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public class ProductRepository
        : Base.AbstractRepository, Base.IProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include(x => x.ProductType).ToArray();
        }

        public IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> func)
        {
            return _context.Products.Include(x => x.ProductType).Where(func).ToArray();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Include(x => x.ProductType).FirstOrDefault(x => x.Id == id);
        }

        public Product GetProduct(Expression<Func<Product, bool>> func)
        {
            return _context.Products.Include(x => x.ProductType).FirstOrDefault(func);
        }

        public void UpdateProduct(Product product)
        {
            var oldProduct = GetProduct(product.Id);

            oldProduct.Cost = product.Cost;
            oldProduct.Name = product.Name;
            oldProduct.Description = product.Description;
            oldProduct.ProductTypeId = product.ProductTypeId;

            _context.SaveChanges();
        }


        public void RemoveProduct(int productId)
        {
            var product = GetProduct(productId);

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}