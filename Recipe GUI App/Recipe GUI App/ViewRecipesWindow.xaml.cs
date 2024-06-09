using Recipe_GUI_App;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            var sortedRecipes = RecipeRepository.Recipes.OrderBy(recipe => recipe.RecipeName).ToList();

            // Bind the sorted recipes to the ListBox
            RecipesListBox.ItemsSource = sortedRecipes;
        }

        private void RecipesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)RecipesListBox.SelectedItem;
            if (selectedRecipe != null)
            {
                RecipeDetailWindow recipeDetailWindow = new RecipeDetailWindow(selectedRecipe);
                recipeDetailWindow.ShowDialog();
                // Refresh the recipes list after a recipe might be deleted
                LoadRecipes();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
