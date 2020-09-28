using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace RepairShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper _mapper)
        {
            this.orderService = orderService;
            this._mapper = _mapper;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrderAsync(OrderDTO orderDTO)
        {
            var serviceActionResult = await orderService.CreateOrderAsync(orderDTO);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpPut]
        [Route("EditOrder")]
        public async Task<IActionResult> EditOrderAsync(OrderDTO orderDTO)
        {
            var serviceActionResult = await orderService.EditOrderAsync(orderDTO);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public async Task<IActionResult> DeleteOrderAsync(OrderDTO orderDTO)
        {
            var serviceActionResult = await orderService.DeleteOrderAsync(orderDTO);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            return Ok(await orderService.GetAllOrdersAsync());
        }

        [HttpGet]
        [Route("GetOrdersByCustomer")]
        public async Task<IActionResult> GetOrdersByCustomerAsync(int id)
        {
            return Ok(await orderService.GetOrderByUserAsync(id));
        }

        [HttpGet]
        [Route("GetOrderById")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            return Ok(await orderService.GetOrderById(id));
        }

        [HttpGet]
        [Route("GetActiveOrders")]
        public async Task<IActionResult> GetActiveOrdersAsync()
        {
            return Ok(await orderService.GetActiveOrdersAsync());
        }
    }
}