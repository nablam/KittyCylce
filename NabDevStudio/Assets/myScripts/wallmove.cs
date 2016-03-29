using UnityEngine;
using System.Collections;

public class wallmove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left  * Time.deltaTime * 200, Space.World);

        if (this.transform.position.x < -100)
            Destroy(this.gameObject);
    }
}
