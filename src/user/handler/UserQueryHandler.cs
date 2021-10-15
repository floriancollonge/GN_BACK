using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using Microsoft.Extensions.Configuration;
using nursery.context;
using nursery.prospect.models;

namespace nursery.user
{
    /// <summary>Database requests handler</summary>
    public class UserQueryHandler
    {
        private ILogger Logger;
        protected IConfiguration configuration;
        private MyDbContext dbContext;

        internal UserQueryHandler(ILogger logger, IConfiguration configuration, MyDbContext dbContext)
        {
            this.Logger = logger;
            this.configuration = configuration;
            this.dbContext = dbContext;
        }

        /// <summary>get informations users</summary>
        /// <param name="criterias">search criterias for users list</param>
        /// <returns>SearchUserResponse : Search informations DTO</returns>
        internal List<UserDTO> GetUsers()
        {
            using (Operation.Time("Get the list of the users"))
            {
                return (from userTable in dbContext.Users
                where !userTable.Deleted
                select new UserDTO
                {
                    IdUser = userTable.IdUser,
                    Login = userTable.Login,
                    Password = userTable.Password,
                    FirstName = userTable.FirstName,
                    LastName = userTable.LastName
                                    }).ToList();
            }
        }

    }
}