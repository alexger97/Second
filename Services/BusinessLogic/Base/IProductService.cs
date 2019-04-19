using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.BusinessLogic.Base
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> func);
        Product GetProduct(int id);
        Product GetProduct(Expression<Func<Product, bool>> func);

        void UpdateProduct(Product product);
        void RemoveProduct(int id);
    }
}