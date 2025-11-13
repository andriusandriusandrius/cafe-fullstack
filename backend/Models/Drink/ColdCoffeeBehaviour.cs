namespace backend.Models.Drink
{
    public class ColdCoffeeBehaviour : IDrinkBehaviour
    {

        public bool IsSizeAllowed(DrinkSize coffeSize) => coffeSize != DrinkSize.Large;
    }
}