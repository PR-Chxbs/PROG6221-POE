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
}
