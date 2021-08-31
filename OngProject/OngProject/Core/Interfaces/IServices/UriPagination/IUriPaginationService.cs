using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices.IUriPaginationService
{
   public interface IUriPaginationService
    {
        public Uri GetPaginationUri(int page, string actionUrl);
    }
}
