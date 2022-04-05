using IdentityInfra.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityInfra.Database
{
    public class IdentityClientContext : IdentityDbContext<
         ClientApplicationUser, ClientApplicationRole, string,
         ClientApplicationUserClaim, ClientApplicationUserRole, ClientApplicationUserLogin,
         ClientApplicationRoleClaim, ClientApplicationUserToken>
    {
        public IdentityClientContext(DbContextOptions<IdentityClientContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ClientApplicationUser>(b =>
            {
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<ClientApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            builder.Entity<ClientApplicationUser>(b => b.ToTable("ClientIdentityUser"));
            builder.Entity<ClientApplicationUserClaim>(b => b.ToTable("ClientIdentityUserClaim"));
            builder.Entity<ClientApplicationUserLogin>(b => b.ToTable("ClientIdentityUserLogin")
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId }));
            builder.Entity<ClientApplicationUserToken>(b => b.ToTable("ClientIdentityUserToken")
                .HasKey(l => new { l.LoginProvider, l.Name, l.UserId }));
            builder.Entity<ClientApplicationRole>(b => b.ToTable("ClientIdentityRole"));
            builder.Entity<ClientApplicationRoleClaim>(b => b.ToTable("ClientIdentityRoleClaim"));
            builder.Entity<ClientApplicationUserRole>(b => b.ToTable("ClientIdentityUserRole")
                .HasKey(r => new { r.UserId, r.RoleId }));
        }
    }
}
