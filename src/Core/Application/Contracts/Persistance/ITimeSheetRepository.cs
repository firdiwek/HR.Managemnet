using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Management.Domain;

namespace Application.Contracts.Persistance
{
    public interface ITimeSheetRepository : IGenericRepository<TimeSheet>
    {
        
    }
}