using Recipe_App;

internal class Program
{
    static string line = $"{ColorText("===================================================", "cyan")}";
    static string starLine = "***************************************************";
    public static void Main(string[] args)
    {
        List<Recipe> recipes = new List<Recipe>(); // List containing all recipes to be added
        Recipe recipe = new Recipe(); // Placeholder recipe object
        bool recipeAdded = false;
        bool running = true;
        bool recipeDeleted = false;

        string menuR =
            $"{line}" + "\n" +
            $"Select an option:" + "\n" +
            $"1. Add new recipe" + "\n" +
            $"2. View all recipes" + "\n" +
            $"3. Quit";

        int choiceR = VerifyInput(menuR, 1, 3);
        switch (choiceR)
        {
            case 1:
                recipe = AddRecipe();
                recipes.Add(recipe);
                break;

            case 2:
                if (recipeAdded)
                {
                    Recipe[] sortedList = SortAllRecipes(recipes);
                    string allRecipeMenu = AllRecipeNames(sortedList);
                    int choiceP = VerifyInput(allRecipeMenu, 1, sortedList.Length);
                    if (choiceP == (sortedList.Length + 1))
                    {
                        break;
                    }
                    recipe = sortedList[choiceP-1];
                }
                break;

            case 3:
                break;
        }
        

        
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
        Console.Write("Enter recipe name: ");
        string recipeName = Console.ReadLine();
        recipe.RecipeName = recipeName;

        int numberOfIngredients = VerifyInput("Enter the number of ingredients: ", 1);
        recipe.SetIngredientsLength(numberOfIngredients);
        Console.WriteLine();

        // Loop to create all the ingredient objects and add them to the recipe
        for (int i = 0; i<numberOfIngredients; i++)
        {
            Console.WriteLine($"-----------{ColorText("Enter ingredient details", "magenta")}-------------");
            Console.Write("Name: ");
            string ingredientName = Console.ReadLine();

            int ingredientQuantity = VerifyInput("Quantity: ", 0);

            Console.Write("Unit of measurement: ");
            string ingredientUnitOfMeasurement = Console.ReadLine();
            recipe.AddIngredient(ingredientName, ingredientQuantity, ingredientUnitOfMeasurement, i); // Method that will instantiate the ingredient object
            Console.WriteLine();
        }

        Console.WriteLine(starLine);
        int numberOfSteps = VerifyInput("Enter the number of steps: ", 1);
        recipe.SetStepsLength(numberOfSteps);
        Console.WriteLine();

        // Loop to create all the step objects and add them to the recipe
        for (int i = 0; i<numberOfSteps; i++)
        {
            int stepNumber = i + 1;
            Console.WriteLine($"-----------{ColorText($"Step {stepNumber}", "magenta")}-------------");

            Console.Write("Step description: ");
            string stepDescription = Console.ReadLine();

            recipe.AddStep(stepNumber, stepDescription, i); // Method that will instantiate the step object
            Console.WriteLine();
        }
        return recipe;
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
        int x = 0;
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
            $"{ColorText("Select an option:", "red")}" + "\n" +
            $"{ColorText("1", "magenta")}. Display Recipe" + "\n" +
            $"{ColorText("2", "magenta")}. Scale Recipe" + "\n" +
            $"{ColorText("3", "magenta")}. Reset Original Values" + "\n" +
            $"{ColorText("4", "magenta")}. Back to main menu" + "\n" +
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

                /*case 4:
                    // Only runs if a recipe has been added, clears the recipe
                    if (recipeAdded)
                    {
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
                                recipeDeleted = true;
                                break;

                            case 2:
                                Console.WriteLine("Cancelled");
                                break;

                            default:
                                Console.WriteLine(ColorText("Invalid input", "red"));
                                break;
                        }

                        break;
                    }
                    break;*/

                case 4:
                    // Terminates the program
                    Console.WriteLine(line);
                    running = false;
                    break;
            }
        } while (running);

        return recipe;
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
