using UnityEngine;
using System.Collections;
using System;

public class Computer : Toggleable
{

    /// <summary>
    /// The wire going into the computer
    /// </summary>
    public Wire inWire, outWire;
    public float timeMoleIsUp;
    public float minTimeSinceLastOff = 0;

    private float timeOfLastOff;
    private Coroutine moleTimer;

    /// <summary>
    /// If the computer can be used to score
    /// true means that you can score
    /// </summary>
    public bool isMoleUp;

    public bool isOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void TurnOn()
    {
        isOn = true;
        Debug.Log(gameObject.name + " turned on");

        if (isMoleUp)
        {
            SmashMole();
            GameController.singleton.score++;
        }

        if (outWire != null)
        {
            outWire.TurnOn();
        }

    }

    public override void TurnOff()
    {
        isOn = false;
        timeOfLastOff = Time.time;
        if (outWire != null)
        {
            outWire.TurnOff();
        }
    }

    public void PopUpMole()
    {
        //TODO: graphic stuff
        isMoleUp = true;
    }

    public void SmashMole()
    {
        isMoleUp = false;
        //TODO: graphic stuff
    }

    /// <summary>
    /// Hides the mole once it has been up for too long
    /// </summary>
    public void PopDownMole()
    {
        isMoleUp = false;
        GameController.singleton.missed++;
        //TODO: graphic stuff
    }

    public IEnumerator MoleTimer()
    {
        yield return new WaitForSeconds(timeMoleIsUp);
        PopDownMole();
    }

    /// <summary>
    /// By setting a minimum time a computer must be off before it is hacked, the player cannot just spam the switch.
    /// Right now, minTimeSinceLastOff is 0, so it does not matter.
    /// </summary>
    /// <returns>a bool determining if the mole can pop up</returns>
    public bool CanMolePopUp()
    {
        return (!isOn && Time.time > minTimeSinceLastOff + timeOfLastOff );
    }
}
