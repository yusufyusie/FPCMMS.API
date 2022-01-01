﻿using FPCMMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPCMMS.Infrastructure.Persistence.Configuration
{
    public class NotifyWeaponConfiguration : IEntityTypeConfiguration<NotifyWeapon>
    {
        public void Configure(EntityTypeBuilder<NotifyWeapon> builder)
        {
            builder.HasData
            (
                new NotifyWeapon
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Gun",
                    Type = "AK-47, MD 2021",
                    Description = "Made in Turkey",
                    Attachment = "/weapon.png"
                },
                new NotifyWeapon
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Sniper",
                    Type = "AK-47, MD 2021",
                    Description = "Made in Turkey",
                    Attachment = "/gunshgut.png"
                }
            );
        }
    }
}
