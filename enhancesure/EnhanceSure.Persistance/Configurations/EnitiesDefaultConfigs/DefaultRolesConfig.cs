using EnhanceSure.Domain.Common;
using EnhanceSure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnhanceSure.Persistance.Configurations.EnitiesDefaultConfigs {
    /// <summary>
    /// This class is created to setup the default configurations of the Role
    /// </summary>
    public class DefaultRolesConfig: IEntityTypeConfiguration<Role> {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //inserts automatically while migration command is executed 
            builder.HasData(
            new Role
            {
                Id=Guid.NewGuid(),
                RoleName="User",
                CreatedAt=DateTime.UtcNow,
                LastModifiedAt=DateTime.UtcNow,
                CreatedBy=CommonActor.SystemDefaultID, 
                LastModifiedBy=CommonActor.SystemDefaultID,
            },
            new Role
            {
                Id=Guid.NewGuid(),
                RoleName="Admin",
                CreatedAt=DateTime.UtcNow,
                LastModifiedAt=DateTime.UtcNow,
                CreatedBy=CommonActor.SystemDefaultID,
                LastModifiedBy=CommonActor.SystemDefaultID,

            },
            new Role
            {
                Id=Guid.NewGuid(),
                RoleName="SuperAdmin",
                CreatedAt=DateTime.UtcNow,
                LastModifiedAt=DateTime.UtcNow,
                CreatedBy=CommonActor.SystemDefaultID,
                LastModifiedBy=CommonActor.SystemDefaultID,

            }
            );
        }
    }
}
