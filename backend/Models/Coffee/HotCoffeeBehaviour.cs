namespace backend.Models.Coffee
{
    public class HotCoffeeBehaviour : ICoffeeBehaviour
    {
         public bool IsSizeAllowed(CoffeSize coffeSize) => true;
    }
}