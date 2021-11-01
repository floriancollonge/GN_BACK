using nursery.prospect.models;

namespace nursery.prospect
{
    /// <summary>Mapper between entity and dto</summary>
    public class ProspectMapper
    {

        /// <summary>Create an entity from the DTO object</summary>
        /// <returns>ProspectDAO : The entity created from the dto</returns>
        internal static ProspectDAO MapEntityFromDTO(ProspectDTO dto)
        {
            ProspectDAO entity = new ProspectDAO();
            entity.DateInsert = dto.DateInsert;
            entity.FirstName = dto.FirstName;
            entity.IdProspect = dto.IdProspect;
            entity.IdStep = dto.IdStep;
            entity.IdUser = dto.IdUser;
            entity.CompanyName = dto.CompanyName;
            entity.LastContactDate = dto.LastContactDate;
            entity.LastName = dto.LastName;
            entity.Mail = dto.Mail;
            entity.NextContactDate = dto.NextContactDate;
            entity.Phone = dto.Phone;

            return entity;
        }

    }
}