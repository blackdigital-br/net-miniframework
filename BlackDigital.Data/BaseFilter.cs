using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDigital.Data
{
    public static class BaseFilter
    {
        #region "BaseCreated"

        public static IQueryable<BaseCreated> FilterCreatedGreater(this IQueryable<BaseCreated> query, DateTime? minValue)
        {
            if (minValue.HasValue)
                return query.Where(item => item.Created > minValue.Value);

            return query;
        }

        public static IQueryable<BaseCreated> FilterCreatedGreaterOrEqual(this IQueryable<BaseCreated> query, DateTime? minValue)
        {
            if (minValue.HasValue)
                return query.Where(item => item.Created >= minValue.Value);

            return query;
        }

        public static IQueryable<BaseCreated> FilterCreatedLess(this IQueryable<BaseCreated> query, DateTime? maxValue)
        {
            if (maxValue.HasValue)
                return query.Where(item => item.Created < maxValue.Value);

            return query;
        }

        public static IQueryable<BaseCreated> FilterCreatedLessOrEqual(this IQueryable<BaseCreated> query, DateTime? maxValue)
        {
            if (maxValue.HasValue)
                return query.Where(item => item.Created <= maxValue.Value);

            return query;
        }

        public static IQueryable<BaseCreated> FilterCreatedBetween(this IQueryable<BaseCreated> query, DateTime? minValue, DateTime? maxValue)
        {
            if (minValue.HasValue && maxValue.HasValue)
                return query.Where(item => item.Created >= minValue.Value && item.Created <= maxValue.Value);

            return query;
        }

        #endregion "BaseCreated"

        #region "BaseUpdated"

        public static IQueryable<BaseUpdated> FilterUpdatedGreater(this IQueryable<BaseUpdated> query, DateTime? minValue)
        {
            if (minValue.HasValue)
                return query.Where(item => item.Updated > minValue.Value);

            return query;
        }

        public static IQueryable<BaseUpdated> FilterUpdatedGreaterOrEqual(this IQueryable<BaseUpdated> query, DateTime? minValue)
        {
            if (minValue.HasValue)
                return query.Where(item => item.Updated >= minValue.Value);

            return query;
        }

        public static IQueryable<BaseUpdated> FilterUpdatedLess(this IQueryable<BaseUpdated> query, DateTime? maxValue)
        {
            if (maxValue.HasValue)
                return query.Where(item => item.Updated < maxValue.Value);

            return query;
        }

        public static IQueryable<BaseUpdated> FilterUpdatedLessOrEqual(this IQueryable<BaseUpdated> query, DateTime? maxValue)
        {
            if (maxValue.HasValue)
                return query.Where(item => item.Updated <= maxValue.Value);

            return query;
        }

        public static IQueryable<BaseUpdated> FilterUpdatedBetween(this IQueryable<BaseUpdated> query, DateTime? minValue, DateTime? maxValue)
        {
            if (minValue.HasValue && maxValue.HasValue)
                return query.Where(item => item.Updated >= minValue.Value && item.Updated <= maxValue.Value);

            return query;
        }

        #endregion "BaseUpdated"

        #region "BaseDeleted"

        public static IQueryable<BaseDeleted> FilterDeletedGreater(this IQueryable<BaseDeleted> query, DateTime? minValue)
        {
            if (minValue.HasValue)
                return query.Where(item => item.Deleted > minValue.Value);

            return query;
        }

        public static IQueryable<BaseDeleted> FilterDeletedGreaterOrEqual(this IQueryable<BaseDeleted> query, DateTime? minValue)
        {
            if (minValue.HasValue)
                return query.Where(item => item.Deleted >= minValue.Value);

            return query;
        }

        public static IQueryable<BaseDeleted> FilterDeletedLess(this IQueryable<BaseDeleted> query, DateTime? maxValue)
        {
            if (maxValue.HasValue)
                return query.Where(item => item.Deleted < maxValue.Value);

            return query;
        }

        public static IQueryable<BaseDeleted> FilterDeletedLessOrEqual(this IQueryable<BaseDeleted> query, DateTime? maxValue)
        {
            if (maxValue.HasValue)
                return query.Where(item => item.Deleted <= maxValue.Value);

            return query;
        }

        public static IQueryable<BaseDeleted> FilterDeletedBetween(this IQueryable<BaseDeleted> query, DateTime? minValue, DateTime? maxValue)
        {
            if (minValue.HasValue && maxValue.HasValue)
                return query.Where(item => item.Deleted >= minValue.Value && item.Deleted <= maxValue.Value);

            return query;
        }

        public static IQueryable<BaseDeleted> HasDeleted(this IQueryable<BaseDeleted> query)
        {
            return query.Where(item => item.Deleted != null);
        }

        public static IQueryable<BaseDeleted> HasNotDeleted(this IQueryable<BaseDeleted> query)
        {
            return query.Where(item => item.Deleted == null);
        }

        #endregion "BaseDeleted"
    }
}
