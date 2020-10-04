using System;
using System.Collections.Generic;
using System.Text;

namespace Emeal.Model
{
    public class ItemDto
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
    }
}
