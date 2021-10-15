namespace nursery.prospect.models
{
    public class UserDTO
    {
        public int IdUser {get;set;}
        
        public string FirstName {get;set;}

        public string LastName {get;set;}

        public string Login {get;set;}

        public string Password {get;set;}

        public bool Deleted {get;set;}

       public UserDTO()         
        {         
        }
    }
}