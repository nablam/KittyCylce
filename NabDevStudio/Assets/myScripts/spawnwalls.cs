using UnityEngine;
using System.Collections;

public class spawnwalls : MonoBehaviour {
    private float InstantiationTimer = 5f;

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
        CreatePrefab();
    }



    void CreatePrefab()
    {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
           // uiscript.updateScore();
            int rand = Random.Range(0, 5);
          //  Debug.Log(rand);
            switch (rand)
            {
                case 0:
                    go = Instantiate(Resources.Load("walls/wall50")) as GameObject;
                    break;
                case 1:
                    go = Instantiate(Resources.Load("walls/wall100")) as GameObject;
                    break;
                case 2:
                    go = Instantiate(Resources.Load("walls/wall150")) as GameObject;
                    break;
                case 3:
                    go = Instantiate(Resources.Load("walls/wall200")) as GameObject;
                    break;
                case 4:
                    go = Instantiate(Resources.Load("walls/wall150")) as GameObject;
                    break;
                default:
                    go = Instantiate(Resources.Load("walls/wall50")) as GameObject;
                    break;
            }

            float newtimer = Random.Range(0.1f, 10.0f);
            
            InstantiationTimer = newtimer;
        }
    }
}
