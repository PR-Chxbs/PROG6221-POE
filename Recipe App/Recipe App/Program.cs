using Recipe_App;

internal class Program
{
    static string line = $"{ColorText("===================================================", "cyan")}";
    static string starLine = "***************************************************";
    public static void Main(string[] args)
    {
        
        Recipe recipe = new Recipe(); // Placeholder recipe object
        bool recipeAdded = false;
        bool running = true;
        bool recipeDeleted = false;

        // String containing the menu content
        string menu = 
            $"{line}" + "\n" +
            $"{ColorText("Select an option:", "red")}" + "\n" +
            $"{ColorText("1", "magenta")}. Add Recipe Details" + "\n" +
            $"{ColorText("2", "magenta")}. Display Recipe" + "\n" +
            $"{ColorText("3", "magenta")}. Scale Recipe" + "\n"  +
            $"{ColorText("4", "magenta")}. Reset Original Values" + "\n" +
            $"{ColorText("5", "magenta")}. Clear Recipe" + "\n" +
            $"{ColorText("6", "magenta")}. Quit" + "\n" +
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
                    // If recipe already exists, display an error message and skip the rest of the code
                    if (recipeAdded)
                    {
                        Console.WriteLine("Recipe already added");
                        break;
                    }

                    // Add recipe
                    Console.WriteLine(starLine);
                    recipe = AddRecipe();
                    Console.WriteLine(starLine);
                    recipeAdded = true;
                    break;

                case 2:

                    // Only runs if a recipe has been added, displays recipe details
                    if (recipeAdded)
                    {
                        recipe.PrintDetails();
                        break;
                    }
                    break;

                case 3:

                    // Only runs if a recipe has been added, factoring
                    if (recipeAdded)
                    {
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
                    }
                    break;

                case 4:

                    // Only runs if a recipe has been added, resets the quantity values to their original values
                    if (recipeAdded)
                    {
                        recipe.ResetIngredientValues();
                        Console.WriteLine("Values reset to original");
                        break;
                    }
                    break;

                case 5:
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
                    break;

                case 6:
                    // Terminates the program
                    Console.WriteLine("Program terminated");
                    Console.WriteLine(line);
                    running = false;
                    break;
            }
            if (!recipeAdded && running)
            {
                Console.WriteLine("That function cannot be used until you add a recipe\n");
            }

            // Resetting boolean values
            if (recipeDeleted)
            {
                recipeDeleted = false;
                recipeAdded = false;
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
