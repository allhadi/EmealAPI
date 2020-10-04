using System;
using System.Collections.Generic;

namespace Emeal.EFCore.Models
{
    public partial class Company : URF.Core.EF.Trackable.Entity // My Handlebars Helper
    {
        public Company()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
