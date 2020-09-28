using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IModelPhoneService
    {
        Task<OperationDetails> CreateModelPhoneAsync(ModelPhoneDTO modelPhoneDTO);
        Task<OperationDetails> DeleteModelPhoneAsync(ModelPhoneDTO modelPhoneDTO);
        Task<OperationDetails> EditModelPhoneAsync(ModelPhoneDTO modelPhoneDTO);
        Task<ICollection<ModelPhoneDTO>> GetAllModelPhoneAsync();
        Task<ICollection<ModelPhoneDTO>> GetModelPhoneByBrand(string brand);
        Task<ModelPhoneDTO> GetModelPhoneById(int id);
    }
}
