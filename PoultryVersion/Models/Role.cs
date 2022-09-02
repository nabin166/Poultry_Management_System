using System;
using System.Collections.Generic;

namespace PoultryVersion.Models
{
    public partial class Role
    {
        public Role()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public int Id { get; set; }
        public string? Roles { get; set; }

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
