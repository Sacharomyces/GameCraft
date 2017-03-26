using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCraft.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

      
        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public byte MembershipTypeId { get; set; }

        [ValidationMin18Years]
        public DateTime? BirthDate { get; set; }

       



    }
}