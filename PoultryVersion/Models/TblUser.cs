using System;
using System.Collections.Generic;

namespace PoultryVersion.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblPoultryFarms = new HashSet<TblPoultryFarm>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? RoleId { get; set; }
        public string? Password { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<TblPoultryFarm> TblPoultryFarms { get; set; }
    }
}
