namespace backend.Models.Coffee
{
    public interface ICoffeeBehaviour
    {
        public bool IsSizeAllowed(CoffeSize coffeeSize);
    }
}