using Microsoft.Extensions.Configuration;

namespace Document.Api.Models
{
    public class ApiBaseSingleton
    {
        public IConfiguration _configuration { get; set; }
        private static ApiBaseSingleton _instance;

        private ApiBaseSingleton() { }

        public static ApiBaseSingleton Instance 
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new ApiBaseSingleton();
                }
                return _instance;
            }
        }
    }
}
