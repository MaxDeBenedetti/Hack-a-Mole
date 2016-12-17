using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static GameController singleton;

    public int score = 0;

    public void Awake()
    {
        singleton = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
