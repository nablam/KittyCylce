using UnityEngine;
using System.Collections;

public class pawscript : MonoBehaviour {

    //particles/pawplosion

    // Use this for initialization
    void Start()
    {



    }
    void Update()
    {
        int globalspeed = GameManager.level + 1;
        transform.Translate(Vector3.left * Time.deltaTime * globalspeed, Space.World);
        if (this.transform.position.x < -15)
        {
          
            Destroy(this.gameObject);
        }
    }
}
