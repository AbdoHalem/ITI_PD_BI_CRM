using Day1.Models.ViewModel;
using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Authorize]
    public class StudentController : Controller // Dependent
    {
        // Dependency Inversion Principle (DIP) is a software design
        // principle that states that high-level modules should not depend
        // on low-level modules, but both should depend on abstractions.
        // In this code, the StudentController is a high-level module that
        // depends on the abstraction of IEntityRepo<Student> rather than a concrete
        // implementation like StudentRepo. This allows for greater flexibility and maintainability,
        // as the controller can work with any implementation of the repository interface
        // without being tightly coupled to a specific one.
        IEntityRepo<Student> stdRepo;
        IEntityRepo<Department> deptRepo;
        /**
         * A constructor that is used in the DIC
         */
        public StudentController(IEntityRepo<Student> _stdRepo, IEntityRepo<Department> _deptRepo)
        {
            stdRepo = _stdRepo;
            deptRepo = _deptRepo;
        }
        public IActionResult Index()
        {
            return View(stdRepo.GetAll());
        }
        /**
         * This action method handles the HTTP GET request for creating a new student.
         */
        public IActionResult Create()
        {
            ViewBag.Depts = deptRepo.GetAll(); // Retrieve all departments from the repository and store them in ViewBag.Depts to be used in the Create view (e.g., for a dropdown list)
            return View();
        }
        /**
         * This action method handles the HTTP POST request for creating a new student.
         * It takes a Student object as a parameter, which is populated from the form data submitted by the user.
         * If the model state is valid, it adds the new student to the repository and redirects to the Index action.
         * If the model state is not valid, it returns the Create view again, allowing the user to correct any errors.
         */
        [HttpPost]
        public IActionResult Create(StudentVM student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Depts = deptRepo.GetAll(); // Retrieve all departments from the repository and store them in ViewBag.Depts to be used in the Create view (e.g., for a dropdown list)
                return View(student);
            }
            Student std = new Student
            {
                Name = student.Name,
                Age = student.Age,
                Deptno = student.DeptNo
            };
            stdRepo.Add(std);
            return RedirectToAction("Index");
        }
        /**
         * This action method is used to check if an email address is already in use by another student.
         * It takes an email address and an optional student ID as parameters. The student ID is used to exclude the current student when checking for email uniqueness during updates.
         * If the student ID is null, it means we are creating a new student, and the method checks if any student already has the given email.
         * If the student ID is not null, it means we are updating an existing student, and the method checks if any other student (excluding the one being updated) has the given email.
         * The method returns a JSON response indicating whether the email is available (true) or already in use (a message).
         */
        public IActionResult CheckEmail(string email, int? id)
        {
            if (id == null)
            {
                var std = stdRepo.FindAll(s => s.Email == email).First();
                if (std == null)
                    return Json(true); // If no student with the given email is found, return true (indicating that the email is available)
                else
                    return Json($"Email {email} is already in use."); // If a student with the given email is found, return a message indicating that the email is already in use
            }
            else
            {
                var std = stdRepo.FindAll(s => s.Email == email && s.Id != id).First();
                if (std == null)
                    return Json(true);
                else
                    return Json($"Email {email} is already in use.");
            } 
        }
    }
}
