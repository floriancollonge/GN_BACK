using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using Microsoft.Extensions.Configuration;
using nursery.context;
using nursery.prospect.models;

namespace nursery.prospect
{
    /// <summary>Database requests handler</summary>
    public class ProspectQueryHandler
    {
        private ILogger Logger;
        protected IConfiguration configuration;
        private MyDbContext dbContext;

        internal ProspectQueryHandler(ILogger logger, IConfiguration configuration, MyDbContext dbContext)
        {
            this.Logger = logger;
            this.configuration = configuration;
            this.dbContext = dbContext;
        }

        /// <summary>get informations about prospects</summary>
        /// <returns>List<ProspectDTO> : List of the prospects from DB</returns>
        internal List<ProspectDTO> GetProspects()
        {
            using (Operation.Time("Get the list of the prospects"))
            {
                return (from prospectTable in dbContext.Prospects
                select new ProspectDTO
                {
                    IdUser = prospectTable.IdUser,
                    FirstName = prospectTable.FirstName,
                    LastName = prospectTable.LastName,
                    DateInsert = prospectTable.DateInsert,
                    IdProspect = prospectTable.IdProspect,
                    IdStep = prospectTable.IdStep,
                    LastContactDate = prospectTable.LastContactDate,
                    Mail = prospectTable.Mail,
                    NextContactDate = prospectTable.NextContactDate,
                    Phone = prospectTable.Phone
                }).ToList();
            }
        }

    }
}