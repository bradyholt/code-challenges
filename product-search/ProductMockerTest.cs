using System;
using System.Collections.Generic;
using ProductSearch.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductSearch.Test
{
    [TestClass]
    public class ProductMockerTest
    {
        private ProductMocker m_mocker;

        [TestInitialize]
        public void Init()
        {
            m_mocker = new ProductMocker();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestException()
        {
            m_mocker.Search("error");
        }

        [TestMethod]
        public void TestNoResults()
        {
            List<Product> results = m_mocker.Search("sdksdksdlsdklsdklsdkdslk");
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestResults()
        {
            List<Product> results = m_mocker.Search("blinds");
            Assert.AreNotEqual(0, results.Count);

            results = m_mocker.Search("BLINDS");
            Assert.AreNotEqual(0, results.Count);
        }
    }
}
