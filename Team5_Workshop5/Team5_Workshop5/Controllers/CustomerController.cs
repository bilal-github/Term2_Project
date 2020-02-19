/** Name: Bilal Ahmad
 * Date: Feb 13, 2020
 * Purpose: Controller for All Customer related views
 * Every user has a default password of 123123123
     */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team5_Workshop5.Models;

namespace Team5_Workshop5.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.firstName = Session["CustFirstName"];
            return View();
        }
        /// <summary>
        /// Gets a blank registration for new customers to register
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult CustomerRegistration()
        {
            return View();
        }
        /// <summary>
        /// Sends new customer data and creates a record
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CustomerRegistration(Customer customer)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                int customerID = CustomerModel.RetrieveCustomerID(customer.UserID);
                if (customerID == 0)
                {
                    customer.Password = Encryption.Encrypt(customer.Password);
                    Customer newCustomer = CustomerModel.RegisterCustomer(customer);
                    Session["CustFirstName"] = newCustomer.CustFirstName;
                    Session["UserID"] = newCustomer.UserID;
                    ViewBag.firstName = Session["CustFirstName"];
                    return RedirectToAction("PersonalInformation", "Customer");
                }
                else
                {
                    ViewBag.message = "UserID already exists, Choose another UserID";
                }
            }
            return View(customer);

        }
        /// <summary>
        /// brings the login screen
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult LoginCustomer()
        {
            return View();
        }
        /// <summary>
        /// Checks login credentials and logs in customer 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoginCustomer(Customer customer)
        {

            if ((customer.UserID != null) && (customer.Password != null))
            {

                string hashedPassword = CustomerModel.retrievePasswordHash(customer.UserID);
                if (hashedPassword != null)
                {
                    bool CheckPassword = Encryption.Verify(customer.Password, hashedPassword);
                    if (CheckPassword == true)
                    {
                        int customerID = CustomerModel.RetrieveCustomerID(customer.UserID);
                        customer = CustomerModel.GetCustomerInfo(customer.UserID);
                        Session["CustFirstName"] = customer.CustFirstName;
                        Session["UserID"] = customer.UserID;
                        Session["CustomerID"] = customerID;
                        ViewBag.firstName = Session["CustFirstName"];
                        ViewBag.message = "Valid User";
                        return RedirectToAction("PersonalInformation", "Customer");
                    }
                    else
                    {
                        ViewBag.message = "UserID and Password don't match";
                        return View();
                    }
                }
                else
                {
                    ViewBag.message = "UserID doesn't Exist";
                    return View();
                }
            }
            return View();
        }
        /// <summary>
        /// Gets all customer information and shows it as a summary
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PersonalInformation()
        {
            if (Session["UserID"] != null)
            {
                string UserID = Session["UserID"].ToString();
                Customer customer = CustomerModel.GetCustomerInfo(UserID);
                return View(customer);
            }
            else
            {
                return RedirectToAction("LoginCustomer", "Customer");
            }

        }
        /// <summary>
        /// Redirects to updateinformation page, so the information can be updated
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PersonalInformation(Customer customer)
        {
            return RedirectToAction("UpdatePersonalInformation", "Customer");
        }
        /// <summary>
        /// Gets all customer info so it can be edited
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdatePersonalInformation()
        {
            if (Session["UserID"] != null)
            {
                string UserID = Session["UserID"].ToString();
                Customer customer = CustomerModel.GetCustomerInfo(UserID);
                return View(customer);
            }
            else
            {
                return RedirectToAction("LoginCustomer", "Customer");
            }
        }
        /// <summary>
        /// Sends the updated information to database and updates the record
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdatePersonalInformation(Customer customer)
        {
            if (ModelState.IsValid)
            {
                string UserID = Session["UserID"].ToString();

                if (UserID == customer.UserID)
                {
                    int customerID = CustomerModel.RetrieveCustomerID(UserID);
                    customer.Password = Encryption.Encrypt(customer.Password);
                    Customer updatedcustomer = CustomerModel.UpdateCustomer(customer, customerID);
                    Session["UserID"] = updatedcustomer.UserID;
                    Session["CustFirstName"] = customer.CustFirstName;
                    return RedirectToAction("PersonalInformation", "Customer");
                }
                else
                {
                    int newCustomerID = CustomerModel.RetrieveCustomerID(customer.UserID);
                    if (newCustomerID == 0)
                    {
                        int oldCustomerID = CustomerModel.RetrieveCustomerID(UserID);
                        customer.Password = Encryption.Encrypt(customer.Password);
                        Customer updatedcustomer = CustomerModel.UpdateCustomer(customer, oldCustomerID);
                        Session["UserID"] = updatedcustomer.UserID;
                        Session["CustFirstName"] = updatedcustomer.CustFirstName;
                        return RedirectToAction("PersonalInformation", "Customer");
                    }
                    else
                    {
                        ViewBag.message = "UserID already exists, Choose another UserID";
                    }
                }
            }
            return View(customer);


        }
        /// <summary>
        /// logs out the customer by clearing the session variables
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Logout()
        {
            Session["CustFirstName"] = null;
            Session["UserID"] = null;
            Session["CustomerID"] = null;
            return RedirectToAction("LoginCustomer", "Customer");

        }
    }
}