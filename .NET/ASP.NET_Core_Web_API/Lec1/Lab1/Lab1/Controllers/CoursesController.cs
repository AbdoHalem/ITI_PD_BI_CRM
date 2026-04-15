using Lab1.Data;
using Lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Inject the AppDbContext using Dependency Injection
        public CoursesController(AppDbContext context)
        {
            _context = context;
        }
        /**
         * GET: api/Courses
         * Retrieves a list of all courses from the database.
         * If no courses are found, returns a 404 Not Found response with a message.
         * Otherwise, returns a 200 OK response with the list of courses.
         */
        [HttpGet]
        public IActionResult get()
        {
            List<Course> crs = _context.Courses.ToList();
            if(crs.Count == 0)
            {
                return NotFound("No Courses Found");
            }
            return Ok(crs);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCourse(int id)
        {
            var crs = _context.Courses.Find(id);
            if(crs == null)
            {
                return NotFound("Course Not Found");
            }
            _context.Courses.Remove(crs);
            _context.SaveChanges();
            return Ok(_context.Courses.ToList());
        }

        [HttpPut("{id}")]
        public IActionResult put(int id, Course course)
        {
            if(id != course.ID){
                return BadRequest("Course ID mismatch");
            }
            Course? crs = _context.Courses.Find(id);
            if(crs == null)
            {
                return NotFound("Course Not Found");
            }
            crs.Crs_name = course.Crs_name;
            crs.Crs_desc = course.Crs_desc;
            crs.Duration = course.Duration;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult post(Course course)
        {
            if(course == null)
            {
                return BadRequest("Course data is null");
            }
            _context.Courses.Add(course);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getById), new { id = course.ID }, course);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Course? crs = _context.Courses.Find(id);
            if(crs == null)
            {
                return NotFound("Course Not Found");
            }
            return Ok(crs);
        }

        [HttpGet("name/{name}")]
        public IActionResult courseByName(string name)
        {
            var crs = _context.Courses.FirstOrDefault(c => c.Crs_name.Contains(name));
            if(crs == null)
            {
                return NotFound("Course not found");
            }
            return Ok(crs);
        }
    }
}
