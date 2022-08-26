using BlackDigital.Data.Test;

namespace BlackDigital.Data.Tests
{
    [Trait("BaseFilter", "Test Object helper")]
    public class BaseFilterTest
    {
        private static IQueryable<BaseDeleted> ListTest
        {
            get
            {
                List<TestModel> list = new()
                {
                    new TestModel
                    {
                        Created = DateTime.Now.AddMonths(-3),
                        Updated = DateTime.Now.AddMonths(-3),
                    },

                    new TestModel
                    {
                        Created = DateTime.Now.AddMonths(-2),
                        Updated = DateTime.Now.AddMonths(-1),
                    },

                    new TestModel
                    {
                        Created = DateTime.Now.AddMonths(-1),
                        Updated = DateTime.Now.AddMonths(-1),
                        Deleted = DateTime.Now.AddDays(-1)
                    }
                };

                return list.AsQueryable();
            }
        }


        [Fact]
        public void Greater()
        {
            var minDate = DateTime.Now.AddMonths(-2).AddDays(-1);
            var filter = ListTest.FilterCreatedGreater(minDate);
            Assert.Equal(2, filter.Count());

            filter = ListTest.FilterUpdatedGreater(minDate);
            Assert.Equal(2, filter.Count());

            filter = ListTest.FilterDeletedGreater(minDate);
            Assert.Equal(1, filter.Count());

            minDate = minDate.AddMonths(1);
            filter = ListTest.FilterCreatedGreater(minDate);
            Assert.Equal(1, filter.Count());

            filter = ListTest.FilterUpdatedGreater(minDate);
            Assert.Equal(2, filter.Count());

            filter = ListTest.FilterDeletedGreater(minDate);
            Assert.Equal(1, filter.Count());

            minDate = DateTime.Now.AddDays(1);
            filter = ListTest.FilterCreatedGreater(minDate);
            Assert.Equal(0, filter.Count());

            filter = ListTest.FilterUpdatedGreater(minDate);
            Assert.Equal(0, filter.Count());

            filter = ListTest.FilterDeletedGreater(minDate);
            Assert.Equal(0, filter.Count());
        }

        [Fact]
        public void Less()
        {
            var maxDate = DateTime.Now.AddMonths(-1).AddDays(-1);
            var filter = ListTest.FilterCreatedLess(maxDate);
            Assert.Equal(2, filter.Count());

            filter = ListTest.FilterUpdatedLess(maxDate);
            Assert.Equal(1, filter.Count());

            filter = ListTest.FilterDeletedLess(maxDate);
            Assert.Equal(0, filter.Count());

            maxDate = maxDate.AddMonths(1);
            filter = ListTest.FilterCreatedLess(maxDate);
            Assert.Equal(3, filter.Count());

            filter = ListTest.FilterUpdatedLess(maxDate);
            Assert.Equal(3, filter.Count());

            filter = ListTest.FilterDeletedLess(maxDate);
            Assert.Equal(0, filter.Count());

            maxDate = DateTime.Now.AddDays(1);
            filter = ListTest.FilterCreatedLess(maxDate);
            Assert.Equal(3, filter.Count());

            filter = ListTest.FilterUpdatedLess(maxDate);
            Assert.Equal(3, filter.Count());

            filter = ListTest.FilterDeletedLess(maxDate);
            Assert.Equal(1, filter.Count());
        }

        [Fact]
        public void Deleted()
        {
            var filter = ListTest.HasDeleted();
            Assert.Equal(1, filter.Count());

            filter = ListTest.HasNotDeleted();
            Assert.Equal(2, filter.Count());
        }
    }
}