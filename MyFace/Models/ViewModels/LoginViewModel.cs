using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFace.Models.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}