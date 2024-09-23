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
    public class GenaricRepository<T>:IGenaticRepository<T> where T:ModelBase
    {
        private protected readonly CompanyDBContext _companydbcontext;
        public GenaricRepository(CompanyDBContext companyDBContext)
        {
            _companydbcontext = companyDBContext;
        }
        public void Add(T t)
        {
            _companydbcontext.Set<T>().Add(t);
            //return _companydbcontext.SaveChanges();
        }

        public void Delete(T t)
        {
            _companydbcontext.Set<T>().Remove(t);
            //return _companydbcontext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            if(typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>) _companydbcontext.Employees.Include(e=>e.Department).AsNoTracking().ToList();
            }
            return _companydbcontext.Set<T>().AsNoTracking().ToList();

        }

        public T GetById(int id)
        {
            return _companydbcontext.Set<T>().Find(id);
        }

        public void Update(T t)
        {
            _companydbcontext.Set<T>().Update(t);
            //return _companydbcontext.SaveChanges();
        }

    }
}
