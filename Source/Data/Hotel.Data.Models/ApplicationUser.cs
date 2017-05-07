namespace Hotel.Data.Hotel.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using global::Hotel.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.CreatedOn = DateTime.Now;
            this.PreviousStays = new HashSet<Reservation>();
        }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }
        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public virtual ICollection<Reservation> PreviousStays{ get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            return userIdentity;
        }
    }
}
