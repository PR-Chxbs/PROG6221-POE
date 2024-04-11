namespace Recipe_App
{
    internal class Recipe
    {
        private Ingredient[] ingredients;
        private Step[] steps;
        private string recipeName;

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
