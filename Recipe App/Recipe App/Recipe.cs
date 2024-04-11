namespace Recipe_App
{
    internal class Recipe
    {
        private Ingredient[] ingredients;
        private Step[] steps;
        private string recipeName;

        public void AddIngredient(string name, int quantity, string unitOfMeasurement, int index)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Name = name;
            ingredient.Quantity = quantity;
            ingredient.UnitOfMeasurement = unitOfMeasurement;

            ingredients[index] = ingredient;
        }

        public void SetIngredientsLength(int length)
        {
            ingredients = new Ingredient[length];
        }

        public Ingredient[] Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        public Step[] Steps
        {
            get { return steps; }
            set { steps = value; }
        }

        public string RecipeName
        {
            get { return recipeName; }
            set { recipeName = value; }
        }
    }
}
