using System;
using System.Collections.Generic;

namespace Emeal.EFCore.Models
{
    public partial class Address : URF.Core.EF.Trackable.Entity // My Handlebars Helper
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
