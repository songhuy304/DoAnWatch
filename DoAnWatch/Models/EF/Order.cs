using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnWatch.Models
{
    [Table("tb_Order")]
    public class Order : CommonAbstract
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [Required(ErrorMessage = " Tên Không Đuợc trống")]
        public string CustomerName { get; set; }
        public string Code { get; set; }
        [Required]
        public string Phone { get; set; }

        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quatity { get; set; }
        public int TypePayment { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}