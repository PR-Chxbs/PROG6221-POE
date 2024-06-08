using Recipe_App;

internal class Program
{
    static string line = $"===================================================";
    static string starLine = "***************************************************";
    public static void Main(string[] args)
    {
        List<Recipe> recipes = new List<Recipe>(); // List containing all recipes to be added
        Recipe recipe = new Recipe(); // Placeholder recipe object
        bool recipeAdded = false;
        bool running = true;

        string menu =
            $"{line}" + "\n" +
             "Select an option:" + "\n" +
             "1. Add new recipe" + "\n" +
             "2. View all recipes" + "\n" +
             "3. Quit" + "\n" +
             ": ";

        // Main program loop

        do
        {
            
            int choice = VerifyInput(menu, 1, 3);
            Console.WriteLine(line);
            switch (choice)
            {
                case 1:
                    recipe = AddRecipe();
                    recipes.Add(recipe);
                    recipeAdded = true;
                    break;

                case 2:
                    if (recipeAdded)
                    {
                        Recipe[] sortedList = SortAllRecipes(recipes);
                        string allRecipeMenu = AllRecipeNames(sortedList);
                        int recipeChoice = VerifyInput(allRecipeMenu, 1, (sortedList.Length + 1));

                        // Returns to main menu if last option is chosen
                        if (recipeChoice == (sortedList.Length + 1))
                        {
                            break;
                        }

                        recipe = sortedList[recipeChoice - 1]; // Recipe the program will be working with
                        recipe = RecipeManipulation(recipe);

                        // Checking if the delete function was used
                        if (recipe.RecipeName == string.Empty)
                        {
                            recipes.Remove(recipe);

                            // Checking if all recipes have been removed
                            if (recipes.Count == 0)
                            {
                                recipeAdded = false;
                            }
                        }
                        else
                        {
                            // Changing the recipe in the list to match the modified one
                            int recipeIndex = recipes.IndexOf(recipe);
                            recipes[recipeIndex] = recipe;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Add recipes first");
                    }
                    break;

                case 3:
                    Console.WriteLine("Program terminated");
                    running = false;
                    break;
            }
        } while (running);     
    }

    // Overloaded method, this version will ensure that an int input is greater than or equal to a specified number
    public static int VerifyInput(string prompt, int start)
    {
        bool validInput = false;
        int input;

        // Method that will repeat until the entered input matches the condition
        do
        {
            input = GetIntInput(prompt);

            if (input >= start)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine($"Enter a number larger than or equal to {start}\n");
            }
        } while (!validInput);
        return input;
    }

    // Overloaded method, this version will ensure that an int input is between two specified numbers
    public static int VerifyInput(string prompt, int start, int end)
    {
        bool validInput = false;
        int input;

        // Method that will repeat until the entered input matches the condition
        do
        {
            input = GetIntInput(prompt);

            if (input >= start && input <= end)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine($"Enter a number between {start} and {end}\n");
            }
        } while (!validInput);
        return input;
    }

    // Method to handle int input
    public static int GetIntInput(string prompt)
    {
        bool validInput;
        int input;

        // Method that will repeat until the entered input is a number
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

    // Method to create a recipe object and fill in the attributes
    public static Recipe AddRecipe()
    {
        Recipe recipe = new Recipe(); // Creating the recipe object

        // Subscribing to the TotalCaloriesExceeded event
        recipe.TotalCaloriesExceeded += HandleTotalCaloriesExceeded;

        Console.Write("Enter recipe name: ");
        string recipeName = Console.ReadLine();
        recipe.RecipeName = recipeName;

        int numberOfIngredients = VerifyInput("Enter the number of ingredients: ", 1);
        Console.WriteLine();

        // Loop to create all the ingredient objects and add them to the recipe
        for (int i = 0; i<numberOfIngredients; i++)
        {
            Console.WriteLine("Enter ingredient details");
            Console.Write("Name: ");
            string ingredientName = Console.ReadLine();

            int ingredientQuantity = VerifyInput("Quantity: ", 0);
            Console.Write("Unit of measurement: ");
            string ingredientUnitOfMeasurement = Console.ReadLine();
            double ingredientCalories = VerifyInput("Calories: ", 0);
            Console.Write("Food group: ");
            string foodGroup = Console.ReadLine();

            recipe.AddIngredient(ingredientName, ingredientQuantity, ingredientUnitOfMeasurement, ingredientCalories, foodGroup, i); // Method that will instantiate the ingredient object
            Console.WriteLine();
        }

        Console.WriteLine(starLine);
        int numberOfSteps = VerifyInput("Enter the number of steps: ", 1);
        Console.WriteLine();

        // Loop to create all the step objects and add them to the recipe
        for (int i = 0; i<numberOfSteps; i++)
        {
            int stepNumber = i + 1;
            Console.WriteLine($"Step {stepNumber}");

            Console.Write("Step description: ");
            string stepDescription = Console.ReadLine();

            recipe.AddStep(stepNumber, stepDescription, i); // Method that will instantiate the step object
            Console.WriteLine();
        }
        return recipe;
    }

    // Event handler for the TotalCaloriesExceeded event
    static void HandleTotalCaloriesExceeded(double totalCalories)
    {
        Console.WriteLine("Total calories exceeded 300");
        Console.WriteLine($"Total calories: {totalCalories}");
    }

    public static Recipe[] SortAllRecipes(List<Recipe> recipes)
    {
        int listSize = recipes.Count;
        string[] recipeNames = new string[listSize];
        Recipe[] sortedRecipes = new Recipe[listSize];

        for (int i = 0; i<listSize; i++)
        {
            Recipe recipe = recipes[i];
            recipeNames[i] = recipe.RecipeName;
        }

        Array.Sort(recipeNames);

        for (int i = 0; i < listSize; i++)
        {
            Recipe recipe = recipes[i];
            int index = Array.IndexOf(recipeNames, recipe.RecipeName);
            sortedRecipes[i] = recipes[index];
        }

        return sortedRecipes;
    }

    public static string AllRecipeNames(Recipe[] recipes)
    {
        string recipeNames = "Select an option:\n";
        int x = 1;
        for (int i = 0; i<recipes.Length; i++)
        {
            recipeNames += $"{i+1}. {recipes[i].RecipeName}\n";
            x++;
        }
        recipeNames += 
            $"{x}. Back" + "\n" +
            ": ";
        return recipeNames;
    }

    public static Recipe RecipeManipulation(Recipe recipe)
    {
        bool running = true;
        // String containing the menu content
        string menu =
            $"{line}" + "\n" +
            $"Select an option:" + "\n" +
            $"1. Display Recipe" + "\n" +
            $"2. Scale Recipe" + "\n" +
            $"3. Reset Original Values" + "\n" +
            $"4. Delete recipe" + "\n" +
            $"5. Back to main menu" + "\n" +
            ": ";

        // Main program loop
        do
        {
            int choice = VerifyInput(menu, 1, 6);
            Console.WriteLine(line);

            // Executing code that corresponds with the users chosen option
            switch (choice)
            {

                case 1:

                    // Only runs if a recipe has been added, displays recipe details
                    recipe.PrintDetails();                   
                    break;

                case 2:

                    Console.WriteLine(starLine);
                    string scaleMenu =
                        "Select an option:" + "\n" +
                        "1. Half" + "\n" +
                        "2. Double" + "\n" +
                        "3. Triple" +
                        ": ";

                    int scaleChoice = VerifyInput(scaleMenu, 1, 3);
                    Console.WriteLine(starLine);

                    // Scales the ingredient quantities by the chosen factor
                    double scaleFactor = 0;
                    switch (scaleChoice)
                    {
                        case 1:
                            scaleFactor = 0.5;
                            break;

                        case 2:
                            scaleFactor = 2;
                            break;

                        case 3:
                            scaleFactor = 3;
                            break;
                    }
                    recipe.Scale(scaleFactor);
                    Console.WriteLine("Scaled successfully");
                    break;                    

                case 3:
                    // Resets the quantity values to their original values
                    recipe.ResetIngredientValues();
                    Console.WriteLine("Values reset to original");                 
                    break;

                case 4:
                    // Deletes the recipe
                    string confirmationMenu =
                             "Are you sure" + "\n" +
                             "1. Yes" + "\n" +
                             "2. No" + "\n" +
                             ": ";

                    // Confirming if the user wants to clear the recipe
                    int confirmationChoice = GetIntInput(confirmationMenu);
                    switch (confirmationChoice)
                    {
                        case 1:
                            recipe.ClearRecipe();
                            Console.WriteLine("Recipe cleared");
                            break;

                        case 2:
                            Console.WriteLine("Cancelled");
                            break;

                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }

                    break;

                case 5:
                    // Terminates the program
                    Console.WriteLine(line);
                    running = false;
                    break;
            }
        } while (running);

        return recipe;
    }
}
