using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestorClient.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pendiente;

        public Customer Customer { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public enum OrderStatus
        {
            Pendiente,
            Enviado,
            Cancelado
        }
    }
}