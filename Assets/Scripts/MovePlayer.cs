using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public string runningAnimation = "RunningAnimation";
    public string jumpingAnimation = "JumpingAnimation";
    Animator anim;

    private Rigidbody2D selfRb;
    private SpriteRenderer spriteR;

    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private float horizontalMove;
    private float verticalMove;
    public float speed = 5;

    private Sprite sprite1st;

    void Start()
    {
        selfRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        sprite1st = spriteR.sprite;
        
        //On a freeze la rotation pour qu'il puisse rester dans la meme position, il faut maintenant adapter sa position pour qu'elle soit toujours parallele au sol
        selfRb.angularVelocity = 0f;
        //selfRb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
    }
    

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }


    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    public void PointerClickJump()
    {
        moveUp = true;
    }

    public void PointerUpJump()
    {
        moveUp = false;
    }

    private void MovementPlayer()
    {
        float horizontalScale = transform.localScale.x;

        if (moveLeft)
        {
            //Si mario est dans la direction de droite
            if(horizontalScale < 0)
            {
                //On flip le sprite
                transform.localScale = new Vector2(-horizontalScale, transform.localScale.y);
            }
            anim.enabled = true;
            horizontalMove = -speed;
            anim.Play(runningAnimation);
        }

        else if (moveRight)
        {
            //Si mario est dans la direction de gauche
            if (horizontalScale > 0)
            {
                //On flip le sprite
                transform.localScale = new Vector2(-horizontalScale, transform.localScale.y);
            }
            anim.enabled = true;
            horizontalMove = speed;
            anim.Play(runningAnimation);
        }
        else if (moveUp)
        {
            //
            anim.enabled = true;
            anim.Play(jumpingAnimation);
            verticalMove = 6;

        }

        else
        {
            horizontalMove = 0;
            anim.enabled = false;
            // Jump animation  marche pas car moveUp est � true pendant une frame seulement, donc pas le temps d'afficher. Il faudrait pouvoir detecter quand il jump soit en l'air soit pas collision du sol en omettant les autres
            spriteR.sprite = sprite1st;
        }
        selfRb.angularVelocity = 0f;
    }

    private void FixedUpdate()
    {

        if (moveUp )
        {
            selfRb.velocity = new Vector2(horizontalMove, verticalMove);

            moveUp = false;
        }
        else
        {
            selfRb.velocity = new Vector2(horizontalMove, selfRb.velocity.y);
        }
    }

}
