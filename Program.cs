using System;
using System.Collections.Generic;

namespace RecipeApplication
{

    class Recipe
    {
        private string[] ingredients; private double[] quantities; private string[] units; private string[] steps;

        public Recipe()
        {
            ingredients = null;
            quantities = null;
            units = null;
            steps = null;
        }

        public void EnterRecipeDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            ingredients = new string[ingredientCount];
            quantities = new double[ingredientCount];
            units = new string[ingredientCount];

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"\nIngredient #{i + 1}");
                Console.Write("Name: ");
                ingredients[i] = Console.ReadLine();
                Console.Write("Quantity: ");
                quantities[i] = double.Parse(Console.ReadLine());
                Console.Write("Unit of measurement: ");
                units[i] = Console.ReadLine();
            }

            Console.Write("\nEnter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            steps = new string[stepCount];

            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"\nStep #{i + 1}");
                Console.Write("Description: ");
                steps[i] = Console.ReadLine();
            }
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }
        }

        public void ResetQuantities()
        {
            // Assuming the original quantities are stored separately
            // and can be retrieved to reset the ingredient quantities.
        }

        public void ClearRecipe()
        {
            ingredients = null;
            quantities = null;
            units = null;
            steps = null;
        }
    }

    class Program
    {
        void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("Enter the details for the recipe:");
            recipe.EnterRecipeDetails();

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Display Recipe");
                Console.WriteLine("2. Scale Recipe");
                Console.WriteLine("3. Reset Quantities");
                Console.WriteLine("4. Clear Recipe");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.DisplayRecipe();
                        break;
                    case 2:
                        Console.Write("\nEnter scaling factor (0.5, 2, 3): ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        Console.WriteLine("Recipe scaled successfully!");
                        break;
                    case 3:
                        recipe.ResetQuantities();
                        Console.WriteLine("Quantities reset successfully!");
                        break;
                    case 4:
                        recipe.ClearRecipe();
                        Console.WriteLine("Recipe cleared successfully!");
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}

namespace RecipeApp
{
    class Ingredient { public string Name { get; set; } public double Quantity { get; set; } public string Unit { get; set; } public double Calories { get; set; } public string FoodGroup { get; set; } }

    class Step
    {
        public string Description { get; set; }
    }

    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }
    namespace RecipeApp
    {
        class Program
        {
            static List<Recipe> recipes = new List<Recipe>();

            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. Add Recipe");
                    Console.WriteLine("2. Display Recipe List");
                    Console.WriteLine("3. Select Recipe");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddRecipe();
                            break;
                        case 2:
                            DisplayRecipeList();
                            break;
                        case 3:
                            SelectRecipe();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
            }

            static void AddRecipe()
            {
                Recipe recipe = new Recipe();

                Console.Write("Enter the name of the recipe: ");
                recipe.Name = Console.ReadLine();

                Console.WriteLine("\nEnter the details for the recipe:");
                Console.Write("Number of ingredients: ");
                int ingredientCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.WriteLine($"\nIngredient #{i + 1}");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Quantity: ");
                    double quantity = double.Parse(Console.ReadLine());
                    Console.Write("Unit of measurement: ");
                    string unit = Console.ReadLine();
                    Console.Write("Calories: ");
                    double calories = double.Parse(Console.ReadLine());
                    Console.Write("Food group: ");
                    string foodGroup = Console.ReadLine();

                    Ingredient ingredient = new Ingredient
                    {
                        Name = name,
                        Quantity = quantity,
                        Unit = unit,
                        Calories = calories,
                        FoodGroup = foodGroup
                    };

                    recipe.Ingredients.Add(ingredient);
                }

                Console.Write("\nNumber of steps: ");
                int stepCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < stepCount; i++)
                {
                    Console.WriteLine($"\nStep #{i + 1}");
                    Console.Write("Description: ");
                    string description = Console.ReadLine();

                    Step step = new Step
                    {
                        Description = description
                    };

                    recipe.Steps.Add(step);
                }

                recipes.Add(recipe);
                Console.WriteLine("\nRecipe added successfully!");
            }

            static void DisplayRecipeList()
            {
                if (recipes.Count == 0)
                {
                    Console.WriteLine("\nNo recipes found.");
                    return;
                }

                recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name, StringComparison.Ordinal));

                Console.WriteLine("\nRecipe List:");
                foreach (var recipe in recipes)
                {
                    Console.WriteLine(recipe.Name);
                }
            }

            static void SelectRecipe()
            {
                if (recipes.Count == 0)
                {
                    Console.WriteLine("\nNo recipes found.");
                    return;
                }

                Console.Write("\nEnter the name of the recipe to display: ");
                string recipeName = Console.ReadLine();

                Recipe selectedRecipe = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

                if (selectedRecipe == null)
                {
                    Console.WriteLine("Recipe not found.");
                    return;
                }

                Console.WriteLine("\nSelected Recipe:");
                Console.WriteLine($"Name: {selectedRecipe.Name}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in selectedRecipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
                }

                Console.WriteLine("\nSteps:");
                foreach (var step in selectedRecipe.Steps)
                {
                    Console.WriteLine(step.Description);
                }

                double totalCalories = selectedRecipe.CalculateTotalCalories();
                Console.WriteLine($"\nTotal Calories: {totalCalories}");

                if (totalCalories > 300)
                {
                    Console.WriteLine("Warning: This recipe exceeds 300 calories.");
                }
            }
        }
    }
}
