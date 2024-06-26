﻿namespace Recipe_App
{
    delegate void CaloriesNotification(double totalCalories);
    internal class Recipe
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<Step> steps = new List<Step>();
        private string recipeName;
        private double totalCalories = 0;

        // Event to notify when total calories exceed 300
        public event CaloriesNotification TotalCaloriesExceeded;

        // Method to instantiate an Ingredient
        public void AddIngredient(string name, int quantity, string unitOfMeasurement, double calories, string foodGroup, int index)
        {
            Ingredient ingredient = new Ingredient
            {
                Name = name,
                Quantity = (double)quantity,
                OriginalQuantity = quantity,
                UnitOfMeasurement = unitOfMeasurement,
                Calories = calories,
                OriginalCalories = calories,
                FoodGroup = foodGroup
            };

            totalCalories += calories;
            ingredients.Add(ingredient);

            // Check if total calories exceed 300 and raise the event if necessary
            if (totalCalories > 300)
            {
                TotalCaloriesExceeded?.Invoke(totalCalories);
            }
        }

        // Method to add a step to the recipe
        public void AddStep(int stepNumber, string description, int index)
        {
            Step step = new Step(stepNumber)
            {
                Description = description
            };

            Steps.Add(step);
        }


        // Method to display recipe details
        public void PrintDetails()
        {
            string ingredientsString = "";
            string stepString = "";

            // Creating output for ingredient details
            foreach (Ingredient ingredient in ingredients)
            {
                ingredientsString += $"- {ColorText(ingredient.Quantity, "magenta")} {ColorText(ingredient.UnitOfMeasurement, "yellow")} of {ingredient.Name} ({ingredient.Calories} calories) ({ingredient.FoodGroup})\n";
            }

            // Creating output for step details
            foreach (Step step in Steps)
            {
                stepString += $"{ColorText(step.StepNumber, "magenta")}. {step.Description}\n";
            }

            // Output template
            Console.WriteLine(
                $"{ColorText("==============================================", "cyan")}" + "\n" + 
                 "**********************************************" + "\n" +
                $"              {ColorText(recipeName, "cyan")}" + "\n" +
                 "**********************************************" + "\n" +
                 "\n" +
                $"{ColorText("Ingredients:", "red")}" + "\n" +
                $"{ingredientsString}" + "\n" +
                $"{ColorText("Steps:", "red")}" + "\n" +
                $"{stepString}" +
                 "**********************************************" + "\n" +
                $"Total Calories: {totalCalories}" + "\n" +
                $"{ColorText("==============================================", "cyan")}");
        }

        // Method to scale ingredient quantities by a factor
        public void Scale(double factor)
        {
            // loop to scale for each ingredient
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.Quantity * factor;
                ingredient.Calories = ingredient.Calories * factor;
            }
            totalCalories = CalcTotalCalories();
        }

        // Method to reset ingredient quantities back to the original values
        public void ResetIngredientValues()
        {
            // loop to reset for each ingredient
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
            totalCalories = CalcTotalCalories();
        }

        // Method to clear recipe
        public void ClearRecipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<Step>();
            recipeName = string.Empty;
        }

        // Method to calculate total calories
        public double CalcTotalCalories()
        {
            double totalCaloriesReturn = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                totalCaloriesReturn += ingredient.Calories;
            }
            return totalCaloriesReturn;
        }

        // Getters and setters for private attributes
        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        public List<Step> Steps
        {
            get { return steps; }
            set { steps = value; }
        }

        public string RecipeName
        {
            get { return recipeName; }
            set { recipeName = value; }
        }

        public double TotalCalories
        {
            get { return totalCalories; }
            set { totalCalories = value; }
        }

        public static string ColorText(string text, string color)
        {
            string coloredText = "";
            switch (color)
            {
                case "red":
                    coloredText = $"\u001b[31m{text}\u001b[0m";
                    break;

                case "green":
                    coloredText = $"\u001b[32m{text}\u001b[0m";
                    break;

                case "yellow":
                    coloredText = $"\u001b[33m{text}\u001b[0m";
                    break;

                case "blue":
                    coloredText = $"\u001b[34m{text}\u001b[0m";
                    break;

                case "magenta":
                    coloredText = $"\u001b[35m{text}\u001b[0m";
                    break;

                case "cyan":
                    coloredText = $"\u001b[36m{text}\u001b[0m";
                    break;

                default:
                    coloredText = text;
                    break;
            }
            return coloredText;
        }

        public static string ColorText(double text, string color)
        {
            string coloredText = "";
            switch (color)
            {
                case "red":
                    coloredText = $"\u001b[31m{text}\u001b[0m";
                    break;

                case "green":
                    coloredText = $"\u001b[32m{text}\u001b[0m";
                    break;

                case "yellow":
                    coloredText = $"\u001b[33m{text}\u001b[0m";
                    break;

                case "blue":
                    coloredText = $"\u001b[34m{text}\u001b[0m";
                    break;

                case "magenta":
                    coloredText = $"\u001b[35m{text}\u001b[0m";
                    break;

                case "cyan":
                    coloredText = $"\u001b[36m{text}\u001b[0m";
                    break;
            }
            return coloredText;
        }

        public static string ColorText(int text, string color)
        {
            string coloredText = "";
            switch (color)
            {
                case "red":
                    coloredText = $"\u001b[31m{text}\u001b[0m";
                    break;

                case "green":
                    coloredText = $"\u001b[32m{text}\u001b[0m";
                    break;

                case "yellow":
                    coloredText = $"\u001b[33m{text}\u001b[0m";
                    break;

                case "blue":
                    coloredText = $"\u001b[34m{text}\u001b[0m";
                    break;

                case "magenta":
                    coloredText = $"\u001b[35m{text}\u001b[0m";
                    break;

                case "cyan":
                    coloredText = $"\u001b[36m{text}\u001b[0m";
                    break;
            }
            return coloredText;
        }
    }
}
