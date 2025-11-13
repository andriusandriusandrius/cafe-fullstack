namespace backend.Models.Coffee
{
    public class ColdCoffeeBehaviour : ICoffeeBehaviour
    {

        public bool IsSizeAllowed(CoffeSize coffeSize) => coffeSize != CoffeSize.Large;
    }
}