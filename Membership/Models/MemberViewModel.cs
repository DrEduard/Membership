using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Membership.Models
{
    public class MemberViewModel
    {
        public MemberViewModel()
        {

        }
        public MemberViewModel(Member member, List<Status> statuses)
        {
            Member = member;
            Statuses = statuses;
        }
        public Member Member { get; set; }
        public List<Status> Statuses { get; set; }
    }
}