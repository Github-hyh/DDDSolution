using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDD.Application;
using DDD.TransferDTOS;

namespace DDD.WebMvc.Controllers
{
    public class ProductController : Controller
    {
        ProductAppService productappservice =
            new ProductAppService();
        // GET: Product
        public ActionResult Index()
        {
            var productdtos = productappservice.GetAllProductDTO();
            return View(productdtos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductDTO productdto)
        {
            if(ModelState.IsValid)
            {
                productappservice.CreateProduct(productdto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string ProductName)
        {
            var product = productappservice.GetProductDTOByName(ProductName);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(ProductDTO productdto)
        {
            if(ModelState.IsValid)
            {
                productappservice.ModifyProductDTO(productdto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Del(string ProductName)
        {
            productappservice.DropProduct(ProductName);
            return RedirectToAction("Index");
        }
    }
}