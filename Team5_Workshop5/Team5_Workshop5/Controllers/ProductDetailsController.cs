using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team5_Workshop5.Models;

namespace Team5_Workshop5.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: ProductDetails
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                int custId = Convert.ToInt32(Session["CustomerID"]); // Needs to be passed in from session
                List<ProductDetails> pdList = new List<ProductDetails>();
                pdList = ProductDetailsDB.GetProductDetails(custId);
                decimal total = 0;
                foreach (ProductDetails p in pdList)
                {
                    total += p.Price;
                }
                ViewBag.total = total;
                return View(pdList);
            }
            else
            {
                return RedirectToAction("LoginCustomer", "Customer");
            }
        }

        //// GET: ProductDetails/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
    }
}