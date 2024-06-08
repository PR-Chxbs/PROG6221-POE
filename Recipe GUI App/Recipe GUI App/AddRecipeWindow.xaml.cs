using System.Windows;
using System.Windows.Controls;

namespace Recipe_GUI_App
{
    public partial class AddRecipeWindow : Window
    {
        private Recipe currentRecipe;

        public AddRecipeWindow()
        {
            //InitializeComponent();
            currentRecipe = new Recipe();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            // Collect ingredient details
            string name = IngredientNameTextBox.Text;
            if (int.TryParse(QuantityTextBox.Text, out int quantity) &&
                double.TryParse(CaloriesTextBox.Text, out double calories))
            {
                string unit = UnitTextBox.Text;
                string foodGroup = FoodGroupTextBox.Text;

                // Add ingredient to the recipe
                currentRecipe.AddIngredient(name, quantity, unit, calories, foodGroup, currentRecipe.Ingredients.Count);

                // Display the ingredient in the stack panel
                IngredientsStackPanel.Children.Add(new TextBlock { Text = name });

                // Clear the form
                IngredientNameTextBox.Clear();
                QuantityTextBox.Clear();
                UnitTextBox.Clear();
                CaloriesTextBox.Clear();
                FoodGroupTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for Quantity and Calories.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            // Collect step details
            string description = StepDescriptionTextBox.Text;
            int stepNumber = currentRecipe.Steps.Count + 1;

            // Add step to the recipe
            currentRecipe.AddStep(stepNumber, description, currentRecipe.Steps.Count);

            // Display the step in the stack panel
            StepsStackPanel.Children.Add(new TextBlock { Text = description });

            // Clear the form
            StepDescriptionTextBox.Clear();
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Collect recipe name
            string recipeName = RecipeNameTextBox.Text;
            currentRecipe.RecipeName = recipeName;

            // Save the recipe to the repository

            RecipeRepository.Recipes.Add(currentRecipe);

            // Close the window
            this.Close();
        }
    }
}
