using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static GameController singleton;

    public int score = 0;
    public int missed = 0;

    public Computer[] comps;

    public void Awake()
    {
        singleton = this;
        comps = GameObject.FindObjectsOfType<Computer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// PopUps a single mole
    /// </summary>
    public void PopUpAMole()
    {
        bool hasNotChanged = true;
        Computer comp;
        do
        {
            comp = comps[Random.Range(0, comps.Length - 1)];
            if (comp.CanMolePopUp())
            {
                comp.PopUpMole();
                hasNotChanged = false;
            }
        } while (hasNotChanged);
    }

    /// <summary>
    /// PopUp a specified number of moles at once
    /// </summary>
    /// <param name="numOfMoles">the number of moles to pop up</param>
    public void PopUpManyMoles(int numOfMoles)
    {
        for(int i = 0; i < numOfMoles; i++)
        {
            PopUpAMole();
        }
    }
}
