using DDD.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.WebMvc.Controllers
{
    public class SalesOrderController : Controller
    {
        SalesOrderAppService salesorderappservice =
            new SalesOrderAppService();
        ProductAppService productappservice =
            new ProductAppService();
        CustomerAppService customerappservice =
            new CustomerAppService();
        // GET: SalesOrder
        public ActionResult Index()
        {
            var salesorders = salesorderappservice.GetAllSalesOrderDTO();
            return View(salesorders);
        }

        public ActionResult Create()
        {
            var products = productappservice.GetAllProduct();
            var customers = customerappservice.GetAllCustomer();
            ViewBag.ProductName = new SelectList(products, "ProductName", "ProductName");
            ViewBag.CustomerName = new SelectList(customers, "Name", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            //string Customer = Request.Form["CustomerName"];
            string customername = fc["CustomerName"];
            string state = fc["State"];
            string city = fc["City"];
            string street = fc["Street"];

            List<string> productnames = new List<string>();
            string productname = fc["ProductName"];
            productnames.Add(productname);

            List<int> amounts = new List<int>();
            int amount = int.Parse(fc["Amount"]);
            amounts.Add(amount);

            salesorderappservice.CreateSalesOrder(productnames,
                amounts, customername, state, city, street);
            return RedirectToAction("Index");
        }
    }
}