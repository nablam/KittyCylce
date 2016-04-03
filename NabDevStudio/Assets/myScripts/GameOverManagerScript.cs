using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverManagerScript : MonoBehaviour {


    public Text scoretext;
    // Use this for initialization
    void Start () {

        int INTscore = PlayerPrefs.GetInt("PlayerScore");
        string s = INTscore.ToString();
        scoretext.text = s;
    }

    //GameOverButton

    // Update is called once per frame
    void Update () {
        if (CrossPlatformInputManager.GetButtonDown("GameOverButton"))
        {
           
            SceneManager.LoadScene("GameManager");
            //Application.LoadLevel("HighScore");
        }

    }
}
