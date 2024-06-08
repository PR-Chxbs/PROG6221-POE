using Recipe_GUI_App;
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
            RecipesListBox.ItemsSource = RecipeRepository.Recipes;
        }

        private void RecipesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)RecipesListBox.SelectedItem;
            if (selectedRecipe != null)
            {
                RecipeDetailWindow recipeDetailWindow = new RecipeDetailWindow(selectedRecipe);
                recipeDetailWindow.ShowDialog();
            }
        }
    }
}
