using UnityEngine;
using System.Collections;

public class WireAnimationController : MonoBehaviour
{

    public static WireAnimationController singleton;
    public float speed;
    [HideInInspector]
    public float cycleOffset;

    private float zero = 0f;

    // Use this for initialization
    void Start()
    {
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        cycleOffset = Mathf.Repeat(Time.time, 1.0f);
    }
}
