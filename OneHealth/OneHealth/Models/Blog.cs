using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneHealth.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250),Required(ErrorMessage ="Qaqa title yaz")]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Column(TypeName = "nText"), Required]
        public string Content { get; set; }
        [ForeignKey("Category"), Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("CustomUser")]
        public string CustomUserId { get; set; }
        [NotMapped]
        public int[] TagsId { get; set; }
        public CustomUser CustomUser { get; set; }
        public List<TagToBlog> TagToBlogs { get; set; }
    }
}
