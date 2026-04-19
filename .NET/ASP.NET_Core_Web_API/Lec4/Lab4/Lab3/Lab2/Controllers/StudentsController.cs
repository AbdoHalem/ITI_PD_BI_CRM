using AutoMapper;
using Lab4.DTO.StudentsDTO;
using Lab4.Models;
using Lab4.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        // Replace ITIContext with IUnitOfWork
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        // Inject the IUnitOfWork through the constructor
        public StudentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        // Accept query parameters for search, page number, and page size
        public IActionResult GetAll([FromQuery] string? name, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            // 1. Start with an IQueryable to build the query without executing it immediately
            // We use AsQueryable() so we can chain conditions before hitting the database
            // Use _unitOfWork.Students.GetAll() instead of _context.Students
            var query = _unitOfWork.Students.GetAll()
                .Include(s => s.Dept)
                .Include(s => s.St_superNavigation)
                .AsQueryable();

            // 2. Apply Searching if a name parameter is provided
            if(!string.IsNullOrEmpty(name))
            {
                // Filter by First Name or Last Name
                query = query.Where(s => s.St_Fname.Contains(name) || s.St_Lname.Contains(name));
            }

            // 3. Apply Pagination using Skip and Take
            // Skip: bypasses the records of previous pages
            // Take: retrieves the exact number of records for the current page
            var students = query
                .Skip((pageNumber - 1) * pageSize) // Calculate how many records to skip
                .Take(pageSize) // Take the number of records for the current page
                .ToList(); // Execute the query and get the results as a list

            // 4. Map the retrieved entities to DTOs
            var studentsDTO = _mapper.Map<List<DisplayStudentDTO>>(students);
            // 5. Return the final list
            return Ok(studentsDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var stud = _unitOfWork.Students.GetAll()
                .Include(s => s.Dept)
                .Include(s => s.St_superNavigation)
                .FirstOrDefault(s => s.St_Id == id);
            if (stud == null)
            {
                return NotFound("Student Not Found");
            }
            // Use the Repository to delete, then UnitOfWork to save
            _unitOfWork.Students.Delete(stud);
            _unitOfWork.SaveTransaction();
            var studDTO = _mapper.Map<DisplayStudentDTO>(stud);
            return Ok(studDTO);
        }

        [HttpPut("{id}")]
        public IActionResult EditStudent(int id, EditStudentDTO student)
        {
            if (id != student.St_Id)
            {
                return BadRequest("Student ID mismatch");
            }
            Student? std = _unitOfWork.Students.GetById(id);
            if (std == null)
            {
                return NotFound("Student is Not Found");
            }
            // Map the properties from the EditStudentDTO to the existing Student entity
            _mapper.Map(student, std);
            // Use the Repository to update, then UnitOfWork to save
            _unitOfWork.Students.Update(std);
            _unitOfWork.SaveTransaction();
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddStudent(EditStudentDTO student)
        {
            if (student == null)
            {
                return BadRequest("Student data is null");
            }
            var newStudent = _mapper.Map<Student>(student);
            // Use the Repository to add, then UnitOfWork to save
            _unitOfWork.Students.Add(newStudent);
            _unitOfWork.SaveTransaction();
            var newStudentDTO = _mapper.Map<DisplayStudentDTO>(newStudent);
            return CreatedAtAction(nameof(GetById), new { id = newStudent.St_Id }, newStudentDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // 1. Retrieve the student with the specified ID from the database, including related Department and Supervisor data
            Student? stud = _unitOfWork.Students.GetAll()
                .Include(s => s.Dept)
                .Include(s => s.St_superNavigation)
                .FirstOrDefault(s => s.St_Id == id);
            // 2. If the student is not found, return a 404 Not Found response
            if (stud == null)
            {
                return NotFound("Student Not Found");
            }
            // 3. Map the Student entity to a DisplayStudentDTO using AutoMapper
            var studDTO = _mapper.Map<DisplayStudentDTO>(stud);
            return Ok(studDTO);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var std = _unitOfWork.Students.GetAll()
                .Include(s => s.Dept)
                .Include(s => s.St_superNavigation)
                .FirstOrDefault(s => s.St_Fname.Contains(name));
            if (std == null)
            {
                return NotFound("Student not found");
            }
            var stdDTO = _mapper.Map<DisplayStudentDTO>(std);
            return Ok(stdDTO);
        }
    }
}
