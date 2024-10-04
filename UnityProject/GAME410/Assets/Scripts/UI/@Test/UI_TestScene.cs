using UnityEngine;

public class UI_TestScene : UI_Scene
{
    GameManage _game;

    bool isGameEnd = false;


    #region Events Bindings
    // Default UI structure for the scene
    enum GameObjects
    {
        ContentObject,
    }

    enum Buttons
    {
        //PopUpButton,
        //ToastButton,
        PauseButton,
        //SettingButton,
    }
    enum Texts
    {
        //PopUpText,
        //ToastText,
        PauseText,
        //SettingText,
        //TimeLimitValueText,
    }

    enum Images
    {
        //PopUpImage,
        //ToastImage,
        //PauseImage,
        //SettingImage,
        //TimeImage,
    }

    //enum AlarmType
    //{
    //    TimeLeft,
    //    TimeOver,
    //}

    #endregion



    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        // Object binding

        //BindButton(typeof(Buttons));
        //BindText(typeof(Texts));
        //BindObject(typeof(GameObjects));

        //GetButton((int)Buttons.PauseButton).gameObject.BindEvent(OnClickPauseButton);
        //GetButton((int)Buttons.PauseButton).GetOrAddComponent<UI_ButtonAnimation>();


        //GetButton((int)Buttons.PopUpButton).gameObject.BindEvent(OnClickPopUpButton);
        //GetButton((int)Buttons.PopUpButton).GetOrAddComponent<UI_SamplePopup>();
        //GetButton((int)Buttons.ToastButton).gameObject.BindEvent(OnClickToastButton);
        //GetButton((int)Buttons.ToastButton).GetOrAddComponent<UI_SampleToast>();
        //GetButton((int)Buttons.SettingButton).gameObject.BindEvent(OnClickSettingButton);
        //GetButton((int)Buttons.SettingButton).GetOrAddComponent<UI_SettingPopup>();



        // Get<TextMeshProUGUI>((int)Texts.TimeText).text = Managers.Time.GetTime();

        // _game = Managers.Game;

        GetComponent<Canvas>().worldCamera = Camera.main;

        return true;
    }

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        // Managers.Game.Init();
        // Managers.Time.Init();
    }




    #region Click Events
    public void OnClickPopUpButton()
    {
        // sound play
        // Managers.UI.ShowPopupUI<UI_PopupTest>();
    }
    public void OnClickPopUpCloseButton()
    {
        // SetActive(false);
    }

    public void OnClickToastButton()
    {
        // sound play
        // Managers.UI.ShowPopupUI<UI_ToastTest>();
    }

    public void OnClickPauseButton()
    {
        // sound play
        Managers.UI.ShowPopupUI<UI_PausePopup>();
    }

    public void OnClickSettingButton()
    {
        // sound play
        //  Managers.UI.ShowPopupUI<UI_SettingPopup>();
    }

    public void UpdateTime()
    {
        // Get<TextMeshProUGUI>((int)Texts.TimeText).text = Managers.Time.GetTime();
    }
    #endregion


}
