﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnWatch.Models
{
    public class OrderViewModel
    {
        public string CustomerName { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }

        public int Payment { get; set; }
    }
}