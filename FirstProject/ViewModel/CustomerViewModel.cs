using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstProject.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Membership> GetMemberships { get; set; }
        public List<SelectListItem> Gender { get; set; }
    }
}