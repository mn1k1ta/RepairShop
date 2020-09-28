using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace RepairShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpPut]
        [Route("EditCustomerAsync")]
        public async Task<IActionResult> EditCustomerAsync(CustomerDTO customerDTO)
        {
            var serviceActionResult = await customerService.EditCustomerAsync(customerDTO);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }
    }
}