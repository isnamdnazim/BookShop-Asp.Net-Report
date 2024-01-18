using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BulkyBook.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (paymentStatus != null)
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentID(int id, string sessionId, string paymentItentId)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            orderFromDb.PaymentDate = DateTime.Now;
            orderFromDb.SessionId = sessionId;
            orderFromDb.PaymentIntentId = paymentItentId;

           
        }

		public IQueryable<OrderHeader> GetOrderHeaders()
		{
			return _db.OrderHeaders;
		}

      public  IQueryable<OrderHeader> GetOrderHeadersWithDetails(DateTime from , DateTime to)
        {
            //        var orders = _db.OrderHeaders
            //.Join(_db.OrderDetail,
            //    header => header.Id,
            //    detail => detail.OrderId,
            //    (header, detail) => new { Header = header, Detail = detail })
            //.Where(o => o.Header.OrderDate >= from && o.Header.OrderDate <= to)
            //.Select(o => o.Header);


            var orders = _db.OrderHeaders.Include(x => x.OrderDetails).ThenInclude(x=>x.Product);
    

            return orders;
        }
    }
}
