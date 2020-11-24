using System.Collections.Generic;

namespace SmileDirectClub.Common
{
    public class ApiRequest<T> : IApiRequest<T>
    {
        public List<T> Data { get; set; }

        public Pagination Pagination { get; set; }

        public string ConnectionString { get; set; }
    }
}
