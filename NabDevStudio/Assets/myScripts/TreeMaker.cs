using UnityEngine;
using System.Collections;

public class TreeMaker : MonoBehaviour {

    private GameObject tree;

 
    // Use this for initialization
    void Start()
    {

        //  cubeMountainGood

        string path = "trees/tree1";

        tree = Resources.Load(path) as GameObject;
        
        InvokeRepeating("MakeTree", 1f, 5f);
    }

    // Update is called once per frame
    void Update () {
	
	}

    void MakeTree()
    {
        GameObject go = Instantiate(tree, transform.position, transform.rotation) as GameObject;
        int randZ = Random.RandomRange(10, 90);
        
       
        go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, randZ);
    }

}
