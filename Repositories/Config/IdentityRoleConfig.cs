using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole() { Name = "User", NormalizedName = "USER" },
                new IdentityRole() { Name = "Editor", NormalizedName = "EDITOR" },
                new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" }
            );
        }
    }
}