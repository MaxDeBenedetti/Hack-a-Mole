using UnityEngine;
using System.Collections;
using System;

public class Switch : Toggleable
{
    public ToggleGroup[] groups;
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
        Debug.Log("clicked");
        Toggle();
    }

    /// <summary>
    /// Changes the switches active wire
    /// </summary>
    public void Toggle()
    {
        isUp = !isUp;
        ChangeSprite();
        if (isBlue  && !(groups.Length == 0))
        {
            groups[selectedWire].TurnOffGroup();
            selectedWire = (selectedWire + 1) % groups.Length;
            groups[selectedWire].TurnOnGroup();
        }
    }

    public override void TurnOn()
    {
        isBlue = true;
        ChangeSprite();
        if(groups.Length > 0)
            groups[selectedWire].TurnOnGroup();
    }

    public override void TurnOff()
    {
        isBlue = false;
        ChangeSprite();
        if (groups.Length > 0)
            groups[selectedWire].TurnOffGroup();
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
