using UnityEngine;
using System.Collections;

public class pawgenerator : MonoBehaviour {

    private GameObject paw;


    // Use this for initialization
    void Start()
    {

        //  cubeMountainGood

        string path = "paws/paw";

        paw = Resources.Load(path) as GameObject;

        InvokeRepeating("MakePaw", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MakePaw()
    {

        int speed = GameManager.level;

        GameObject go = Instantiate(paw) as GameObject;
        
        int randY = Random.RandomRange(1, 4);


        go.transform.position = new Vector3(go.transform.position.x, randY, go.transform.position.z);
    }
}
