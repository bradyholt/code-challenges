using ProductSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductSearch.Controllers
{
    public class ProductsController : Controller
    {
        public ViewResult Index()
        {
            return View("Index");
        }

        public JsonResult Search(string searchtext)
        {
            List<Product> results = null;

            //use product mocker
            IDataContext<Product> context = new ProductMocker();

            Repository<Product> repo = new Repository<Product>(context);
          
            if (string.IsNullOrEmpty(searchtext))
            {
                //no seach text so just return popular products
                results = repo.LoadPopular();
            }
            else
            {
                results = repo.Search(searchtext);
            }

            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}
