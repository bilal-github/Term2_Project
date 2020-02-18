/** Name: Bilal Ahmad
 * Date: Feb 13, 2020
 * Purpose: Customer properties and validation used in all views
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team5_Workshop5.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "First Name is Required")]
        [DisplayName("First Name")]
        public string CustFirstName { get; set; }//
        [Required(ErrorMessage = "Last Name is Required")]
        [DisplayName("Last Name")]
        public string CustLastName { get; set; }//
        [Required(ErrorMessage = "Address is Required")]
        [DisplayName("Address")]
        public string CustAddress { get; set; }//
        [Required(ErrorMessage = "City is Required")]
        [DisplayName("City")]
        public string CustCity { get; set; }//
        [Required(ErrorMessage = "Province is Required")]
        [StringLength(2, ErrorMessage = "The Province must be 2 characters long.")]
        [DisplayName("Province")]
        public string CustProv { get; set; }//
        [Required(ErrorMessage = "Postal Code is Required")]
        [StringLength(7, ErrorMessage = "The Postal Code must be no loger than 7 characters.")]
        [DisplayName("Postal Code")]
        public string CustPostal { get; set; }//
        [Required(ErrorMessage = "Country is Required")]
        [RegularExpression(@"^(?i)(Canada|US|America|United States|USA|CAN|CA)$", ErrorMessage = "Invalid Country")]
        [DisplayName("Country")]
        public string CustCountry { get; set; }//
        [DisplayName("Home Phone")]
        [RegularExpression(@"([0-9]{10})$", ErrorMessage = "Invalid Phone Number")]
        public string CustHomePhone { get; set; }
        [DisplayName("Business Phone")]
        [RegularExpression(@"([0-9]{10})$", ErrorMessage = "Invalid Phone Number")]
        public string CustBusPhone { get; set; }
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$", ErrorMessage = "Please enter correct email address")]
        [DisplayName("Email")]
        public string CustEmail { get; set; }//
        [Required]
        [DisplayName("UserID")]
        public string UserID { get; set; }//
        [Required]
        [StringLength(25, ErrorMessage = "The Password must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }//
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords don't match")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }//
    }
}