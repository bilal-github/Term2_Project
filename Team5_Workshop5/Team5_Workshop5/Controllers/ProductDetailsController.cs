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
        public ViewResult Index()
        {
            int custId = 135; // Needs to be passed in from session
            List<ProductDetails> pdList = new List<ProductDetails>();
            pdList = ProductDetailsDB.GetProductDetails(custId);
            return View(pdList);
        }

        // GET: ProductDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductDetails/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
