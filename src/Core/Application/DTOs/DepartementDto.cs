using System.Collections.Generic;
using Application.DTOs.Common;

namespace HR.Management.Application.DTOs
{
    public class DepartmentDto: BaseDto
    {
        // public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public IEnumerable<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>(); // Optional: Include employee details if needed
    }
}
