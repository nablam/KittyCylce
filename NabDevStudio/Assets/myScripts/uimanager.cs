using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uimanager : MonoBehaviour {
    public Text scoretext;
    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        scoretext.text = "score: " + score.ToString();
    }

    public void updateScore() {
        score++;
        scoretext.text = "score: " + score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
