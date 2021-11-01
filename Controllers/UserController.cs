using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using nursery.context;
using System.Collections.Generic;
using nursery.prospect.models;
using nursery.user;

namespace nursery.Controllers.User
{
    /*
     * Handle the users 
     */
    [Route("/")]
    [ApiController]
    public class UserController : ControllerBase
    {

        /// <summary>Default logger</summary>
        protected ILogger _logger;
        /// <summary>Link to the configuration files</summary>
        protected IConfiguration _configuration;
        /// <summary>Db context</summary>
        protected readonly MyDbContext _dbContext;

        public UserController(IConfiguration configuration, ILogger<UserController> logger, MyDbContext dbContext) : base()
        {
            this._logger = logger;
            this._configuration = configuration;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Get the list of accounts from the DB
        /// </summary>
        [Route("/v1/users")]
        [HttpGet]
        // [Authorize]
        public IActionResult GetUsers()
        {
            var handler = new UserQueryHandler(_logger, _configuration, _dbContext);
            List<UserDTO> users = handler.GetUsers();

            return Ok(users);
        }

    }
}