using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SmileDirectClub.Business;
using SmileDirectClub.Common;
using SmileDirectClub.DataAccess.Models;

namespace Document.Api.Controllers
{
    public class DocumentController : BaseController
    {
        #region Variables

        private readonly DocumentLogic service = new DocumentLogic();

        #endregion

        #region Constructor

        public DocumentController(IConfiguration iConfig) : base(iConfig) { }

        #endregion

        #region End Points

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] string request)
        {
            try
            {
                ApiRequest<SmileDirectClub.DataAccess.Models.Document> apiRequest = JsonConvert.DeserializeObject<ApiRequest<SmileDirectClub.DataAccess.Models.Document>>(request);
                apiRequest.ConnectionString = sqlConnection;

                // Get list
                IEnumerable<SmileDirectClub.DataAccess.Models.Document> result = service.GetMany(ref apiRequest, "admin");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApiRequest<SmileDirectClub.DataAccess.Models.Document> request)
        {
            try
            {
                request.ConnectionString = sqlConnection;

                // Get list
                IEnumerable<SmileDirectClub.DataAccess.Models.Document> result = service.Save(request, "admin");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }

        #endregion
    }
}
