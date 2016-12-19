using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnykeyStartScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
            LoadStart();
	}

    public void LoadStart()
    {
        SceneManager.LoadScene("Start");
    }
}
