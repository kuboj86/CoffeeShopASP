using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopWebApp.Models
{
    public class UserInput
    {
        public UserInput()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            TelephoneNumber = 0;
            Password = "";
        }

        public UserInput(string firstname, string lastname, string email, int telephonenumber, string password)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.TelephoneNumber = telephonenumber;
            this.Password = password;
        }
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string LastName { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public int TelephoneNumber { set; get; }
        [Required]
        public string Password { set; get; }
        
            
        
    }
}