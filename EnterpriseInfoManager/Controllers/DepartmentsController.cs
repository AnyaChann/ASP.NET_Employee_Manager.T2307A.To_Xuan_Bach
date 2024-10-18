using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EnterpriseInfoManager.Models;
using EnterpriseInfoManager.Repositories;

namespace EnterpriseInfoManager.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentsController(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                await _departmentRepository.CreateAsync(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return View(departments);
        }
    }
}