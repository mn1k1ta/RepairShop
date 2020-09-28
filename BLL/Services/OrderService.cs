using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelDTO;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }
        public async Task<OperationDetails> CreateOrderAsync(OrderDTO orderDTO)
        {
            if (orderDTO == null)
            {
                return new OperationDetails("Order is null!", false);
            }

            var user = await _database.customerRepository.GetWhereAsync(c => c.Phone == orderDTO.Phone);
            if (user.Count == 0)
            {
                _database.customerRepository.Create(new Customer { Name = orderDTO.Name, Phone = orderDTO.Phone, DateRegister = DateTime.Now.ToString() });
                await _database.SaveAsync();
            }
            var model = await _database.modelPhoneRepository.GetWhereAsync(m => m.ModelName == orderDTO.ModelName);
            if (model.Count == 0)
            {
                return new OperationDetails("This model phone is not found ", false);
            }
            var order = _mapper.Map<Order>(orderDTO);
            order.Date = DateTime.Now;
            _database.orderRepository.Create(order);
            foreach (var item in orderDTO.Prices)
            {
                var price = await _database.priceRepository.GetByIdAsync(item);
                if (price == null)
                {
                    return new OperationDetails($"Price with this id : {item} is not found!", false);
                }
                _database.orderPriceRepository.Create(new OrderPrice { Order=order,Price=price});
               
            }
            await _database.SaveAsync();
            return new OperationDetails("Order is created !", true);
        }

        public async Task<OperationDetails> DeleteOrderAsync(OrderDTO orderDTO)
        {
            if (orderDTO == null)
            {
                return new OperationDetails("Order is null!", false);
            }
            var order = await _database.orderRepository.GetByIdAsync(orderDTO.OrderId);
            if(order == null)
            {
                return new OperationDetails("Order with this id is null", false);
            }
            _database.orderRepository.Delete(order);
            await _database.SaveAsync();
            return new OperationDetails("Order is deleted!", true);
        }

        public async Task<OperationDetails> EditOrderAsync(OrderDTO orderDTO)
        {
            if (orderDTO == null)
            {
                return new OperationDetails("OrderDTO is null", false);
            }
            var order = await _database.orderRepository.GetByIdAsync(orderDTO.OrderId);
            if (order == null)
            {
                return new OperationDetails("Order with this id is not found", false);
            }
            _database.orderRepository.Update(_mapper.Map(orderDTO, order));
            await _database.SaveAsync();
            return new OperationDetails("Order is Updated!", true);

        }

        public async Task<ICollection<OrderDTO>> GetActiveOrdersAsync()
        {
            return _mapper.Map<ICollection<OrderDTO>>(await _database.orderRepository.GetWhereAsync(o=>o.Active=="Active"));
        }

        public async Task<ICollection<OrderDTO>> GetAllOrdersAsync(OrderDTO orderDTO)
        {
            return _mapper.Map<ICollection<OrderDTO>>(await _database.orderRepository.GetAllAsync());
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            var order = await _database.orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new ServiceException("This order is not found");
            }
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<ICollection<OrderDTO>> GetOrderByUserAsync(int id)
        {
            var order = await _database.orderRepository.GetWhereAsync(o => o.Customer.CustomerId == id);
            return _mapper.Map<ICollection<OrderDTO>>(order);
        }
    }
}
