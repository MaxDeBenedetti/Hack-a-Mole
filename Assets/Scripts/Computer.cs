using UnityEngine;
using System.Collections;
using System;

public class Computer : Toggleable
{


    public float timeMoleIsUp = 2f;
    public float minTimeSinceLastOff = 0.6f;

    public Sprite onSprite, offSprite, moleSprite;
    [HideInInspector]
    public SpriteRenderer sp;

    private float timeOfLastOff;
    private Coroutine moleTimer;

    private float timeMolePoppedUp;

    /// <summary>
    /// If the computer can be used to score
    /// true means that you can score
    /// </summary>
    public bool isMoleUp;

    public bool isOn;

    public void Awake()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.N))
            PopUpMole();
        if (isMoleUp && (Time.time > timeMolePoppedUp + timeMoleIsUp))
            PopDownMole();

        float dieRoll = UnityEngine.Random.value;
        if (GameController.singleton.isPlaying && CanMolePopUp() && dieRoll < 0.001f)
            PopUpMole();
    }

    public override void TurnOn()
    {
        isOn = true;
        sp.sprite = onSprite;

        if (isMoleUp)
        {
            SmashMole();
            GameController.singleton.score++;
        }

    }

    public override void TurnOff()
    {
        isOn = false;
        timeOfLastOff = Time.time;
        sp.sprite = offSprite;
        
    }

    public void PopUpMole()
    {
        sp.sprite = moleSprite;
        isMoleUp = true;
        //moleTimer = StartCoroutine(MoleTimer());
        timeMolePoppedUp = Time.time;
    }

    public void SmashMole()
    {
        isMoleUp = false;
        Debug.Log("smashed");
        //StopCoroutine(moleTimer);
        //TODO: graphic stuff
    }

    /// <summary>
    /// Hides the mole once it has been up for too long
    /// </summary>
    public void PopDownMole()
    {
        isMoleUp = false;
        GameController.singleton.missed++;
        sp.sprite = offSprite;
    }

    public IEnumerator MoleTimer()
    {
        yield return new WaitForSeconds(timeMoleIsUp);
        PopDownMole();
    }

    /// <summary>
    /// By setting a minimum time a computer must be off before it is hacked, the player cannot just spam the switch.
    /// Right now, minTimeSinceLastOff is 0, so it does not matter.
    /// </summary>
    /// <returns>a bool determining if the mole can pop up</returns>
    public bool CanMolePopUp()
    {
        return (!isOn && !isMoleUp && (Time.time > (minTimeSinceLastOff + timeOfLastOff)));
    }
}
