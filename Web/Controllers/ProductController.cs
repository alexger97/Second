using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Entities;
using Services.BusinessLogic.Base;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService = null;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var products = _productService.GetProducts();

            return View(products);
        }

        [HttpGet]
        public JsonResult RemoveProduct(int productId)
        {
            _productService.RemoveProduct(productId);

            return Json(new { isRemoved = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
                return Json(new { isSaved = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { isSaved = false }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetProductPartial(int productId)
        {
            var product = _productService.GetProduct(productId);

            return PartialView("Modal/_ProductPartial", product);
        }
    }
}