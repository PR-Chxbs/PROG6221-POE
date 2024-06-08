using System;
using System.Windows;
using System.Windows.Controls;

namespace Recipe_GUI_App
{
    public partial class RecipeDetailWindow : Window
    {
        private Recipe currentRecipe;
        private int recipeIndex;

        public RecipeDetailWindow(Recipe recipe, int index)
        {
            InitializeComponent();
            currentRecipe = recipe;
            recipeIndex = index;
            DisplayRecipeDetails();
        }

        private void DisplayRecipeDetails()
        {
            RecipeNameTextBlock.Text = currentRecipe.RecipeName;
            IngredientsStackPanel.Children.Clear();
            foreach (var ingredient in currentRecipe.Ingredients)
            {
                TextBlock ingredientTextBlock = new TextBlock
                {
                    Text = $"- {ingredient.Quantity} {ingredient.UnitOfMeasurement} of {ingredient.Name} ({ingredient.Calories} calories) ({ingredient.FoodGroup})"
                };
                IngredientsStackPanel.Children.Add(ingredientTextBlock);
            }

            StepsStackPanel.Children.Clear();
            foreach (var step in currentRecipe.Steps)
            {
                TextBlock stepTextBlock = new TextBlock
                {
                    Text = $"{step.StepNumber}. {step.Description}"
                };
                StepsStackPanel.Children.Add(stepTextBlock);
            }

            TotalCaloriesTextBlock.Text = currentRecipe.TotalCalories.ToString();
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipeWindow scaleWindow = new ScaleRecipeWindow(currentRecipe);
            if (scaleWindow.ShowDialog() == true)
            {
                double scaleFactor = scaleWindow.ScaleFactor;
                currentRecipe.Scale(scaleFactor);
                DisplayRecipeDetails();
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            currentRecipe.ResetIngredientValues();
            DisplayRecipeDetails();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeRepository.DeleteRecipe(recipeIndex);
            this.Close();
        }
    }
}
