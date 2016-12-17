using UnityEngine;
using System.Collections;
using System;

public class Computer : Toggleable
{

    /// <summary>
    /// The wire going into the computer
    /// </summary>
    public Wire inWire, outWire;

    /// <summary>
    /// If the computer can be used to score
    /// true means that you can score
    /// </summary>
    public bool isMoleUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void TurnOn()
    {
        if(outWire != null)
        {
            outWire.TurnOn();
        }

        if (isMoleUp && inWire)
        {
            GameController.singleton.score++;
        }
    }

    public override void TurnOff()
    {
        if (outWire != null)
        {
            outWire.TurnOff();
        }
    }
}
