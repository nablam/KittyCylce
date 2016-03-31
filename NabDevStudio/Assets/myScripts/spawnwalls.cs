using UnityEngine;
using System.Collections;

public class spawnwalls : MonoBehaviour {
    private float InstantiationTimer = 1f;

    GameObject go;

    uimanager uiscript;
    GameObject UiGO;

    void Start()
    {
        UiGO = GameObject.Find("UIManager");
        uiscript = UiGO.GetComponent<uimanager>();
    }

    // Update is called once per frame
    void Update () {
       // CreatePrefab();
    }



   public void CreatePrefab(int level)
    {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
           // uiscript.updateScore();
            int rand = Random.Range(1, 7);

          Instantiate(makeWallwithspeed(rand, level));
      
          float newtimer = Random.Range(1, 5);
            
            InstantiationTimer = newtimer;
        }
    }

    GameObject makeWallwithspeed(int wallnumber, int level) {
        string path = "walls/wall" + wallnumber.ToString();

        go =  Resources.Load(path) as GameObject;
        go.GetComponent<wallmove>().setSpeed(level);
        return go;
    }


}
