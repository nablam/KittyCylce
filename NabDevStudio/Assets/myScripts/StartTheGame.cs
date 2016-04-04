using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartTheGame : MonoBehaviour {

    public Text OnOff;
    private bool onoff;

	// Use this for initialization
	void Start () {
        onoff = true;
        OnOff.color = Color.white;

    }
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("StartButton"))
        {
         
            if (onoff)
            { PlayerPrefs.SetInt("SoundOnOff", 1); }
            else
            {
                PlayerPrefs.SetInt("SoundOnOff", 0);
            }

            SceneManager.LoadScene("GameManager");
          
        }

        if (onoff) {
            OnOff.text = "Sound: ON";
        }
        else
            OnOff.text = "Sound: OFF";

        if (CrossPlatformInputManager.GetButtonDown("SoundButton"))
        {
            onoff = !onoff;


        }
    


    }
}
