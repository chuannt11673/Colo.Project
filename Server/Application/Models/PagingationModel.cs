using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Models
{
    public class PagingationRequestModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class PagingationModel<TModel>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public List<TModel> Items { get; private set; }


        public PagingationModel(List<TModel> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static PagingationModel<TModel> Create(IQueryable<TModel> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PagingationModel<TModel>(items, count, pageIndex, pageSize);
        }
    }
}
