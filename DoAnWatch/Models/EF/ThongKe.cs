using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnWatch.Models.EF
{
    public class ThongKe
    {
        public int Id { get; set; }
       
        public DateTime ThoiGian { get; set; }
      
        public string Description { get; set; }
        public string Detail { get; set; }
    }
}