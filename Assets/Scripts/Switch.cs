using UnityEngine;
using System.Collections;
using System;

public class Switch : Toggleable
{

    public Wire inWire;
    public Wire[] outWires;

    public Sprite[] sprites;

    private bool isUp = true;
    private bool isBlue = false;

    private int selectedWire;
    private SpriteRenderer sp;

    public void Awake()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

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
        isUp = !isUp;
        ChangeSprite();
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
        isBlue = true;
        ChangeSprite();
        outWires[selectedWire].TurnOn();
    }

    public override void TurnOff()
    {
        isBlue = false;
        ChangeSprite();
        outWires[selectedWire].TurnOff();
    }

    public void ChangeSprite()
    {
        int selectedSprite = 0;
        if (!isUp)
        {
            selectedSprite += 1;
        }
        if (isBlue)
            selectedSprite += 2;
        sp.sprite = sprites[selectedSprite];
    }


}
