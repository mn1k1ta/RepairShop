using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        Task<OperationDetails> CreateOrderAsync(OrderDTO orderDTO);
        Task<OperationDetails> EditOrderAsync(OrderDTO orderDTO);
        Task<OperationDetails> DeleteOrderAsync(OrderDTO orderDTO);
        Task<ICollection<OrderDTO>> GetAllOrdersAsync(OrderDTO orderDTO);
        Task<OrderDTO> GetOrderById(int id);
        Task<ICollection<OrderDTO>> GetOrderByUserAsync(string id);
        Task<ICollection<OrderDTO>> GetActiveOrdersAsync();
 
    }
}
