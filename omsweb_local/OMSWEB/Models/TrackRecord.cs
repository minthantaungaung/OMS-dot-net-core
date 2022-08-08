using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OMSWEB.Models
{
    public partial class TrackRecord
    {
        public int Id { get; set; }
        public string Project { get; set; }
        public string Detail { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:MM}", ApplyFormatInEditMode = true)]
        public DateTime? StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:MM}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }
        public DateTime? Date { get; set; }
        public string WorkingHr { get; set; }
        public bool? Billable { get; set; }
        public DateTime? AccessTime { get; set; }
        public string CompanyCode { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
