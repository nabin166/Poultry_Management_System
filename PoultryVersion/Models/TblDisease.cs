using System;
using System.Collections.Generic;

namespace PoultryVersion.Models
{
    public partial class TblDisease
    {
        public TblDisease()
        {
            TblTreatments = new HashSet<TblTreatment>();
        }

        public int Id { get; set; }
        public string? DiseaseName { get; set; }
        public int? EffectiveNumber { get; set; }
        public string? Date { get; set; }
        public int? NoOfDead { get; set; }
        public int? PoultryId { get; set; }

        public virtual TblPoultryFarm? Poultry { get; set; }
        public virtual ICollection<TblTreatment> TblTreatments { get; set; }
    }
}
