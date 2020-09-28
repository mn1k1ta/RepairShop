using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IBrandPhoneRepository brandPhoneRepository { get; }
        ICommentRepository commentRepository { get; }
        ICrashRepository crashRepository { get; }
        ICustomerRepository customerRepository { get; }
        IModelPhoneRepository modelPhoneRepository { get; }
        IOrderRepository orderRepository { get; }
        IOrderCrashRepository orderCrashRepository { get; }
         IOrderPriceRepository orderPriceRepository { get; }
        IPriceRepository priceRepository { get; }
        Task SaveAsync();

    }
}
