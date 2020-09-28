using BLL.Helpers;
using BLL.ModelDTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBrandPhoneService
    {
        Task<OperationDetails> CreateBrandPhoneAsync(BrandPhoneDTO brandPhoneDTO);
        Task<OperationDetails> DeleteBrandPhoneAsync(BrandPhoneDTO brandPhoneDTO);
        Task<OperationDetails> EditPhoneBrandAsync(BrandPhoneDTO brandPhoneDTO);
        Task<ICollection<BrandPhoneDTO>> GetAllBrandPhone();
        Task<BrandPhoneDTO> GetBrandPhoneById(int id);
    }
}
