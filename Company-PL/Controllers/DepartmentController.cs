using Company_BLL.Interfaces;
using Company_BLL.Repositories;
using Company_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company_PL.Controllers
{
    [Authorize]
    public class DepartmentController:Controller
    {
        //private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            //_departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(string Search)
        {
            if (string.IsNullOrEmpty(Search))
            {
                return View(_unitOfWork.departmentRepository.GetAll());

            }

            else
            {
                return View(_unitOfWork.departmentRepository.GetByName(Search));
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.departmentRepository.Add(department);
                if (_unitOfWork.Complete()> 0)
                {
                    return RedirectToAction("Index");
                }  
            }
                return View(department);
        }

        public IActionResult Details(int id)
        {
            ViewData["id"] = id;
            return View(_unitOfWork.departmentRepository.GetById(id));
        }
        public IActionResult Update(int id)
        {
            return View(_unitOfWork.departmentRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.departmentRepository.Update(department);
                if (_unitOfWork.Complete() > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(department);
        }

        public IActionResult Delete(int id)
        {
            return View(_unitOfWork.departmentRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.departmentRepository.Delete(department);
                if (_unitOfWork.Complete() > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(department);
        }
    }
}
