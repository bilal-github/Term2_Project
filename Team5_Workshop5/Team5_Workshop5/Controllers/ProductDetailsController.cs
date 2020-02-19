/*
 * Name: Ivan Lo and Elias Nahas
 * Date: Feb 13, 2020
 * Purpose: Methods to create and populate bookings list
 */

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
        /// <summary>
        /// Gets Customer ID from browser session and
        /// passes it to the bookings list view database method
        /// to create a list of bookings to display
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                int custId = Convert.ToInt32(Session["CustomerID"]);
                List<ProductDetails> pdList = new List<ProductDetails>();
                pdList = ProductDetailsDB.GetProductDetails(custId);
                decimal total = 0;

                // Keeps a running total of all bookings and stores it in
                // ViewBag.total
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