using AutoMapper;
using Lab3.DTO.DepartmentsDTO;
using Lab3.DTO.StudentsDTO;
using Lab3.Models;

namespace Lab3.MappingProfiles
{
    public class MappConfig : Profile
    {
        public MappConfig()
        {
            // Create mapping between Student and DisplayStudentDTO
            CreateMap<Student, DisplayStudentDTO>()
                // Map Dept_Name from the related Department entity
                .ForMember(dest => dest.Dept_Name, opt => opt.MapFrom(src => src.Dept.Dept_Name))
                // Map Supervisor_Name from the related Supervisor entity (combining first and last name)
                .ForMember(dest => dest.Supervisor_Name, opt => opt.MapFrom(src => src.St_superNavigation.St_Fname + " " + src.St_superNavigation.St_Lname));
            
            // Create mapping between Student and EditStudentDTO
            CreateMap<Student, EditStudentDTO>()
                .ForMember(dest => dest.Supervisor_Id, opt => opt.MapFrom(src => src.St_super))
				.ReverseMap();

            // Create mapping between Department and DisplayDepartmemtDTO
            CreateMap<Department, DisplayDepartmemtDTO>()
                .ForMember(dest => dest.Manager_Name, opt => opt.MapFrom(src => src.Dept_ManagerNavigation.Ins_Name))
                .ForMember(dest => dest.Students_Count, opt => opt.MapFrom(src => src.Students.Count));

            // Create mapping between Department and EditDepartmentDTO
            CreateMap<Department, EditDepartmentDTO>().ReverseMap();
        }
    }
}
