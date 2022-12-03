using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public string runningAnimation = "RunningAnimation";
    Animator anim;

    private Rigidbody2D selfRb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        selfRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;

    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
    }


    public void PointerDownLeft()
    {
        moveLeft = true;
        Debug.Log("PointerDownLeft");
    }

    public void PointerUpLeft()
    {
        Debug.Log("PointerUpLeft");
        moveLeft = false;
    }


    public void PointerDownRight()
    {
        Debug.Log("PointerDownRight");
        moveRight = true;
    }

    public void PointerUpRight()
    {
        Debug.Log("PointerUpRight");
        moveRight = false;
    }

    private void MovementPlayer()
    {
        Debug.Log("MovementPlayer");
        //moveRight = false;
        if (moveLeft)
        {
            anim.enabled = true;
            horizontalMove = -speed;
            anim.Play(runningAnimation);
        }

        else if (moveRight)
        {
            anim.enabled = true;
            horizontalMove = speed;
            anim.Play(runningAnimation);
        }

        else
        {
            horizontalMove = 0;
            anim.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
        selfRb.velocity = new Vector2(horizontalMove, selfRb.velocity.y);
    }

    public void CallThisFromButton()
    {
        anim.Play(runningAnimation);
    }
}
