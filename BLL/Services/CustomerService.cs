using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelDTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }
        public async Task<OperationDetails> DeleteCustomerAsync(CustomerDTO customerDTO)
        {
            if(customerDTO == null)
            {
                return new OperationDetails("CustomerDTO is null!", false);
            }
            var customer = await _database.customerRepository.GetWhereAsync(c => c.CustomerId == customerDTO.CustomerId);
            if (customer.Count == 0)
            {
                return new OperationDetails("Customer with this id is not found!", false);
            }
            _database.customerRepository.Delete(customer.FirstOrDefault());
            await _database.SaveAsync();
            return new OperationDetails("User deleted!", true);
        }

        public async Task<OperationDetails> EditCustomerAsync(CustomerDTO customerDTO)
        {
            if(customerDTO == null)
            {
                return new OperationDetails("customer is null!", false);
            }
            var customer = await _database.customerRepository.GetWhereAsync(c => c.CustomerId == customerDTO.CustomerId);
            if (customer.Count == 0)
            {
                return new OperationDetails("This user is not found", false);
            }
            _database.customerRepository.Update(_mapper.Map(customerDTO, customer.FirstOrDefault()));
            await _database.SaveAsync();
            return new OperationDetails("User is updated", true);

        }

        public async Task<ICollection<CustomerDTO>> GetAllCustomersAsync()
        {
            return _mapper.Map<ICollection<CustomerDTO>>(await _database.customerRepository.GetAllAsync());
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _database.customerRepository.GetWhereAsync(c => c.CustomerId == id);
            if (customer.Count == 0)
            {
                throw new ServiceException("Customer with this id is not found");
            }
            return _mapper.Map<CustomerDTO>(customer.FirstOrDefault());
        }

        public async Task<CustomerDTO> GetCustomerByPhoneAsync(string phone)
        {
            if (phone == null)
            {
                throw new ServiceException("Phone number is null");
            }

            var customer = await _database.customerRepository.GetWhereAsync(c => c.Phone == phone);
            if (customer.Count == 0)
            {
                throw new ServiceException("Customer with this id null");
            }
            return _mapper.Map<CustomerDTO>(customer.FirstOrDefault());
        }

        public async Task<ICollection<CustomerDTO>> GetCustomersByNameAsync(string name)
        {
            if (name == null)
            {
                throw new ServiceException("name is null");
            }

            var customers = await _database.customerRepository.GetWhereAsync(c => c.Name == name);

            return _mapper.Map<ICollection<CustomerDTO>>(customers);
        }
    }
}
