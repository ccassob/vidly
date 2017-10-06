using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.WebApp.Models;

namespace Vidly.WebApp.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customer Customers { get; set; }

    }
}