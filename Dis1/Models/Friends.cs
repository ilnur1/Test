using System;
using System.Collections.Generic;

namespace Dis1.Models
{
    public partial class Friends
    {
        public decimal Cf { get; set; }
        public decimal? FriendOne { get; set; }
        public decimal? FriendTwo { get; set; }
        public decimal Stat { get; set; }

        public Company FriendOneNavigation { get; set; }
        public Company FriendTwoNavigation { get; set; }
    }
}
