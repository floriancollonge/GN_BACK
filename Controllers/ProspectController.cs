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

        /// <summary>
        /// Adding a prospect to the list in DB
        /// </summary>
        /// <param name="prospect">Prospect to add to the application</param>
        [Route("/v1/prospect")]
        [HttpPost]
        // [Authorize]
        public IActionResult AddProspect(ProspectDTO prospect)
        {
            validateInputs(prospect);
            ProspectCommandHandler commandHandler = new ProspectCommandHandler(_logger, _configuration, _dbContext);
            commandHandler.AddProspect(prospect);
            return Created("/v1/prospect", prospect);
        }

        /// <summary>Validate the datas inside the DTO</summary>
        /// <param name="prospect"*>The DTO to validate</param>
        /// <returns>bool : true if everything is in order, false otherwise</returns>
        private bool validateInputs(ProspectDTO prospect)
        {
            if (string.IsNullOrEmpty(prospect.FirstName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(prospect.LastName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(prospect.Mail))
            {
                return false;
            }

            return true;
        }

    }
}