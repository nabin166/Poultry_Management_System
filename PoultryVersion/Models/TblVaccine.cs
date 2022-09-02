using System;
using System.Collections.Generic;

namespace PoultryVersion.Models
{
    public partial class TblVaccine
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Date { get; set; }
        public int? PoultryId { get; set; }

        public virtual TblPoultryFarm? Poultry { get; set; }
    }
}
