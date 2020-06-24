using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tut12.DTOs.Responces
{
    public class GetOrderResponse
    {
        public int IdOrder { get; set; }

        public DateTime DateAccepted { get; set; }

        public DateTime DateFinished { get; set; }

        public string Notes { get; set; }

        public int IdCustomer { get; set; }

        public int IdConfectionery { get; set; }

    }
}
