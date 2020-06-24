using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tut12.DTOs.Requests;
using Tut12.DTOs.Responces;

namespace Tut12.Services
{
    interface IOrderDbService
    {
        public List<GetOrderResponse> GetListOfOrders(GetOrderRequest request);
        


    }
}
