namespace backend.Models.Coffee
{
    public class Coffee
    {
        private Guid Id {get;set;}
        private String Name {get;set;} = String.Empty;
        private Double Price {get;set;}
        private String Recipe {get;set;} = String.Empty;
        private CoffeSize Size {get;set;}
        private ICollection<Ingredient> Ingredients = new List<Ingredient>();
        private ICoffeeBehaviour? Behaviour {get;}

        public bool IsHot => Behaviour is HotCoffeeBehaviour;
        public bool IsCold => Behaviour is ColdCoffeeBehaviour;

        public Coffee(Guid Id, String Name, Double Price, String Recipe, ICollection<Ingredient> Ingredients, CoffeSize Size, ICoffeeBehaviour Behaviour)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Recipe = Recipe;
            this.Size = Size;
            this.Ingredients = Ingredients;
            this.Behaviour = Behaviour;

            if(IsCold && Size == CoffeSize.Large ) throw new ArgumentException($"Size {Size} is not allowed for cold coffees");
        }


    }
}