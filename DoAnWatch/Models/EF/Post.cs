using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnWatch.Models
{
    [Table("tb_Post")]

    public class Post : CommonAbstract
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = " Tiêu đề Không Đuợc trống")]
        public string Title { get; set; }
        public string Alidas { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public virtual Category Category { get; set; }
    }
}