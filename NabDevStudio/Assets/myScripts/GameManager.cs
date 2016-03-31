using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private int level = 1;
    private int wallspeed = 5;
    private int score=0;
    private int Lives=3;
    public GameObject theWallSpawner;

    private GameObject player=null;
    private GameObject localplayer;
    private playerKittyForce playerScript;
    GameObject UiGO;
    uimanager uiscript;


    enum State { Playing, Hit, Invincible, Lost }
    private State state = State.Playing;

    // Use this for initialization
    void Start () {
        UiGO = GameObject.Find("UIManager");
        uiscript = UiGO.GetComponent<uimanager>();

        string path = "Pasha/PashaPrefab";
        player = Resources.Load(path)as GameObject;

        localplayer= Instantiate(player);

    }
	
	// Update is called once per frame
	void Update () {
     
       
        if (localplayer != null) {

            if (playerIsOutOfBound(localplayer.transform.position))
            {
                Destroy(localplayer.gameObject);
                Lives--;
                uiscript.updateLives(Lives);
            }

        }
   
        theWallSpawner.GetComponent<spawnwalls>().CreatePrefab(wallspeed);


    }


    bool playerIsOutOfBound(Vector3 pos) {

        if (pos.y > 12 || pos.y < -5) return true;
        else
        if (pos.x > 18 || pos.x < -12) return true;
        else
        if (pos.z > 2 || pos.z < -4) return true;
        else
        return false;
    }








    //IEnumerator killKitty()
    //{
    //    state = State.Hit;
        
    //    gameObject.renderer.enabled = false;
       

    //    yield return new WaitForSeconds();



    //    if (player.lives > 0)
    //    {

    //        gameObject.renderer.enabled = true;
    //        while (transform.position.z <= -2.2)
    //        {
    //            float slideup = shipMoveOnToScreenSpeed * Time.deltaTime;
    //            transform.position = new Vector3(0f, transform.position.y, transform.position.z + slideup);
    //            yield return 0;
    //        }

    //        state = State.Invincible;
    //        while (blinkCount < numberOfTimeToBlink)
    //        {
    //            gameObject.renderer.enabled = !gameObject.renderer.enabled;
    //            if (gameObject.renderer.enabled == true)
    //                blinkCount++;
    //            yield return new WaitForSeconds(blinkRate);

    //        }
    //        blinkCount = 0;
    //        state = State.Playing;
    //    }



    //    else
    //        Application.LoadLevel(2);



    //    //closing if life test
    //}

}
