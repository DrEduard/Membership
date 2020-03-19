using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Membership.Models
{
    public class MVCGridToolbarModel
    {
        ApplicationDbContext db;
        public MVCGridToolbarModel()
        {
            db = new ApplicationDbContext();
            Statuses = db.Statuses.ToList();
        }

        public MVCGridToolbarModel(string gridName)
        {
            MVCGridName = gridName;
            db = new ApplicationDbContext();
            Statuses = db.Statuses.ToList();
        }

        public string MVCGridName { get; set; }
        public bool PageSize { get; set; }
        public bool ColumnVisibility { get; set; }
        public bool Export { get; set; }
        public bool GlobalSearch { get; set; }
        public List<Status> Statuses { get; set; }
    }
}