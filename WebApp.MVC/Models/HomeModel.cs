using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.MVC.Models
{
    public class HomeModel
    {
        [Display(Name = "ユーザーID")]
        [Required(ErrorMessage = "ユーザーIDは必須入力です。")]
        public string UserId { get; set; }

        [Display(Name = "パスワード")]
        [Required(ErrorMessage = "パスワードは必須入力です。")]
        public string Password { get; set; }
    }
}