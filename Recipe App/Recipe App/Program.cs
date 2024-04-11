﻿using Recipe_App;

internal class Program
{
    public static void Main(string[] args)
    {
        string menu = 
            "Select an option:" + "\n" +
            "1. Add Recipe Details" + "\n" +
            "2. Display Recipe" + "\n" +
            "3. Scale Recipe" + "\n"  +
            "4. Reset Original Values" + "\n" +
            "5. Clear Recipe" + "\n" +
            "6. Quit" + "\n" +
            ": "; 

        int choice = GetIntInput(menu);
    }

    public static int GetIntInput(string prompt)
    {
        bool validInput;
        int input;

        do
        {
            Console.Write(prompt);
            string stringInput = Console.ReadLine();
            validInput = int.TryParse(stringInput, out input);

            if (!validInput)
            {
                Console.WriteLine("Please enter a number\n");
            }
        }
        while (!validInput);

        return input;
    }

    public static Recipe AddRecipe()
    {
        Recipe recipe = new Recipe();

        int numberOfIngredients = GetIntInput("Enter the number of ingredients: ");
        recipe.SetIngredientsLength(numberOfIngredients);

        for (int i = 0; i<numberOfIngredients; i++)
        {
            Console.Write("Name: ");
            string recipeName = Console.ReadLine();

            int recipeQuantity = GetIntInput("Quantity: ");

            Console.Write("Unit of measurement: ");
            string recipeUnitOfMeasurement = Console.ReadLine();
            recipe.AddIngredient(recipeName, recipeQuantity, recipeUnitOfMeasurement, i);
        }


        int numberOfSteps = GetIntInput("Enter the number of steps: ");
        recipe.SetStepsLength(numberOfSteps);

        for (int i = 0; i<numberOfSteps; i++)
        {
            int stepNumber = i + 1;
            Console.Write("Name: ");
            string stepName = Console.ReadLine();

            Console.Write("Step description: ");
            string stepDescription = Console.ReadLine();

            recipe.AddStep(stepNumber, stepName, stepDescription, i);
        }
        return recipe;
    }
}
