using System;
using System.Collections.Generic;

namespace Emeal.EFCore.Models
{
    public partial class OrderType : URF.Core.EF.Trackable.Entity // My Handlebars Helper
    {
        public OrderType()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
