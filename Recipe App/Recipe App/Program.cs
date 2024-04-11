using Recipe_App;

internal class Program
{
    public static void Main(string[] args)
    {

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
        return recipe;
    }
}
