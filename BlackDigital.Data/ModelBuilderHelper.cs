using Microsoft.EntityFrameworkCore;
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

        public static void AddCreatedColumn<TEntity>(this ModelBuilder modelBuilder)
            where TEntity : BaseCreated
        {
            modelBuilder.Entity<TEntity>().Property(s => s.Created)
                                          .HasColumnName(CreatedColumnName)
                                          .IsRequired();
        }

        public static void AddUpdatedColumn<TEntity>(this ModelBuilder modelBuilder)
            where TEntity : BaseUpdated
        {
            AddCreatedColumn<TEntity>(modelBuilder);

            modelBuilder.Entity<TEntity>().Property(s => s.Updated)
                                          .HasColumnName(UpdatedColumnName)
                                          .IsRequired();
        }

        public static void AddDeletedColumn<TEntity>(this ModelBuilder modelBuilder)
            where TEntity : BaseDeleted
        {
            AddUpdatedColumn<TEntity>(modelBuilder);

            modelBuilder.Entity<TEntity>().Property(s => s.Deleted)
                                          .HasColumnName(DeletedColumnName)
                                          .IsRequired();
        }
    }
}
