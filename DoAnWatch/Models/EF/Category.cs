using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnWatch.Models
{
    [Table("tb_Category")]
    public class Category : CommonAbstract
    {
        public  Category(){
            this.News = new HashSet<New>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required (ErrorMessage =" Tên Danh Mục Không Đuợc trống")] 
        public string Title  { get; set; }
       
        public string Alidas { get; set; }
        [Required]
        public string Description { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; } 
        public int Position { get; set; }
        public ICollection<New> News { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}