﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDD.Domain;
using DDD.Repository;
using DDD.Repository.Repositories;
using DDD.Application;
using System.Collections.Generic;
using DDD.TransferDTOS;

namespace DDD.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        EFRepositoryContext context = new EFRepositoryContext();

        [TestMethod]
        public void CreateProduct()
        {
            //Product product = new Product(new ProductRepository());
            ProductAppService product = new ProductAppService();
            //product.CreateProduct("P1", "Red", "Small", 100, 55, "C1", "T-Shirt");
            //product.CreateProduct("P2", "Green", "Big", 200, 44, "C2", "Sports");
            //context.Commit();
            ProductDTO productdto = new ProductDTO();
            productdto.Name = "P3";
            productdto.Color = "Blue";
            productdto.Size = "Middle";
            productdto.Amount = 5000;
            productdto.UnitPrice = 10;
            productdto.PCategoryName = "C3";
            productdto.PDescription = "正装";
            product.CreateProduct(productdto);
            context.Commit();

            Assert.IsNotNull(product.GetProductByName("P3"));
        }

        [TestMethod]
        public void GetproductDTOByName()
        {
            ProductAppService productappservice =
                new ProductAppService();
            var productdto = productappservice.GetProductDTOByName("P3");
            Assert.AreEqual("P3", productdto.Name);
            Assert.AreEqual("C3", productdto.PCategoryName);
        }

        [TestMethod]
        public void CreateCustomer()
        {
            Customer customer = new Customer(new CustomerRepository());
            customer.CreateCustomer("Dick", "10086", "Sichuan", "Chengdu", "58 Street");
            context.Commit();

            Assert.IsNotNull(customer.GetCustomerByName("Dick"));
        }

        [TestMethod]
        public void CreateSalesOrder()
        {
            SalesOrderAppService salesOrder = new SalesOrderAppService();
            List<string> productNames = new List<string>() { "P1", "P2" };
            List<int> amounts = new List<int>() { 10, 20 };
            salesOrder.CreateSalesOrder(productNames,amounts,"Dick", "Sichuan", "Chengdu", "58 Street");
        }
    }
}
