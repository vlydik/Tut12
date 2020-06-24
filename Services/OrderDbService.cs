using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tut12.DTOs.Requests;
using Tut12.DTOs.Responces;
using Tut12.Exceptions;
using Tut12.Models;

namespace Tut12.Services
{


    public class OrderDbService : IOrderDbService
    {
        private OrderDbContext _context;

        public OrderDbService(OrderDbContext context)
        {
            _context = context;
        }

        public List<GetOrderResponse> GetListOfOrders(GetOrderRequest request)
        {
            string name = request.Name;

            if (name != null)
            {
                int count = 0;
                //int count = _context.Customer.Where(c => c.Name == name).Count();
                if (count == 0) throw new NoCustomerException("No customer found with name " + name);
            }


            return null;

        }
    }
}
