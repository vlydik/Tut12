﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tut12.Models
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; }

        public DateTime DateAccepted { get; set; }

        public DateTime DateFinished { get; set; }

        public string Notes { get; set; }

        public int IdCustomer { get; set; }

        [ForeignKey("IdCustomer")]
        public Customer Customer { get; set; }

        public int IdEmployee { get; set; }

        [ForeignKey("IdEmployee")]
        public Employee Employee { get; set; }
    }
}
