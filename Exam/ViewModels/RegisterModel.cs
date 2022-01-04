using System.ComponentModel.DataAnnotations;

namespace Exam.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не вказаний логін")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не вказане ім'я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не вказане прізвище")]
        public string Surname { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль ввели некоректно")]
        public string ConfirmPassword { get; set; }
    }
}
