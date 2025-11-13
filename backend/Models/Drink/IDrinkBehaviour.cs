namespace backend.Models.Drink
{
    public interface IDrinkBehaviour
    {
        public bool IsSizeAllowed(DrinkSize drinkSize);
    }
}