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

    private int lastmaxscore;
    private int thismaxscore;
    private int CurentSessionScore;
    void Start()
    {
    // PlayerPrefs.DeleteAll();  Uncomment this to load the first score of 0
        CurentSessionScore = 0;
         lastmaxscore = 0;
    

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

        CurentSessionScore = mangerScore;
        PlayerPrefs.SetInt("CurentSessionScore", CurentSessionScore);
       SceneManager.LoadScene("GameOver");
    }
   
}
