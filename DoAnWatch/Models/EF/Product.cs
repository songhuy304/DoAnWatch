using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWatch.Models
{
    [Table("tb_Product")]
    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = " Tiêu Đề Không Đuợc trống")]
        public string Title { get; set; }
        public string Alidas { get; set; }

        public string ProductCode { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public bool IsHome { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }

        public bool IsSale { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public int Quantity { get; set; }

        public int ProductCategoryId { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        //public IEnumerable<SelectListItem> CategoryList { get; set; }
        public virtual ProductCategogy ProductCategory { get; set; }

    }
}