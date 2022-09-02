using System;
using System.Collections.Generic;

namespace PoultryVersion.Models
{
    public partial class TblPoultryFarm
    {
        public TblPoultryFarm()
        {
            TblDiseases = new HashSet<TblDisease>();
            TblProductions = new HashSet<TblProduction>();
            TblVaccines = new HashSet<TblVaccine>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? NoOfHens { get; set; }
        public int? UserId { get; set; }

        public virtual TblUser? User { get; set; }
        public virtual ICollection<TblDisease> TblDiseases { get; set; }
        public virtual ICollection<TblProduction> TblProductions { get; set; }
        public virtual ICollection<TblVaccine> TblVaccines { get; set; }
    }
}
