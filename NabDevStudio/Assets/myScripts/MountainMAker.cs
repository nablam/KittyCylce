using UnityEngine;
using System.Collections;

public class MountainMAker : MonoBehaviour {


    private GameObject cube;

    int[] sizes;
 
    public float spawnTime = 3f;
    // Use this for initialization
    void Start()
    {

        //  cubeMountainGood

        string path = "Mountains/cubeMountainGood";

        cube = Resources.Load(path) as GameObject;
        sizes = new int[4];
        sizes[0] = 40;
        sizes[1] = 60;
        sizes[2] = 80;
        sizes[3] = 100;

        InvokeRepeating("SpawnBall", 1f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void SpawnBall()
    {
       GameObject go= Instantiate(cube, transform.position, transform.rotation )as GameObject;
       int randindex= Random.RandomRange(0, 4);
        int chozensize = sizes[randindex];
        go.transform.localScale = new Vector3(chozensize, chozensize, 10);
        go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z + randindex);
    }

}
