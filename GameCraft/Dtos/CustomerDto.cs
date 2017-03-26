using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GameCraft.Models;

namespace GameCraft.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; } //this property has to have the same name as customer property to be properly mapped with automapper


        //[ValidationMin18Years]
        public DateTime? BirthDate { get; set; }

    }
}