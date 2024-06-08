using Recipe_GUI_App;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Recipe_GUI_App
{
    public partial class ViewRecipesWindow : Window
    {
        public ViewRecipesWindow()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            // Sort recipes alphabetically by name
            List<Recipe> sortedRecipes = RecipeRepository.Recipes.OrderBy(r => r.RecipeName).ToList();
            RecipesListBox.ItemsSource = sortedRecipes;
        }

        private void RecipesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)RecipesListBox.SelectedItem;
            if (selectedRecipe != null)
            {
                // Get the index of the selected recipe in the sorted list
                int selectedIndex = RecipesListBox.SelectedIndex;

                // Fetch the corresponding recipe from the RecipeRepository using the index
                Recipe correspondingRecipe = RecipeRepository.Recipes.OrderBy(r => r.RecipeName).ElementAt(selectedIndex);

                // Create and show the RecipeDetailWindow
                RecipeDetailWindow recipeDetailWindow = new RecipeDetailWindow(correspondingRecipe, selectedIndex);
                recipeDetailWindow.ShowDialog();
            }
        }
    }
}
