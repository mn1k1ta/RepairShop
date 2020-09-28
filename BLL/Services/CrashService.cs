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
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CrashService : ICrashService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public CrashService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }
        public async Task<OperationDetails> CreateCrashAsync(CrashDTO crashDTO)
        {
            if (crashDTO == null)
            {
                return new OperationDetails("Crash is null!", false);
            }

            _database.crashRepository.Create(_mapper.Map<Crash>(crashDTO));
            await _database.SaveAsync();
            return new OperationDetails("Customer is created!",true);
        }

        public async Task<OperationDetails> DeleteCrashAsync(CrashDTO crashDTO)
        {
            if (crashDTO == null)
            {
                return new OperationDetails("crash is null", false);

            }
            var crash = await _database.crashRepository.GetWhereAsync(c => c.CrashId == crashDTO.CrashId);
            if (crash.Count == 0)
            {
                return new OperationDetails("This crash is not found", false);
            }
            _database.crashRepository.Delete(crash.FirstOrDefault());
            await _database.SaveAsync();
            return new OperationDetails("Crash is deleted!", true);
        }

        public async Task<OperationDetails> EditCrashAsync(CrashDTO crashDTO)
        {
            if (crashDTO == null)
            {
                return new OperationDetails("This crash is null", false);
            }

            var crash = await _database.crashRepository.GetWhereAsync(c=>c.CrashId==crashDTO.CrashId);

            if (crash.Count == 0)
            {
                return new OperationDetails("Crash with this id is not found", false);
            }

            _database.crashRepository.Update(_mapper.Map(crashDTO,crash.FirstOrDefault()));
            await _database.SaveAsync();
            return new OperationDetails("Crash is updated!", false);

        }

        public Task<ICollection<CrashDTO>> GetAllCrashesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
