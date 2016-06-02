using System;

namespace ProjectSample.Infrastructure.DataAccess.List.Models
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