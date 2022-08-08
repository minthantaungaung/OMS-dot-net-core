using System;
using System.Collections.Generic;

namespace OMSWEB.Models
{
    public partial class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public DateTime? Accesstime { get; set; }
        public string Remark { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
