using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private int level;
    private int wallspeed = 5;
    public GameObject theWallSpawner;


    void Start()
    {
        level = 1;
        theWallSpawner = GameObject.Find("WallSpawnr");
    }
    void Update()
    {
        theWallSpawner.GetComponent<spawnwalls>().CreatePrefab(level);
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

    bool playerIsOutOfBound(Vector3 pos) {

        if (pos.y > 12 || pos.y < -5) return true;
        else
        if (pos.x > 18 || pos.x < -15) return true;
        else
        if (pos.z > 2 || pos.z < -4) return true;
        else
        return false;
    }
  */
    #endregion old
}
