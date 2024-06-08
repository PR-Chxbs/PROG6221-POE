using Recipe_GUI_App;
using System.Windows;

namespace RecipeApp
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
        }

        private void ViewRecipes_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipesWindow viewRecipesWindow = new ViewRecipesWindow();
            viewRecipesWindow.ShowDialog();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
