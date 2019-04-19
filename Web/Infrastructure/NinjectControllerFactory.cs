using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using DataAccess.Repositories;
using DataAccess.Repositories.Base;
using Ninject;
using Services.BusinessLogic;
using Services.BusinessLogic.Base;

namespace Web.Infrastructure
{
    public class NinjectControllerFactory
        : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();

            AddBindings();
        }

        public void AddBindings()
        {
            _kernel.Bind<IUserRepository>().To<UserRepository>();
            _kernel.Bind<IGroupRepository>().To<GroupRepository>();
            _kernel.Bind<IRoleRepository>().To<RoleRepository>();
            _kernel.Bind<IProductRepository>().To<ProductRepository>();
            _kernel.Bind<IProductTypeRepository>().To<ProductTypeRepository>();

            _kernel.Bind<IUserService>().To<UserService>();
            _kernel.Bind<IRoleService>().To<RoleService>();
            _kernel.Bind<IGroupService>().To<GroupService>();
            _kernel.Bind<IProductService>().To<ProductService>();
            _kernel.Bind<IProductTypeService>().To<ProductTypeService>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            return (IController)_kernel.Get(controllerType);
        }
    }
}