using Recipe_App;

internal class Program
{
    public static void Main(string[] args)
    {
        Recipe recipe;

        string menu = 
            "Select an option:" + "\n" +
            "1. Add Recipe Details" + "\n" +
            "2. Display Recipe" + "\n" +
            "3. Scale Recipe" + "\n"  +
            "4. Reset Original Values" + "\n" +
            "5. Clear Recipe" + "\n" +
            "6. Quit" + "\n" +
            ": "; 

        int choice = VerifyInput(menu, 1, 6);

        
    }

    public static int VerifyInput(string prompt, int start)
    {
        bool validInput = false;
        int input;

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

    public static int VerifyInput(string prompt, int start, int end)
    {
        bool validInput = false;
        int input;

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

        int numberOfIngredients = VerifyInput("Enter the number of ingredients: ", 1);
        recipe.SetIngredientsLength(numberOfIngredients);

        for (int i = 0; i<numberOfIngredients; i++)
        {
            Console.Write("Name: ");
            string recipeName = Console.ReadLine();

            int recipeQuantity = VerifyInput("Quantity: ", 0);

            Console.Write("Unit of measurement: ");
            string recipeUnitOfMeasurement = Console.ReadLine();
            recipe.AddIngredient(recipeName, recipeQuantity, recipeUnitOfMeasurement, i);
        }


        int numberOfSteps = VerifyInput("Enter the number of steps: ", 1);
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
