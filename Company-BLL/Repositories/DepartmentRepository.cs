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
    public class DepartmentRepository : GenaricRepository<Department>,IDepartmentRepository
    {
        //private readonly CompanyDBContext _companydbcontext;
        public DepartmentRepository(CompanyDBContext companyDBContext):base(companyDBContext)
        {
            //_companydbcontext = companyDBContext;
        }
        public int Add(Department department)
        {
            _companydbcontext.departments.Add(department);
            return _companydbcontext.SaveChanges();
        }

        public int Delete(Department department)
        {
            _companydbcontext.departments.Remove(department);
            return _companydbcontext.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return _companydbcontext.departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            return _companydbcontext.departments.AsNoTracking().Where(D=>D.Id==id).FirstOrDefault();
        }

        public IEnumerable<Department> GetByName(string name)
        {
            return _companydbcontext.departments.AsNoTracking().Where(D => D.Name == name).ToList();
        }

        public int Update(Department department)
        {
            _companydbcontext.departments.Update(department);
            return _companydbcontext.SaveChanges();
        }
    }
}
