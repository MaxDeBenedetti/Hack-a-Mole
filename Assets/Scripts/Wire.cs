using UnityEngine;
using System.Collections;
using System;

public class Wire : Toggleable
{

    public bool isLive = false;
    public Toggleable endpoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    

    public override void TurnOn()
    {
        if(endpoint != null)
        {
            endpoint.TurnOn();
        }
    }

    public override void TurnOff()
    {
        if(endpoint != null)
        {
            endpoint.TurnOff();
        }
    }
}
