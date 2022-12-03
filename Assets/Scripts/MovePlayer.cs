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
    //private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        //transform = GetComponent<Transform>;
        selfRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;


        //On a freeze la rotation pour qu'il puisse rester dans la meme position, il faut maintenant adapter sa position pour qu'elle soit toujours parallele au sol
        selfRb.angularVelocity = 0f;
        //selfRb.freezeRotation = true;
        Debug.Log("Scale = " + transform.localScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
    }


    public void PointerDownLeft()
    {
        moveLeft = true;
        //Debug.Log("PointerDownLeft");
    }

    public void PointerUpLeft()
    {
        Debug.Log("PointerUpLeft");
        moveLeft = false;
    }


    public void PointerDownRight()
    {
       // Debug.Log("PointerDownRight");
        moveRight = true;
    }

    public void PointerUpRight()
    {
        //Debug.Log("PointerUpRight");
        moveRight = false;
    }

    private void MovementPlayer()
    {
        //Debug.Log("MovementPlayer");
        //moveRight = false;
        float horizontalScale = transform.localScale.x;
        Debug.Log("moveLeft : " + moveLeft + " - moveRight : "  + moveRight);
        if (moveLeft)
        {
            if(horizontalScale < 0)
            {
                Debug.Log("Hello Lefft");
                transform.localScale = new Vector2(-horizontalScale, transform.localScale.y);
            }
            anim.enabled = true;
            horizontalMove = -speed;
            anim.Play(runningAnimation);
        }

        else if (moveRight)
        {
            if (horizontalScale > 0)
            {
                transform.localScale = new Vector2(-horizontalScale, transform.localScale.y);
            }
            anim.enabled = true;
            horizontalMove = speed;
            anim.Play(runningAnimation);
        }

        else
        {
            horizontalMove = 0;
            anim.enabled = false;
        }
        selfRb.angularVelocity = 0f;
    }

    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
        selfRb.velocity = new Vector2(horizontalMove, selfRb.velocity.y);
    }

    public void CallThisFromButton()
    {
        anim.Play(runningAnimation);
    }
}
