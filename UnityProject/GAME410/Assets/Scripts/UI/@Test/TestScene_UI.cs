using System.Collections;
using UnityEngine;

public class TestScene_UI : BaseScene
{
    GameManage _game;
    UI_TestScene _ui;

    bool isGameEnd = false;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.TestScene_UI;
        _game = Managers.Game;

        _ui = Managers.UI.ShowSceneUI<UI_TestScene>();

    }

    void Update()
    {
        if (isGameEnd)
            return;

    }


    // TODO : [Dahye] What UI to show when the game ends.
    void OnStageClear()
    {
        StartCoroutine(CoGameEnd());
    }

    IEnumerator CoGameEnd()
    {
        yield return new WaitForSeconds(1f);
        isGameEnd = true;

        Managers.Game.IsGameEnd = true;

        // TODO : [Dahye] What you're going to do when the game ends

        // UI_GameResultPopup gameResult = Managers.UI.ShowPopupUI<UI_GameResultPopup>();
        //  gameResult.SetInfo();
    }




    public override void Clear()
    {

    }
}
