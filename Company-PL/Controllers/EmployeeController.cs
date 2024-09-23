using Company_BLL.Interfaces;
using Company_BLL.Repositories;
using Company_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company_PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        public IUnitOfWork _UnitOfWork { get; }

        //private readonly IEmployeeRepository _employeeRepository;
        //private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            //_employeeRepository = employeeRepository;
            _UnitOfWork = unitOfWork;
            //_departmentRepository = departmentRepository;
        }

        public IActionResult Index(string Search)
        {
            if (string.IsNullOrEmpty(Search))
            {
                return View(_UnitOfWork.employeeRepository.GetAll());

            }

            else
            {
                return View(_UnitOfWork.employeeRepository.GetByName(Search));
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ImageName=DocumentSetting.UploadFile(employee.Image, "Images");
                _UnitOfWork.employeeRepository.Add(employee);
                if (_UnitOfWork.Complete() > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(employee);
        }

        public IActionResult Details(int id)
        {
            ViewData["id"] = id;
            return View(_UnitOfWork.employeeRepository.GetById(id));
        }
        public IActionResult Update(int id)
        {
            return View(_UnitOfWork.employeeRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            employee.ImageName = DocumentSetting.UploadFile(employee.Image, "Images");
            _UnitOfWork.employeeRepository.Update(employee);
            if (ModelState.IsValid)
            {
                if (_UnitOfWork.Complete() > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            return View(_UnitOfWork.employeeRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _UnitOfWork.employeeRepository.Delete(employee);
            if (_UnitOfWork.Complete() > 0)
            {
                DocumentSetting.DeleteFile(employee.ImageName, "Images");
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
