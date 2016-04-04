using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public static int level;
    public static int managerLives=9;
    public static int mangerScore = 0;
    public static int managerWallNumber = 0;

    public GameObject theWallSpawner;
    public GameObject musicobject;
    private AudioSource audio;

    GameObject UiGO;
    uimanager uiscript;


    GameObject starmaker;
    starSpawn starSpawnscript;
    GameObject localStar;

    public static GameObject player = null;
    public static GameObject localplayer;

    void Start()
    {
        audio = musicobject.GetComponent<AudioSource>();
        int onoff=PlayerPrefs.GetInt("SoundOnOff");
        if (onoff == 1) { audio.enabled = true; }
        else
            if (onoff == 0) { audio.enabled = false; }

        managerWallNumber = 0;
        managerLives = 9;
        level = 1;
        mangerScore = 0;
        starmaker = GameObject.Find("StarSpawner");
        starSpawnscript = starmaker.GetComponent<starSpawn>();

        theWallSpawner = GameObject.Find("WallSpawnr");
        UiGO = GameObject.Find("UIManager");
        uiscript = UiGO.GetComponent<uimanager>();


        string path = "Pasha/PashaPrefab";
        player = Resources.Load(path) as GameObject;

        localplayer = Instantiate(player);
    }


    void Update()
    {

        if (managerLives <= 0) {
            gameover();
        }
        level = (managerWallNumber / 5) + 1;
        theWallSpawner.GetComponent<spawnwalls>().CreatePrefab(level);
        uiscript.updateScore(mangerScore);
        uiscript.updateLives(managerLives);
        uiscript.updateLevel(level);


        int rand = Random.Range(1, 1000);
        if (rand == 25) {

            string path = "stars/star";

             GameObject go = Resources.Load(path) as GameObject;

            localStar = Instantiate(go) as GameObject;
        }


    }

    public static void managerMakePlayer() {
        string path = "Pasha/PashaPrefab";
        player = Resources.Load(path) as GameObject;

        localplayer = Instantiate(player);
    }

    public void gameover() {

        PlayerPrefs.SetInt("PlayerScore", mangerScore);  // 
        SceneManager.LoadScene("GameOver");
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
