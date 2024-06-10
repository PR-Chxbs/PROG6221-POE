using Recipe_GUI_App;
using System.Windows;

namespace Recipe_GUI_App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow();
            addRecipeWindow.Show();
            this.Close();
        }

        private void ViewRecipes_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipesWindow viewRecipesWindow = new ViewRecipesWindow();
            viewRecipesWindow.Show();
            this.Close();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddTestRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Create and add test recipes
            Recipe recipe1 = new Recipe { RecipeName = "Pancakes" };
            recipe1.AddIngredient("Flour", 2, "cups", 200, "Grain", 0);
            recipe1.AddIngredient("Milk", 1, "cup", 100, "Dairy", 1);
            recipe1.AddStep(1, "Mix flour and milk", 0);
            recipe1.AddStep(2, "Cook on griddle", 1);
            RecipeRepository.Recipes.Add(recipe1);

            Recipe recipe2 = new Recipe { RecipeName = "Salad" };
            recipe2.AddIngredient("Lettuce", 1, "head", 15, "Vegetable", 0);
            recipe2.AddIngredient("Tomato", 2, "whole", 40, "Vegetable", 1);
            recipe2.AddStep(1, "Chop lettuce and tomato", 0);
            recipe2.AddStep(2, "Mix together", 1);
            RecipeRepository.Recipes.Add(recipe2);

            Recipe recipe3 = new Recipe { RecipeName = "Spaghetti" };
            recipe3.AddIngredient("Spaghetti", 1, "package", 800, "Grain", 0);
            recipe3.AddIngredient("Tomato Sauce", 1, "jar", 150, "Vegetable", 1);
            recipe3.AddStep(1, "Cook spaghetti", 0);
            recipe3.AddStep(2, "Add sauce", 1);
            RecipeRepository.Recipes.Add(recipe3);

            MessageBox.Show("Test recipes added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
