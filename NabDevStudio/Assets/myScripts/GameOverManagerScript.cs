using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverManagerScript : MonoBehaviour {


    public Text scoretext;
    public Text Maxscoretext;


    private int lastLevelScore;
    private int maxscore;
    void Start () {
        lastLevelScore = PlayerPrefs.GetInt("CurentSessionScore");
        maxscore = PlayerPrefs.GetInt("MaxScore");

        if (lastLevelScore > maxscore) { maxscore = lastLevelScore; PlayerPrefs.SetInt("MaxScore", maxscore); }

        scoretext.text ="Last session score="+ lastLevelScore.ToString();

      Maxscoretext.text = "All times top score ="+maxscore.ToString();
    }

    //GameOverButton

    // Update is called once per frame
    void Update () {
        if (CrossPlatformInputManager.GetButtonDown("GameOverButton"))
        {
            SceneManager.LoadScene("GameManager");        
        }

    }
}
