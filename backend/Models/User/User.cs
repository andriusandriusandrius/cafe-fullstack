namespace backend.Models.User
{
    public abstract class User
    {
        private Guid Id {get;set;}
        private String Username {get;set;} = String.Empty;
        private String HashedPassword {get;set;} = String.Empty;
    }
}