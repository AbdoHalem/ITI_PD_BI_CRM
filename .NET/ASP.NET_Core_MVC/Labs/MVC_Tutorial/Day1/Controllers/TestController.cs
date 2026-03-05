using Day1.Filters;
using Day1.Models.ViewModel;
using ITIEntities;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    public class TestController : Controller
    {
        // How to call this method: https://localhost:7008/Day1/Display
        public string Display()
        {
            //IEntityRepo<Student> s1 = new StudentRepo();
            ////s1.GetById(10);
            //s1.Add(new Student { Name = "aseal", Age = 23, Deptno = 100 });
            return "Hello World!";
        }
        /**
         * Send parameters in url: https://localhost:7008/Day1/Add?x=5&y=3
         */
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        /*
        Pseudocode / Plan:
        1. Purpose: Provide an action that returns a view result for the "Display2" page.
        2. Inputs: none (this action reads no route/query/body parameters).
        3. Behavior:
           - Call the controller's View() helper to produce a ViewResult.
           - Let the MVC view engine locate and render the appropriate view file 
             (typically /Views/Day1/Display2.cshtml or /Views/Shared/Display2.cshtml).
        4. Output: return the ViewResult to the ASP.NET Core runtime so it can render the page.
        5. Error handling: this method itself does not catch exceptions; view resolution or rendering
           may throw and are handled by the MVC pipeline or global error handlers.
        */
        /// <summary>
        /// Returns the view associated with the Display2 action.
        /// </summary>
        /// <remarks>
        /// This action method returns a <see cref="ViewResult"/>. When no explicit view name is provided,
        /// the MVC view engine will search for a view that matches the action name (for example,
        /// /Views/Day1/Display2.cshtml or /Views/Shared/Display2.cshtml).
        /// Use this action to render a page without supplying a model or when the view obtains its
        /// data by other means.
        /// </remarks>
        /// <returns>A <see cref="ViewResult"/> that will be rendered by the MVC view engine.</returns>
        public ViewResult Display2()
        {
            Student s1 = new Student { Id = 1, Name = "Aly", Age = 20 };
            // Pass data to the view using ViewData, which is a dictionary that the view can access.
            ViewData["student"] = s1;
            ViewData["x"] = 20;
            ViewData["y"] = 30;
            // Pass data to the view using ViewBag, which is a dynamic wrapper around ViewData for more convenient syntax.
            ViewBag.z = 50;
            //return View();
            Student s2 = new Student() { Id = 2, Name = "Sara", Age = 22 };
            Display2ViewModel model = new Display2ViewModel() { Student = s2, X = 100 };
            // Return the view and pass `s2` as the model by calling the overloaded View(object model) helper.
            //return View(s2);
            return View(model);
        }
        
        public ViewResult ShowForm()
        {
            return View();
        }

        [MyExceptionFilter]
        public IActionResult Update()
        {
            int id = int.Parse("sdad");
            return View();
        }

        [Authorize]
        public IActionResult Update2()
        {
            int id = int.Parse("20");
            return Content("update2");
        }
    }
}