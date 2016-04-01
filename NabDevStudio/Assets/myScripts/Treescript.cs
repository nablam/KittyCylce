using UnityEngine;
using System.Collections;

public class Treescript : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        speed = 5;
    }
    public int speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);

        if (this.transform.position.x < -200)
        {
            Destroy(this.gameObject);
        }
    }
}
