using Membership.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Membership.Startup))]
namespace Membership
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin role    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                string userPWD = "sas2mem";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            if (!roleManager.RoleExists("Editor"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Editor";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "editor";
                user.Email = "editor@editor.com";

                string userPWD = "sas2mem";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Editor");
                }
            }

            if (!roleManager.RoleExists("Viewer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Viewer";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "viewer";
                user.Email = "viewer@viewer.com";

                string userPWD = "sas2mem";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Viewer");
                }
            }

            if(context.Statuses.ToList().Count == 0)
            {
                context.Statuses.Add(new Status { Name = "Active Res" });
                context.Statuses.Add(new Status { Name = "Assoc" });
                context.Statuses.Add(new Status { Name = "Honorary" });
                context.Statuses.Add(new Status { Name = "Widow" });
                context.Statuses.Add(new Status { Name = "Waiting" });
                context.Statuses.Add(new Status { Name = "Active NonRes" });
                context.Statuses.Add(new Status { Name = "Admin" });
                context.Statuses.Add(new Status { Name = "Deceased" });
                context.SaveChanges();
            }
        }
    }
}
