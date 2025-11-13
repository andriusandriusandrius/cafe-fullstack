namespace backend.Models{
    public class Ingredient
    {
        private Guid Id {get;set;}
        private String Name {get;set;} = String.Empty;
        private Double Price {get;set;}
    }
}