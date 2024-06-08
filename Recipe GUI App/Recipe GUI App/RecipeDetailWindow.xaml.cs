using Recipe_GUI_App;
using System.Windows;

namespace Recipe_GUI_App
{
    public partial class RecipeDetailWindow : Window
    {
        private Recipe recipe;

        public RecipeDetailWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            LoadRecipeDetails();
        }

        private void LoadRecipeDetails()
        {
            RecipeDetailsTextBlock.Text = recipe.ToString(); // Assuming you have a ToString() method in Recipe class that formats the recipe details
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ScaleFactorTextBox.Text, out double scaleFactor))
            {
                recipe.Scale(scaleFactor);
                LoadRecipeDetails();
            }
            else
            {
                MessageBox.Show("Invalid scale factor.");
            }
        }

        private void ResetRecipe_Click(object sender, RoutedEventArgs e)
        {
            recipe.ResetIngredientValues();
            LoadRecipeDetails();
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            RecipeRepository.Recipes.Remove(recipe);
            MessageBox.Show("Recipe deleted.");
            this.Close();
        }
    }
}
