using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRunningAnimation : MonoBehaviour
{
    public string runningAnimation = "RunningAnimation";
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CallThisFromButton()
    {
        anim.Play(runningAnimation);
    }

}
