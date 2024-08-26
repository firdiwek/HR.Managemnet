
using AutoMapper;
using HR.Management.Application.DTOs;
using HR.Management.Domain;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap()
               .ForMember(dest=>dest.Employees, opt => opt.MapFrom(src=> src.Employees));
            CreateMap<Attendance, AttendanceDto>().ReverseMap();
            CreateMap<LeaveRequest,LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<Payroll, PayrollDto>().ReverseMap();
            CreateMap<TimeSheet, TimeSheetDto>().ReverseMap();
            CreateMap<TimeSheetEntry, TimeSheetDto>().ReverseMap();
            CreateMap<WorkSchedule, WorkScheduleDto>().ReverseMap()
                .ForMember(dest=>dest.WorkScheduleEntries, opt => opt.MapFrom(src=> src.WorkScheduleEntries));
                
            CreateMap<WorkScheduleEntry, WorkScheduleEntryDto>().ReverseMap();


                            

        }
    }
}