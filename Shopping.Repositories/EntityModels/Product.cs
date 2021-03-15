using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Repositories.EntityModels
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Required]
        [Range(1,5000)]
        public int AvailableQuantity { get; set; }

        public DateTime Date { get; set; }
        [Required]
        [Range(1, 5000000)]
        public float Price { get; set; }


    }
}
