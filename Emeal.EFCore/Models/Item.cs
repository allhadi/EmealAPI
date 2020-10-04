using System;
using System.Collections.Generic;

namespace Emeal.EFCore.Models
{
    public partial class Item : URF.Core.EF.Trackable.Entity // My Handlebars Helper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public int OrderId { get; set; }
        public bool NonDiscount { get; set; }
        public int SortingOrder { get; set; }
        public string Instruction { get; set; }

        public virtual Order Order { get; set; }
    }
}
