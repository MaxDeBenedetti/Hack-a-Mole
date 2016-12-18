using UnityEngine;
using System.Collections;

public class ToggleGroup : MonoBehaviour {

    public Toggleable[] toggles;

    private bool isOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToggleTheGroup()
    {
        isOn = !isOn;
        if (isOn)
        {
            foreach(Toggleable toggle in toggles)
            {
                if(toggle != null)
                    toggle.TurnOn();
            }
        }
        else
        {
            foreach (Toggleable toggle in toggles)
            {
                if (toggle != null)
                    toggle.TurnOff();
            }
        }
    }

    public void TurnOnGroup()
    {
        isOn = true;
        foreach (Toggleable toggle in toggles)
        {
            if (toggle != null)
                toggle.TurnOn();
        }
    }

    public void TurnOffGroup()
    {
        isOn = false;
        foreach (Toggleable toggle in toggles)
        {
            if (toggle != null)
                toggle.TurnOff();
        }
    }
}
