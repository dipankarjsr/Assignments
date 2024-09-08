using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAssignment_DataAccess.IRepository;
using MyAssignment_Model;
using MyAssignment_Model.ViewModels;
using Newtonsoft.Json;

namespace MyAssignment.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerInfoRepository _customerInfoRepository;
        private readonly IDistrictRepository _districtRepository;

        public CustomerController(ICustomerInfoRepository customerInfoRepository, IDistrictRepository districtRepository)
        {
            _customerInfoRepository = customerInfoRepository;
            _districtRepository = districtRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CustomerVM customerVM = new CustomerVM()
            {
                CustomerInfoList = await _customerInfoRepository.GetAll(),
                CustomerInfo = new CustomerInfoVM()
            };
            return View(customerVM);
        }

        [HttpPost]
        public async Task<JsonResult> GetDistricts(int stateId)
        {            
            var districtList = (await _districtRepository.GetByStateIdAsync(stateId)).Select(x => new { x.Name, x.Id });
            var jsonResult = JsonConvert.SerializeObject(districtList);
            return Json(jsonResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCustomerInfo(CustomerInfoVM customerInfoVM)
        {
            if (ModelState.IsValid)
            {
                Customer_Info customer_Info = new Customer_Info()
                {
                    Id = customerInfoVM.Id,
                    Name = customerInfoVM.Name,
                    GenderId = customerInfoVM.GenderId,
                    DistrictId = customerInfoVM.DistrictId
                };
                if (customer_Info.Id == 0)
                {
                    await _customerInfoRepository.Add(customer_Info);
                    ViewBag.Message = "Data added successfully.";
                }
                else
                {
                    await _customerInfoRepository.Update(customer_Info);
                    ViewBag.Message = "Data updated successfully.";
                }
                var customerList = await _customerInfoRepository.GetAll();

                return PartialView("_CustomerDetails", customerList);
            }
            else
            {

                return Json(new { success = false, message = "Invalid data.Kindly fill all required fields.", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

            }
        }

        [HttpPost]
        public async Task<IActionResult> RenderCustomerInfoForm(int id)
        {
            CustomerInfoVM customerInfoVM = new CustomerInfoVM();
            if (id != 0)
            {
                Customer_Info customer_Info = await _customerInfoRepository.GetById(id);
                customerInfoVM.Id = customer_Info.Id;
                customerInfoVM.Name = customer_Info.Name;
                customerInfoVM.StateId = await _districtRepository.GetStateByDistrictIdAsync(customer_Info.DistrictId);
                customerInfoVM.GenderId = customer_Info.GenderId;
                ViewBag.DistrictList = (await _districtRepository.GetByStateIdAsync(customerInfoVM.StateId)).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
                customerInfoVM.DistrictId = customer_Info.DistrictId;

            }

            return PartialView("_CustomerInfoForm", customerInfoVM);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteCustomer(int id)
        {            
            await _customerInfoRepository.Delete(id);
            ViewBag.Message = "Data deleted successfully.";
            var customerList = await _customerInfoRepository.GetAll();
            return PartialView("_CustomerDetails", customerList);
        }
       
    }
}
