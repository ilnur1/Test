using System;
using System.Collections.Generic;

namespace Dis1.Models
{
    public partial class Company
    {
        public Company()
        {
            FriendsFriendOneNavigation = new HashSet<Friends>();
            FriendsFriendTwoNavigation = new HashSet<Friends>();
            Report = new HashSet<Report>();
            Shablon = new HashSet<Shablon>();
        }

        public decimal Cc { get; set; }
        public string CompanyLogin { get; set; }
        public string CompanyPas { get; set; }
        public string CompanyName { get; set; }
        public string CompanyInn { get; set; }
        public string Family { get; set; }
        public string Firstname { get; set; }
        public string Lasttname { get; set; }
        public string CompanyAdress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyDescription { get; set; }

        public ICollection<Friends> FriendsFriendOneNavigation { get; set; }
        public ICollection<Friends> FriendsFriendTwoNavigation { get; set; }
        public ICollection<Report> Report { get; set; }
        public ICollection<Shablon> Shablon { get; set; }
    }
}
