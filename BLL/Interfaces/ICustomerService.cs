using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICustomerService
    {
        Task<ICollection<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int id);
        Task<CustomerDTO> GetCustomerByPhoneAsync(string phone);
        Task<ICollection<CustomerDTO>> GetCustomersByNameAsync(string name);
        Task<OperationDetails> DeleteCustomerAsync(CustomerDTO customerDTO);
        Task<OperationDetails> EditCustomerAsync(CustomerDTO customerDTO);
    }
}
