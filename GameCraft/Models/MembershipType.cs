using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameCraft.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }

        public static readonly byte Unknown = 1;
        public static readonly byte PayAsGo = 2;
    }
}