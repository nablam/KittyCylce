using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uimanager : MonoBehaviour {
    public Text scoretext;
    public Text livesText;
    public Text levelText;

    void Start () {
        scoretext.text = "Score: 0";
        livesText.text = "Lives: 3";
    }

    public void updateScore(int score) {
      
        scoretext.text = "Score: " + score.ToString();
    }

    public void updateLives(int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    public void updateLevel(int level)
    {
        levelText.text = "Level: " + level.ToString();
    }

}
