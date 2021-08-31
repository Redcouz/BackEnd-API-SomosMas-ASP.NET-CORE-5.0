using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OngProject.Core.Helper.Pagination
{
    public class ResponsePagination<T>
    {
        public ResponsePagination(T data)
        {
            Data = data;
        }

    
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        [JsonIgnore]
        public bool HasNextPage { get; set; }

        [JsonIgnore]
        public bool HasPreviousPage { get; set; }
        public string NextPageUrl { get; set; }
        public string PreviousPageUrl { get; set; }
        public T Data { get; set; }
    }
}
