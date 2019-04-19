using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Login
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Поле обязательны для заполнения")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле обязательны для заполнения")]
        public string Password { get; set; }
    }
}