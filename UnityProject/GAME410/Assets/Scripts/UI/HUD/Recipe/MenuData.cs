using System;
using System.Collections.Generic;
using static Define;

public class MenuData
{
    public MenuType MenuType { get; private set; }
    public string Name { get; private set; }
    public string MenuPrefab { get; private set; } // Not for UI // to check submission
    public string MenuIconLabel { get; private set; }
    public float TimeLimit { get; private set; }
    public string IngredientPrefab { get; private set; } // Not for UI // to check submission 
    public List<string> IngredientIcons { get; private set; }
    public List<string> IngredientIconPaths { get; private set; }

    // TODO : [Dahye] check parameter contents from above
    public MenuData(MenuType menuType, string name, string MenuPrefab, string menuIconLabel, float timeLimit, List<string> ingredients)
    {
        MenuType = menuType;
        Name = name;
        MenuIconLabel = menuIconLabel;
        TimeLimit = timeLimit;
        IngredientIcons = ingredients;
        IngredientIconPaths = GenerateIngredientPaths(ingredients);
    }

    // Must match the name of the ingredient with the path
    private List<string> GenerateIngredientPaths(List<string> ingredients)
    {
        List<string> paths = new List<string>();
        foreach (var ingredient in ingredients)
        {
            paths.Add($"Sprites/UI/Recipe/{ingredient}");
        }
        return paths;
    }
}

[Serializable]
public class MenuDataLoader
{
    public List<MenuData> menuList;

    public MenuDataLoader()
    {
        menuList = new List<MenuData>
        {
            new MenuData(
                MenuType.Pizza,
                "Pizza",
                "Prefabs/Menu/Pizza",
                "Sprites/UI/Recipe/PizzaIcon",
                60f,
                new List<string> { "Dough", "Tomato", "Cheese", "Bacon" }
            ),

            new MenuData(
                MenuType.Burger,
                "Burger",
                "Prefabs/Menu/Burger",
                "Sprites/UI/Recipe/BurgerIcon",
                50f,
                new List<string> { "Bun", "Patty", "Lettuce", "Cheese" }
            ),
           //new MenuData(
           //    MenuType.Pasta,
           //    "Pasta",
           //    "Prefabs/Menu/Pasta",
           //    "Sprites/UI/Recipe/PastaIcon",
           //    40f,
           //    new List<string> { "Pasta", "Tomato", "Cheese", "Bacon" }),
           //new MenuData(
           //    MenuType.Salad,
           //    "Salad",
           //    "Prefabs/Menu/Salad",
           //    "Sprites/UI/Recipe/SaladIcon",
           //    30f,
           //    new List<string> { "Lettuce", "Tomato", "Cheese", "Bacon" }),

        };
    }
}
