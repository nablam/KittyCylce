using UnityEngine;
using System.Collections;

public class starSpawn : MonoBehaviour {

    GameObject go;
    GameObject star;
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public GameObject instantThatShit() {
        string path = "stars/star";

        go = Resources.Load(path) as GameObject;

        star =Instantiate(go) as GameObject;
       return star;
    }

    GameObject makeastar()
    {
        string path = "stars/star";

        go = Resources.Load(path) as GameObject;
        
        return go;
    }
}
