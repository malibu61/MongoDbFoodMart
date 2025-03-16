using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Dtos.DepartmentDto;
using MongoDbFoodMart.Services.Department;

namespace MongoDbFoodMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _DepartmentService;

        public DepartmentController(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }

        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            await _DepartmentService.CreateDepartmentAsync(createDepartmentDto);
            return RedirectToAction("DepartmentList");
        }

        public async Task<IActionResult> DepartmentList()
        {
            var values = await _DepartmentService.GetAllDepartmentAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteDepartment(string id)
        {
            await _DepartmentService.DeleteDepartmentAsync(id);
            return RedirectToAction("DepartmentList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateDepartment(string id)
        {
            var values = await _DepartmentService.GetByIdDepartmentAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            await _DepartmentService.UpdateDepartmentDto(updateDepartmentDto);
            return RedirectToAction("DepartmentList");
        }
    }
}
