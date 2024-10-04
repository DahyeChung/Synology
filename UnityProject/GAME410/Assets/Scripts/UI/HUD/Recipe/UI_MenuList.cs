using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuList : UI_Base
{
    enum GameObjects
    {
        ContentObject,
        RecipeListObject,
    }

    [SerializeField] private GameObject recipeCardPrefab;
    [SerializeField] private int maxRecipes = 6;
    [SerializeField] private float recipeSpawnInterval = 30f;

    public List<MenuData> ActiveMenuList;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        return true;
    }

    private void OnEnable()
    {
        Init();
    }

    private MenuDataLoader menuDataLoader;

    void Start()
    {
        ActiveMenuList = new List<MenuData>();
        menuDataLoader = new MenuDataLoader();

        List<MenuData> allMenus = menuDataLoader.menuList;

        // Generate initial 2 recipes
        for (int i = 0; i < 2; i++)
        {
            SetMenu();
        }

        StartCoroutine(MenuSpawnCoroutine());
    }

#if UNITY_EDITOR

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetMenu();
        }
    }
#endif

    private IEnumerator MenuSpawnCoroutine()
    {
        while (true)
        {
            if (ActiveMenuList.Count < maxRecipes)
            {
                SetMenu();
            }
            yield return new WaitForSeconds(recipeSpawnInterval);
        }
    }

    public void SetMenu()
    {
        if (ActiveMenuList.Count >= maxRecipes)
            return;

        MenuData newMenu = GetRandomMenu();
        ActiveMenuList.Add(newMenu);
        Debug.Log("New Menu Added: " + newMenu.Name);

        CreateRecipeCard(newMenu); // Create the RecipeCard prefab
    }

    private void CreateRecipeCard(MenuData menu)
    {
        Transform recipeListTransform = GetObject((int)GameObjects.RecipeListObject).transform;

        GameObject go = Instantiate(recipeCardPrefab, recipeListTransform);

        RecipeCard recipeCard = go.GetComponent<RecipeCard>();
        recipeCard.SetInfo(menu);
    }

    MenuData GetRandomMenu()
    {
        List<MenuData> allMenus = menuDataLoader.menuList;
        int randomIndex = Random.Range(0, allMenus.Count);
        return allMenus[randomIndex];
    }

    // TODO : [Dahye] Rewrite submission check conditions // Have to check ingredient prefab inclusion
    public void Submitted(Define.MenuType submittedMenuType)
    {
        if (ActiveMenuList.Count == 0) return;

        if (ActiveMenuList[0].MenuType == submittedMenuType)
        {
            ActiveMenuList.RemoveAt(0);
            Debug.Log("Correct Submission: " + submittedMenuType);
        }
        else
        {
            Debug.Log("Incorrect Submission: " + submittedMenuType);
        }
    }
}
