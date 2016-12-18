using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour {

    public Text myScore, myMissed, highScore, highMissed;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("myScore") > PlayerPrefs.GetInt("highScore"))
            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("myScore"));
        myScore.text = ""+ PlayerPrefs.GetInt("myScore");
        highScore.text = "" + PlayerPrefs.GetInt("highScore");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
            SceneManager.LoadScene("Start");
    }
}
