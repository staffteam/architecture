﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YH.Framework.Core.Domain.Security;

namespace YH.Framework.Data.Mapping
{
    public class EntityPermissionMap : EntityTypeConfiguration<EntityPermission>
    {
        public EntityPermissionMap()
        {
            this.HasKey(t => new { t.EntityID, t.EntityName, t.RoleID });
            this.Property(t => t.EntityID).IsRequired();
            this.Property(t => t.EntityName).IsRequired().HasMaxLength(20);
            this.HasRequired(t => t.Role).WithMany().HasForeignKey(t => t.RoleID).WillCascadeOnDelete(true);
        }
    }
}
