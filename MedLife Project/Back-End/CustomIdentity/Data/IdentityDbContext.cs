using CustomIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIdentity.Data
{
    public class IdentityDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(b =>
            {
                b.ToTable("AppUser");


            });

            builder.Entity<AppRole>(b =>
            {

                b.ToTable("AppRoles");


            });

            builder.Entity<AppRoleClaim>(b =>
            {

                b.ToTable("AppRoleClaims");


            });

            builder.Entity<AppUserClaim>(b =>
            {

                b.ToTable("AppUserClaims");


            });

            builder.Entity<AppUserLogin>(b =>
            {

                b.ToTable("AppUserLogins");


            });

            builder.Entity<AppUserRole>(b =>
            {

                b.ToTable("AppUserRoles");


            });

            builder.Entity<AppUserToken>(b =>
            {

                b.ToTable("AppUserTokens");


            });



        }
    }
}