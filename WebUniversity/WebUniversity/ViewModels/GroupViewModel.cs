using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebUniversity.DataLayer;
using WebUniversity.DataLayer.Entity;

namespace WebUniversity.ViewModels
{
    public class GroupViewModel
    {
        [Display(Name = "Id")]
        [UIHint("number")]
        public int? Id { get; set; }

        [Display(Name = "Name")]
        [UIHint("text")]
        [Required(ErrorMessage = "Enter name of the group")]
        [MinLength(2, ErrorMessage = "Name of a course must be more 2 symbols")]
        public string Name { get; set; }

        [Display(Name = "Course Id")]
        [UIHint("number")]
        [Required(ErrorMessage = "Enter the course id of the group")]
        public int CourseID { get; set; }

        public PaginatedList<Student>? MyStudents { get; set; }

        public List<SelectListItem>? existingCourses { get; set; }

        public bool HasStudents { get; set; }

        public GroupViewModel()
        {
            HasStudents = false;
        }
    }
}
