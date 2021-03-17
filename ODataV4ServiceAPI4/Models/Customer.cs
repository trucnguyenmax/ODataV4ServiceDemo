using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ODataV4ServiceAPI4.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Order> Orders { get; set; }
    }
}