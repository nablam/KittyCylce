using UnityEngine;
using System.Collections;

public class wallmove : MonoBehaviour {


    GameObject go;

    uimanager uiscript;
    GameObject UiGO;

    void Start()
    {
        UiGO = GameObject.Find("UIManager");
        uiscript = UiGO.GetComponent<uimanager>();
    }

 
    void Update () {
        transform.Translate(Vector3.left  * Time.deltaTime * 200, Space.World);

        if (this.transform.position.x < -100) {
            uiscript.updateScore();
            Destroy(this.gameObject);
        }
         
    }
}
