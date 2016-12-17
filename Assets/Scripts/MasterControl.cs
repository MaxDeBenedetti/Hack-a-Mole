using UnityEngine;
using System.Collections;

public class MasterControl : MonoBehaviour {

    public Wire[] outWires;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartSecurity()
    {
        foreach (Wire wire in outWires)
        {
            wire.TurnOn();
        }
    }
}
