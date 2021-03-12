using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shopping.Repositories.EntityModels
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public int AvailableQuantity { get; set; }

        public DateTime Date { get; set; }
        public float Price { get; set; }


    }
}
