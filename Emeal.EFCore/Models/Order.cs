using System;
using System.Collections.Generic;

namespace Emeal.EFCore.Models
{
    public partial class Order : URF.Core.EF.Trackable.Entity // My Handlebars Helper
    {
        public Order()
        {
            Item = new HashSet<Item>();
        }

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

        public virtual OrderType OrderType { get; set; }
        public virtual PaymentGateway PaymentGateway { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Item> Item { get; set; }
    }
}
