namespace Recipe_App
{
    internal class Recipe
    {
        private Ingredient[] ingredients;
        private Step[] steps;
        private string recipeName;

        public void AddIngredient(string name, int quantity, string unitOfMeasurement, int index)
        {
            Ingredient ingredient = new Ingredient
            {
                Name = name,
                Quantity = (double)quantity,
                OriginalQuantity = quantity,
                UnitOfMeasurement = unitOfMeasurement
            };
            

            ingredients[index] = ingredient;
        }

        public void SetIngredientsLength(int length)
        {
            ingredients = new Ingredient[length];
        }

        public void AddStep(int stepNumber, string name, string description, int index)
        {
            Step step = new Step(stepNumber);
            step.StepName = name;
            step.Description = description;

            Steps[index] = step;
        }

        public void SetStepsLength(int length)
        {
            Steps = new Step[length];
        }

        public void PrintDetails()
        {
            string ingredientsString = "";
            string stepString = "";

            foreach (Ingredient ingredient in ingredients)
            {
                ingredientsString += $"- {ingredient.Quantity} {ingredient.UnitOfMeasurement} of {ingredient.Name}\n";
            }

            foreach (Step step in Steps)
            {
                stepString += $"{step.StepNumber}. {step.Description}\n";
            }

            Console.WriteLine(
                "==============================================" + "\n" + 
                "**********************************************" + "\n" +
                $"              {recipeName}" + "\n" +
                "**********************************************" + "\n" +
                "\n" +
                "Ingredients:" + "\n" +
                $"{ingredientsString}" + "\n" +
                "Steps:" + "\n" +
                $"{stepString}" +
                "==============================================");
        }

        public void Scale(double factor)
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.Quantity * factor;
            }
        }

        public void ResetIngredientValues()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }
        public void ClearRecipe()
        {
            ingredients = new Ingredient[0];
            steps = new Step[0];
            recipeName = string.Empty;
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
