using UnityEngine;
using System.Collections;

public class MasterControl : MonoBehaviour {

    public ToggleGroup firstGroup;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartSecurity()
    {
        firstGroup.TurnOnGroup();
    }
}
