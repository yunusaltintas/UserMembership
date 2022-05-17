using System;
using System.Collections.Generic;
using System.Text;

namespace UserMembership.Data.Models
{
    public class UserSignUpViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Mail { get; set; }
        public string UserName { get; set; }
    }
}
