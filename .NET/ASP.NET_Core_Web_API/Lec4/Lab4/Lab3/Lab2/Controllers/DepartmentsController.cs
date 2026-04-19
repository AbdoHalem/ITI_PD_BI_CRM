using AutoMapper;
using Lab4.DTO.DepartmentsDTO;
using Lab4.DTO.StudentsDTO;
using Lab4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        // Declare a private readonly field to hold the context
        private readonly ITIContext _context;
        private readonly IMapper _mapper;

        // Inject the ITIContext through the constructor
        public DepartmentsController(ITIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        // Enriching Operation Metadata
        [SwaggerOperation(
            Summary = "Returns all departments",
            Description = "Retrieves a complete list of all departments including their manager names and student counts."
        )]
        // Enriching Response Metadata
        [SwaggerResponse(200, "Successfully retrieved the list of departments", typeof(List<DisplayDepartmemtDTO>))]
        [Produces("application/json")]
        public IActionResult GetAll()
        {
            // 1. Retrieve all departments from the database, including related Department and Supervisor data
            var depts = _context.Departments
                .Include(d => d.Dept_ManagerNavigation)
                .Include(d => d.Students)
                .ToList();
            // 2. Map the list of Department entities to a list of DisplayDepartmemtDTOs using AutoMapper
            var deptsDTO = _mapper.Map<List<DisplayDepartmemtDTO>>(depts);
            return Ok(deptsDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var dept = _context.Departments
                .Include(d => d.Dept_ManagerNavigation)
                .Include(d => d.Students)
                .FirstOrDefault(d => d.Dept_Id == id);
            if (dept == null)
            {
                return NotFound("Department Not Found");
            }
            _context.Departments.Remove(dept);
            _context.SaveChanges();
            var deptDTO = _mapper.Map<DisplayDepartmemtDTO>(dept);
            return Ok(deptDTO);
        }

        [HttpPut("{id}")]
        public IActionResult EditDepartment(int id, EditDepartmentDTO dept)
        {
            if (id != dept.Dept_Id)
            {
                return BadRequest("Department ID mismatch");
            }
            Department? existingDept = _context.Departments.Find(id);
            if (existingDept == null)
            {
                return NotFound("Department is Not Found");
            }
            // Map the properties from the EditDepartmentDTO to the existing Department entity
            _mapper.Map(dept, existingDept);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation(
            Summary = "Creates a new department",
            Description = "Adds a new department to the database. Requires valid department data."
        )]
        [SwaggerResponse(201, "The department was successfully created", typeof(DisplayDepartmemtDTO))]
        [SwaggerResponse(400, "The department data is invalid or null")]
        public IActionResult AddDepartment(EditDepartmentDTO dept)
        {
            if (dept == null)
            {
                return BadRequest("Department data is null");
            }
            var newDept = _mapper.Map<Department>(dept);
            _context.Departments.Add(newDept);
            _context.SaveChanges();
            var newDeptDTO = _mapper.Map<DisplayDepartmemtDTO>(newDept);
            return CreatedAtAction(nameof(GetById), new { id = newDept.Dept_Id }, newDeptDTO);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a specific department by ID")]
        [SwaggerResponse(200, "Department found", typeof(DisplayDepartmemtDTO))]
        [SwaggerResponse(404, "Department not found")]
        public IActionResult GetById(int id)
        {
            // 1. Retrieve the department with the specified ID from the database, including related Department and Supervisor data
            Department? dept = _context.Departments
                .Include(d => d.Dept_ManagerNavigation)
                .Include(d => d.Students)
                .FirstOrDefault(d => d.Dept_Id == id);
            // 2. If the department is not found, return a 404 Not Found response
            if (dept == null)
            {
                return NotFound("Department Not Found");
            }
            // 3. Map the Department entity to a DisplayDepartmentDTO using AutoMapper
            var deptDTO = _mapper.Map<DisplayDepartmemtDTO>(dept);
            return Ok(deptDTO);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var dept = _context.Departments
                .Include(d => d.Dept_ManagerNavigation)
                .Include(d => d.Students)
                .FirstOrDefault(d => d.Dept_Name.Contains(name));
            if (dept == null)
            {
                return NotFound("Department not found");
            }
            var deptDTO = _mapper.Map<DisplayDepartmemtDTO>(dept);
            return Ok(deptDTO);
        }
    }
}
