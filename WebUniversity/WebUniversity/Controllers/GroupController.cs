using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUniversity.DataLayer;
using WebUniversity.DataLayer.Entity;
using WebUniversity.DataLayer.UnitOfWork;
using WebUniversity.ViewModels;

namespace WebUniversity.Controllers
{
    public class GroupController : EntityController<Group>
    {
        public GroupController(ILogger<GroupController> logger, IUnitOfWork<StateDbContext> unitOfWork, IMapper mapper) : base(logger, unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["CourseIdSortParm"] = sortOrder == "CourseId" ? "courseId_desc" : "CourseId";
            var groups = _repository.GetAll().Include(g => g.Course).AsQueryable();



            Filter(ref groups, currentFilter, searchString, ref pageNumber);

            Sort(ref groups, sortOrder);

            int pageSize = jsonObject.PageSettings.PageSize.ToObject<int>();
            return View(await PaginatedList<GroupViewModel>.CreateAsync(groups.Select(x => _mapper.Map<GroupViewModel>(x)).AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Create(int CourseId)
        {
            var existingCourse = _unitOfWork.GetRepository<Course>().GetAll().Select(x => new SelectListItem { Value = $"{x.Id}", Text = $"{x.Id} {x.Name}" });
            GroupViewModel newGroup = new();
            newGroup.existingCourses = existingCourse.ToList();

            newGroup.CourseID = CourseId;

            return View(newGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GroupViewModel newGroup)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(_mapper.Map<Group>(newGroup));

                return RedirectToAction("Details", "Course", new { id = newGroup.CourseID });
            }

            return View(newGroup);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var existingCourse = _unitOfWork.GetRepository<Course>().GetAll().Select(x => new SelectListItem { Value = $"{x.Id}", Text = $"{x.Id} {x.Name}" });
            GroupViewModel group = _mapper.Map<GroupViewModel>(_repository.Find(id));
            group.existingCourses = existingCourse.ToList();

            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GroupViewModel changedGroup)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(_mapper.Map<Group>(changedGroup));

                return RedirectToAction("Index");
            }

            return View(changedGroup);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            GroupViewModel group = _mapper.Map<GroupViewModel>(_repository.Find(id));
            group.MyStudents = new PaginatedList<Student>(_unitOfWork.GetRepository<Student>().GetAll(x => x.GroupId == group.Id).ToList(), 0, 1, 0);

            if (group.MyStudents != null && group.MyStudents.Count > 0)
            {
                group.HasStudents = true;
            }

            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(GroupViewModel group)
        {
            if (group.HasStudents)
            {
                ViewData["messageIsStudents"] = "You do not can delete this group, because It contain students.";
                return View(group);
            }

            _repository.Delete(_mapper.Map<Group>(group));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            var group = _mapper.Map<GroupViewModel>(_repository.Find(id));
            var students = _unitOfWork.GetRepository<Student>().GetAll();
            students = students.Where(student => student.GroupId == id);

            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : "";
            ViewData["LastNameSortParm"] = sortOrder == "LastName" ? "lastname_desc" : "LastName";
            ViewData["FirstNameSortParm"] = sortOrder == "FirstName" ? "first_desc" : "FirstName";
            ViewData["GroupIdSortParm"] = sortOrder == "GroupId" ? "groupId_desc" : "GroupId";

            Filter(ref students, currentFilter, searchString, ref pageNumber);

            StudentController.Sort(ref students, sortOrder);

            int pageSize = jsonObject.PageSettings.PageSize.ToObject<int>();
            group.MyStudents = await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize);
            return View(group);
        }

        public static void Sort(ref IQueryable<Group> groups, string sortOrder)
        {
            switch (sortOrder)
            {
                case "id_desc":
                    groups = groups.OrderByDescending(c => c.Id);
                    break;
                case "Name":
                    groups = groups.OrderBy(c => c.Name);
                    break;
                case "name_desc":
                    groups = groups.OrderByDescending(c => c.Name);
                    break;
                case "CourseId":
                    groups = groups.OrderBy(c => c.CourseID);
                    break;
                case "courseId_desc":
                    groups = groups.OrderByDescending(c => c.CourseID);
                    break;
                default:
                    groups = groups.OrderBy(c => c.Id);
                    break;
            }
        }
    }
}
