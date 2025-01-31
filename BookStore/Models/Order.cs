using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public string? CustomerName { get; set; }

        [Required]
        public string? CustomerEmail { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; 

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        [NotMapped]
        public decimal TotalAmount => OrderDetails?.Sum(od => od.Quantity * od.UnitPrice) ?? 0;
    }
}
