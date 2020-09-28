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
    }
}