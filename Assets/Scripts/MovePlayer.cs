using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D selfRb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        selfRb = GetComponent<Rigidbody2D>();
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
            horizontalMove = -speed;
        }

        else if (moveRight)
        {
            horizontalMove = speed;
        }

        else
        {
            horizontalMove = 0;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
        selfRb.velocity = new Vector2(horizontalMove, selfRb.velocity.y);
    }
}
