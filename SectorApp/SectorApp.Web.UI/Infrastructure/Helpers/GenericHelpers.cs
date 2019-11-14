using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SectorApp.Web.UI.Infrastructure.Helpers
{
    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Children { get; set; }
    }

    public static class GenericHelpers
    {
        public static IEnumerable<TreeItem<T>> GenerateTree<T, TK>(
            this IEnumerable<T> collection,
            Func<T, TK> idSelector,
            Func<T, TK> parentIdSelector,
            TK rootId = default(TK))
        {
            var enumerable = collection.ToList();
            foreach (var c in enumerable.Where(c => parentIdSelector(c).Equals(rootId)))
            {
                yield return new TreeItem<T>
                {
                    Item = c,
                    Children = enumerable.GenerateTree(idSelector, parentIdSelector, idSelector(c))
                };
            }
        }
    }
}
