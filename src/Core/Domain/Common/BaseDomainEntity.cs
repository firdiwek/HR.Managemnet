using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; } // Foreign key to Employee  
    }
}