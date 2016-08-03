using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductSearch.Controllers;
using ProductSearch.Models;
using System.Web.Mvc;

namespace ProductSearch.Tests
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var controller = new ProductsController();
            var result = controller.Index();
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestNoSearchTextResultsTopSellers()
        {
            var controller = new ProductsController();
            var result = controller.Search("");
            Assert.IsTrue(((List<Product>)result.Data).All(p => p.IsTopSeller));
        }

        [TestMethod]
        public void TestNoSearcResults()
        {
            var controller = new ProductsController();
            var result = controller.Search("sdksldksldkds");
            Assert.AreEqual(0, ((List<Product>)result.Data).Count);
        }

        [TestMethod]
        public void TestSearchResults()
        {
            var controller = new ProductsController();
            var result = controller.Search("blinds");
            Assert.AreNotEqual(0, ((List<Product>)result.Data).Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestException()
        {
            var controller = new ProductsController();
            var result = controller.Search("error");
        }
    }
}
