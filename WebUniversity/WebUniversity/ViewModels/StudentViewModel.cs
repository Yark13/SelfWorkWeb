using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebUniversity.ViewModels
{
    public class StudentViewModel
    {
        [Display(Name = "Id")]
        [UIHint("number")]
        public int Id { get; set; }

        [Display(Name = "Group Id")]
        [UIHint("number")]
        [Required(ErrorMessage = "Enter group Id of the Student")]
        public int GroupId { get; set; }

        [Display(Name = "Last name")]
        [UIHint("text")]
        [Required(ErrorMessage = "Enter last name of the student")]
        [MinLength(2, ErrorMessage = "Name must be more 2 symbols")]
        [RegularExpression(@"^[A-Za-z'\s]+$", ErrorMessage = "Invalid characters!")]
        public string LastName { get; set; }

        [Display(Name = "First name")]
        [UIHint("text")]
        [Required(ErrorMessage = "Enter first name of the student")]
        [MinLength(2, ErrorMessage = "Name must be more 2 symbols")]
        [RegularExpression(@"^[A-Za-z'\s]+$", ErrorMessage = "Invalid characters!")]
        public string FirstName { get; set; }

        public List<SelectListItem>? existingGroups { get; set; }
    }
}
