using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nursery.prospect.models
{
    [Table("prospects")]
    public class ProspectDAO
    {
        [Key]
        [Column("id_prospect")]
        public string IdProspect {get;set;}
        
        [Column("id_user")]
        [Required]
        public string IdUser {get;set;}

        [Column("first_name")]
        [Required]
        public string FirstName {get;set;}

        [Column("last_name")]
        [Required]
        public string LastName {get;set;}

        [Column("company_name")]
        public string CompanyName {get;set;}

        [Column("mail")]
        public string Mail {get;set;}

        [Column("phone")]
        public string Phone {get;set;}

        [Column("id_step")]
        public int IdStep {get;set;}

        [Column("last_contact_date")]
        public DateTime LastContactDate {get;set;}

        [Column("next_contact_date")]
        public DateTime NextContactDate {get;set;}

        [Column("date_insert")]
        [Required]
        public DateTime DateInsert {get;set;}

        public ProspectDAO()         
        {         
        }
    }
}