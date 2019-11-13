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

    internal static class GenericHelpers
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

    public static class StringExtensions
    {
        public static string Repeat(this char chatToRepeat, int repeat)
        {

            return new string(chatToRepeat, repeat);
        }
        public static string Repeat(this string stringToRepeat, int repeat)
        {
            var builder = new StringBuilder(repeat * stringToRepeat.Length);
            for (int i = 0; i < repeat; i++)
            {
                builder.Append(stringToRepeat);
            }
            return builder.ToString();
        }
    }
}
