using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using nursery.context;
using System.Collections.Generic;
using nursery.prospect.models;
using nursery.prospect;

namespace nursery.Controllers.User
{
    /*
     * Handle the prospects 
     */
    [Route("/")]
    [ApiController]
    public class ProspectController : ControllerBase
    {

        /// <summary>Default logger</summary>
        protected ILogger _logger;
        /// <summary>Link to the configuration files</summary>
        protected IConfiguration _configuration;
        /// <summary>Db context</summary>
        protected readonly MyDbContext _dbContext;

        public ProspectController(IConfiguration configuration, ILogger<UserController> logger, MyDbContext dbContext) : base()
        {
            this._logger = logger;
            this._configuration = configuration;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Get a list of the prospects for the user selected
        /// </summary>
        /// <param name="idUser">Id of the user using the application</param>
        [Route("/v1/prospects")]
        [HttpGet]
        // [Authorize]
        public IActionResult GetProspects(string idUser)
        {
            var handler = new ProspectQueryHandler(_logger, _configuration, _dbContext);
            List<ProspectDTO> prospects = handler.GetProspects();

            return Ok(prospects);
        }

    }
}