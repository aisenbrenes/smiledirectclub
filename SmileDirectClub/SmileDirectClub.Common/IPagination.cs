using System;
using System.Collections.Generic;
using System.Text;

namespace SmileDirectClub.Common
{
    public interface IPagination
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
        int ItemsCount { get; set; }
        double PageCount { get; set; }
    }
}
