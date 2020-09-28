using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelDTO;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BrandPhoneService : IBrandPhoneService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public BrandPhoneService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }

        public async Task<OperationDetails> CreateBrandPhoneAsync(BrandPhoneDTO brandPhoneDTO)
        {
            if (brandPhoneDTO == null)
            {
                return new OperationDetails("Brand Phone is NULL!!", false);
            }

            var brandPhone = await _database.brandPhoneRepository.GetWhereAsync(u => u.BrandName == brandPhoneDTO.BrandName);
            if (brandPhone.Count > 0)
            {
                return new OperationDetails("Brand with this name already is exist", false);
            }

            _database.brandPhoneRepository.Create(_mapper.Map<BrandPhone>(brandPhoneDTO));
            await _database.SaveAsync();
            return new OperationDetails("Brand is created!", true);
        }

        public async Task<OperationDetails> DeleteBrandPhoneAsync(BrandPhoneDTO brandPhoneDTO)
        {
            if (brandPhoneDTO == null)
            {
                return new OperationDetails("Brand is null", false);
            }
            _database.brandPhoneRepository.Delete(_mapper.Map<BrandPhone>(brandPhoneDTO));
            await _database.SaveAsync();
            return new OperationDetails("Brand is deleted!", true);
        }

        public async Task<OperationDetails> EditPhoneBrandAsync(BrandPhoneDTO brandPhoneDTO)
        {
            if (brandPhoneDTO == null)
            {
                return new OperationDetails("Brand is null", false);
            }
            var brandPhone = await _database.brandPhoneRepository.GetByIdAsync(brandPhoneDTO.BrandPhoneId);
            if (brandPhone== null)
            {
                return new OperationDetails("Brand with this id is null!", false);
            }
            _database.brandPhoneRepository.Update(_mapper.Map(brandPhoneDTO, brandPhone));
            await _database.SaveAsync();
            return new OperationDetails("Brand with this id is updated", true);
        }

        public async Task<ICollection<BrandPhoneDTO>> GetAllBrandPhone()
        {
            return  _mapper.Map<ICollection<BrandPhoneDTO>>(await _database.brandPhoneRepository.GetAllAsync());
        }

        public async Task<BrandPhoneDTO> GetBrandPhoneById(int id)
        {
            var brandPhone = await _database.brandPhoneRepository.GetByIdAsync(id);
            if (brandPhone == null)
            {
                throw new ServiceException("Brand with this id is noy found!");
            }

            return _mapper.Map<BrandPhoneDTO>(brandPhone);
        }
    }
}
