using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ODataV4ServiceAPI4.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}