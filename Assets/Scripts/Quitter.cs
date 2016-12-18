using UnityEngine;
using System.Collections;

public class Quitter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            LeaveGame();
        }
	}

    public void LeaveGame()
    {
        Application.Quit();
    }
}
