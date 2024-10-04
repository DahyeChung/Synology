using UnityEngine;


public class RecipeCard : UI_Base
{
    #region Object Binding
    enum GameObjects
    {
        Slider,
        IngredientGroup,
    }

    enum Images
    {
        Menu,
        Ingredient0,
        Ingredient1,
        Ingredient2,
        Ingredient3,
    }
    #endregion
    private void Awake()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        #region Object Bind
        BindObject(typeof(GameObjects));
        BindImage(typeof(Images));
        #endregion

        return true;
    }

    public void SetInfo(MenuData menu)
    {
        transform.localScale = Vector3.one;

        // Set Menu Image
        GetImage((int)Images.Menu).sprite = Managers.Resource.Load<Sprite>($"Sprites/UI/Recipe/{menu.MenuIconLabel}");

        // Set IngredientIcons Image
        for (int i = 0; i < menu.IngredientIcons.Count; i++)
        {
            if (i < 4) // 최대 4개의 재료 이미지 바인딩
            {
                GetImage((int)Images.Ingredient0 + i).sprite = Managers.Resource.Load<Sprite>($"Sprites/UI/Icons/{menu.IngredientIcons[i]}");
            }
        }
    }



}

