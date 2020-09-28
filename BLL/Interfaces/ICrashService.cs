using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICrashService
    {
        Task<OperationDetails> CreateCrashAsync(CrashDTO crashDTO);
        Task<OperationDetails> EditCrashAsync(CrashDTO crashDTO);
        Task<OperationDetails> DeleteCrashAsync(CrashDTO crashDTO);
        Task<ICollection<CrashDTO>> GetAllCrashesAsync();
        
    }
}
