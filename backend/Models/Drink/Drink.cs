namespace backend.Models.Drink
{
    public class Drink
    {
        private Guid Id {get;set;}
        private String Name {get;set;} = String.Empty;
        private Double Price {get;set;}
        private String Recipe {get;set;} = String.Empty;
        private DrinkSize Size {get;set;}
        private ICollection<Ingredient> Ingredients = new List<Ingredient>();
        private IDrinkBehaviour? Behaviour {get;}

        public bool IsHot => Behaviour is HotCoffeeBehaviour;
        public bool IsCold => Behaviour is ColdCoffeeBehaviour;

        public Drink(Guid Id, String Name, Double Price, String Recipe, ICollection<Ingredient> Ingredients, DrinkSize Size, IDrinkBehaviour Behaviour)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Recipe = Recipe;
            this.Size = Size;
            this.Ingredients = Ingredients;
            this.Behaviour = Behaviour;

            if(IsCold && Size == DrinkSize.Large ) throw new ArgumentException($"Size {Size} is not allowed for cold coffees");
        }


    }
}