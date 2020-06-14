using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Membership.Models
{
    public class UsersViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public List<Status> Statuses { get; set; }

        public UsersViewModel()
        {

        }
    }
}