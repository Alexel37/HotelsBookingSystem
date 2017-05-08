using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace HotelsBookingSystem.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Здесь добавьте настраиваемые утверждения пользователя
            return userIdentity;
        }

        public ApplicationUser()
        {
            this.CreditCards = new HashSet<CreditCard>();
            this.BookingHistories = new HashSet<BookingHistory>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserLevelId { get; set; }

        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<BookingHistory> BookingHistories { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<BookingHistory> BookingHistories { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<TypeOfRoom> TypeOfRooms { get; set; }
        public DbSet<UserLevel> UserLevels { get; set; }
    }
}