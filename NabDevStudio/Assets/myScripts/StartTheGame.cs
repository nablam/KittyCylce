using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class StartTheGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("StartButton"))
        {
            print("CLICK");
           SceneManager.LoadScene("GameManager");
            //Application.LoadLevel("HighScore");
        }
            

    }
}
