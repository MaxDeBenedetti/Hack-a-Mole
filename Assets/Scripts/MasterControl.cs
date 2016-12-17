using UnityEngine;
using System.Collections;

public class MasterControl : MonoBehaviour {

    public Wire[] outWires;

	// Use this for initialization
	void Start () {
	    foreach(Wire wire in outWires)
        {
            wire.TurnOn();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
