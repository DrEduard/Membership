using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Membership.Models
{
    public class StatusViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}