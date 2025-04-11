using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUniversity.DataLayer;
using WebUniversity.DataLayer.Entity;
using WebUniversity.DataLayer.UnitOfWork;
using WebUniversity.ViewModels;

namespace WebUniversity.Controllers
{
    public class CourseController : EntityController<Course>
    {
        public CourseController(ILogger<CourseController> logger, IUnitOfWork<StateDbContext> unitOfWork, IMapper mapper) : base(logger, unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            var courses = _repository.GetAll();

            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";

            Filter(ref courses, currentFilter, searchString, ref pageNumber);

            Sort(ref courses, sortOrder);

            int pageSize = jsonObject.PageSettings.PageSize.ToObject<int>();
            return View(await PaginatedList<CourseViewModel>.CreateAsync(courses.Select(x => _mapper.Map<CourseViewModel>(x)).AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseViewModel newCourse)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(_mapper.Map<Course>(newCourse));

                return RedirectToAction("Index");
            }

            return View(newCourse);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_mapper.Map<CourseViewModel>(_repository.Find(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseViewModel changedCourse)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(_mapper.Map<Course>(changedCourse));

                return RedirectToAction("Index");
            }

            return View(changedCourse);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CourseViewModel course = _mapper.Map<CourseViewModel>(_repository.Find(id));
            course.Mygroups = new PaginatedList<Group>(_unitOfWork.GetRepository<Group>().GetAll(x => x.CourseID == course.Id).ToList(), 0, 1, 0);

            if (course.Mygroups != null && course.Mygroups.Count > 0)
            {
                course.HasGroups = true;
            }

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CourseViewModel changedCourse)
        {
            if (changedCourse.HasGroups)
            {
                ViewData["messageIsGroups"] = "You do not can delete this course, because It contain groups.";

                return View(changedCourse);
            }

            _repository.Delete(_mapper.Map<Course>(changedCourse));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            CourseViewModel course = _mapper.Map<CourseViewModel>(_repository.Find(id));
            var groups = _unitOfWork.GetRepository<Group>().GetAll();
            groups = groups.Where(g => g.CourseID == id);

            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";

            Filter(ref groups, currentFilter, searchString, ref pageNumber);

            GroupController.Sort(ref groups, sortOrder);

            int pageSize = jsonObject.PageSettings.PageSize.ToObject<int>();
            course.Mygroups = await PaginatedList<Group>.CreateAsync(groups.AsQueryable().AsNoTracking(), pageNumber ?? 1, pageSize);

            return View(course);
        }

        private void Sort(ref IQueryable<Course> courses, string sortOrder)
        {
            switch (sortOrder)
            {
                case "id_desc":
                    courses = courses.OrderByDescending(c => c.Id);
                    break;
                case "Name":
                    courses = courses.OrderBy(c => c.Name);
                    break;
                case "name_desc":
                    courses = courses.OrderByDescending(c => c.Name);
                    break;
                default:
                    courses = courses.OrderBy(c => c.Id);
                    break;
            }
        }
    }
}
