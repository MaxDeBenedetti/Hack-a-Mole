using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseUp()
    {
        LoadTheGame();
    }

    public void LoadTheGame()
    {
        SceneManager.LoadScene("main");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
