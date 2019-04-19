using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
  public  class ProductTypeRepository : Base.AbstractRepository, Base.IProductTypeRepository
    {

     
        public IEnumerable<ProductType> GetProductTypes()
        {
            return _context.ProductTypes.ToArray();
        }

        public IEnumerable<ProductType> GetProductTypes(Expression<Func<ProductType, bool>> func)
        {
            return _context.ProductTypes.Where(func).ToArray();
        }
    }
}
