using System;

namespace nursery.prospect.models
{
    public class ProspectDTO
    {
        public string IdProspect {get;set;}
        
        public string IdUser {get;set;}

        public string FirstName {get;set;}

        public string LastName {get;set;}

        public string CompanyName {get;set;}

        public string Mail {get;set;}

        public string Phone {get;set;}

        public int IdStep {get;set;}

        public DateTime LastContactDate {get;set;}

        public DateTime NextContactDate {get;set;}

        public DateTime DateInsert {get;set;}

        public ProspectDTO()         
        {         
        }
    }
}