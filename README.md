# PROG6221-POE
 Repository for my programming POE

ST10310050
Wahina Prince Chabalala
PROG6221 POE Part 1

https://github.com/PR-Chxbs/PROG6221-POE
======================================================================
# FilePath
To run the program, open the project using Visual Studio

The project file's path from this directory is:

`.\Recipe App\Recipe App.sln`

All the project source code is in:

`.\Recipe App\Recipe App\`

The file which you need to run is:

`.\Recipe App\Recipe App\Program.cs`

======================================================================

Program.cs relies on the classes Ingredient.cs, Recipe.cs and Step.cs in order for it to run.
Do not move any of the files found in this repository otherwise the code may not work well.
Run it in its current state and arrangement.

======================================================================
# Usage
When you run the code, you will be presented with a menu that looks something likes this:

Select an option:
1. Add Recipe Details
2. Display Recipe
3. Scale Recipe
4. Reset Original Values
5. Clear Recipe
6. Quit


Before being able to use any of the other options, you will have to add a recipe ``(option 1)``,
however the application has sufficient error handling and will not crash if you decide
to display recipe details before actually adding a recipe. It will simply let you know that
you need to add a recipe first.

Once you have added recipe details, you will now be able to use the other options, to either view
the recipe details you had entered ``(option 2)`` or even scale the ingredient quantities by a factor from 3 given options ``(option 3)``.

You also have the option of resetting the ingredient quantities to what you had originally entered ``(option 4)``

Additionally you can choose to clear the recipe so that you can enter new recipe details ``(option 5)``

***********************

The application runs up until you have decided to quit by entering 6 in the main menu ``(option 6)``.

======================================================================

Updates

Added part 2 Functionality

- Unlimited recipes
- Added calories to the ingredients
- Added food groups
- Changed arrays to generic collections