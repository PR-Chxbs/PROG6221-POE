namespace Recipe_App
{
    internal class Recipe
    {
        private Ingredient[] ingredients;
        private Step[] steps;

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
    }
}
