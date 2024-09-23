using Company_BLL.Interfaces;
using Company_DAL.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDBContext _companyDBContext1;
        public UnitOfWork(CompanyDBContext companyDBContext)
        {
            _companyDBContext1 = companyDBContext;
            employeeRepository = new EmployeeRepository(_companyDBContext1);
            departmentRepository = new DepartmentRepository(_companyDBContext1);
        }
        public IEmployeeRepository employeeRepository { get ; set ; }
        public IDepartmentRepository departmentRepository { get ; set ; }

        public int Complete()
        {
            return _companyDBContext1.SaveChanges();
        }

        public void Dispose()
        {
            _companyDBContext1.Dispose();
        }
    }
}
