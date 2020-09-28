using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        Task<OperationDetails> CreateCommentAsync(CommentDTO commentDTO);
        Task<OperationDetails> DeleteCommentAsync(CommentDTO commentDTO);
        Task<OperationDetails> EditCommentAsync(CommentDTO commentDTO);
        Task<ICollection<CommentDTO>> GetAllCommentsAsync();
    }
}
