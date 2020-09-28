using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private IBrandPhoneRepository _brandPhoneRepository;
        private ICommentRepository _commentRepository;
        private ICrashRepository _crashRepository;
        private ICustomerRepository _customerRepository;
        private IModelPhoneRepository _modelPhoneRepository;
        private IOrderCrashRepository _orderCrashRepository;
        private IOrderRepository _orderRepository;
        private IPriceRepository _priceRepository;
        private IOrderPriceRepository _orderPriceRepository;
        private ShopDBContext _dBContext;

        public UnitOfWork(ShopDBContext dBContext)
        {
            _dBContext = dBContext;
            _dBContext.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
        }
        public IBrandPhoneRepository brandPhoneRepository
        {
            get
            {
                if (_brandPhoneRepository == null)
                    _brandPhoneRepository = new BrandPhoneRepository(_dBContext);
                return _brandPhoneRepository;
            }
        }

        public ICommentRepository commentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_dBContext);
                return _commentRepository;
            }
        }

        public ICrashRepository crashRepository
        {
            get
            {
                if (_crashRepository == null)
                    _crashRepository = new CrashRepository(_dBContext);
                return _crashRepository;
            }
        }

        public ICustomerRepository customerRepository
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_dBContext);
                return _customerRepository;
            }
        }

        public IModelPhoneRepository modelPhoneRepository
        {
            get
            {
                if (_modelPhoneRepository == null)
                    _modelPhoneRepository = new ModelPhoneRepository(_dBContext);
                return _modelPhoneRepository;
            }
        }

        public IOrderCrashRepository orderCrashRepository
        {
            get
            {
                if (_orderCrashRepository == null)
                    _orderCrashRepository = new OrderCrushRepository(_dBContext);
                return _orderCrashRepository;
            }
        }

        public IOrderPriceRepository orderPriceRepository
        {
            get
            {
                if (_orderPriceRepository == null)
                    _orderPriceRepository = new OrderPriceRepository(_dBContext);
                return _orderPriceRepository;
            }
        }
        public IOrderRepository orderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_dBContext);
                return _orderRepository;
            }
        }

        public IPriceRepository priceRepository
        {
            get
            {
                if (_priceRepository == null)
                    _priceRepository = new PriceRepository(_dBContext);
                return _priceRepository;
            }
        }

        public async Task SaveAsync()
        {
           await _dBContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dBContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
