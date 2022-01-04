﻿using System.ComponentModel.DataAnnotations;

namespace Exam.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не вказаний логін")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
