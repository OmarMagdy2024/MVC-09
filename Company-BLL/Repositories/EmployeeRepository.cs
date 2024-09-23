using Company_BLL.Interfaces;
using Company_DAL.Connection;
using Company_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_BLL.Repositories
{
    public class EmployeeRepository : GenaricRepository<Employee>,IEmployeeRepository
    {
        //private readonly CompanyDBContext _companydbcontext;
        public EmployeeRepository(CompanyDBContext companyDBContext):base(companyDBContext)
        {
            //_companydbcontext = companyDBContext;
        }
        public int Add(Employee employee)
        {
            _companydbcontext.Employees.Add(employee);
            return _companydbcontext.SaveChanges();
        }

        public int Delete(Employee employee)
        {
            _companydbcontext.Employees.Remove(employee);
            return _companydbcontext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _companydbcontext.Employees.Include(e=>e.Department).AsNoTracking().ToList();
        }

        public Employee GetById(int id)
        {
            return _companydbcontext.Employees.Include(e => e.Department).AsNoTracking().Where(E=>E.Id == id).FirstOrDefault();
        }

        public IEnumerable<Employee> GetByName(string name)
        {
            return _companydbcontext.Employees.Include(e => e.Department).AsNoTracking().Where(e => e.Name.ToLower().Contains(name.ToLower()));
        }

        public int Update(Employee employee)
        {
            _companydbcontext.Employees.Update(employee);
            return _companydbcontext.SaveChanges();
        }
    }
}
