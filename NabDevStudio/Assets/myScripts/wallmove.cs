using UnityEngine;
using System.Collections;

public class wallmove : MonoBehaviour {


    GameObject go;


   // cubeMountain
    public int wallspeed=0;

    public void setSpeed(int x) {
        wallspeed = x;
    }
 
    void Start()
    {

    }

 
    void Update () {
        transform.Translate(Vector3.left  * Time.deltaTime * wallspeed, Space.World);
       
        if (this.transform.position.x < -12) {
            GameManager.mangerScore++;
            Destroy(this.gameObject);
        }
         
    }
}
