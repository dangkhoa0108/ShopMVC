using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("Footers")]
    public class Footer
    {
        [Key]
        public string ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Content { get; set; }
    }
}