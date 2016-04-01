using UnityEngine;
using System.Collections;

public class starScript : MonoBehaviour {


    public int starspeed = 1;

    public void setSpeed(int x)
    {
        starspeed = x;
    }
    void Start () {
	
	}
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime * starspeed, Space.World);
        if (this.transform.position.x < -15)
        {
            Destroy(this.gameObject);
        }
    }
}
