using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nursery.prospect.models
{
    [Table("user")]
    public class UserDAO
    {
        [Key]
        [Column("id_user")]
        public int IdUser {get;set;}
        
        [Column("first_name")]
        [Required]
        public string FirstName {get;set;}

        [Column("last_name")]
        [Required]
        public string LastName {get;set;}

        [Column("login")]
        [Required]
        public string Login {get;set;}

        [Column("password")]
        [Required]
        public string Password {get;set;}

        [Column("deleted")]
        [Required]
        public bool Deleted {get;set;}

       public UserDAO()         
        {         
        }
    }
}