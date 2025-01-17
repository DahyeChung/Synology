using UnityEngine;

public class UI_Toast : UI_Base
{
    #region Enum

    enum Images
    {
        BackgroundImage
    }

    enum Texts
    {
        ToastMessageValueText,
    }
    public void OnEnable()
    {
        //OpenAnimation();
        PopupOpenAnimation(gameObject);
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
        BindImage(typeof(Images));
        BindText(typeof(Texts));

        #endregion

        Refresh();
        return true;
    }

    public void SetInfo(string msg)
    {
        // change message
        transform.localScale = Vector3.one;
        GetText((int)Texts.ToastMessageValueText).text = msg;
        Refresh();
    }

    void Refresh()
    {


    }

}
