﻿using UnityEngine;
using System.Collections;

public class wallmove : MonoBehaviour {


    GameObject go;

    

    public int wallspeed=0;

    public void setSpeed(int x) {
        wallspeed = x;
    }
 
    void Start()
    {

    }

 
    void Update () {
        transform.Translate(Vector3.left  * Time.deltaTime * wallspeed, Space.World);

        if (this.transform.position.x < -20) {           
            Destroy(this.gameObject);
        }
         
    }
}
