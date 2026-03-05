using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        IEntityRepo<Department> deptRepo;
        IEntityRepo<Course> courseRepo;
        IEntityRepo<StudentCourse> stdCourseRepo;
        IEntityRepo<Student> studentRepo;

        public CourseController(IEntityRepo<Department> _deptRepo, IEntityRepo<Course> _courseRepo,
            IEntityRepo<StudentCourse> _stdCourseRepo, IEntityRepo<Student> _studentRepo)
        {
            deptRepo = _deptRepo;
            courseRepo = _courseRepo;
            stdCourseRepo = _stdCourseRepo;
            studentRepo = _studentRepo;
        }
        public IActionResult Index()
        {
            var model = courseRepo.GetAll();
            return View(model);
        }
        public IActionResult UpdateDegrees(int id)
        {
            //id is the CsId
            // Get Departments that have this course
            var depts = deptRepo.FindAll(d => d.Courses.Any(c => c.CrsId == id));
            return View(depts);
        }
        /**
         * This action method is intended to update the degrees of a course based on the provided course ID (crsId) and department ID (DeptId).
         * The user select the course and the department, then it will show the students degrees of the course in that department, and allow the user to update them.
         */
        [HttpPost]
        public IActionResult UpdateDegrees(int id, int selectedDeptId)
        {
            return RedirectToAction("SetDegrees", new { crsId = id, deptId = selectedDeptId });
            //return RedirectToAction("SetDegrees", "Course", id);
        }

        public IActionResult SetDegrees(int CrsId, int deptId)
        {
            // Get the students objects
            var students = studentRepo.FindAll(s => s.Deptno == deptId && s.StudentCourses
                .Any(sc => sc.CrsNo == CrsId))
                .ToList();
            // Get degrees from stdCourseRepo
            var degreesDict = stdCourseRepo.FindAll(sc => sc.CrsNo == CrsId && sc.Student.Deptno == deptId)
                                   .ToDictionary(sc => sc.StudentId, sc => sc.Degree);
            // Pass the Course ID and the Degrees Dictionary to the ViewBag
            ViewBag.CrsId = CrsId;
            ViewBag.Degrees = degreesDict;
            return View(students);  // return the students to the view
        }

        [HttpPost]
        public IActionResult SetDegrees(int CrsId, Dictionary<int, int> degrees)
        {
            // Loop through the dictionary (Key: StudentId, Value: Degree)
            foreach (var degreesEntry in degrees)
            {
                int studentId = degreesEntry.Key;
                int degree = degreesEntry.Value;
                // Find the specific StudentCourse record using both StudentId and CrsId
                var studentCourse = stdCourseRepo.FindAll(sc => sc.StudentId == studentId && sc.CrsNo == CrsId).FirstOrDefault();
                if (studentCourse != null)
                {
                    // Update the degree
                    studentCourse.Degree = degree;
                    // Save changes to the database using the Update method from the repo
                    stdCourseRepo.Update(studentCourse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
