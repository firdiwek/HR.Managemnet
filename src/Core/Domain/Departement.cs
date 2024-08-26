using System.Collections.Generic;
using Domain.Common;

namespace HR.Management.Domain
{
    public class Department : BaseDomainEntity
    {
        public string Name { get; set; } = string.Empty; // E.g., HR, IT, Sales
        public string Description { get; set; } = string.Empty;
        public decimal Budget { get; set; } // Optional: Budget for the department

        // Navigation property
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
