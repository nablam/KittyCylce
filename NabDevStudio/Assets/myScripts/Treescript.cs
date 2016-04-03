using UnityEngine;
using System.Collections;

public class Treescript : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
  
    }
  
    public int treespeed = 0;

    public void setSpeed(int x)
    {
        treespeed = x;
    }

    // Update is called once per frame
    void Update()
    {

        int globalspeed=GameManager.level+2;
        transform.Translate(Vector3.left * Time.deltaTime * globalspeed, Space.World);

        if (this.transform.position.x < -200)
        {
            Destroy(this.gameObject);
        }
    }
}
