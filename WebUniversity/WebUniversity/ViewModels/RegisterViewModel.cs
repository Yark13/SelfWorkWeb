using System.ComponentModel.DataAnnotations;

namespace WebUniversity.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Login")]
        [UIHint("text")]
        [Required(ErrorMessage = "Enter your login")]
        [MinLength(5, ErrorMessage = "Login must have more 5 symbols")]
        [MaxLength(100, ErrorMessage = "Login must have less 100 symbols")]
        public string Login { get; set; }

        [Display(Name = "Password")]
        [UIHint("Password")]
        [Required(ErrorMessage = "Enter your password")]
        [MinLength(10, ErrorMessage = "Password must have more 10 symbols")]
        [MaxLength(50, ErrorMessage = "Login must have less 50 symbols")]
        public string Password { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is RegisterViewModel vm)
            {
                return vm.Login == Login && vm.Password == Password;
            }

            return false;
        }
    }
}
