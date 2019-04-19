using DataAccess.Entities;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
   public class ProductTypeService : Base.IProductTypeService
    {

        private IProductTypeRepository _productTypeRepository = null;


        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;


        }
        public IEnumerable<ProductType> GetProductTypes()
        {
            return _productTypeRepository.GetProductTypes();
        }

        public IEnumerable<ProductType> GetProductTypes(Expression<Func<ProductType, bool>> func)
        {
            return _productTypeRepository.GetProductTypes(func);
        }

        
    }
}
