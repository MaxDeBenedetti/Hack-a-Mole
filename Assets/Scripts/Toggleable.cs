using UnityEngine;
using System.Collections;

public abstract class Toggleable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public abstract void TurnOn();
    public abstract void TurnOff();
}
