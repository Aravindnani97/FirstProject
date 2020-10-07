using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstProject.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public string MembershipType { get; set; }
        public int SignUpFee { get; set; }
        public int Duration { get; set; }
        public int Discount { get; set; }
    }
}