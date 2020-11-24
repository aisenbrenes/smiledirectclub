using System;
using System.Collections.Generic;
using System.Text;

namespace SmileDirectClub.Common
{
    public interface IApiRequest<T>
    {
        List<T> Data { get; set; }

        Pagination Pagination { get; set; }
    }
}
