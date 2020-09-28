using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelDTO;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ModelPhoneService : IModelPhoneService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public ModelPhoneService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }
        public async Task<OperationDetails> CreateModelPhoneAsync(ModelPhoneDTO modelPhoneDTO)
        {
            if (modelPhoneDTO == null)
            {
                return new OperationDetails("model phone is null!", false);
            }

            var phoneBrand = await _database.brandPhoneRepository.GetWhereAsync(p => p.BrandName == modelPhoneDTO.BrandName);
            if (phoneBrand.Count == 0)
            {
                return new OperationDetails("This brand is not found!", false);
            }
            var modelPhone = new ModelPhone();
            modelPhone.BrandPhone = phoneBrand.First();
            _database.modelPhoneRepository.Create(_mapper.Map(modelPhoneDTO, modelPhone));
            await _database.SaveAsync();
            return new OperationDetails("Model is created!", true);
            
        }

        public async Task<OperationDetails> DeleteModelPhoneAsync(ModelPhoneDTO modelPhoneDTO)
        {
            if(modelPhoneDTO == null)
            {
                return new OperationDetails("ModelPhone is null!", false);
            }
            var modelPhone = await _database.modelPhoneRepository.GetByIdAsync(modelPhoneDTO.ModelPhoneId);
            if (modelPhone == null)
            {
                return new OperationDetails("Model with this id is not found!", false);
            }
            _database.modelPhoneRepository.Delete(modelPhone);
            await _database.SaveAsync();
            return new OperationDetails("Model is deleted", true);
        }

        public async Task<OperationDetails> EditModelPhoneAsync(ModelPhoneDTO modelPhoneDTO)
        {

            if (modelPhoneDTO == null)
            {
                return new OperationDetails("Model phone is null!", false);
            }
            var modelPhone = await _database.modelPhoneRepository.GetByIdAsync(modelPhoneDTO.ModelPhoneId);
            if (modelPhone == null)
            {
                return new OperationDetails("Model with this id is not found", false);
            }

            _database.modelPhoneRepository.Update(_mapper.Map(modelPhoneDTO, modelPhone));
            await _database.SaveAsync();
            return new OperationDetails("Model is updated", false);
        }

        public async Task<ICollection<ModelPhoneDTO>> GetAllModelPhoneAsync()
        {
            return _mapper.Map<ICollection<ModelPhoneDTO>>(await _database.modelPhoneRepository.GetAllAsync());
        }

        public async Task<ICollection<ModelPhoneDTO>> GetModelPhoneByBrand(string brand)
        {
            var brandPhone = await _database.brandPhoneRepository.GetWhereAsync(b => b.BrandName == brand);
            if (brandPhone == null)
            {
                throw new ServiceException("This brand is not found!");
            }
            var modelPhones = await _database.modelPhoneRepository.GetWhereAsync(m => m.BrandPhone == brandPhone);
            var modelPhonesDTO = _mapper.Map<ICollection<ModelPhoneDTO>>(modelPhones);
            foreach (var item in modelPhonesDTO)
            {
                item.BrandName = brandPhone.First().BrandName;
            }
            return modelPhonesDTO;
        }

        public async Task<ModelPhoneDTO> GetModelPhoneById(int id)
        {
            var modelPhone = await _database.modelPhoneRepository.GetByIdAsync(id);
            if (modelPhone == null)
            {
                throw new ServiceException("Model with this id is not found");
            }
            return _mapper.Map<ModelPhoneDTO>(modelPhone);
        }
    }
}
