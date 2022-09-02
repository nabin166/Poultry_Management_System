using System;
using System.Collections.Generic;

namespace PoultryVersion.Models
{
    public partial class TblProduction
    {
        public int Id { get; set; }
        public string? EggType { get; set; }
        public int? Quantity { get; set; }
        public int? PoultryId { get; set; }

        public virtual TblPoultryFarm? Poultry { get; set; }
    }
}
