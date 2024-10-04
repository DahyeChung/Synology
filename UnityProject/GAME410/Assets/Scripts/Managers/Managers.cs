using UnityEngine;

/// <summary>
/// Manage all Managers
/// </summary>
public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }


    #region Managers List
    public static GameManage Game { get { return Instance?._game; } }
    public static SceneManagerEx Scene { get { return Instance?._scene; } }
    public static ResourceManager Resource { get { return Instance?._resource; } }
    public static PoolManager Pool { get { return Instance?._pool; } }
    public static SoundManager Sound { get { return Instance?._sound; } }
    public static UIManager UI { get { return Instance?._ui; } }
    public static TimeManager Time { get; private set; }




    GameManage _game = new GameManage();
    SceneManagerEx _scene = new SceneManagerEx();
    ResourceManager _resource = new ResourceManager();
    PoolManager _pool = new PoolManager();
    SoundManager _sound = new SoundManager();
    UIManager _ui = new UIManager();
    TimeManager _time = new TimeManager();

    #endregion

    public static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");

            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
            s_instance._time = go.AddComponent<TimeManager>();
            //s_instance._sound.Init();

        }
    }

    public static void Clear()
    {
        // TODO : [Dahye] Add later

        //Sound.Clear();
        Scene.Clear();
        UI.Clear();
        Pool.Clear();
        //Object.Clear();
    }


}
