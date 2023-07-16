using JobSite.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace JobSite.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Пароль слишком простой")]
        public string? Password { get; set; }

    }

}
