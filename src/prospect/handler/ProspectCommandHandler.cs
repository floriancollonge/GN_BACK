using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using Microsoft.Extensions.Configuration;
using nursery.context;
using nursery.prospect.models;
using System;

namespace nursery.prospect
{
    /// <summary>Database requests handler</summary>
    public class ProspectCommandHandler
    {
        private ILogger _logger;
        protected IConfiguration _configuration;
        private MyDbContext _dbContext;

        internal ProspectCommandHandler(ILogger logger, IConfiguration configuration, MyDbContext dbContext)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._dbContext = dbContext;
        }

        /// <summary>Add a prospect to the DB</summary>
        /// <returns>ProspectDTO : The updated prospect</returns>
        internal void AddProspect(ProspectDTO prospect)
        {
            using (Operation.Time("Adding a new prospect to the list"))
            {
                ProspectDAO entity = ProspectMapper.MapEntityFromDTO(prospect);
                entity.DateInsert = System.DateTime.Now;
                entity.IdProspect = Guid.NewGuid().ToString();
                _dbContext.Prospects.Add(entity);
                _dbContext.SaveChanges();
            }
        }

    }
}