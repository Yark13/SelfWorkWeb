using System.ComponentModel.DataAnnotations;
using WebUniversity.DataLayer;
using WebUniversity.DataLayer.Entity;

namespace WebUniversity.ViewModels
{
    public class CourseViewModel
    {
        [Display(Name = "Id")]
        [UIHint("number")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [UIHint("text")]
        [Required(ErrorMessage = "Enter name of the course")]
        [MinLength(5, ErrorMessage = "Name of a course must be more 5 symbols")]
        [RegularExpression(@"^[A-Za-z'\s0-9]+$", ErrorMessage = "Invalid characters")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [UIHint("text")]
        public string Description { get; set; }

        public PaginatedList<Group>? Mygroups { get; set; }

        public bool HasGroups { get; set; }

        public CourseViewModel()
        {
            HasGroups = false;
        }
    }
}
