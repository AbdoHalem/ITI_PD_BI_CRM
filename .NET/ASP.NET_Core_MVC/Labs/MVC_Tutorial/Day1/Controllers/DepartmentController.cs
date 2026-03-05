using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        IEntityRepo<Department> deptRepo;
        IEntityRepo<Course> courseRepo;

        public DepartmentController(IEntityRepo<Department> _deptRepo, IEntityRepo<Course> _courseRepo)
        {
            deptRepo = _deptRepo;
            courseRepo = _courseRepo;
        }

        /**
         * GET: Department
         */
        public IActionResult Index()
        {
            var model = deptRepo.GetAll();
            return View(model);
        }
        /**
         * GET: Department/Details/5
         */
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = deptRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            //return RedirectPermanent("https://www.google.com");
            //return RedirectToAction("index", "home", new { x = 10, y = 20 });
            //return Json(model);
            return View(model);
        }
        /**
         * GET: Department/Create
         */
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]  // [ValidateAntiForgeryToken]
        /**
         * Model Binding:
         */
        public IActionResult Create(Department dept)  // Model Binder
        {
            deptRepo.Add(dept);
            return RedirectToAction(nameof(Index));
            //Department dept = new Department();
            //dept.DeptId = int.Parse(Request.Form["DeptId"]);
            //dept.DeptName = Request.Query["DeptName"];
            //dept.Capacity = int.Parse(Request.Form["Capacity"]);
            //return Json(dept);
        }
        /**
         * GET: Department/Edit/5
         */
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = deptRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }
        /**
         * POST: Department/Edit/5
         */
        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            deptRepo.Update(dept);
            return RedirectToAction(nameof(Index));
        }
        /**
         * GET: Department/Delete/5
         */
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = deptRepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }
        /**
         * POST: Department/Delete/5
         */
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return BadRequest();
            deptRepo.Delete(id.Value);
            return RedirectToAction(nameof(Index));
        }
        /**
         * GET: Department/ShowCourses/5
         */
        public IActionResult ShowCourses(int id)
        {
            var model = deptRepo.GetDeptCourses(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
        /**
         * GET: Department/ManageDeptCourses/5
         */
        [Authorize(Roles = "Admin")]
        public IActionResult ManageDeptCourses(int id)
        {
            var model = deptRepo.GetDeptCourses(id);
            // Get all courses
            var allCourses = courseRepo.GetAll();
            //var coursesNotInDept = allCourses.Except(model.Courses).ToList();
            // ExceptBy: Exclude from the first collection all items that have a matching key in the second collection, and return the remaining items.
            var coursesNotInDept = allCourses
                .ExceptBy(model.Courses.Select(c => c.CrsId), c => c.CrsId)
                .ToList();
            ViewBag.coursesNotInDept = coursesNotInDept;
            if (model == null)
                return NotFound();
            return View(model);
        }
        /**
         * POST: Department/ManageDeptCourses/5
         */
        [HttpPost, Authorize(Roles = "Admin")]
        public IActionResult ManageDeptCourses(int id, int[] coursesToRemove, int[] coursesToAdd)
        {
            var dept = deptRepo.GetDeptCourses(id);
            if (dept == null)
                return NotFound();
            foreach (var crsId in coursesToRemove)
            {
                var crs = dept.Courses.FirstOrDefault(c => c.CrsId == crsId);
                if (crs != null)
                    dept.Courses.Remove(crs);
            }
            foreach (var crsId in coursesToAdd)
            {
                var crs = courseRepo.GetById(crsId);
                if (crs != null)
                    dept.Courses.Add(crs);
            }
            deptRepo.Update(dept);  // Update the department with the modified courses
            return RedirectToAction(nameof(ShowCourses), new { id = id });
        }
    }
}
