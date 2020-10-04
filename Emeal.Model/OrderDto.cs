using System;
using System.Collections.Generic;
using System.Text;

namespace Emeal.Model
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DespatchTime { get; set; }
        public int UserId { get; set; }
        public double Total { get; set; }
        public double DiscountAmount { get; set; }
        public double Charge { get; set; }
        public int PaymentStatusId { get; set; }
        public int PaymentTypeId { get; set; }
        public int OrderTypeId { get; set; }
        public string DeliveryAddress { get; set; }
        public string BillingAddress { get; set; }
        public string PaymentReference { get; set; }
        public int? PaymentGatewayId { get; set; }
        public string Note { get; set; }
    }
}
