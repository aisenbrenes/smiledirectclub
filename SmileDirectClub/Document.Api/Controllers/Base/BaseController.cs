using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using SmileDirectClub.Business;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Document.Api.Controllers
{
    [ApiController]
    [Route("api/smiledirectclub/[controller]")]

    public class BaseController : ControllerBase
    {
        protected IConfiguration configuration;
        protected string sqlConnection;

        public BaseController(IConfiguration iConfig) 
        {
            configuration = iConfig;
            sqlConnection = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
    }
}