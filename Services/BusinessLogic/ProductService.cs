using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories.Base;

namespace Services.BusinessLogic
{
    public class ProductService
        : Base.IProductService
    {
        private IProductRepository _productRepository = null;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> func)
        {
            return _productRepository.GetProducts(func);
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        public Product GetProduct(Expression<Func<Product, bool>> func)
        {
            return _productRepository.GetProduct(func);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

        public void RemoveProduct(int porductId)
        {
            _productRepository.RemoveProduct(porductId);
        }
    }
}
