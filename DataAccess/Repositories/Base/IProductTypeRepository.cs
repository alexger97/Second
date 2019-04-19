using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Base
{
   public interface IProductTypeRepository
    {
        IEnumerable<ProductType> GetProductTypes();
        IEnumerable<ProductType> GetProductTypes(Expression<Func<ProductType,bool>> func);
    }
}
