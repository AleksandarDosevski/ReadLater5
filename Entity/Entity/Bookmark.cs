using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Bookmark
    {
        [Key]
        public int ID { get; set; }

        [StringLength(maximumLength: 500)]
        public string URL { get; set; }

        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [DisplayName("Category")]
        public int? CategoryId { get; set; }

        [DisplayName("Date Created")]
        public DateTime CreateDate { get; set; }

        public string UserId { get; set; }
    }
}
