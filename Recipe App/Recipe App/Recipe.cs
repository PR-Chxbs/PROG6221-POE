namespace Recipe_App
{
    internal class Recipe
    {
        private Ingredient[] ingredients;
        private Step[] steps;
        private string recipeName;

        // Method to instantiate an Ingredient
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

        // Instantiate ingredients array
        public void SetIngredientsLength(int length)
        {
            ingredients = new Ingredient[length];
        }

        // Method to instantiate an Step
        public void AddStep(int stepNumber, string name, string description, int index)
        {
            Step step = new Step(stepNumber)
            {
                StepName = name,
                Description = description
            };

            Steps[index] = step;
        }

        // Instantiate steps array
        public void SetStepsLength(int length)
        {
            Steps = new Step[length];
        }

        // Method to display recipe details
        public void PrintDetails()
        {
            string ingredientsString = "";
            string stepString = "";

            // Creating output for ingredient details
            foreach (Ingredient ingredient in ingredients)
            {
                ingredientsString += $"- {ingredient.Quantity} {ingredient.UnitOfMeasurement} of {ingredient.Name}\n";
            }

            // Creating output for step details
            foreach (Step step in Steps)
            {
                stepString += $"{step.StepNumber}. {step.Description}\n";
            }

            // Output template
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

        // Method to scale ingredient quantities by a factor
        public void Scale(double factor)
        {
            // loop to scale for each ingredient
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.Quantity * factor;
            }
        }

        // Method to reset ingredient quantities back to the original values
        public void ResetIngredientValues()
        {
            // loop to reset for each ingredient
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        // Method to clear recipe
        public void ClearRecipe()
        {
            ingredients = new Ingredient[0];
            steps = new Step[0];
            recipeName = string.Empty;
        }

        // Getters and setters for privare attributes
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
