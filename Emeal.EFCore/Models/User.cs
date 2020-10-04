using System;
using System.Collections.Generic;

namespace Emeal.EFCore.Models
{
    public partial class User : URF.Core.EF.Trackable.Entity // My Handlebars Helper
    {
        public User()
        {
            Address = new HashSet<Address>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
