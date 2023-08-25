using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Blogger.WebAPI.Data
{
    public class Users : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [MaxLength(6)]
        public string Gender { get; set; } = null!;

        public string? Address { get; set; }

        public string? RefreshToken { get; set; }


        //DROP TABLE __EFMigrationsHistory
        //Drop Table AspNetRoleClaims
        //DROP TABLE AspNetUserLogins
        //DROP TABLE AspNetUserRoles
        //DROP TABLE AspNetUserClaims
        //Drop Table AspNetUserTokens
        //DROP TABLE AspNetRoles
        //DROP TABLE AspNetUsers
    }
}
