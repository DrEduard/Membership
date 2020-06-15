using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Membership.Models
{
    public interface IApplicationDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("Membership", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<Status> Statuses { get; set; }
    }

    [Table("Member")]
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index(IsUnique = true)]
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public int MemNum { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public Status Status { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string NickName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Suffix { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Spouse { get; set; }
        public string Clan { get; set; }
        public string Kilted { get; set; }
        public string Business { get; set; }
        public string OfficePhone { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public DateTime? ElectionDate { get; set; }
        public DateTime? ActivitionDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Reason { get; set; }
        public string NewMemberOrientation { get; set; }
        public string WaitingStatus { get; set; }
        public int CountPK { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    [Table("Status")]
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}