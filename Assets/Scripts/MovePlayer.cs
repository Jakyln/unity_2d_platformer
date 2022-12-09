using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public string runningAnimation;
    public string jumpingAnimation;
    public string playerHitAnimation;
    Animator anim;

    private Rigidbody2D selfRb;
    private SpriteRenderer spriteR;
    private Sprite sprite1st;

    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private float horizontalMove;
    private float verticalMove;
    public float speed;
    private Boolean isTonneauCollision;

    private Transform transform;
    [SerializeField]
    public GameObject entityCollision;


    void Start()
    {
        transform = gameObject.transform;
        selfRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        isTonneauCollision = false;
        sprite1st = spriteR.sprite;
        speed = 3;

        runningAnimation = "RunningAnimation";
        jumpingAnimation = "JumpingAnimation";
        playerHitAnimation = "PlayerHitAnimation";

        //On a freeze la rotation pour qu'il puisse rester dans la meme position, il faut maintenant adapter sa position pour qu'elle soit toujours parallele au sol
        selfRb.angularVelocity = 0f;
        //selfRb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(selfRb.velocity.y);
        MovementPlayer();
    }

    //Fonctions d'appels de boutons
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
            anim.enabled = false;
            if(horizontalScale < 0)
            {
                transform.localScale = new Vector2(-horizontalScale, transform.localScale.y);
            }
            anim.enabled = true;
            horizontalMove = -speed;
            anim.Play(runningAnimation);

            if (isTonneauCollision)
            {
                playerHit();
            }
        }

        else if (moveRight)
        {

            anim.enabled = false;
            if (horizontalScale > 0)
            {
                transform.localScale = new Vector2(-horizontalScale, transform.localScale.y);
            }
            anim.enabled = true;
            horizontalMove = speed;
            anim.Play(runningAnimation);

            if (isTonneauCollision)
            {
                playerHit();
            }
        }
        //il s'apprete a sauter mais il touche une plateforme, sol (il est au sol)
        else if (moveUp && selfRb.IsTouchingLayers(1) && selfRb.velocity.y < 0)
        {
            /*            anim.enabled = false;
                        verticalMove = 0;*/
            anim.enabled = false;
            anim.enabled = true;
            anim.Play(jumpingAnimation);
            verticalMove = 6;
        }
        //Il a sautée, il est dans les airs mais il touche une plateforme
        else if (moveUp && selfRb.IsTouchingLayers(1))
        {
            verticalMove = 0;
            moveUp = false;
        }
        //Il a sauté, il est dans les airs et touche aucune plateforme
        else if (moveUp)
        {
            /*verticalMove = 0;
            moveUp = false;*/

            anim.enabled = false;
            anim.enabled = true;
            anim.Play(jumpingAnimation);
            verticalMove = 6;

            //Mario jump pas parfois, car velocity est inf a 0 ?

            // Jump animation  marche pas car moveUp est à true pendant une frame seulement, donc pas le temps d'afficher. Il faudrait pouvoir detecter quand il jump soit en l'air soit pas collision du sol en omettant les autres
        }
        //Le joueur est immobile, on veut qu'aucune animation se joue et juste le sprite de mario immobile
        else
        {
            verticalMove = 0;
            horizontalMove = 0;
            anim.enabled = false;
            spriteR.sprite = sprite1st;

            /*if (isTonneauCollision)
            {
                playerHit();
            }*/
        }
        selfRb.angularVelocity = 0f;
    }

    private void playerHit()
    {
        //anim.enabled = false;
        if (isTonneauCollision)
        {
            anim.enabled = true;
            anim.Play(playerHitAnimation);
        }
    }
    private void FixedUpdate()

    {
        //Si il touche une plateforme pendant son saut dans les airs
        if (moveUp && selfRb.IsTouchingLayers(1))
        {
            selfRb.velocity = new Vector2(0, verticalMove);
        }
        //Si il touche le sol
        else if (selfRb.IsTouchingLayers(1))
        {
            moveUp = false;
            selfRb.velocity = new Vector2(horizontalMove, selfRb.velocity.y);
        }
        else
        {
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //si l'animation du hit précedent est toujours en train de jouer
        if (isTonneauCollision && !anim.GetCurrentAnimatorStateInfo(0).IsName(playerHitAnimation))
        {
            isTonneauCollision = false;
        }
        if (collision.gameObject.name.Contains("Clone")){
            isTonneauCollision = true;
            playerHit();
        }



    }

}
