using UnityEngine;
using System.Collections;
using System;

public class Wire : Toggleable
{

    public bool isLive = false;
    [HideInInspector]
    public Animator anim;

    public void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    // Use this for initialization
    void Start()
    {
        

    }

    public void FixedUpdate()
    {
        anim.SetFloat("EnergyStartPoint", WireAnimationController.singleton.cycleOffset);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void TurnOn()
    {
        isLive = true;
        anim.SetTrigger("TurnOn");
    }

    public override void TurnOff()
    {
        isLive = false;
        anim.SetTrigger("TurnOff");
    }
}
