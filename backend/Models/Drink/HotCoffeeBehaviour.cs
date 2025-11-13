namespace backend.Models.Drink
{
    public class HotCoffeeBehaviour : IDrinkBehaviour
    {
         public bool IsSizeAllowed(DrinkSize coffeeSize) => true;
    }
}