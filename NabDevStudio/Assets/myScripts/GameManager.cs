using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int level;
    public static int managerLives=3;
    public static int mangerScore = 0;

    public GameObject theWallSpawner;

    GameObject UiGO;
    uimanager uiscript;

    public static GameObject player = null;
    public static GameObject localplayer;

    void Start()
    {
        level = 1;
  
        theWallSpawner = GameObject.Find("WallSpawnr");
        UiGO = GameObject.Find("UIManager");
        uiscript = UiGO.GetComponent<uimanager>();


        string path = "Pasha/PashaPrefab";
        player = Resources.Load(path) as GameObject;

        localplayer = Instantiate(player);
    }


    void Update()
    {
        level = (mangerScore / 10) + 1;
        theWallSpawner.GetComponent<spawnwalls>().CreatePrefab(level);
        uiscript.updateScore(mangerScore);
        uiscript.updateLives(managerLives);
        
    }

    public static void managerMakePlayer() {
        string path = "Pasha/PashaPrefab";
        player = Resources.Load(path) as GameObject;

        localplayer = Instantiate(player);
    }
   

    #region old

    /*
    enum GameState { Playing, Win, Lose }
    GameState _gamestate;
    private int level = 1;
  
    private int score=0;
    private int Lives;


    private GameObject player=null;
    private GameObject localplayer;
    private playerKittyForce playerScript;
    private Vector3 initialpos;
    private Vector3 offscreenpos;

    GameObject UiGO;
    uimanager uiscript;



    private bool Outofbound = false;

    private bool decrementlivesOn = true;



    void Start () {
        _gamestate = GameState.Playing;

        UiGO = GameObject.Find("UIManager");
        uiscript = UiGO.GetComponent<uimanager>();

        string path = "Pasha/PashaPrefab";
        player = Resources.Load(path)as GameObject;

        localplayer= Instantiate(player);
        initialpos = localplayer.transform.position;
        offscreenpos = new Vector3(initialpos.x - 10, initialpos.y, initialpos.z);
    }


    void Update () {

        if(_gamestate == GameState.Playing)
  

        if (localplayer != null) {

            if (playerIsOutOfBound(localplayer.transform.position))
            {
                FindPlayerLivesdecrementLives();
                Destroy(localplayer.gameObject);


                Outofbound = true;
                GetNewPlayer();
            }
        }       
    }

    void FindPlayerLivesdecrementLives() {

       Lives= localplayer.GetComponent<playerKittyForce>().TotalLives;
            uiscript.updateLives(Lives);



    }

    void GetNewPlayer() {

        string path = "Pasha/PashaPrefab";
        player = Resources.Load(path) as GameObject;

        localplayer = Instantiate(player, offscreenpos, Quaternion.Euler(0, 90, 0)) as GameObject;
        //decrementlivesOn = true;
    }

  
  */
    #endregion old
}
