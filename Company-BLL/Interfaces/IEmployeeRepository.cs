using Company_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_BLL.Interfaces
{
    public interface IEmployeeRepository:IGenaticRepository<Employee>
    {
        public IEnumerable<Employee> GetByName(string name);
    }
}
