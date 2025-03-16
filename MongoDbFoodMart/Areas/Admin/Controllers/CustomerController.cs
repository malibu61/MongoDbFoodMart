using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Dtos.CustomerDto;
using MongoDbFoodMart.Services.Customer;

namespace MongoDbFoodMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService CustomerService)
        {
            _customerService = CustomerService;
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            await _customerService.CreateCustomerAsync(createCustomerDto);
            return RedirectToAction("CustomerList");
        }

        public async Task<IActionResult> CustomerList()
        {
            var values = await _customerService.GetAllCustomerAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteCustomer(string id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return RedirectToAction("CustomerList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(string id)
        {
            var values = await _customerService.GetByIdCustomerAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            await _customerService.UpdateCustomerDto(updateCustomerDto);
            return RedirectToAction("CustomerList");
        }

    }
}
