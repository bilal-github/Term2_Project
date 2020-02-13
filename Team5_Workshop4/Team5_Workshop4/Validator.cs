/*
 * Author: Bilal Ahmad
 * Date: December 07, 2019
 * Purpose: Class that holds all of the validation for inputs. 
 *  checks for value present, positive and negative and the type of the input (int, double or decimal)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // for MessageBox

namespace Team5_Workshop4
{
    //repository of validation methods
    public static class Validator
    {
        // method to check if fields have input
        public static bool IsPresent(TextBox tb, string name)
        {
            bool valid = true; // tb has input
            if (tb.Text == "")
            {
                valid = false;
                MessageBox.Show(name + " is required", "Input Error");
                tb.Focus();
            }

            return valid;
        }//ends IsPresent method

        // method to check if value is in int32
        public static bool IsInt32(TextBox tb, string name)
        {
            bool valid = true;
            int val;

            if(!Int32.TryParse(tb.Text, out val))
            {
                valid = false;
                MessageBox.Show(name + " must be a whole number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        // method to check the value is a positive int32
        public static bool IsNonNegativeInt32(TextBox tb, string name)
        {
            bool valid = true;
            int val;

            if (!Int32.TryParse(tb.Text, out val)) //not int32
            {
                valid = false;
                MessageBox.Show(name + " must be a whole number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            else if (val < 0) // negative
            {
                valid = false;
                MessageBox.Show(name + " Must be positive or zero", "Negative Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        // method to check the value is a double
        public static bool IsDouble(TextBox tb, string name)
        {
            bool valid = true;
            double val;

            if (!Double.TryParse(tb.Text, out val))
            {
                valid = false;
                MessageBox.Show(name + " must be a number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        
        // method to check the value is a positive double 
        public static bool IsNonNegativeDouble(TextBox tb, string name)
        {
            bool valid = true;
            double val;

            if (!Double.TryParse(tb.Text, out val)) // not a double
            {
                valid = false;
                MessageBox.Show(name + " must be a whole number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            else if (val < 0) // negative
            {
                valid = false;
                MessageBox.Show(name + " Must be positive or zero", "Negative Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        //method to check if the number is a decimal
        public static bool IsDecimal(TextBox tb, string name)
        {
            bool valid = true;
            decimal val;

            if (!Decimal.TryParse(tb.Text, out val))
            {
                valid = false;
                MessageBox.Show(name + " must be a number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        // method to check if the value is a positive decimal
        public static bool IsNonNegativeDecimal(TextBox tb, string name)
        {
            bool valid = true;
            decimal val;

            if (!Decimal.TryParse(tb.Text, out val)) // not a double
            {
                valid = false;
                MessageBox.Show(name + " must be a whole number", "Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            else if (val < 0) // negative
            {
                valid = false;
                MessageBox.Show(name + " Must be positive or zero", "Negative Input Error");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        // method to check if the keypressevent is a valid character
        public static bool IsNameString(TextBox tb, string name, KeyPressEventArgs e)
        {
            bool valid = true;

            /*  e.KeyChar contains the character that was pressed
             e.Handled is a boolean that indicates that handling is done            
            if a bad character is entered, set e.Handled to true
            */
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-' &&
              e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                valid = false;
                MessageBox.Show(name+ " can only accept letters, space, - and .");
                tb.Focus();

            }
            return valid;
        }

    }//ends class
}//ends namespace
