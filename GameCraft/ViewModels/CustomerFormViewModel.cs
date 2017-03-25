using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using GameCraft.Models;

namespace GameCraft.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType>  MembershipType { get; set; }
        public Customer Customer { get; set; }
    }

}