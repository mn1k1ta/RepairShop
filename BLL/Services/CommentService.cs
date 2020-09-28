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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _dataBase;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork _dataBase, IMapper _mapper)
        {
            this._dataBase = _dataBase;
            this._mapper = _mapper;
        }
        public async Task<OperationDetails> CreateCommentAsync(CommentDTO commentDTO)
        {
            if (commentDTO == null)
            {
                return new OperationDetails("Comment is null", false);
            }
            var customer = await _dataBase.customerRepository.GetWhereAsync(c => c.Phone == commentDTO.Phone && c.Name == commentDTO.Name);
            if (customer.Count == 0)
            {
                return new OperationDetails("You can not leave a comment", false);
            }
            _dataBase.commentRepository.Create(_mapper.Map<Comment>(commentDTO));
            await _dataBase.SaveAsync();
            return new OperationDetails("Comment is created!",true);
             
        }

        public Task<OperationDetails> DeleteCommentAsync(CommentDTO commentDTO)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDetails> EditCommentAsync(CommentDTO commentDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CommentDTO>> GetAllCommentsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
