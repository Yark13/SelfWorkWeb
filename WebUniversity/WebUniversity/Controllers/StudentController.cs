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
    public class StudentController : EntityController<Student>
    {

        public StudentController(ILogger<StudentController> logger, IUnitOfWork<StateDbContext> unitOfWork, IMapper mapper) : base(logger, unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : sortOrder == "Id" ? "Id_desc" : "Id";
            ViewData["LastNameSortParm"] = sortOrder == "LastName" ? "lastname_desc" : "LastName";
            ViewData["FirstNameSortParm"] = sortOrder == "FirstName" ? "first_desc" : "FirstName";
            ViewData["GroupIdSortParm"] = sortOrder == "GroupId" ? "groupId_desc" : "GroupId";
            var students = _repository.GetAll();

            Filter(ref students, currentFilter, searchString, ref pageNumber);

            Sort(ref students, sortOrder);

            int pageSize = jsonObject.PageSettings.PageSize.ToObject<int>();
            return View(await PaginatedList<StudentViewModel>.CreateAsync(students.Select(x => _mapper.Map<StudentViewModel>(x)).AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Create(int GroupId)
        {
            var existingGroups = _unitOfWork.GetRepository<Group>().GetAll().AsQueryable().Select(x => new SelectListItem { Value = $"{x.Id}", Text = $"ID: {x.Id} Name: {x.Name}" });

            StudentViewModel newGroup = new StudentViewModel();
            newGroup.GroupId = GroupId;
            newGroup.existingGroups = existingGroups.ToList();

            return View(newGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentViewModel newStudent)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(_mapper.Map<Student>(newStudent));

                return RedirectToAction("Details", "Group", new { id = newStudent.GroupId });
            }

            return View(newStudent);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var existingGroups = _unitOfWork.GetRepository<Group>().GetAll().AsQueryable().Select(x => new SelectListItem { Value = $"{x.Id}", Text = $"ID: {x.Id} Name: {x.Name}" });
            StudentViewModel student = _mapper.Map<StudentViewModel>(_repository.Find(id));
            student.existingGroups = existingGroups.ToList();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentViewModel changedStudent)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(_mapper.Map<Student>(changedStudent));

                return RedirectToAction("Index");
            }

            return View(changedStudent);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_mapper.Map<StudentViewModel>(_repository.Find(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(StudentViewModel changedStudent)
        {
            _repository.Delete(_mapper.Map<Student>(changedStudent));

            return RedirectToAction("Index");
        }

        public static void Sort(ref IQueryable<Student> students, string sortOrder)
        {
            switch (sortOrder)
            {
                case "id_desc":
                    students = students.OrderByDescending(c => c.Id);
                    break;
                case "LastName":
                    students = students.OrderBy(c => c.LastName);
                    break;
                case "lastname_desc":
                    students = students.OrderByDescending(c => c.LastName);
                    break;
                case "FirstName":
                    students = students.OrderBy(c => c.FirstName);
                    break;
                case "first_desc":
                    students = students.OrderByDescending(c => c.FirstName);
                    break;
                case "GroupId":
                    students = students.OrderBy(c => c.GroupId);
                    break;
                case "groupId_desc":
                    students = students.OrderByDescending(c => c.GroupId);
                    break;
                default:
                    students = students.OrderBy(c => c.Id);
                    break;
            }
        }
    }
}
