﻿namespace Core.Helpers.PageHelper
{
   public class PaginatedList<T>
    {
        public List<T> Data { get; set; }
        public int Page { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; set; }
        public int CollectionSize { get; set; }
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            Data = items;
            Page = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            CollectionSize = count;
            // this.AddRange(items);
        }
        public bool HasNextPage => Page * PageSize < CollectionSize;
        public bool HasPreviousPage => Page > 1;
        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int count =  source.Count();
            if (pageSize == 0) pageSize = count;
            var items =  source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
