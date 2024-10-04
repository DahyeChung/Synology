/// <summary>
/// Collection of names used through out the project.
/// </summary>
public class Define
{
    /// <summary>
    /// Exact name of all scenes 
    /// </summary>
    public enum Scene
    {
        Unknown,
        TitleScene,
        WB1, // temp
        WB2,
        WB3,
        WB4,
        WB5,
        WB6,
        WB7,
        WB8,
        TestScene_UI,

    }


    // temp
    public enum MenuType
    {
        Pizza,
        Burger,
        //Pasta,
        //Salad,
        //Sushi,
    }


    public enum Sound
    {
        Bgm,
        SubBgm,
        Effect,
        Max,
    }

    public enum UIEvent
    {
        Click,
        Preseed,
        PointerDown,
        PointerUp,
        BeginDrag,
        Drag,
        EndDrag,
    }
}


