using System;
using System.Collections.Generic;

namespace PoultryVersion.Models
{
    public partial class TblTreatment
    {
        public int Id { get; set; }
        public string? CheckedBy { get; set; }
        public string? Medicine { get; set; }
        public int? DiseaseId { get; set; }
        public string? Date { get; set; }

        public virtual TblDisease? Disease { get; set; }
    }
}
