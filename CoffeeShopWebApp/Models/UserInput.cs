using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;


namespace CoffeeShopWebApp.Models
{
    public class UserInput
    {
        [RegularExpression("^[A-Za-z]{2,}$", ErrorMessage = "Can only accept letters")]
        [Required(ErrorMessage = "Must enter in a name")]
        public string FirstName { set; get; }

        [RegularExpression("^[A-Za-z]{2,}$", ErrorMessage = "Can only accept letters")]
        [Required(ErrorMessage = "Must enter in a name")]
        public string LastName { set; get; }
        
        public string Email { set; get; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [Required(ErrorMessage = "Must enter in a phone number")]
        public string TelephoneNumber { set; get; }
        

        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$")]
        [Required(ErrorMessage = "Password must have at least eight characters with atleast one letter and one number")]


        public string Password { set; get; }


        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$")]
        [Required(ErrorMessage = "Passwords must match")]
        
        
        public string PasswordTwo { set; get; }



    }
}