using UnityEngine;
using System.Collections;
using System;

public class Switch : Toggleable
{

    public Wire inWire;
    public Wire[] outWires;

    private int selectedWire;

    // Use this for initialization
    void Start()
    {
        selectedWire = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        Toggle();
    }

    /// <summary>
    /// Changes the switches active wire
    /// </summary>
    public void Toggle()
    {

        if (inWire.isLive)
        {

            Debug.Log("clicked");
            outWires[selectedWire].TurnOff();
            selectedWire = (selectedWire + 1) % outWires.Length;
            outWires[selectedWire].TurnOn();
        }
    }

    public override void TurnOn()
    {
        outWires[selectedWire].TurnOn();
    }

    public override void TurnOff()
    {
        outWires[selectedWire].TurnOff();
    }
}
