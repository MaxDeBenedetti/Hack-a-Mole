﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static GameController singleton;

    public int score = 0;
    public int missed = 0;

    public int timer = 60;
    public float minRandTime = 0.05f;
    public float maxRandTime = 1f;

    public MasterControl mc;

    public Computer[] comps;

    private float startTime;

    public Animator anim;

    public void Awake()
    {
        singleton = this;
        comps = GameObject.FindObjectsOfType<Computer>();
        anim = gameObject.GetComponent<Animator>();
        mc = GameObject.FindObjectOfType<MasterControl>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Mathf.FloorToInt(Time.time - startTime);
    }

    public void StartGame()
    {
        mc.StartSecurity();
        StartRandomMoles();
        anim.SetTrigger("PlayGame");
        startTime = Time.time;
    }

    public void StartRandomMoles()
    {
        StartCoroutine(RandomPopUps());
    }

    /// <summary>
    /// PopUps a single mole
    /// </summary>
    public void PopUpAMole()
    {
        bool hasNotChanged = true;
        Computer comp;
        do
        {
            comp = comps[Random.Range(0, comps.Length - 1)];
            if (comp.CanMolePopUp())
            {
                comp.PopUpMole();
                hasNotChanged = false;
            }
        } while (hasNotChanged);
    }

    public void PopUpAMoleIgnoreRules()
    {
        bool hasNotChanged = true;
        Computer comp;
        do
        {
            comp = comps[Random.Range(0, comps.Length - 1)];
            if (!comp.isOn && !comp.isMoleUp)
            {
                comp.PopUpMole();
                hasNotChanged = false;
            }
        } while (hasNotChanged);
    }

    /// <summary>
    /// PopUp a specified number of moles at once
    /// </summary>
    /// <param name="numOfMoles">the number of moles to pop up. 
    /// If you specify 0, then the moles of all currently off computer will turn on at once ignoring typical pop up rules
    /// If you specify a negative number, then the moles will ignore typical pop up rules</param>
    public void PopUpManyMoles(int numOfMoles)
    {
        if (numOfMoles == 0)
        {
            foreach(Computer comp in comps)
            {
                if (!comp.isOn)
                {
                    comp.PopUpMole();
                }
            }
        }
        else if(numOfMoles < 0)
        {
            numOfMoles *= -1;
            for (int i = 0; i < numOfMoles; i++)
            {
                PopUpAMoleIgnoreRules();
            }
        }
        else
        {
            for (int i = 0; i < numOfMoles; i++)
            {
                PopUpAMole();
            }
        }
    }

    public IEnumerator RandomPopUps()
    {
        while (timer >= 0)
        {
            yield return new WaitForSeconds(Random.Range(minRandTime, maxRandTime));
            PopUpAMole();
        }
    }

}
