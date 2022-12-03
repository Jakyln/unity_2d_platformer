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

    //private Sprite[] sprites;
    private Sprite sprite1st;
   // Sprite[] loadedSprites;

    /*[SerializeField]
    int groundLayer;*/
    //private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        //transform = GetComponent<Transform>;
        selfRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        sprite1st = spriteR.sprite;
        //sprites = Resources.LoadAll<Sprite>("m_Sprite");
        /*Debug.Log(sprites[0]);
        Debug.Log(sprites[1]);*/
        //AssetDatabase.GetAssetPath(spriteR.sprite.GetInstanceID()).Replace(".png", "");

        //loadedSprites = Resources.LoadAll("Sprites", typeof(Sprite));
        //spriteR.sprite.GetInstanceID()
        //sprite1st = spriteR.sprite.GetInstanceID().Replace(".png", "").Replace("Assets/Resources/", "")

        //Debug.Log(sprites.Length);

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
        //Debug.Log("PointerDownLeft");
    }

    public void PointerUpLeft()
    {
        //Debug.Log("PointerUpLeft");
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

    public void PointerClickJump()
    {
        moveUp = true;
        Debug.Log("PointerDownJump");
    }

    public void PointerUpJump()
    {
        Debug.Log("PointerUpJump");
        moveUp = false;
    }

    private void MovementPlayer()
    {
        //Debug.Log("MovementPlayer");
        //moveRight = false;
        float horizontalScale = transform.localScale.x;
        //Debug.Log("moveLeft : " + moveLeft + " - moveRight : "  + moveRight);
        Debug.Log("moveUp : " + moveUp);

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
            /*Debug.Log("selfRb.velocity.y : " + selfRb.velocity.y)
            if(selfRb.velocity.y > 0)
            {
                spriteR.sprite = sprite1st;
            }*/
            // Jump animation  marche pas car moveUp est à true pendant une frame seulement, donc pas le temps d'afficher. Il faudrait pouvoir detecter quand il jump soit en l'air soit pas collision du sol en omettant les autres
            spriteR.sprite = sprite1st;
        }
        selfRb.angularVelocity = 0f;
    }

    private void FixedUpdate()
    {

        //Debug.Log("FixedUpdate");
        if (moveUp /*&& selfRb.velocity.y > 0*/)
        {
            /*if (selfRb.IsTouchingLayers(groundLayer))
            {
                selfRb.AddForce(new Vector2(0, verticalMove));
            }*/
            //selfRb.AddForce(new Vector2(0, verticalMove));
            selfRb.velocity = new Vector2(horizontalMove, verticalMove);

            moveUp = false;
        }
        else
        {
            selfRb.velocity = new Vector2(horizontalMove, selfRb.velocity.y);
        }
    }

}
