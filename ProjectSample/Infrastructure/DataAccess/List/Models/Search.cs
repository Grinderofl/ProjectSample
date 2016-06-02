using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectSample.Infrastructure.DataAccess.List.Models
{
    public class Search<T>
    {
        private readonly List<Expression<Func<T, bool>>> _searchItems = new List<Expression<Func<T, bool>>>();
        //private readonly IList<SearchItem<T>> _searchItems = new List<SearchItem<T>>();

        //public IEnumerable<SearchItem<T>> SearchItems => _searchItems;

        public IEnumerable<Expression<Func<T, bool>>> SearchItems => _searchItems; 

        public void AddItem(Expression<Func<T, bool>> expression)
        {
            _searchItems.Add(expression);
        }
    }
}