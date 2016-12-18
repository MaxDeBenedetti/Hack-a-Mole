using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController singleton;

    public int score = 0;
    public int missed = 0;

    public int timer = 45;
    public float minRandTime = 0.05f;
    public float maxRandTime = 1f;

    public MasterControl mc;

    public Computer[] comps;

    private float startTime;

    public Animator anim;

    public bool isPlaying;

    public Text timerText, scoreText, missedText, startText;

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
        if (startText.text.Equals("End"))
        {
            if (Input.anyKey)
            {
                PlayerPrefs.SetInt("myScore", score);
                SceneManager.LoadScene("HighScores");
            }
        }

        if (!isPlaying)
        {
            if (Input.anyKey)
            {
                StartGame();
                isPlaying = !isPlaying;
            }
        }

        timerText.text = "" + timer;
        if (timer < 0)
            timerText.text = "0";
        scoreText.text = "Score: " + score;
        missedText.text = "Missed: " + missed;

        
    }

    public void StartGame()
    {
        mc.StartSecurity();
        StartCoroutine(TickTimer());
        startText.text = "";
    }

    public void StartRandomMoles()
    {
        StartCoroutine(RandomPopUps());
    }

    /// <summary>
    /// PopUps a single mole
    /// </summary>
    public int PopUpAMole()
    {
        Debug.Log("Pop UP");
        bool hasNotChanged = true;
        Computer comp;
        int i = 0;
        do
        {
            comp = comps[Random.Range(0, comps.Length - 1)];
            if (comp.CanMolePopUp())
            {
                comp.PopUpMole();
                hasNotChanged = false;
                if (i < comps.Length)
                {
                    i++;
                }
                else
                {
                    hasNotChanged = false;
                }
            }
        } while (hasNotChanged);
        Debug.Log("pop out");
        return 1;
    }

    public int PopUpAMoleIgnoreRules()
    {
        Debug.Log("pop up");
        bool hasNotChanged = true;
        Computer comp;
        int i = 0;
        do
        {
            comp = comps[Random.Range(0, comps.Length - 1)];
            if (!comp.isOn && !comp.isMoleUp)
            {
                comp.PopUpMole();
                hasNotChanged = false;
                if(i < comps.Length)
                {
                    i++;
                }
                else
                {
                    hasNotChanged = false;
                }
            }
        } while (hasNotChanged);
        Debug.Log("pop out");
        return 1;
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
            yield return new WaitForSeconds(0.3f);
            int blah = PopUpAMoleIgnoreRules();
            Debug.Log("random mole "+ blah);
        }
    }

    public IEnumerator TickTimer()
    {
        while (timer >= 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
        isPlaying = false;
        startText.text = "End";
    }
}
