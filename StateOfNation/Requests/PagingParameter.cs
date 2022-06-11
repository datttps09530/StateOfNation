using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateOfNation.Requests
{
    public class PagingParameter
    {
        const int maxPageSize = 40;
        public int pageNumber { get; set; } = 1;
        public int _pageSize { get; set; } = 10;

        public int pageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}