using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using nursery.context;
using System.Collections.Generic;
using nursery.prospect.models;
using nursery.user;

namespace api.Controllers.User
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
        /// Get information about user from headers token (Uniquely for
        /// the current user connected to the application, page My Profile for example)
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