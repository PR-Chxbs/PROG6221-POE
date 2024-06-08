using System.Windows;
using System.Windows.Controls;

namespace Recipe_GUI_App
{
    public partial class RecipeDetailWindow : Window
    {
        public RecipeDetailWindow(Recipe recipe)
        {
            InitializeComponent();
            DisplayRecipeDetails(recipe);
        }

        private void DisplayRecipeDetails(Recipe recipe)
        {
            RecipeNameTextBox.Text = recipe.RecipeName;

            // Display ingredients
            foreach (var ingredient in recipe.Ingredients)
            {
                IngredientsStackPanel.Children.Add(new TextBlock
                {
                    Text = $"{ingredient.Quantity} {ingredient.UnitOfMeasurement} of {ingredient.Name} ({ingredient.Calories} calories) ({ingredient.FoodGroup})"
                });
            }

            // Display steps
            foreach (var step in recipe.Steps)
            {
                StepsStackPanel.Children.Add(new TextBlock
                {
                    Text = $"{step.StepNumber}. {step.Description}"
                });
            }

            // Display total calories
            TotalCaloriesTextBox.Text = recipe.TotalCalories.ToString();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
