using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDigital.Data
{
    public static class ModelBuilderHelper
    {
        private const string CreatedColumnName = "created_at";
        private const string UpdatedColumnName = "updated_at";
        private const string DeletedColumnName = "deleted_at";

        public static void AddCreatedColumn<TEntity>(this EntityTypeBuilder<TEntity> entity)
            where TEntity : BaseCreated
        {
            entity.Property(s => s.Created)
                  .HasColumnName(CreatedColumnName)
                  .IsRequired();
        }

        public static void AddUpdatedColumn<TEntity>(this EntityTypeBuilder<TEntity> entity)
            where TEntity : BaseUpdated
        {
            AddCreatedColumn(entity);

            entity.Property(s => s.Updated)
                  .HasColumnName(UpdatedColumnName)
                  .IsRequired();
        }

        public static void AddDeletedColumn<TEntity>(this EntityTypeBuilder<TEntity> entity)
            where TEntity : BaseDeleted
        {
            AddUpdatedColumn(entity);

            entity.Property(s => s.Deleted)
                  .HasColumnName(DeletedColumnName);
        }
    }
}
