using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.Interfaces.IServices.IUriPaginationService;

namespace OngProject.Core.Services.UriPagination
{
    public class UriPaginationService : IUriPaginationService
    {
        private readonly string _baseUri;
        public UriPaginationService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri GetPaginationUri(int page, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
