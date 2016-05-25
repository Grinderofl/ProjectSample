using System;

namespace ProjectSample.Core.Infrastructure.DataAccess.List
{
    public class SearchItem<T>
    {
        public Func<T, object> Property { get; }
        public object Value { get; }

        public SearchItem(Func<T, object> property, object value)
        {
            Property = property;
            Value = value;
        }
    }
}