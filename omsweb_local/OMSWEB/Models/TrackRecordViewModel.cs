using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSWEB.Models
{
    public class TrackRecordViewModel
    {
        public string Project { get; set; }
        public string Detail { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime? Date { get; set; }
        public string WorkingHr { get; set; }
        public bool? Billable { get; set; }
    }
}
