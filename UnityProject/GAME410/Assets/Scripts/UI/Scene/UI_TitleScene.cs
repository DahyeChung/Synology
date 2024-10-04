using DG.Tweening;

public class UI_TitleScene : UI_Scene
{
    #region Enum 
    // Enum {Button, text, object} should have the same name as the object in the hierarchy.
    // Will bind with the objects, buttons, and texts to be used in the inspector and connect them with actions.
    enum GameObjects
    {
        Slider,
    }

    enum Buttons
    {
        StartButton,
    }

    enum Texts
    {
        StartText
    }
    #endregion

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        // TODO : [Dahye] Which scene to transfer from the title scene? 

        // Move to white box 1
        GetButton((int)Buttons.StartButton).gameObject.BindEvent(() =>
        {
            Managers.Scene.LoadScene(Define.Scene.WB1, transform);
        });
        GetButton((int)Buttons.StartButton).gameObject.SetActive(false);

        return true;
    }

    private void Awake()
    {
        Init();
    }
    private void Start()
    {
        GetButton((int)Buttons.StartButton).gameObject.SetActive(false);
        GetButton((int)Buttons.StartButton).gameObject.SetActive(true);

        //        Managers.Game.Init();
        //        Managers.Time.Init();
        StartButtonAnimation();

    }

    // Text fade animation
    void StartButtonAnimation()
    {
        GetText((int)Texts.StartText).DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic).Play();
    }

}
