using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackDigital.Data
{
    public static class ListHelper
    {
        public static ICollection<ItemA> UpdateAllByList<ItemA, ItemB>(this ICollection<ItemA> currentList,
                                            ICollection<ItemB> newList,
                                            Func<ItemA, ItemB, bool> compare,
                                            Func<ItemA, ItemB, ItemA>? updateData = null)
            where ItemA : class, new()
            where ItemB : class, new()
        {
            currentList.RemoveByList(newList, compare);

            if (updateData != null)
                currentList.UpdateDataByList(newList, compare, updateData);

            return currentList.AddByList(newList, compare, updateData);
        }

        public static ICollection<ItemA> RemoveByList<ItemA, ItemB>(this ICollection<ItemA> currentList, 
                                            ICollection<ItemB> newList,
                                            Func<ItemA, ItemB, bool> compare)
            where ItemA : class, new()
            where ItemB : class, new()
        {
            var itensToRemove = currentList.Where(currentItem =>
            {
                return !newList.Any(newItem =>
                {
                    return compare(currentItem, newItem);
                });
            });

            foreach (var item in itensToRemove)
                currentList.Remove(item);

            return currentList;
        }

        public static ICollection<ItemA> UpdateDataByList<ItemA, ItemB>(this ICollection<ItemA> currentList,
                                            ICollection<ItemB> newList,
                                            Func<ItemA, ItemB, bool> compare,
                                            Func<ItemA, ItemB, ItemA>? updateData = null)
            where ItemA : class, new()
            where ItemB : class, new()
        {
            if (updateData != null)
            {
                foreach (var newItem in newList)
                {
                    var currentItem = currentList.FirstOrDefault(currentItem =>
                    {
                        return compare(currentItem, newItem);
                    });

                    if (currentItem != null)
                        currentItem = updateData(currentItem, newItem);
                }
            }

            return currentList;
        }

        public static ICollection<ItemA> AddByList<ItemA, ItemB>(this ICollection<ItemA> currentList,
                                            ICollection<ItemB> newList,
                                            Func<ItemA, ItemB, bool> compare,
                                            Func<ItemA, ItemB, ItemA>? updateData = null)
            where ItemA : class, new()
            where ItemB : class, new()
        {
            var itensToAdd = newList.Where(newItem =>
            {
                return !currentList.Any(currentItem =>
                {
                    return compare(currentItem, newItem);
                });
            });

            foreach (var item in itensToAdd)
            {
                ItemA newItem;

                if (typeof(ItemA) == typeof(ItemB))
                {
                    newItem = (ItemA)Convert.ChangeType(item, typeof(ItemA));
                }
                else
                {
                    newItem = new();

                    if (updateData != null)
                        newItem = updateData(newItem, item);
                }
                    
                if (newItem != null)
                    currentList.Add(newItem);
            }

            return currentList;
        }
    }
}
