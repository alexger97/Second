using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Services.BusinessLogic.Base;

namespace Web.Controllers
{
    public class DefaultController
        : Controller
    {
        private IUserService _userService = null;
        private IRoleService _roleService = null;
        private IGroupService _groupService = null;

        public DefaultController(
            IUserService userService,
            IRoleService roleService,
            IGroupService groupService)
        {
            _userService = userService;
            _roleService = roleService;
            _groupService = groupService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var result = _userService.GetAllUsers();
            return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}